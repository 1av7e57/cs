// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio04.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio04.Modelos;

// Clase Perro: Implementamos INombrable (para el nombre) 
// que hereda de IComparable<INombrable> (para ordenar)
public class Perro : IAtendible, IVendible, ILavable, ISecable, INombrable
{
    // La propiedad Nombre ya existía, ahora cumple el contrato de INombrable
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

    // El método CompareTo implementa el contrato de la interfaz extendida
    public int CompareTo(INombrable? other)
    {
        if (other == null) return 1;
        return this.Nombre.CompareTo(other.Nombre);
    }

    // Sobrescritura de ToString()
    public override string ToString()
    {
        return $"{Nombre} es un perro";
    }
}