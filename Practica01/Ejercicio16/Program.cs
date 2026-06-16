﻿/*Utilizar el operador ternario condicional para establecer el contenido de una variable entera con
el menor valor de otras dos variables enteras.*/

// Importamos el namespace System para acceder a las clases básicas como Console
using System;

// Clase principal del programa
class Program
{
    // Método principal de entrada al programa
    static void Main()
    {
        // Declaramos e inicializamos la primera variable entera con un valor de ejemplo
        int numero1 = 10;
        // Declaramos e inicializamos la segunda variable entera con otro valor de ejemplo
        int numero2 = 5;
        // Declaramos una variable entera para almacenar el valor mínimo de la comparación
        int menor;
        
        // Asignamos el valor de la variable 'menor' usando el operador ternario: 
        // si 'numero1' es menor que 'numero2', se asigna 'numero1', de lo contrario se asigna 'numero2'
        menor = (numero1 < numero2) ? numero1 : numero2;
        
        // Mostramos el valor de la variable 'numero1' en la consola usando interpolación de cadenas ($)
        Console.WriteLine($"El valor de numero1 es: {numero1}");
        // Mostramos el valor de la variable 'numero2' en la consola usando interpolación de cadenas ($)
        Console.WriteLine($"El valor de numero2 es: {numero2}");
        // Mostramos el valor de la variable 'menor' en la consola usando interpolación de cadenas ($)
        Console.WriteLine($"El menor valor es: {menor}");
        
        // Mantenemos la consola abierta esperando una tecla para que el usuario pueda ver el resultado
        Console.ReadKey();
    }
}
