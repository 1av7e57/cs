﻿// Código modificado para que Program.cs aproveche la Navegación de entidades 
// Que implementamos añadiendo la Propiedad 'Examenes' a la clase Alumno.cs

// 1. Importamos el namespace de Entity Framework Core para usar la extensión .Include()
using Microsoft.EntityFrameworkCore;

// 2. Importamos nuestro namespace de la aplicación
using Escuela;

// 3. Creamos una instancia del contexto de base de datos.
using (var db = new EscuelaContext())
{
  // 4. Carga de datos con relación (Eager Loading).
  //    - 'db.Alumnos': Obtiene todos los alumnos.
  //    - '.Include(a => a.Examenes)': Instrucción explícita para EF Core.
  //      Le dice: "No solo cargues los datos del Alumno, también carga la colección de Exámenes relacionados para cada uno".
  //      Esto genera un SQL con JOIN interno y evita consultas adicionales por cada alumno.
  foreach (Alumno a in db.Alumnos.Include(a => a.Examenes))
  {
    // 5. Imprimimos el nombre del alumno.
    Console.WriteLine(a.Nombre);

    // 6. Iteramos sobre los exámenes del alumno actual.
    //    - 'a.Examenes?': El operador '?' (null-conditional) verifica si la lista existe.
    //      Si un alumno no tiene exámenes, la lista es null y el código salta esta línea sin error.
    //    - '.ToList()': Convierte la colección en una lista para poder iterar.
    //    - '.ForEach(e => ...)': Ejecuta una acción para cada examen 'e' en la lista.
    //      - 'Console.WriteLine(...)': Imprime la materia y la nota.
    a.Examenes?.ToList().ForEach(e => Console.WriteLine($" - {e.Materia} {e.Nota}"));
  }
}

/*NOTAS:
Resumen de la ejecución:
    Al ejecutar dotnet run con este código:
        1. EF Core conectará a la base de datos.
        2. Ejecutará una consulta SQL única que une Alumnos y Examenes.
        3. Recorrerá los resultados en memoria.
        4. Imprimirá la lista anidada: Nombre del alumno seguido de sus exámenes (si los tiene).

¿Qué se verá al ejecutarlo?
Ahora la salida estará anidada y será más legible, mostrando la relación real:
    Juan
    - Algebra 10
    - Ingles 5
    Ana
    - Ingles 9
    Laura

// Para Laura no imprime nada ya que no tiene exámenes en la DB.

*/
