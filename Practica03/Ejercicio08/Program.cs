/*Señalar errores de compilación y/o ejecución en el siguiente código
object obj = new int[10];
dynamic dyn = 13;
Console.WriteLine(obj.Length);
Console.WriteLine(dyn.Length);*/

// LÍNEA 1: object obj = new int[10];
// Esto es válido. 'obj' es de tipo 'object' pero referencia a un array de 10 enteros.
// No hay error aquí, aunque se pierde el acceso directo a la propiedad 'Length' sin casting.
object obj = new int[10];

// LÍNEA 2: dynamic dyn = 13;
// Válido. 'dyn' es de tipo dinámico y contiene el entero 13.
dynamic dyn = 13;

// LÍNEA 3: Console.WriteLine(obj.Length);
// ❌ ERROR DE COMPILACIÓN.
// La variable 'obj' es de tipo 'object'. La clase 'object' NO tiene una propiedad 'Length'.
// El compilador de C# no sabe que en realidad es un array en tiempo de compilación.
// Para que funcione, se debe hacer un cast: ((int[])obj).Length
Console.WriteLine(obj.Length);

// LÍNEA 4: Console.WriteLine(dyn.Length);
// ❌ ERROR DE EJECUCIÓN (Runtime Error).
// El compilador NO verifica el tipo de 'dyn' porque es 'dynamic'.
// Acepta la línea sin problemas de compilación.
// Sin embargo, en tiempo de ejecución, 'dyn' contiene un entero (13).
// Los enteros (System.Int32) NO tienen una propiedad 'Length'.
// Esto lanzará una excepción: RuntimeBinderException indicando que 'int' no tiene propiedad 'Length'.
Console.WriteLine(dyn.Length);

// Posibles correcciónes:
// (Si la intención es acceder a la longitud)
object obj = new int[10];
dynamic dyn = 13;

// Corrección para obj: Casting explícito
Console.WriteLine(((int[])obj).Length); // Imprime 10

// Corrección para dyn: Asegurar que es un tipo compatible con Length (ej. string o array)
dynamic dynStr = "Hola"; 
Console.WriteLine(dynStr.Length); // Imprime 4
