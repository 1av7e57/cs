// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio04.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio04.Modelos;

// Clase Persona: Implementamos INombrable (para el nombre) 
// que hereda de IComparable<INombrable> (para ordenar)
public class Persona : IAtendible, IComercial, IImportante, INombrable
{
    // La propiedad Nombre ya existía, ahora cumple el contrato de INombrable
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

    // El método CompareTo implementa el contrato de la interfaz extendida
    public int CompareTo(INombrable? other)
    {
        if (other == null) return 1;
        return this.Nombre.CompareTo(other.Nombre);
    }

    // Sobrescritura de ToString() para la salida personalizada
    public override string ToString()
    {
        return $"{Nombre} es una persona";
    }
}