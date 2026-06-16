﻿/*Escribir un programa que calcule la suma de dos números reales introducidos por teclado y
muestre el resultado en la consola (utilizar double.Parse(st) para obtener el valor double a partir del string st.*/

using System; // Importa el namespace System para acceder a la consola y tipos básicos

class Programa // Define la clase principal
{
    static void Main() // Define el método Main, punto de entrada del programa
    {
        double num1; // Declara la variable num1 para almacenar el primer número
        double num2; // Declara la variable num2 para almacenar el segundo número
        // Declara una variable temporal para guardar el texto ingresado por el usuario
        string? st; // Se usa ? para indicar que la entrada puede estar vacía (null)

        // Bucle para obtener el primer número válido
        while (true) // Inicia un bucle infinito que solo se romperá si se ingresa un número válido
        {
            try // Inicia un bloque de código que puede generar una excepción
            {
                Console.Write("Introduce el primer número: "); // Muestra un mensaje pidiendo el primer número al usuario
                st = Console.ReadLine(); // Lee la entrada del usuario como texto y la guarda en la variable st
                // Intenta convertir el texto de st a un número decimal (double) y lo guarda en num1
                num1 = double.Parse(st!); /// Se usa ! para evitar la advertencia del compilador sobre null, confiando en el catch 
                break; // Si la conversión es exitosa, sale inmediatamente del bucle while
            } // Finaliza el bloque de prueba
            catch (Exception) // Si ocurre un error (texto vacío o no numérico), captura la excepción
            {
                Console.WriteLine("Entrada no válida. Por favor, ingresa un número real."); // Muestra un mensaje de error instando al usuario a corregir
            } // Finaliza el bloque de captura de errores y se reinicia el bucle while hasta llegar al break
        } // Finaliza el bucle de validación del primer número

        // Bucle para obtener el segundo número válido
        while (true) // Inicia otro bucle infinito para el segundo número
        {
            try // Inicia un bloque de código que puede generar una excepción
            {
                Console.Write("Introduce el segundo número: "); // Muestra un mensaje pidiendo el segundo número al usuario
                st = Console.ReadLine(); // Lee la entrada del usuario como texto y la guarda en la variable st
                // Intenta convertir el texto de st a un número decimal (double) y lo guarda en num2
                num2 = double.Parse(st!); // Se usa ! para evitar la advertencia del compilador sobre null, confiando en el catch
                break; // Si la conversión es exitosa, sale inmediatamente del bucle while
            } // Finaliza el bloque de prueba
            catch (Exception) // Si ocurre un error, captura la excepción
            {
                Console.WriteLine("Entrada no válida. Por favor, ingresa un número real."); // Muestra un mensaje de error instando al usuario a corregir
            } // Finaliza el bloque de captura de errores y se reinicia el bucle while hasta llegar al break
        } // Finaliza el bucle de validación del segundo número

        double suma = num1 + num2; // Calcula la suma de num1 y num2, y guarda el resultado en la variable suma

        Console.WriteLine("La suma es: " + suma); // Muestra el resultado final de la suma en la consola
    }
}
