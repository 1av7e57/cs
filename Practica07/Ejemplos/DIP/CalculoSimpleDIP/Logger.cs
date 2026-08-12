// La implementación concreta. 
// Ahora es un detalle de implementación que depende de la abstracción (al implementarla), no al revés.

// Definimos el espacio de nombres.
namespace CalculoSimple;

// 1. La clase 'Logger' implementa explícitamente la interfaz 'ILogger'.
//    Esto garantiza que cumple con el contrato definido en la abstracción.
public class Logger : ILogger
{
    // 2. Implementación concreta del método 'Log'.
    //    Aquí definimos el comportamiento real: escribir en la consola.
    public void Log(string mensaje)
    {
        // Escribimos en la salida estándar.
        // Si mañana quisiéramos guardar en un archivo, 
        // podríamos crear otra clase 'FileLogger : ILogger'.
        // 'Calculador' no se enteraría del cambio.
        Console.WriteLine(mensaje);
    }
}