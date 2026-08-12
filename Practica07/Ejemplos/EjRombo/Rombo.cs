using System; // Necesario para 'double'

namespace EjRombo;

class Rombo : Figura, IImprimible, IAgrandable
{
    // Implementación de IImprimible
    public void Imprimir()
    {
        Console.WriteLine("Soy un rombo imprimiéndose...");
    }

    // Propiedad requerida por IAgrandable
    public double TamañoMaximo { get; set; } = 100.0; // Valor por defecto

    // Implementación de IAgrandable
    public void Agrandar(double factor)
    {
        if (factor > 0)
        {
            // Ejemplo de lógica: aumentar el tamaño actual
            // Nota: Esto requiere que 'Rombo' tenga un tamaño actual almacenado
            Console.WriteLine($"Agrandando el rombo por un factor de {factor}");
        }
    }
}