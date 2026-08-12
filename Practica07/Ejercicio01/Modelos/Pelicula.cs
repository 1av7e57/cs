// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio01.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio01.Modelos;

// Clase Pelicula: implementa IAlquilable
public class Pelicula : IAlquilable
{
    // Propiedad automática para almacenar el nombre, con valor por defecto "película"
    public string Nombre { get; set; } = "película";

    // Implementación del método de alquiler
    public void SeAlquilaA(Persona p)
    {
        // Imprime en consola el mensaje de alquiler de la película
        Console.WriteLine($"Alquilando {Nombre} a {p.Nombre}");
    }

    // Implementación del método de devolución
    public void SeDevuelvePor(Persona p)
    {
        // Imprime en consola el mensaje de devolución indicando quién la devolvió
        Console.WriteLine($"{Nombre} devuelta por {p.Nombre}");
    }
}