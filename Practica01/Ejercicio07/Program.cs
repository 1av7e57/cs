/*Sea st una variable de tipo string correctamente declarada.
¿Es válida la siguiente instrucción?:
Console.WriteLine(st=Console.ReadLine());

Respuesta:

Sí, la instrucción Console.WriteLine(st=Console.ReadLine()); es sintácticamente válida en C#.

¿Por qué es válida? 

En C#, la asignación (=) no solo guarda un valor en una variable, sino que también devuelve ese valor asignado.

- Console.ReadLine() lee la entrada del usuario y devuelve un string.
- st = ... asigna ese string a la variable st y, como resultado de la operación, devuelve el mismo string.
- Console.WriteLine(...) recibe ese string devuelto y lo imprime en pantalla.

Es decir, suceden dos cosas a la vez: se asigna el valor a la variable st y se escribe inmediatamente en la consola.

Nota:  Aunque es válida, se considera que mezclar asignación y salida en una sola línea es una mala práctica,
porque reduce la legibilidad. Generalmente se prefiere separar las operaciones para mayor claridad.
*/

using System; // Importa el espacio de nombres System para usar Console

class EjemploAsignacion // Define la clase principal del programa
{
    static void Main() // Define el método de entrada que inicia la ejecución
    {
        // Declara una variable de tipo string llamada 'st' (aún no tiene valor)
        // Se usa ? para evitar error si el usuario no ingresa nada (null)
        string? st;

        Console.WriteLine("=== Opción A: Asignación dentro de Write (Ejemplo) ==="); // Imprime un título separador en la consola
        Console.Write("Escribe algo: "); // Muestra un mensaje pidiendo entrada al usuario sin saltar de línea

        // 1. Console.ReadLine() espera al usuario y devuelve lo que escriba como string.
        // 2. La expresión 'st = ...' asigna ese valor a la variable 'st'.
        // 3. La asignación devuelve el mismo valor asignado, que pasa como argumento a WriteLine.
        // 4. Console.WriteLine imprime ese valor devuelto y luego salta a la siguiente línea.
        Console.WriteLine(st = Console.ReadLine());

        Console.WriteLine($"La variable 'st' ahora contiene: '{st}'"); // Imprime el contenido actual de la variable 'st' usando interpolación

        Console.WriteLine("\n=== Opción B: Forma separada (Recomendada) ==="); // Imprime otro título separador, con un salto de línea al inicio (\n)
        Console.Write("Escribe algo más: "); // Muestra otro mensaje pidiendo entrada al usuario

        // 1. Console.ReadLine() espera la entrada del usuario y devuelve el string.
        // 2. Se asigna ese valor a la variable 'st'.
        // 3. La instrucción termina aquí; no se devuelve ni se imprime nada todavía.
        st = Console.ReadLine();

        // 1. Console.WriteLine recibe el valor actual de la variable 'st'.
        // 2. Imprime el contenido de 'st' en la consola.
        Console.WriteLine(st);

         // Imprime nuevamente el contenido de 'st' para confirmar que se actualizó
        Console.WriteLine($"La variable 'st' ahora contiene: '{st}'");
    }
}
