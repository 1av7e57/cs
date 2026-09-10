﻿// Se Ha integrado la lógica de inicialización de datos en el flujo principal. 
// Ahora la aplicación no solo conecta con la base de datos, sino que también 
// asegura que tenga datos de prueba si la base de datos está vacía.

// 1. Importamos el namespace de nuestra aplicación para acceder a 'EscuelaContext', 'EscuelaInit', 'Alumno', etc.
using Escuela;

// 2. Primer bloque 'using': Fase de Inicialización (Code First + Seed).
//    Creamos una nueva instancia del contexto para preparar la base de datos y llenarla si es necesario.
using (var context = new EscuelaContext())
{
  // 3. 'context.Database.EnsureCreated();'
  //    - Verifica si la base de datos 'Escuela.sqlite' existe.
  //    - Si NO existe: Crea el archivo, las tablas 'Alumnos' y 'Examenes' y las columnas basándose en las clases.
  //    - SI YA EXISTE: No hace nada. Es una operación segura y no borra datos existentes.
  //    - Nota: Como ya tiene datos en DB Browser, esto simplemente confirmará que la DB está lista.
  context.Database.EnsureCreated();

  // 4. 'EscuelaInit.Inicializar(context);'
  //    - Llamamos al método estático de la nueva clase 'EscuelaInit' que acabamos de crear.
  //    - Le pasamos el 'context' para que tenga acceso a la base de datos.
  //    - Dentro de ese método, se ejecutará la lógica:
  //      a) Verificará si ya hay alumnos (si hay > 0, retorna y no hace nada).
  //      b) Si está vacía, insertará los alumnos "Juan", "Ana", "Laura" y los exámenes correspondientes.
  //      c) Llamará a SaveChanges() para guardar en la DB.
  EscuelaInit.Inicializar(context);
}
// Fin del primer bloque: El contexto se cierra y libera recursos automáticamente.

// 5. Segundo bloque 'using': Fase de Lectura/Consulta.
//    Creamos una NUEVA instancia del contexto para consultar los datos.
//    (Es buena práctica crear un contexto por operación para evitar estados obsoletos).
using (var context = new EscuelaContext())
{
  // 6. Imprimimos el encabezado para la tabla de alumnos.
  Console.WriteLine("-- Tabla Alumnos --");

  // 7. Iteramos sobre la colección de alumnos.
  //    EF ejecuta: SELECT * FROM Alumnos.
  foreach (var a in context.Alumnos)
  {
    // 8. Imprimimos ID y Nombre de cada alumno en la consola.
    Console.WriteLine($"{a.Id} {a.Nombre}");
  }

  // 9. Imprimimos el encabezado para la tabla de exámenes.
  Console.WriteLine("-- Tabla Exámenes --");

  // 10. Iteramos sobre la colección de exámenes.
  //    EF ejecuta: SELECT * FROM Examenes.
  foreach (var e in context.Examenes)
  {
    // 11. Imprimimos ID, Materia y Nota de cada examen.
    Console.WriteLine($"{e.Id} {e.Materia} {e.Nota}");
  }
}
// Fin del segundo bloque: El contexto se cierra y libera recursos automáticamente.

/*NOTAS:
¿Qué sucederá ahora cuando se ejecute 'dotnet run'?

Si ya se tienen datos en Escuela.sqlite (como los del ejercicio anterior: Ana, Carlos, etc.):
  -EnsureCreated(): Detectará la DB y no hará nada.
  -EscuelaInit.Inicializar: Verá que context.Alumnos.Count() > 0 (porque ya tiene 5 alumnos) 
  y retornará inmediatamente sin agregar nada.
  -Resultado: Se verán los 5 alumnos originales y sus exámenes en la consola:
  -- Tabla Alumnos --
  1 Ana García
  2 Carlos Méndez
  3 Lucía Torres
  4 Javier Ruiz
  5 Sofía Díaz
  -- Tabla Exámenes --
  1 Matemáticas 8.5
  2 Historia 9
  3 Matemáticas 7
  4 Física 6.5
  5 Historia 9.5
  6 Literatura 8
  7 Matemáticas 5.5
  8 Ciencias 7.8
  9 Historia 8.2
  10 Arte 9.8

Si se borras el archivo Escuela.sqlite original antes de ejecutar:
-EnsureCreated(): Creará la base de datos vacía con las tablas correctas.
-EscuelaInit.Inicializar: Verá que Count == 0, entrará en el bloque de if y agregará los 3 alumnos 
("Juan", "Ana", "Laura") y los 3 exámenes de ejemplo.
-Resultado: Se Verá en la consola:
  -- Tabla Alumnos --
  1 Juan
  2 Ana
  3 Laura
  -- Tabla Exámenes --
  1 Ingles 9
  2 Ingles 5
  3 Algebra 10

*/
