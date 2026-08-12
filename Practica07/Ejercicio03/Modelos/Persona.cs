// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio03.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio03.Modelos;

// Clase Persona: implementa IAtendible porque puede ser atendida
// Ahora implementa además IComercial, e IImportante
public class Persona : IAtendible, IComercial, IImportante
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "persona"
    public string Nombre { get; set; } = "persona";

    // Implementación del método Atender de la interfaz IAtendible
    public void Atender()
    {
        // Imprime en consola el mensaje de atención usando el nombre de la persona
        Console.WriteLine($"Atendiendo {Nombre}");
    }

    // Implementación explícita para IComercial
    // Se llama con el nombre de la interfaz para distinguirla
    // ya que IImportante también tiene un método llamadao Importa
    void IComercial.Importa()
    {
        Console.WriteLine("Persona vendiendo al exterior");
    }

    // Implementación explícita para IImportante
    void IImportante.Importa()
    {
        Console.WriteLine("Persona importante");
    }

    // Método público para el casting directo (como pide la salida)
    public void Importar()
    {
        Console.WriteLine("Método Importar() de la clase Persona");
    }
}