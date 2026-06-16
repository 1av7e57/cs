﻿/*Codificar el método Imprimir para que el siguiente código produzca la salida por consola que
se observa. Considerar que el usuario del método Imprimir podría querer más adelante
imprimir otros datos, posiblemente de otros tipos pasando una cantidad distinta de parámetros
cada vez que invoque el método.
Tip: usar params

Imprimir(1, "casa", 'A', 3.4, DayOfWeek.Saturday);
Imprimir(1, 2, "tres");
Imprimir();
Imprimir(" --------------------");

Salida deseada:
1 casa A 3,4 Saturday
1 2 tres

 --------------------
*/

using System; // Importa el espacio de nombres System para acceder a Console y otros tipos básicos

class Program // Define la clase principal del programa
{
    // Definición del método Imprimir
    // El método acepta una lista variable de argumentos,
    // que el compilador convierte automáticamente en un array de objetos llamado 'elementos'.
    // 'params' permite que el método acepte 0 o más argumentos de tipo 'object'
    // 'object' es el tipo base de todo en C#, permitiendo mezclar enteros, cadenas, etc.
    static void Imprimir(params object[] elementos) // 
    {
        // Verificamos si el array es nulo o está vacío (caso de 'Imprimir()' )
        // Si es así, imprimimos un salto de línea vacío y terminamos la ejecución del método
        if (elementos == null || elementos.Length == 0)
        {
            Console.WriteLine(); // Imprime un salto de línea vacío
            return; // Sale del método inmediatamente
        }

        // Recorremos cada elemento del array recibido
        for (int i = 0; i < elementos.Length; i++)
        {
            // Convertimos el objeto actual a su representación en texto (ToString())
            // y lo imprimimos seguido de un espacio en la misma línea
            Console.Write(elementos[i].ToString() + " ");
        }

        // Una vez terminada la lista de elementos, imprimimos un salto de línea para mover el cursor a la siguiente línea
        Console.WriteLine();
    }

    // El método Main es el punto de entrada de la aplicación
    static void Main()
    {
        // Llamamos al método Imprimir con diferentes tipos de datos: int, string, char, double y enum
        // params permite pasar todos estos argumentos como si fueran una lista
        Imprimir(1, "casa", 'A', 3.4, DayOfWeek.Saturday);
        
        // Llamada con enteros y una cadena
        Imprimir(1, 2, "tres");
        
        // Llamada sin argumentos (el array params estará vacío)
        Imprimir();
        
        // Llamada con una única cadena
        Imprimir(" --------------------");
    }
}
