/*Escribir un programa que imprima en la consola todos los números que sean múltiplos de 17 o de 29 comprendidos entre 1 y 1000*/

// Importa el namespace System para acceder a funcionalidades básicas como la consola
using System;

// Define la clase principal del programa
class Program
{
    // Define el método de entrada principal donde se ejecuta el programa
    static void Main()
    {   
        // Imprime un encabezado en la consola
        Console.WriteLine("=== Múltiplos de 17 o 29 : ===");

        // Inicia un bucle for que comienza en 1 y aumenta en 1 hasta llegar a 1000
        for (int i = 1; i <= 1000; i++)
        {
            // Verifica si el número actual 'i' es divisible por 17 O por 29
            // El operador % devuelve el residuo de la división; si es 0, es múltiplo
            if (i % 17 == 0 || i % 29 == 0)
            {
                // Imprime el número 'i' en la consola seguido de un espacio
                Console.Write(i + " ");
            }
        }

        // Imprime un salto de línea al final para mantener la consola limpia
        Console.WriteLine();
    }
}
