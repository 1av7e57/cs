/*Implementación del Servicio:
Esta es la implementación concreta de la interfaz ILogger. 
Actualmente, escribe en la consola, pero podría ser LoggerArchivo, LoggerBaseDeDatos, etc.*/

namespace DiContainer;

// Clase concreta que implementa el contrato definido en ILogger.
// El DI Container se encargará de crear esta instancia y entregársela a quien la necesite.
public class LoggerConsola : ILogger
{
    // Implementación del método Log.
    // Formatea el mensaje con una marca de tiempo para saber cuándo ocurrió el registro.
    public void Log(string mensaje)
    {
        // DateTime.Now:hh:mm:fff obtiene la hora actual con precisión de milisegundos.
        Console.WriteLine($"{DateTime.Now:hh:mm:ss:fff} {mensaje}");
    }
}