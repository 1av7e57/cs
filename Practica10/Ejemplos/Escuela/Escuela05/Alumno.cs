// Este archivo define la clase que representa la tabla Alumnos.

// Las Propiedades de Navegación (Navigation Properties) son un concepto fundamental de EF Core: 
// Estas propiedades permiten "navegar" de una entidad a otra relacionada sin tener que escribir 
// consultas SQL explícitas o usar Join. EF Core las detecta automáticamente, carga las 
// entidades relacionadas y las gestiona.

// 1. Namespace de la aplicación
namespace Escuela;

// 2. Clase Alumno
public class Alumno
{
  // 3. Propiedad Id (Clave Primaria)
  public int Id { get; set; }

  // 4. Propiedad Nombre
  public string Nombre { get; set; } = "";

  // 5. Propiedad Email
  //    El '?' permite que sea nulo, lo cual es correcto para este campo.
  public string? Email { get; set; }

  // 6. Propiedad de Navegación: 'Examenes'
  //    - 'public List<Examen>?': Declara una lista de objetos 'Examen'.
  //    - El '?' al final hace que la lista sea nullable (puede ser null si el alumno no tiene exámenes cargados).
  //    - **Propósito:** Esta propiedad le dice a EF Core: "Cada Alumno tiene una colección de Exámenes relacionados".
  //    - EF Core detectará automáticamente la relación basada en el nombre de la propiedad y la clave foránea 'AlumnoId' en la clase Examen.
  //    - Con esto, se podría hacer: `alumno.Examenes` y obtener todos los exámenes de ese alumno directamente.
  public List<Examen>? Examenes { get; set; }
}

/*NOTAS:
¿Qué cambia con esta propiedad?

Carga Diferida (Lazy Loading) vs Carga Inmediata (Eager Loading):
    -Sin la propiedad: Se debe hacer un Join o dos consultas separadas para saber qué exámenes tiene un alumno.
    -Con la propiedad: Se puede acceder a alumno.Examenes y, si EF Core está bien configurado, cargará los exámenes 
    automáticamente (Lazy Loading) o se podría cargarlos explícitamente antes (Eager Loading con .Include()).

Relación Inversa:
    -EF Core es inteligente: ve que se tiene List<Examen>? Examenes en Alumno 
    Y que en Examen se tiene la propiedad int AlumnoId.
    -Automáticamente crea la relación de "Uno a Muchos" sin que se tenga que configurar con atributos especiales
    (aunque se puede hacerlo si se quiere ser explícito).
*/