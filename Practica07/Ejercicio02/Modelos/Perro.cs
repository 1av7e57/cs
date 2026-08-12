// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio02.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio02.Modelos;

// Clase Perro: implementa IAtendible (puede ser atendida) y IVendible (puede ser vendido)
// Agregamos ILavable e ISecable a la lista de implementaciones
public class Perro : IAtendible, IVendible, ILavable, ISecable
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "perro"
    public string Nombre { get; set; } = "perro";

    // Implementación del método Atender de la interfaz IAtendible
    public void Atender()
    {
        // Imprime en consola el mensaje de atención usando el nombre del perro
        Console.WriteLine($"Atendiendo {Nombre}");
    }

    // Implementación del método SeVendeA de la interfaz IVendible
    public void SeVendeA(Persona p)
    {
        // Imprime en consola el mensaje de venta indicando a quién se le vende el perro
        Console.WriteLine($"Vendiendo {Nombre} a {p.Nombre}");
    }

    // Nuevo método para implementar ILavable
    public void SeLava()
    {
        Console.WriteLine($"Lavando {Nombre}");
    }

    // Nuevo método para implementar ISecable
    public void SeSeca()
    {
        Console.WriteLine($"Secando {Nombre}");
    }
}