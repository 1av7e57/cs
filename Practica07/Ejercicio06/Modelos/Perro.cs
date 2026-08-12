// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio06.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio06.Modelos;

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
    // --- LÓGICA DE COMPARACIÓN MODIFICADA ---
    public int CompareTo(INombrable? other)
    {
        // Devolver 1 aquí asegura que los objetos válidos se agrupen después de los nulos si estos existieran, 
        // manteniendo una lógica predecible: El objeto actual (this) es mayor que algo vacío (null)
        if (other == null) return 1;

        // Paso 1: Verificar si el otro objeto es también un Perro
        if (other is Perro)
        {
            // Si ambos son Perros, comparamos por Nombre
            return this.Nombre.CompareTo(other.Nombre);
        }

        // Paso 2: Si el otro NO es Perro (es una Persona)
        // Retornamos 1 para indicar que "this" es mayor (va después) que "other". (Perro va después que persona)
        return 1;
    }

    // Sobrescritura de ToString()
    public override string ToString()
    {
        return $"{Nombre} es un perro";
    }
}