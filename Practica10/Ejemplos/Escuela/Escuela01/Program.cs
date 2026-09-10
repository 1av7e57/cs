﻿// Este es el punto en el que la aplicación de consola lee los datos creados manualmente en DB Browser.

// 1. Importamos el namespace de nuestra aplicación para tener acceso a las clases Alumno, Examen y EscuelaContext.
using Escuela;

// 2. PRIMER bloque 'using': Creación de la Base de Datos (Code First).
//    Creamos una instancia temporal del contexto solo para verificar/crear la DB.
//    'using (var context = new EscuelaContext())':
//    - Esto crea un objeto 'context' que representa una sesión con la base de datos.
//    - El bloque 'using' es CRUCIAL: garantiza que, al terminar de usar el contexto (ya sea con éxito o por un error),
//      se liberen automáticamente los recursos (conexión a la DB, buffers, etc.) llamando a 'context.Dispose()'.
//    - Un DbContext está pensado para una "unidad de trabajo" breve. No debemos mantenerlo abierto por mucho tiempo.
using (var context = new EscuelaContext())
{
  // 3. context.Database.EnsureCreated();
  //    - Aquí entra en juego el "Code First" en modo rápido.
  //    - EF Core verifica si la base de datos (Escuela.sqlite) existe.
  //    - SI NO EXISTE: Crea la base de datos y las tablas (Alumnos, Examenes) automáticamente basándose en las clases Alumno y Examen.
  //    - SI YA EXISTE: NO HACE NADA. No borra datos, no modifica tablas. Simplemente sigue adelante.
  //    - NOTA IMPORTANTE: Este método es ideal para prototipos o aprendizaje. En producción se usan "Migraciones" (Migrations) para controlar cambios de esquema.
  //    - Como ya creamos la DB manualmente en DB Browser, esta línea simplemente comprobará que existe y no hará cambios.
  context.Database.EnsureCreated();
}

// 4. SEGUNDO bloque 'using': Lectura de Datos.
//    Creamos una NUEVA instancia del contexto para realizar las consultas.
//    (Recordatorio: El contexto anterior se cerró y liberó recursos al salir del PRIMER bloque 'using').
using (var context = new EscuelaContext())
{
  // 5. Imprimimos un título para separar visualmente la salida en consola.
  Console.WriteLine("-- Tabla Alumnos --");

  // 6. Iteramos sobre la colección de alumnos.
  //    'foreach (var a in context.Alumnos)':
  //    - Al acceder a 'context.Alumnos', EF Core genera automáticamente una consulta SQL (SELECT * FROM Alumnos).
  //    - Ejecuta la consulta contra la base de datos SQLite.
  //    - Convierte las filas devueltas en objetos 'Alumno' y los recorre uno por uno.
  //    - Esto se llama "Lazy Loading" implícito en la iteración o consulta diferida.
  foreach (var a in context.Alumnos)
  {
    // 7. Imprimimos los datos de cada alumno.
    //    '{a.Id} {a.Nombre}': Interpolación de cadenas. Inserta los valores de las propiedades del objeto 'a'.
    Console.WriteLine($"{a.Id} {a.Nombre}");
  }

  // 8. Imprimimos el título para la sección de exámenes.
  Console.WriteLine("-- Tabla Exámenes --");

  // 9. Iteramos sobre la colección de exámenes.
  //    'foreach (var e in context.Examenes)':
  //    - EF Core genera: SELECT * FROM Examenes.
  //    - Recorre los objetos 'Examen' devueltos.
  foreach (var e in context.Examenes)
  {
    // 10. Imprimimos los datos de cada examen.
    //    '{e.Id} {e.Materia} {e.Nota}': Muestra el ID, la materia y la nota.
    //    Nota: No estamos mostrando la fecha para no saturar la consola, pero se podría agregar fácilmente.
    Console.WriteLine($"{e.Id} {e.Materia} {e.Nota}");
  }
}
// 11. Al salir del SEGUNDO bloque 'using', el contexto se cierra y libera la conexión a la base de datos automáticamente.


/*NOTAS:

Conceptos Clave de este código:
    -Consulta Diferida (Deferred Execution): La línea foreach (var a in context.Alumnos) no ejecuta 
    la consulta inmediatamente al escribirse, sino en el momento en que se empieza a iterar. 
    EF Core es "perezoso" hasta que se necesitan los datos.
    -Gestión de Recursos: El bloque using es vital. Si no lo usáramos, la conexión a la base de datos 
    podría permanecer abierta innecesariamente, lo cual es malo para el rendimiento y podría causar 
    errores en aplicaciones más grandes.
    -Mapeo Automático: No escribimos SELECT ni WHERE. Simplemente pedimos context.Alumnos y EF Core 
    se encarga de traducir eso a SQL, ejecutarlo y devolver objetos C#.

¿Qué sucede al ejecutar este código?
    -Verificación: El programa inicia, crea el contexto y llama a EnsureCreated().
        -Como ya existe el archivo Escuela.sqlite creado con datos de ejemplo, EF Core detecta que existe y no modifica nada.
        -Si se hubiera borrado el archivo .sqlite antes de ejecutar, EF Core lo habría creado de nuevo y las tablas 
        se habrían generado automáticamente, pero estarían vacías (sin los datos que fueron insertados manualmente).
    -Lectura: El programa cierra ese contexto y abre uno nuevo para leer.
    -Salida: Muestra en consola los datos de alumnos y exámenes.

Salida esperada en Consola (A partir de los datos de ejemplo insertados manualmente en DB Browser):
    Al ejecutar dotnet run, debería verse:

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

*/
