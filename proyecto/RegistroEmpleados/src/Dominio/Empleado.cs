namespace Dominio;

// Capa de Dominio: entidad de negocio que modela un empleado.
// Contiene datos y comportamiento propio, sin dependencias técnicas externas (Single Responsibility, principio S de SOLID).
public class Empleado
{
    public int Id { get; private set; } // ID solo se modifica desde dentro de la clase (AsignarId), protegiendo la identidad
    public string Nombre { get; set; } = ""; // Propiedad con valor por defecto para evitar null reference
    public string NombreCompleto => $"{Nombre} {Apellido}"; // Propiedad de solo lectura calculada dinámicamente
    public string Apellido { get; set; } = ""; // Propiedad con valor por defecto
    public int Edad { get; set; } // Propiedad modificable
    public string Direccion { get; set; } = ""; // Propiedad con valor por defecto
    public char Sexo { get; set; } // Propiedad modificable

    // Método para establecer el ID desde fuera (usado por el servicio al actualizar)
    public void AsignarId(int id) => Id = id;

    // Método para actualizar datos internos directamente (alternativa a crear nueva instancia)
    public void ActualizarDatos(string nombre, string apellido, int edad, string direccion, char sexo)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        Direccion = direccion;
        Sexo = sexo;
    }

    // Representación string útil para depuración y logs
    public override string ToString() => $"[{Id}] {Nombre} {Apellido}";
}