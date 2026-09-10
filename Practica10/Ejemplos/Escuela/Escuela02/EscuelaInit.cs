//  La clase EscuelaInit actúa como un "seeder" (sembrador). 
// Su función es poblar la base de datos con datos iniciales de prueba o de configuración, 
// pero con una protección inteligente para no duplicar datos si la base de datos ya fue inicializada antes.

// 1. Namespace de la aplicación
namespace Escuela;

// 2. Clase pública 'EscuelaInit'.
//    Esta clase no hereda de nada; es simplemente un contenedor estático para métodos de inicialización.
public class EscuelaInit
{
  // 3. Método estático 'Inicializar'.
  //    - 'static': Puede ser llamado sin crear una instancia de la clase (ej: EscuelaInit.Inicializar(context)).
  //    - 'context': Recibe como parámetro la instancia de 'EscuelaContext' que ya está conectada a la base de datos.
  //      Esto es necesario para poder acceder a los 'DbSet' (Alumnos, Examenes) y guardar datos.
  public static void Inicializar(EscuelaContext context)
  {
    // 4. Verificación de seguridad.
    //    - 'context.Alumnos.Count()': Cuenta cuántos alumnos hay actualmente en la base de datos.
    //      (Nota: Esto ejecuta una consulta SQL: SELECT COUNT(*) FROM Alumnos).
    //    - '> 0': Si el contador es mayor que 0, significa que la base de datos YA tiene datos.
    //    - 'return;': Si ya hay datos, el método termina inmediatamente.
    //    - **Objetivo:** Evitar que el código intente agregar los mismos alumnos y exámenes de nuevo cada vez que se ejecute el programa, 
    //      lo cual generaría registros duplicados y errores de claves únicas si se intentara forzar un ID específico.
    if (context.Alumnos.Count() > 0) 
    {
      return;
    }

    // 5. Agregar primer alumno: "Juan".
    //    - 'context.Add(...)': Le indica al contexto que este objeto es "nuevo" y debe ser insertado en la base de datos.
    //    - '{Nombre = "Juan", Email = "juan@gmail.com"}': Inicializador de objeto. Asigna valores a las propiedades.
    //      Aquí Email es "juan@gmail.com" (no nulo).
    context.Add(new Alumno() { Nombre = "Juan", Email = "juan@gmail.com" });

    // 6. Agregar segundo alumno: "Ana".
    //    - '{Nombre = "Ana"}': Solo se asigna el nombre.
    //    - 'Email': Al no asignarse y la propiedad ser 'string?', queda en null.
    //      Esto es correcto porque en nuestro modelo definimos 'public string? Email' (nullable).
    context.Add(new Alumno() { Nombre = "Ana" });

    // 7. Agregar tercer alumno: "Laura".
    //    - 'Email': Quedará null por defecto.
    context.Add(new Alumno() { Nombre = "Laura" });

    // 8. Agregar primer examen.
    //    - 'AlumnoId = 2': Se asigna al alumno con ID 2 (que será "Ana", ya que Juan será el 1 y Ana el 2).
    //      *Nota: Esto asume que los IDs se generan en orden de inserción (1, 2, 3...).
    //    - 'Materia = "Ingles"', 'Nota = 9'.
    //    - 'Fecha = DateTime.Parse("4/4/2022")': Convierte una cadena de texto en un objeto DateTime.
    //      El formato "4/4/2022" depende de la configuración regional del sistema (día/mes/año o mes/día/año).
    //      Este enfoque es útil para pruebas, pero en producción se suele usar new DateTime(2022, 4, 4) para evitar ambigüedades de formato regional.
    context.Add(new Examen() { AlumnoId = 2, Materia = "Ingles", Nota = 9, Fecha = DateTime.Parse("4/4/2022") });

    // 9. Agregar segundo examen (para Juan, ID 1).
    context.Add(new Examen() { AlumnoId = 1, Materia = "Ingles", Nota = 5, Fecha = DateTime.Parse("1/3/2019") });

    // 10. Agregar tercer examen (para Juan, ID 1).
    context.Add(new Examen() { AlumnoId = 1, Materia = "Algebra", Nota = 10, Fecha = DateTime.Parse("4/5/2021") });

    // 11. Guardar cambios.
    //    - 'context.SaveChanges()': Este es el comando más importante.
    //      Hasta este momento, los objetos 'Add' solo están en la memoria (en el contexto).
    //      Este método genera los comandos SQL (INSERT INTO Alumnos..., INSERT INTO Examenes...) y los ejecuta contra la base de datos real.
    //      Si hay algún error en la base de datos (ej. clave foránea inválida), lanzará una excepción aquí.
    context.SaveChanges();
  }
}