﻿/*Utilizar Console.ReadLine() para leer líneas de texto (secuencia de caracteres que finaliza al
presionar <ENTER>) por la consola. Por cada línea leída se debe imprimir la cantidad de caracteres de la misma. 
El programa termina al ingresar la cadena vacía. 

Nota: si st es una variable de tipo string, entonces st.Length devuelve la cantidad de caracteres del string.
*/

// Importar el namespace System para acceder a clases básicas como Console y String
using System;

    // Clase principal que contiene el punto de entrada de la aplicación
    class Program
    {
        // Método Main: punto de entrada donde comienza la ejecución del programa
        static void Main()
        {
            // Declarar una variable de tipo string para almacenar la línea ingresada por el usuario
            // Se declara usando ? para idicar que puede ser nula (vacía)
            string? st;

            // Iniciar un bucle infinito que solo se romperá cuando se ingrese una cadena vacía
            while (true)
            {
                // Mostrar un mensaje al usuario indicando que puede escribir texto
                Console.Write("Escribe una línea (o presiona Enter para salir): ");

                // Leer la línea de texto ingresada por el usuario hasta que presione <ENTER>
                st = Console.ReadLine();

                // Verificar si la línea leída es nula o una cadena vacía para determinar si salir
                if (string.IsNullOrEmpty(st))
                {
                    // Mostrar un mensaje de despedida al usuario
                    Console.WriteLine("Fin del programa.");

                    // Romper el bucle infinito y terminar la ejecución del programa
                    break;
                }

                // Obtener la cantidad de caracteres de la cadena almacenada en la variable 'st'
                // Utilizamos la propiedad Length del objeto string
                int cantidadCaracteres = st.Length;

                // Imprimir en consola la cantidad de caracteres de la línea ingresada
                Console.WriteLine($"La línea tiene {cantidadCaracteres} caracteres.");
            }
        }
    }
