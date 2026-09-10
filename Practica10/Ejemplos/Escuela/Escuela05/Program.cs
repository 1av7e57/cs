﻿// Código modificado para que Program.cs agregue un nuevo alumno con sus respectivos datos de exámen
// a la base de datos cuando se corra el programa.

// 1. Importamos Entity Framework Core para usar .Include()
using Microsoft.EntityFrameworkCore;

// 2. Importamos nuestro namespace
using Escuela;

// 3. Creamos el contexto de base de datos
using (var db = new EscuelaContext())
{
  // 4. Creamos un nuevo objeto 'Alumno' llamado 'nuevo'.
  //    - 'Nombre = "Andrés"'
  //    - 'Examenes = new List<Examen>() { ... }': Inicializamos la lista de exámenes directamente aquí.
  //      Esto es lo que permite la inserción en cascada. EF Core verá que el alumno tiene una lista de exámenes
  //      y los insertará juntos.
  Alumno nuevo = new Alumno() 
  { 
    Nombre = "Andrés",
    Examenes = new List<Examen>() 
    { 
      // Primer examen:
      new Examen() 
      { 
        Materia = "Lengua", 
        Nota = 8, 
        Fecha = DateTime.Parse("10/8/2022") // 10 de agosto de 2022
      },
      // Segundo examen:
      new Examen() 
      { 
        Materia = "Matemáticas", 
        Nota = 9, 
        Fecha = DateTime.Parse("9/7/2022") 
      }
    }
  };

  // 5. 'db.Add(nuevo)':
  //    Le dice a EF Core que 'nuevo' es una entidad nueva que debe ser insertada en la base de datos.
  //    EF Core marca el alumno como 'Added' y, recursivamente, marca todos los exámenes dentro de la lista como 'Added'.
  db.Add(nuevo);

  // 6. 'db.SaveChanges()':
  //    Ejecuta la transacción en la base de datos.
  //    SQL generado internamente (simplificado):
  //      INSERT INTO Alumnos (Nombre) VALUES ('Andrés'); -> Obtiene el nuevo ID (ej. 4)
  //      INSERT INTO Examenes (AlumnoId, Materia, Nota, Fecha) VALUES (4, 'Lengua', 8, ...);
  //      INSERT INTO Examenes (AlumnoId, Materia, Nota, Fecha) VALUES (4, 'Matemáticas', 9, ...);
  db.SaveChanges();

  // 7. Lectura de datos para verificar la inserción.
  //    'Include(a => a.Examenes)': Carga los exámenes junto con el alumno.
  foreach (Alumno a in db.Alumnos.Include(a => a.Examenes))
  {
    // 8. Imprimimos el nombre del alumno.
    Console.WriteLine(a.Nombre);

    // 9. Iteramos sobre sus exámenes.
    a.Examenes?.ToList().ForEach(e => Console.WriteLine($" - {e.Materia} {e.Nota}"));
  }
}

/*NOTAS:
Uno de los puntos más potentes de EF Core es agregar entidades relacionadas en cascada.
Con este código, se está insertando un nuevo alumno y, simultáneamente, sus exámenes, 
todo en una sola llamada a SaveChanges(). EF Core detecta la relación, genera los 
IDs correctos automáticamente y guarda todo con integridad referencial.

Resultado esperado en consola:
    Al ejecutar sobre la base de datos que ya veníamos trabajando ahora se verá:
        Juan
        - Algebra 10
        - Ingles 5
        Ana
        - Ingles 9
        Laura
        Andrés
        - Lengua 8
        - Matemáticas 9
        Andrés
        - Lengua 8
        - Matemáticas 9

Con esta última modificación hemos completado nuestro estudio del ciclo de persistencia:
    -Creación de DB (Code First / Manual).
    -Modelado de entidades y relaciones.
    -Inserción (Seed y nueva entidad con cascada).
    -Consulta (Join, Include, Navegación).
    -Visualización (Consola y SQLite Viewer).
*/
