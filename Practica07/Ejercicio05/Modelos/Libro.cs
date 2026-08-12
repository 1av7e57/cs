// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio05.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio05.Modelos;

// Clase Libro: implementa IAlquilable e IReciclable
public class Libro : IAlquilable, IReciclable
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "libro"
    public string Nombre { get; set; } = "libro";

    // Implementación del método de alquiler
    public void SeAlquilaA(Persona p)
    {
        // Imprime en consola el mensaje de alquiler del libro
        Console.WriteLine($"Alquilando {Nombre} a {p.Nombre}");
    }

    // Implementación del método de devolución
    public void SeDevuelvePor(Persona p)
    {
        // Imprime en consola el mensaje de devolución indicando quién lo devolvió
        Console.WriteLine($"{Nombre} devuelto por {p.Nombre}");
    }

    // Implementación del método de reciclaje
    public void SeRecicla()
    {
        // Imprime en consola el mensaje de reciclaje del libro
        Console.WriteLine($"Reciclando {Nombre}");
    }
}