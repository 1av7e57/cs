﻿/*Codificar usando iteradores los métodos:
-Rango(i, j, p) que devuelve la secuencia de enteros desde i hasta j con un paso de p 
-Potencia(b,k) que devuelve la secuencia b1,b2,. ..... bk
-DivisiblePor(e,i) retorna los elementos de e que son divisibles por i

Observar la salida que debe producir el siguiente código:
using System.Collections;
IEnumerable rango = Rango(6, 30, 3);
IEnumerable potencias = Potencias(2, 10);
IEnumerable divisibles = DivisiblesPor(rango, 6);
foreach (int i in rango)
{
    Console.Write(i + "");
}
Console.WriteLine();
foreach (int i in potencias)
{
    Console.Write(i + "");
}
Console.WriteLine();
foreach (int i in divisibles)
{
    Console.Write(i + "");
}
Console.WriteLine();

Salida por consola:
6 9 12 15 18 21 24 27 30
2 4 8 16 32 64 128 256 512 1024
6 12 18 24 30
*/

using System; // Importamos System para usar Console y otros tipos básicos.
using System.Collections.Generic; // Necesario para usar IEnumerable<int>.
                                  // Es preferible a usar IEnumerable sin tipo 
                                  // para evitar conversiones innecesarias.

// Importamos nuestro espacio de nombres personalizado donde está la clase Iteradores.
using Ejercicio08;

// Clase principal que contiene el punto de entrada de la aplicación.
class Program
{
    // El método Main es el punto de entrada.
    static void Main()
    {
        // 1. Invocamos los métodos estáticos de la clase Iteradores.
        // a) Generamos una secuencia del 6 al 30 con pasos de 3.
        // El método devuelve un objeto que implementa IEnumerable<int>.
        IEnumerable<int> rango = Iteradores.Rango(6, 30, 3);
        
        // b) Generamos las primeras 10 potencias de 2 (2^1 a 2^10).
        IEnumerable<int> potencias = Iteradores.Potencias(2, 10);
        
        // c) Filtramos la secuencia 'rango' para obtener solo los múltiplos de 6.
        // Nota: Aquí pasamos el objeto 'rango' como parámetro.
        // La evaluación es diferida (lazy): no se filtra hasta que se itera.
        IEnumerable<int> divisibles = Iteradores.DivisiblesPor(rango, 6);

        // 2. Imprimimos los resultados usando un método auxiliar.
        // Pasamos el título y la secuencia correspondiente.
        ImprimirSecuencia("Rango", rango);
        ImprimirSecuencia("Potencias", potencias);
        ImprimirSecuencia("Divisibles", divisibles);
    }

    // Método auxiliar estático para evitar repetir el código de impresión.
    // Recibe un título (string) y una secuencia de enteros (IEnumerable<int>).
    static void ImprimirSecuencia(string titulo, IEnumerable<int> secuencia)
    {
        // Imprimimos el título seguido de dos puntos.
        Console.WriteLine($"{titulo}:");
        
        // El bucle foreach es lo que activa la ejecución de los iteradores.
        // Cada vez que se llama a 'MoveNext()' en la secuencia, el método generador
        // se reanuda desde donde se pausó (yield return).
        foreach (int numero in secuencia)
        {
            // Imprimimos el número actual seguido de un espacio, sin salto de línea.
            Console.Write(numero + " ");
        }
        
        // Finalmente, imprimimos un salto de línea para que la siguiente salida empiece abajo.
        Console.WriteLine(); 
    }
}

/*NOTAS:
Puntos clave sobre las Interfaces e Iteradores en este ejercicio:
    1. yield return: Cuando se usa yield return dentro de un método que devuelve IEnumerable<T>,
    el compilador C# genera automáticamente una clase que implementa la interfaz IEnumerator<T> 
    y IEnumerable<T>. No se necesita escribir la lógica de MoveNext() o Current manualmente.

    2. Evaluación diferida (Lazy Evaluation): Los iteradores no ejecutan 
    el código inmediatamente al llamarse. El código se ejecuta solo cuando 
    se recorre la colección con un foreach.
        - En DivisiblesPor(rango, 6), el método no recorre rango hasta que se hace el foreach 
        sobre divisibles. En ese momento, itera sobre rango en tiempo real.

    3. Interfaces implícitas: Aunque no existe la palabra interface en el código, 
    se está trabajando directamente con ellas. La firma IEnumerable<int> garantiza 
    que el método devuelve un objeto que puede ser recorrido.

    4. Al usar IEnumerable<int> en la firma del método de Iteradores, se garantiza 
    que cualquier consumidor (como Program.cs) solo vea la interfaz de enumeración, 
    sin saber cómo se implementa internamente (encapsulamiento).
*/
