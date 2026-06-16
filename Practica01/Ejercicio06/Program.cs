/*¿ Qué hace la instrucción Console.WriteLine("100".Length); ?

Respuesta:

La instrucción Console.WriteLine("100".Length); hace lo siguiente:

- "100": Es un string (cadena de caracteres) que contiene los tres dígitos uno, cero y cero.
- .Length: Es una propiedad intrínseca de los strings en C# que devuelve la cantidad de caracteres que contiene. En este caso, como hay tres símbolos, el valor es 3.
- Console.WriteLine(...): Imprime el resultado en la consola.

Por lo tanto, el programa imprimirá el número 3.

A continuación se muestra un progrma de ejemplo para ilustrar el concepto: */



// Importar el namespace System para acceder a clases básicas como Console y String
using System;

// Clase principal que contiene el punto de entrada de la aplicación
class ProgramaEjemplo

{   // Método Main: punto de entrada donde comienza la ejecución del programa
    static void Main()
    {
        // Ejemplo 1: La instrucción que mencionaste
        // "100" tiene 3 caracteres
        Console.WriteLine($"Longitud de \"100\": { "100".Length }");

        // Ejemplo 2: Espacios en blanco
        // " A " tiene 3 caracteres (espacio + letra A + espacio)
        Console.WriteLine($"Longitud de \" A \": { " A ".Length }");

        // Ejemplo 3: Cadena vacía
        // "" no tiene caracteres
        Console.WriteLine($"Longitud de cadena vacía (\"\"): { "".Length }");

        // Ejemplo 4: Texto con mayúsculas
        // "Hola" tiene 4 letras
        string texto = "Hola";
        Console.WriteLine($"Longitud de texto 'Hola': { texto.Length }");
        
        // Ejemplo 5: Concatenación y cálculo
        // Si unimos dos strings, la longitud es la suma de ambas
        string a = "C#";
        string b = " es genial";
        string combinado = a + b;
        Console.WriteLine($"Longitud de \"C# es genial\": { combinado.Length }");
    }
}

/*Puntos clave a tener en cuenta:

-Conteo de caracteres, no bytes: .Length cuenta caracteres. En C#, los strings están compuestos por caracteres UTF-16. 
Para la mayoría de los casos básicos (letras latinas, números), 1 carácter = 1 unidad de conteo.

-No es mutable: La propiedad .Length es de solo lectura. 
No puedes cambiar la longitud de un string directamente; para modificarlo, debes crear uno nuevo.

-Espacios cuentan: Los espacios en blanco se consideran caracteres válidos y se suman al total.
*/
