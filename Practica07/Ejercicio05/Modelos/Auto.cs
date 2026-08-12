// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio05.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio05.Modelos; 

// Clase Auto: implementa IVendible, ILavable, ISecable e IReciclable
// Ahora implementa además IComercial, e IImportante
public class Auto : IVendible, ILavable, ISecable, IReciclable, IComercial, IImportante
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "auto"
    public string Nombre { get; set; } = "auto";

    // Implementación del método de venta
    public void SeVendeA(Persona p)
    {
        // Imprime en consola el mensaje de venta del auto
        Console.WriteLine($"Vendiendo {Nombre} a {p.Nombre}");
    }

    // Implementación del método de lavado
    public void SeLava()
    {
        // Imprime en consola el mensaje de lavado del auto
        Console.WriteLine($"Lavando {Nombre}");
    }

    // Implementación del método de secado
    public void SeSeca()
    {
        // Imprime en consola el mensaje de secado del auto
        Console.WriteLine($"Secando {Nombre}");
    }

    // Implementación del método de reciclaje
    public void SeRecicla()
    {
        // Imprime en consola el mensaje de reciclaje del auto
        Console.WriteLine($"Reciclando {Nombre}");
    }

    // Implementación explícita para IComercial
    void IComercial.Importa()
    {
        Console.WriteLine("Auto que se vende al exterior");
    }

    // Implementación explícita para IImportante
    void IImportante.Importa()
    {
        Console.WriteLine("Auto importante");
    }

    // Método público para el casting directo (como pide la salida)
    public void Importar()
    {
        Console.WriteLine("Método Importar() de la clase Auto");
    }
}
