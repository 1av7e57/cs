﻿//Opción 1: Variables explícitas con tipos definidos:

// 1. Creamos un array de enteros con valores iniciales.
int[] vector = new int[] { 1, 2, 3, 4, 5 };

// 2. Aplicamos el método de extensión 'Select' 
//    que provee LINQ para multiplicar cada elemento por 2.
//    El tipo de retorno es explícitamente IEnumerable<int>.
//    Nota: Aquí NO se ejecuta la multiplicación aún, solo se define la consulta.
IEnumerable<int> secuencia = vector.Select(n => n * 2);

// 3. Llamamos a Mostrar para ejecutar la consulta y ver los resultados (2, 4, 6, 8, 10).
Mostrar(secuencia);

// 4. Creamos una lista de strings con valores iniciales.
List<string> lista = new List<string>() { "uno", "dos", "tres" };

// 5. Transformamos cada string: 
//    lo pasamos a mayúsculas y le añadimos paréntesis.
//    El tipo de retorno es explícitamente IEnumerable<string>.
//    De nuevo, la ejecución se pospone hasta que se itere.
IEnumerable<string> secuencia1 = lista.Select(st => "(" + st.ToUpper() + ")");

// 6. Ejecutamos la consulta de secuencia1 y mostramos el resultado: "(UNO) (DOS) (TRES)".
Mostrar(secuencia1);

// 7. Tomamos la secuencia anterior (strings) y calculamos la longitud de cada uno.
//    El tipo cambia a IEnumerable<int> porque Length devuelve un entero.
IEnumerable<int> secuencia2 = secuencia1.Select(st => st.Length);

// 8. Ejecutamos y mostramos las longitudes: 5 5 6 (caracteres + paréntesis).
Mostrar(secuencia2);

// 9. Tomamos las longitudes (enteros) y las dividimos entre 2.0 para obtener decimales.
//    El tipo cambia a IEnumerable<double>.
IEnumerable<double> secuencia3 = secuencia2.Select(n => n / 2.0);

// 10. Ejecutamos y mostramos el resultado final: 2.5 2.5 2.5.
Mostrar(secuencia3);

// 11. Definición del método genérico Mostrar.
//     Recibe cualquier secuencia de un tipo T genérico.
void Mostrar<T>(IEnumerable<T> secuencia)
{
    // 12. Inicia la iteración. Es AQUÍ donde LINQ realmente ejecuta las consultas pendientes.
    foreach (T elemento in secuencia)
    {
        // 13. Imprime cada elemento seguido de un espacio.
        Console.Write(elemento + " ");
    }
    // 14. Salto de línea al finalizar la secuencia.
    Console.WriteLine();
}

/*NOTAS:
  En este enfoque, declaramos explícitamente el tipo de dato (IEnumerable<T>) para cada variable. 
  Esto puede ser útil cuando se necesita que el tipo sea evidente en la firma de la variable 
  o cuando el compilador no puede inferirlo (aunque aquí sí podría).

Ventajas:
  -Legibilidad del tipo de dato: El compilador y el lector saben exactamente 
  qué tipo de dato contiene cada variable (int, string, etc.).
  -Depuración: Si se añade un breakpoint en el debugger, se puede inspeccionar el tipo de la variable fácilmente.
  -Reutilización intermedia: Si se necesita usar 'secuencia' (la de números multiplicados por 2) más adelante 
  en el código para otra cosa distinta a la cadena de transformaciones, es ideal guardarla en una variable.

Desventajas:
  -Verbosidad: Escribir IEnumerable<T> muchas veces puede hacer el código más largo y menos ágil de leer.
  -Rigidez: Si se cambia la lógica y el tipo de retorno de una operación intermedia, se tiene que actualizar 
  manualmente el tipo de la variable.

Select vs For Each:
Diferencia Crítica: Ejecución Diferida (Deferred Execution):
  Esta es la gran ventaja de Select sobre un foreach tradicional:
    -foreach: La iteración se ejecuta inmediatamente al llegar a esa línea de código. 
    Si la lista tiene 1 millón de elementos, el CPU trabajará en ese instante.
    -Select: La iteración NO se ejecuta al declarar la consulta. Se guarda la "receta" (delegados lambda). 
    La iteración real ocurre solo cuando se itera sobre el resultado (ej. en un foreach, .ToList(), .Count(), etc.).

Diferencia en el rendimiento y memoria:
    - foreach + Add: Generalmente crea una nueva lista en memoria con todos los elementos 
    transformados inmediatamente. Si la lista es enorme, se consume memoria de golpe.
    - Select: Devuelve un iterador (un objeto que sabe cómo recorrer la lista). No crea 
    una nueva lista de resultados hasta que se le pide que lo haga (ej. con .ToList()).
  Esto permite procesar secuencias infinitas o muy grandes sin agotar la memoria, 
  porque procesa elemento por elemento "al vuelo" (streaming).
*/
