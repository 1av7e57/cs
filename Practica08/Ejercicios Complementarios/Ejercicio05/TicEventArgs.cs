using System; // Importamos para funciónes básicas.

// Clase de Argumentos del Evento.
// La necesitamos para transportar la cantidad de veces que se ha disparado el evento.
public class TicEventArgs : EventArgs // Heredaremos de EventArgs.
{
    // Propiedad pública para leer el contador.
    public int Tics { get; }

    // Constructor que inicializa el contador.
    public TicEventArgs(int tics)
    {
        Tics = tics;
    }
}