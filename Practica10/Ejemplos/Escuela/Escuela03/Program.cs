﻿// Esta modificación en Program.cs introduce el operador .Join() de LINQ, que es fundamental para 
// relacionar datos de diferentes tablas sin tener que hacer múltiples consultas.

// 1. Importamos el namespace de nuestra aplicación.
using Escuela;

// 2. Creamos una instancia del contexto.
using (var context = new EscuelaContext())
{
  // 3. Realizamos una consulta LINQ JOIN.
  //    'context.Alumnos.Join(...)':
  //    - 'Join' es un operador de LINQ que une dos colecciones (en este caso, la tabla Alumnos y la tabla Examenes).
  //    - Esta consulta generará un SQL interno equivalente a:
  //      "SELECT a.Nombre, e.Materia, e.Nota FROM Alumnos a INNER JOIN Examenes e ON a.Id = e.AlumnoId"
  
  //    Los parámetros del Join son:
  //    a) 'context.Alumnos': La primera colección (tabla principal).
  //    b) 'context.Examenes': La segunda colección (tabla a unir).
  
  //    c) 'a => a.Id': Expresión de la clave de la primera colección.
  //       - Para cada alumno (a), tomamos su 'Id'.
  
  //    d) 'e => e.AlumnoId': Expresión de la clave de la segunda colección.
  //       - Para cada examen (e), tomamos su 'AlumnoId'.
  //       - El JOIN unirá las filas donde estas dos claves sean iguales.
  
  //    e) '(a, e) => new { ... }': Función de proyección (result).
  //       - Define cómo se verán los datos en el resultado final.
  //       - Creamos un objeto anónimo (no tiene nombre de clase, definido por el compilador).
  //       - 'Alumno = a.Nombre': Copia el nombre del alumno a la propiedad 'Alumno' del resultado.
  //       - 'Materia = e.Materia': Copia la materia del examen.
  //       - 'Nota = e.Nota': Copia la nota del examen.
  var query = context.Alumnos.Join(context.Examenes,
                                  a => a.Id,
                                  e => e.AlumnoId,
                                  (a, e) => new { Alumno = a.Nombre,
                                                  Materia = e.Materia,
                                                  Nota = e.Nota
                                                });

  // 4. Iteramos sobre el resultado de la consulta.
  //    - 'foreach (var obj in query)': El objeto 'obj' ahora es una instancia del objeto anónimo { Alumno, Materia, Nota }.
  foreach (var obj in query)
  {
    // 5. Imprimimos el objeto.
    //    - Al imprimir un objeto anónimo, .NET llama a su método ToString(), que devuelve una representación de sus propiedades.
    //    - El formato típico será: "{ Alumno = Ana, Materia = Ingles, Nota = 9 }".
    Console.WriteLine(obj);
  }
}

/*NOTAS:
¿Qué hemos logrado con este código?
-Relación Uno a Muchos: Hemos aprovechado la relación AlumnoId para unir las dos tablas. 
Si un alumno tiene 3 exámenes, esa fila de alumno aparecerá 3 veces en el resultado (una por cada examen).
-Objeto Anónimo (new { ... }): En lugar de crear una clase nueva para el resultado (ej: class ResultadoExamenes), 
usamos un objeto anónimo. Esto es muy común en LINQ para consultas rápidas de lectura.
-Eficiencia: EF Core traduce este .Join() en un único comando SQL con INNER JOIN. 
Es mucho más eficiente que hacer dos consultas separadas (una para alumnos y otra para exámenes) 
y luego unirlas en memoria.

Salida esperada en consola (Usando los datos generados por 'EscuelaInit.cs'):
    { Alumno = Ana, Materia = Ingles, Nota = 9 }
    { Alumno = Juan, Materia = Ingles, Nota = 5 }
    { Alumno = Juan, Materia = Algebra, Nota = 10 }
*/
