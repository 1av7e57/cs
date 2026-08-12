using System; // Necesario para usar el método override de ToString()

namespace Almacen.Aplicacion
{
    // ENTIDAD: Representa un objeto de negocio fundamental.
    // No conoce nada sobre bases de datos, archivos o UI.
    public class Producto
    {
        // Propiedad de identificador único.
        public int Id { get; set; }

        // Propiedad de nombre con un valor por defecto para evitar nulos.
        public string Nombre { get; set; } = " ";

        // Sobrescribe el método ToString() para definir cómo se representa 
        // este objeto como cadena de texto (útil para la consola).
        public override string ToString()
        {
            // Retornamos una cadena formateada con los datos del objeto.
            return $"{Nombre} (ID: {Id})";
        }
    }
}
