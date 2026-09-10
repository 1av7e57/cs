// Este archivo define la clase que representa la tabla Alumnos.

// Declaramos el namespace Escuela para agrupar nuestras clases lógicamente
namespace Escuela;

// Declaramos la clase pública Alumno. EF Core buscará automáticamente esta clase para mapearla a la tabla "Alumnos"
public class Alumno
{
    // Propiedad 'Id':
    // - 'public int': Tipo entero, pública para que EF Core pueda acceder a ella.
    // - Corresponde a la columna 'Id INTEGER' en la base de datos.
    // - EF Core la identifica automáticamente como la Clave Primaria (PK) por el nombre "Id".
    public int Id { get; set; }

    // Propiedad 'Nombre':
    // - 'public string': Tipo texto, pública.
    // - ' = ""': Inicializador por defecto. Si EF Core no recibe un valor, asigna una cadena vacía (evita null).
    // - Corresponde a la columna 'Nombre TEXT NOT NULL' en la base de datos.
    public string Nombre { get; set; } = "";

    // Propiedad 'Email':
    // - 'public string?': El '?' hace que la cadena sea 'nullable' (puede ser nula).
    // - Esto es importante porque en la tabla de DB Browser, el campo Email NO tiene la marca 'NN' (No Nulo).
    // - Si se hubiera puesto 'string' sin el '?', EF Core esperaría un valor obligatorio y podría lanzar un error al guardar.
    // - Corresponde a la columna 'Email TEXT' en la base de datos.
    public string? Email { get; set; }
}