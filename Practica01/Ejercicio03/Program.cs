﻿/*Escribir un programa que solicite al usuario ingresar su nombre e imprima en la consola un
saludo personalizado utilizando ese nombre o la frase “Hola mundo” si el usuario ingresó una
línea en blanco. 
Para ingresar un string desde el teclado utilizar Console.ReadLine()*/

// Importamos el namespace System para poder usar clases básicas como Console
using System;

    // Definimos la clase principal que contiene el punto de entrada del programa
    class Program
    {
        // El método Main es donde comienza la ejecución del programa
        static void Main(string[] args)
        {
            // Declaramos una variable de tipo string llamada 'nombre' para almacenar la entrada del usuario
            // Declaramos la variable como 'string?' para permitir valores nulos
            string? nombre;

            // Mostramos un mensaje en la consola pidiendo al usuario que ingrese su nombre
            Console.WriteLine("Por favor, ingresa tu nombre:");

            // Leemos la línea de texto ingresada por el usuario desde el teclado y la asignamos a la variable 'nombre'
            nombre = Console.ReadLine();

            // Utilizamos una estructura condicional para verificar si la variable 'nombre' está vacía o es nula
            if (string.IsNullOrWhiteSpace(nombre))
            {
                // Si el usuario ingresó una línea en blanco (o solo espacios), imprimimos el saludo por defecto
                Console.WriteLine("Hola mundo");
            }
            else
            {
                // Si el usuario ingresó un nombre válido, imprimimos un saludo personalizado concatenando el nombre
                Console.WriteLine("Hola " + nombre);
            }

            // Pausamos la consola para que el usuario pueda ver el resultado antes de que la ventana se cierre
            Console.ReadKey();
        }
    }
