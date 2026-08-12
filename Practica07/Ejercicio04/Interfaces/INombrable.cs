
// Definimos el espacio de nombres propio
namespace Ejercicio04.Interfaces;

// Hacemos que INombrable también herede de IComparable<INombrable>
// Así, todo objeto que sea nombrable también debe saber compararse con otro nombrable
public interface INombrable : IComparable<INombrable>
{
    // Propiedad para almacenar el nombre
    string Nombre { get; set; }
}