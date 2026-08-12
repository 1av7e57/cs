
using System; // Importamos para funciónes básicas.
using System.Threading; // Importamos para trabajar con hilos (Threads).

/* Clase que aborda la lógica compleja, manejando:
- Validación de propiedades.
- Un hilo (Thread) para esperar el intervalo sin bloquear el programa principal.
- Lógica de bloqueo si no hay suscriptores.*/
class Temporizador
{
    // 1. Definición del Evento
    // Usa nuestro tipo personalizado TicEventArgs para pasar el contador.
    public event EventHandler<TicEventArgs>? Tic;

    // 2. Propiedades
    private int _intervalo;
    private bool _habilitado;
    private int _contadorTics = 0;
    private Thread? _hilo; // Referencia al hilo que ejecutará el temporizador

    // Propiedad Intervalo: No permite valores menores a 100.
    public int Intervalo
    {
        get => _intervalo;
        set
        {
            if (value < 100)
            {
                throw new ArgumentException("El intervalo no puede ser menor a 100 ms.");
            }
            _intervalo = value;
        }
    }

    // Propiedad Habilitado: Controla el inicio y fin del hilo.
    public bool Habilitado
    {
        get => _habilitado;
        set
        {
            if (value && !VerificarSuscriptores())
            {
                // Si intentamos activar y no hay nadie escuchando, lanzamos error.
                throw new InvalidOperationException("No se puede activar el temporizador sin suscriptores al evento Tic.");
            }

            _habilitado = value;

            if (_habilitado)
            {
                IniciarHilo();
            }
            else
            {
                DetenerHilo();
            }
        }
    }

    // Método auxiliar para verificar si hay suscriptores al evento.
    private bool VerificarSuscriptores()
    {
        // Event != null verifica si la lista de suscriptores tiene al menos uno.
        return Tic != null;
    }

    // Método para iniciar el hilo del temporizador.
    private void IniciarHilo()
    {
        // Si ya hay un hilo corriendo, no hacemos nada.
        if (_hilo != null && _hilo.IsAlive) return;

        _contadorTics = 0; // Reiniciamos el contador al activar.
        
        // Creamos un nuevo hilo que ejecutará el bucle de espera.
        _hilo = new Thread(EjecutarCiclo);
        _hilo.IsBackground = true; // Importante: Si el programa termina, este hilo no lo bloqueará.
        _hilo.Start();
    }

    // Método para detener el hilo.
    private void DetenerHilo()
    {
        // En un escenario real complejo, usaríamos un CancellationToken.
        // Aquí, simplemente dejamos de activar el bucle. 
        // Nota: En este ejemplo simple, el hilo terminará naturalmente cuando se rompa el bucle 
        // si cambiamos la lógica, pero para detenerlo "suavemente" necesitamos una bandera.
        // Para simplificar este ejercicio, usaremos un flag interno.
        _habilitado = false; 
        
        // Si el hilo está durmiendo, no podemos forzarlo a detenerse inmediatamente sin riesgo,
        // así que simplemente esperamos a que termine el ciclo actual o usamos una bandera.
        // Implementación robusta con bandera de parada:
        _pararHilo = true;
    }
    
    // Bandera para detener el hilo suavemente
    private bool _pararHilo = false;

    // Lógica principal que se ejecutará en el hilo de fondo.
    private void EjecutarCiclo()
    {
        _pararHilo = false; // Reiniciamos bandera

        while (Habilitado && !_pararHilo)
        {
            // Esperamos el intervalo de tiempo.
            Thread.Sleep(Intervalo);

            // Si aún está habilitado y no se pidió parar, procedemos.
            if (Habilitado && !_pararHilo)
            {
                _contadorTics++;
                
                // Disparamos el evento con el nuevo contador.
                OnTic(_contadorTics);
            }
        }
    }

    // Método protegido para disparar el evento (Patrón estándar).
    protected virtual void OnTic(int tics)
    {
        // Creamos los argumentos con el contador actual.
        TicEventArgs args = new TicEventArgs(tics);

        // Disparamos el evento de forma segura.
        Tic?.Invoke(this, args);
    }
}