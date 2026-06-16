﻿/*Idem. al ejercicio anterior salvo que se imprimirá un mensaje de saludo diferente según sea el
nombre ingresado por el usuario. Así para “Juan” debe imprimir “¡Hola amigo!”, para “María”
debe imprimir “Buen día señora”, para “Alberto” debe imprimir “Hola Alberto”. En otro caso,
debe imprimir “Buen día ” seguido del nombre ingresado o “¡Buen día mundo!” si se ha
ingresado una línea vacía.

Versión del programa: 
a) Utilizando 'if' ... 'else if'
*/

// Importamos el namespace System para usar la consola y tipos básicos
using System;

    // Definimos la clase principal del programa
    class Program
    {
        // El método Main es el punto de entrada donde comienza la ejecución
        static void Main()
        {
            // Declaramos una variable nullable para almacenar el nombre ingresado
            string? nombre;

            // Solicitamos al usuario que ingrese su nombre
            Console.WriteLine("Por favor, ingresa tu nombre:");

            // Leemos la línea ingresada por el usuario desde el teclado
            nombre = Console.ReadLine();

            // Verificamos primero si el nombre está vacío o es nulo (línea en blanco)
            if (string.IsNullOrWhiteSpace(nombre))
            {
                // Si está vacío, imprimimos el mensaje específico para el mundo
                Console.WriteLine("¡Buen día mundo!");
            }
            // Verificamos si el nombre es exactamente "Juan" (ignorando mayúsculas/minúsculas)
            else if (nombre.Equals("Juan", StringComparison.OrdinalIgnoreCase))
            {
                // Imprimimos el saludo específico para Juan
                Console.WriteLine("¡Hola amigo!");
            }
            // Verificamos si el nombre es exactamente "María" (ignorando mayúsculas/minúsculas)
            // Nota: el nombre debe contener el tilde en la letra ' í ' para que la coincidencia sea exacta
            else if (nombre.Equals("María", StringComparison.OrdinalIgnoreCase))
            {
                // Imprimimos el saludo específico para María
                Console.WriteLine("Buen día señora");
            }
            // Verificamos si el nombre es exactamente "Alberto" (ignorando mayúsculas/minúsculas)
            else if (nombre.Equals("Alberto", StringComparison.OrdinalIgnoreCase))
            {
                // Imprimimos el saludo personalizado para Alberto
                Console.WriteLine("Hola Alberto");
            }
            // Si no coincide con ninguno de los casos anteriores (caso general)
            else
            {
                // Imprimimos "Buen día " seguido del nombre ingresado
                Console.WriteLine("Buen día " + nombre);
            }

            // Pausamos la ejecución para que el usuario vea el resultado antes de que la consola se cierre
            Console.ReadKey();
        }
    }
