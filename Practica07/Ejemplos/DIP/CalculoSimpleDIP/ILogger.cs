// Este es el archivo más importante para el DIP. Define el "contrato" que todas las implementaciones deben seguir.

// Definimos el espacio de nombres.
namespace CalculoSimple;

// 1. Definimos una INTERFAZ pública.
//    Una interfaz es una abstracción pura: define QUÉ se puede hacer, no CÓMO.
public interface ILogger
{
    // 2. Definimos el método que cualquier clase que quiera ser un "Logger" debe tener.
    //    Cualquier clase que implemente esto podrá ser inyectada en 'Calculador'.
    void Log(string mensaje);
}