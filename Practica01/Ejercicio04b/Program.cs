/*Idem. al ejercicio anterior salvo que se imprimirá un mensaje de saludo diferente según sea el
nombre ingresado por el usuario. Así para “Juan” debe imprimir “¡Hola amigo!”, para “María”
debe imprimir “Buen día señora”, para “Alberto” debe imprimir “Hola Alberto”. En otro caso,
debe imprimir “Buen día ” seguido del nombre ingresado o “¡Buen día mundo!” si se ha
ingresado una línea vacía.

Versión del programa: 
b) Utilizando utilizando switch
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

            // Verificamos primero si el nombre está vacío o es nulo
            if (string.IsNullOrWhiteSpace(nombre))
            {
                // Si está vacío, imprimimos el mensaje específico para el mundo
                Console.WriteLine("¡Buen día mundo!");
            }
            // Si no está vacío, usamos un switch para evaluar el valor del nombre
            else
            {
                // Iniciamos la estructura switch sobre el valor de la variable 'nombre'
                // Usamos StringComparison.OrdinalIgnoreCase para comparar sin importar mayúsculas
                switch (nombre)
                {
                    // Caso: si el nombre es "Juan" (ignorando mayúsculas/minúsculas)
                    case var j when j.Equals("Juan", StringComparison.OrdinalIgnoreCase):
                        // Imprimimos el saludo específico para Juan
                        Console.WriteLine("¡Hola amigo!");
                        // Salimos del switch
                        break;

                    // Caso: si el nombre es "María" (ignorando mayúsculas/minúsculas)
                    // Nota: el nombre debe contener el tilde en la letra ' í ' para que la coincidencia sea exacta
                    case var m when m.Equals("María", StringComparison.OrdinalIgnoreCase):
                        // Imprimimos el saludo específico para María
                        Console.WriteLine("Buen día señora");
                        // Salimos del switch
                        break;

                    // Caso: si el nombre es "Alberto" (ignorando mayúsculas/minúsculas)
                    case var a when a.Equals("Alberto", StringComparison.OrdinalIgnoreCase):
                        // Imprimimos el saludo personalizado para Alberto
                        Console.WriteLine("Hola Alberto");
                        // Salimos del switch
                        break;

                    // Caso por defecto: si el nombre no coincide con los anteriores
                    default:
                        // Imprimimos "Buen día " seguido del nombre ingresado
                        Console.WriteLine("Buen día " + nombre);
                        // Salimos del switch
                        break;
                }
            }

            // Pausamos la ejecución para que el usuario vea el resultado antes de que la consola se cierre
            Console.ReadKey();
        }
    }
