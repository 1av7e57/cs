using System; // Necesario para IComparable
namespace Teoria8;

// Implementamos IComparable
class Empleado : IComparable
{
  public string Nombre { get; private set; }
  public int Legajo { get; set; }

  public Empleado(string nombre)
  {
    Nombre = nombre;
  }

  // Implementación de IComparable (orden por NOMBRE por defecto)
  public int CompareTo(object? obj)
  {
    if (obj is Empleado otroEmpleado)
    {
      return this.Nombre.CompareTo(otroEmpleado.Nombre);
    }
    return 0; // Si no es Empleado, los consideramos iguales para evitar errores
  }

    public void Imprimir()
    {
    // Este método imprime solo Nombre 
    Console.WriteLine($"Soy el empleado {Nombre}");
    }

    public void ImprimirCompleto()
    {
    // Este método imprime Nombre y Legajo
    Console.WriteLine($"Soy el empleado {Nombre}, Legajo: {Legajo}");
    }
}