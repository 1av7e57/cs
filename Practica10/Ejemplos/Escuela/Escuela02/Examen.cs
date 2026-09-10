// Este archivo define la clase que representa la tabla Exámenes.

// Declaramos el mismo namespace Escuela
namespace Escuela;

// Declaramos la clase pública Examen. EF Core la mapeará a la tabla "Examenes"
public class Examen
{
    // Propiedad 'Id':
    // - 'public int': Entero.
    // - EF Core lo identifica como la Clave Primaria (PK) automáticamente.
    // - Corresponde a 'Id INTEGER PK AI' en la base de datos.
    public int Id { get; set; }

    // Propiedad 'AlumnoId':
    // - 'public int': Entero.
    // - EF Core lo reconoce como una **Clave Foránea (Foreign Key)** porque su nombre coincide con la clave primaria de otra entidad ('Alumno').
    // - Esta propiedad crea la relación entre Examen y Alumno.
    // - Corresponde a 'AlumnoId INTEGER NN' en la base de datos.
    public int AlumnoId { get; set; }

    // Propiedad 'Materia':
    // - 'public string': Texto.
    // - '= ""': Inicializador por defecto (cadena vacía).
    // - Corresponde a 'Materia TEXT NN' en la base de datos.
    public string Materia { get; set; } = "";

    // Propiedad 'Nota':
    // - 'public double': Número decimal (real).
    // - EF Core lo mapea correctamente al tipo REAL de SQLite.
    // - Corresponde a 'Nota REAL NN' en la base de datos.
    public double Nota { get; set; }

    // Propiedad 'Fecha':
    // - 'public DateTime': Tipo de fecha y hora nativo de C#.
    // - Aunque en DB Browser se defina como 'TEXT', EF Core es inteligente y puede guardar DateTime como texto (formato ISO 8601) o convertirlo.
    // - En la tabla se definio Fecha como TEXT, y al usar DateTime en C#, EF Core lo guardará como una cadena legible (ej: "2024-09-15T00:00:00").
    // - Si se prefiere guardar solo la fecha como "YYYY-MM-DD", se podría usar 'string' en lugar de 'DateTime', pero DateTime es más potente para consultas.
    // - Corresponde a 'Fecha TEXT NN' en la base de datos.
    public DateTime Fecha { get; set; }
}