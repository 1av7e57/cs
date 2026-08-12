// Esta clase ahora cumple con el DIP. Depende de una abstracción (ILogger), no de una concreción (Logger).

// Definimos el espacio de nombres.
namespace CalculoSimple;

// Clase 'Calculador'.
// Ahora cumple con el principio de responsabilidad única:
// Solo se encarga de la lógica de cálculo, no de cómo se registra el log.
class Calculador
{
    // 1. Definimos una variable privada que depende de la INTERFAZ (abstracción).
    //    Esto es lo que permite el DIP: "Depender de abstracciones".
    //    'ILogger' es la abstracción, no 'Logger'.
    ILogger _logger;

    // 2. Constructor con Inyección de Dependencias.
    //    Recibimos la dependencia desde el exterior en lugar de crearla internamente.
    //    El parámetro 'ILogger logger' puede ser cualquier objeto que implemente esa interfaz.
    public Calculador(ILogger logger)
    {
        // Asignamos la dependencia inyectada a la variable de instancia.
        _logger = logger;
    }

    // Método de lógica de negocio.
    public void Calcular(int n)
    {
        // Realizamos el cálculo.
        int resul = (n + 5) * (n + 7);

        // Usamos la interfaz para registrar.
        // El compilador solo verifica que el objeto tenga el método 'Log'.
        // No sabe ni le importa si es un Logger de consola, archivo o base de datos.
        _logger.Log($"Fin de Calculo - (resul={resul})");
    }
}