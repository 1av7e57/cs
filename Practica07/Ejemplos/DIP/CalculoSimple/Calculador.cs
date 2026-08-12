 // Esta es la clase de negocio principal. 
 // Actualmente, viola el DIP porque depende directamente de una implementación concreta (Logger) 
 // y no de una abstracción.

// Definimos el espacio de nombres para el proyecto
namespace CalculoSimple;

// Clase 'Calculador'.
// Problema: No implementa ninguna interfaz, por lo que no es una abstracción.
class Calculador
{
    // PROBLEMA CRÍTICO: 'Calculador' crea una instancia directa de 'Logger'.
    // Esto crea un "acoplamiento fuerte". Si 'Logger' cambia, 'Calculador' se rompe.
    // Además, no podemos usar otro tipo de log (ej. archivo, consola, nube) sin modificar este código.
    // Esto viola el Principio de Inversión de Dependencias (DIP).
    Logger _logger = new Logger();

    // Método público que realiza el cálculo y el registro.
    public void Calcular(int n)
    {
        // Ejecutamos la lógica de negocio: (n + 5) * (n + 7)
        int resul = (n + 5) * (n + 7);

        // Llamamos al método de logging de nuestra dependencia concreta.
        // El 'Calculador' sabe exactamente qué clase usar para registrar el mensaje.
        _logger.Log($"Fin de Calculo - (resul={resul})");
    }
}