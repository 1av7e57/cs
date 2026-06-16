﻿/*Codificar el método Swap que recibe 2 parámetros enteros e intercambia sus valores. El cambio
debe apreciarse en el método invocador.*/

using System; // Importa el espacio de nombres System para usar la clase Console

class Program // Define la clase principal del programa
{
    // Define el método Swap que recibe dos parámetros enteros por referencia
    // La palabra clave 'ref' en la firma indica que trabajará con las variables originales
    static void Swap(ref int x, ref int y)
    {
        int temp = x; // Crea una variable temporal 'temp' y guarda el valor actual de 'x' en ella
        x = y; // Asigna el valor de 'y' a 'x', sobrescribiendo el valor original de 'x'
        y = temp; // Asigna el valor guardado en 'temp' (el original de 'x') a 'y'
    }
    static void Main() // Define el método de entrada principal que ejecuta el programa
    {
        int a = 10; // Declara una variable entera 'a' e inicializa con el valor 10
        int b = 20; // Declara una variable entera 'b' e inicializa con el valor 20

        Console.WriteLine($"Antes del intercambio: a = {a}, b = {b}"); // Muestra en consola los valores originales de 'a' y 'b' antes de llamar al método

        // Llama al método Swap pasando 'a' y 'b' por referencia usando la palabra clave 'ref'
        // Esto permite que el método modifique las variables originales en lugar de copias
        Swap(ref a, ref b);

        Console.WriteLine($"Después del intercambio: a = {a}, b = {b}"); // Muestra en consola los nuevos valores de 'a' y 'b' después del intercambio
    }

}

/*Nota: 
En C#, por defecto, los tipos como int se pasan por valor. 
Esto significa que si solo se pasan los números al método, cualquier cambio que se haga dentro de él será local 
y no afectará a las variables originales fuera del método.
Para que el cambio se aprecie en el método invocador, deben pasarse los parámetros por referencia utilizando la palabra clave ref.
De esta manera, se pasa la dirección de memoria de la variable, por lo que aquello que se haga en el método SI afectará al original.
(o alternativamente puede usarse out, pero ref es el estándar para intercambiar valores existentes).
Además, la técnica de usar una variable temporal (temp) es el algoritmo clásico de intercambio y funciona igual en casi cualquier lenguaje de programación.
*/
