// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio01.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio01.Modelos;

// Clase Persona: implementa IAtendible porque puede ser atendida
public class Persona : IAtendible
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "persona"
    public string Nombre { get; set; } = "persona";

    // Implementación del método Atender de la interfaz IAtendible
    public void Atender()
    {
        // Imprime en consola el mensaje de atención usando el nombre de la persona
        Console.WriteLine($"Atendiendo {Nombre}");
    }
}