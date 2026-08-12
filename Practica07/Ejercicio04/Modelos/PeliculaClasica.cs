// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio04.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio04.Modelos;

// Hereda de Pelicula (ya tiene IAlquilable) y agrega IVendible
public class PeliculaClasica : Pelicula, IVendible
{
    // Constructor de la clase PeliculaClasica.
    // Se ejecuta en el momento exacto en se instancia un objeto de esta clase
    public PeliculaClasica()
    {
        // Sobrescribimos el nombre heredado por defecto (de "película" a "película clásica")
        this.Nombre = "película clásica";
    }

    // Implementamos el método de venta (propio de IVendible)
    public void SeVendeA(Persona p)
    {
        Console.WriteLine($"Vendiendo {Nombre} a {p.Nombre}");
    }
}