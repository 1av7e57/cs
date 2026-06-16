﻿/*Escribir un programa que solicite un año por pantalla y diga si es bisiesto. Un año es bisiesto si
es divisible por 4 pero no por 100. Si es divisible por 100, para ser bisiesto debe ser divisible
por 400.*/

using System; // Importamos el namespace System para acceder a las entradas y salidas de la consola

class Program // Definimos la clase principal
{
    static void Main() // Definimos el método Main como punto de entrada
    {
        // Declaramos la variable para almacenar el año
        int anio = 0; // Inicializamos con 0 para evitar el error de "variable no asignada"
        bool entradaValida = false; // Variable bandera para controlar el bucle, inicialmente false

        // Bucle while que se repite mientras la entrada NO sea válida
        while (!entradaValida) 
        {
            try // Inicia un bloque de código que puede generar una excepción
            {
                Console.Write("Por favor, ingrese un año válido: "); // Mostramos el mensaje de solicitud
                // Leemos la entrada del usuario
                string? entrada = Console.ReadLine(); // Se usa ? para indicar que la entrada puede estar vacía (null)                 

                // Intentamos convertir la cadena a entero
                // Si la entrada no es un número, lanzará una excepción y saltará al bloque catch                
                anio = int.Parse(entrada!); // Se usa ! para evitar la advertencia del compilador sobre null, confiando en el catch 

                // Si llegamos aquí, la conversión fue exitosa, marcamos la bandera como true para salir del bucle
                entradaValida = true; 
            }
            catch (FormatException) // Si ocurre un error de formato, captura la excepción
            {
                // Se ejecuta si el usuario ingresa texto que no es un número (ej. "abc")
                Console.WriteLine("Error: La entrada no es un número. Inténtelo de nuevo."); // Informamos el error
                Console.WriteLine(); // Añadimos una línea en blanco para mejor legibilidad
            }
            catch (OverflowException) // Si ocurre un error por desborde, captura la excepción
            {
                // Se ejecuta si el número es demasiado grande o pequeño para un tipo int
                Console.WriteLine("Error: El número ingresado es demasiado grande o pequeño. Inténtelo de nuevo."); // Informamos el error
                Console.WriteLine(); // Añadimos una línea en blanco para mejor legibilidad
            }
        }

        // Una vez salimos del bucle, ya tenemos un año válido en la variable 'anio'
        
        // Usamos un operador OR lógico (||). Esto significa que la variable será cierta si se cumple al menos una de las dos condiciones
        // Evaluamos las condiciónes de año bisiesto:
        // 1. Divisible por 4 y NO por 100, O
        // 2. Divisible por 400
        // Nota: Si un número es divisible por 400, automáticamente es divisible por 100 (y también por 4)
        bool esBisiesto = (anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0); // Calculamos si es bisiesto usando módulo

        if (esBisiesto) // Verificamos si la condición de bisiesto es verdadera
        {
            Console.WriteLine($"El año {anio} es bisiesto."); // Mostramos resultado positivo
        }
        else // Si la condición no se cumple
        {
            Console.WriteLine($"El año {anio} NO es bisiesto."); // Mostramos resultado negativo
        }
    }
}
