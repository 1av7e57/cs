
// Definimos la clase encargada de la entrada de datos (Consola).
// Esta clase actúa como el Publicador. Su única responsabilidad es leer la entrada 
// y avisar a quien esté escuchando que algo sucedió. No sabe ni le importa quién está escuchando.
class Ingresador
{
    // 1. DEFINICIÓN DEL EVENTO:
    // 'event' declara un evento público al que otros pueden suscribirse.
    // 'EventHandler' es un tipo de Delegado genérico predefinido en .NET.
    // La firma que define EventHandler es:
    // public delegate void EventHandler(object sender, EventArgs e);
    // 'sender' (object) indica qué objeto disparó el evento (en este caso, 'this', el Ingresador).
    // 'e' (EventArgs) transporta datos adicionales si los hubiera (aquí lo usamos vacío).
    public event EventHandler? LineaIngresada; // LineaIngresada es una variable de tipo EventHandler. 
                                               // Puede apuntar a cualquier método que devuelva void 
                                               // y reciba (object, EventArgs).

    // Método principal para leer la entrada del usuario.
    public void Ingresar()
    {
        // Leemos la primera línea de entrada del usuario.
        // El operador '?? ""' asegura que si la entrada es null, usemos una cadena vacía en su lugar.
        string st = Console.ReadLine() ?? "";

        // Iniciamos un bucle que se ejecutará mientras el texto ingresado NO sea una cadena vacía.
        while (st != "")
        {
            // 2. DISPARO DEL EVENTO:
            // Aquí, estamos ejecutando el Delegado.
            // 'LineaIngresada?.Invoke(...)' busca en la lista de métodos suscritos al evento.
            // y llama a ManejarLineaIngresada a través de la referencia  del Delegado.
            // El operador '?.' (null-conditional) asegura que no haya error si nadie se ha suscrito.
            // 'this' es el objeto que está enviando la notificación.
            // 'EventArgs.Empty' es un objeto de eventos vacío (sin datos extra).
            LineaIngresada?.Invoke(this, EventArgs.Empty);

            // Leemos la siguiente línea para continuar el bucle.
            st = Console.ReadLine() ?? "";
        }
    }
}