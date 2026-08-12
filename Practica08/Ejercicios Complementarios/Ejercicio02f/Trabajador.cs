using System; // Importamos para funciónes básicas
class Trabajador
{
    // Variable privada para almacenar la lista de suscriptores.
    // Es privada porque el evento es explícito y no se expone directamente como campo.
    private EventHandler? _trabajando;

    // Implementación explícita del evento.
    public event EventHandler? Trabajando
    {
        // Descriptor 'add': Se ejecuta cuando alguien usa '+=' para suscribirse.
        add
        {
            // 1. Guardamos el nuevo suscriptor en la lista privada.
            // Usamos el patrón estándar de hilos seguros: _trabajando = (EventHandler?)Delegate.Combine(_trabajando, value);
            // O la forma simplificada: _trabajando += value;
            _trabajando += value;

            // 2. LÓGICA NUEVA: Disparamos el trabajo inmediatamente.
            // Al suscribirse, el evento se ejecuta automáticamente.
            // Esto hace que la llamada explícita a Trabajar() en Main sea innecesaria.
            Trabajar();
        }

        // Descriptor 'remove': Se ejecuta cuando alguien usa '-=' para desuscribirse.
        remove
        {
            // Eliminamos el suscriptor de la lista.
            _trabajando -= value;
        }
    }

    // Método interno que realiza el trabajo.
    // Ahora es invocado tanto por el descriptor 'add' (automáticamente) 
    // como podría serlo manualmente si se quisiéra (aunque en este ejercicio no lo haremos).
    public void Trabajar()
    {
        // Invocamos el evento de forma segura.
        // Si nadie se ha suscrito (aunque en este diseño es raro), no pasa nada.
        _trabajando?.Invoke(this, EventArgs.Empty);

        // Mensaje de conclusión.
        Console.WriteLine("Trabajo concluido");
    }
}