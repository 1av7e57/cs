// HiBlazor4/Entidades/Persona.cs
// Modelo de dominio que representa una persona con nombre, apellido y edad

namespace HiBlazor4.Entidades;  // Namespace que agrupa las entidades del proyecto

public class Persona  // Clase POCO (Plain Old CLR Object) con propiedades de datos
{
    public string Nombre { get; set; } = "";  // Propiedad de texto con inicialización a cadena vacía (evita null)
    public string Apellido { get; set; } = "";  // Apellido con valor por defecto vacío
    public int? Edad { get; set; }  // Tipo nullable: permite que la edad sea opcional (null si no se ingresa)

    // Método estático que simula una fuente de datos (en producción vendría de una API o base de datos)
    public static List<Persona> GetLista()  // Retorna una lista precargada con datos de ejemplo
    {
        return new List<Persona>()  // Crea e inicializa la lista inline
        {
            new Persona() { Nombre = "Matias", Apellido = "Gonzales", Edad = 39 },  // Persona 1: inicializador de objeto
            new Persona() { Nombre = "Juan", Apellido = "Perez", Edad = 39 }  // Persona 2: inicializador de objeto
        };
    }
}
