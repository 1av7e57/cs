﻿/*Escribir un programa que multiplique por 365 el número entero ingresado por el usuario desde
la consola. El resultado debe imprimirse en la consola dígito por dígito, separado por un espacio
comenzando por el dígito menos significativo al más significativo.*/

// Importamos el namespace necesario para la entrada y salida en consola
using System;

// Define la clase principal
class Program
{
    // El método Main es el punto de entrada del programa
    static void Main()
    {
        // Declaramos una variable para almacenar el número ingresado por el usuario
        int numeroIngresado;

        // Iniciamos un bucle infinito que solo se romperá cuando se ingrese un dato válido
        while (true)
        {
            // Solicitamos al usuario que ingrese un número entero
            Console.Write("Ingresa un número entero: ");

            // Iniciamos un bloque de código donde podría ocurrir un error (la conversión)
            try
            {
                // Leemos la entrada de texto desde la consola y la intentamos convertir a entero
                // Si el texto no es un número válido, Convert.ToInt32 lanzará una excepción
                numeroIngresado = Convert.ToInt32(Console.ReadLine());

                // Si llegamos aquí, la conversión fue exitosa, así que salimos del bucle infinito
                break;
            }
            // Capturamos cualquier excepción que ocurra durante la conversión (ej. si el usuario escribe letras)
            catch (Exception)
            {
                // Informamos al usuario que hubo un error y que intente de nuevo
                Console.WriteLine("Entrada inválida. Por favor, ingresa un número entero válido.");

                // El bucle while(true) se repetirá automáticamente pidiendo el dato de nuevo
            }
        }

        // Multiplicamos el número ingresado por 365 y guardamos el resultado
        int resultado = numeroIngresado * 365;

        // Preparamos una variable para trabajar con el valor absoluto del resultado
        // Esto asegura que funcione correctamente si el número es negativo
        int valorTrabajo = Math.Abs(resultado);

        // Si el resultado es 0, lo manejamos como un caso especial
        if (valorTrabajo == 0)
        {
            // Imprimimos el dígito 0
            Console.WriteLine("0");
        }
        else
        {
            // Variable para almacenar los dígitos extraídos
            string digitosSalida = "";

            // Bucle que se ejecuta mientras haya dígitos por procesar
            while (valorTrabajo > 0)
            {
                // Obtenemos el último dígito del número usando el operador módulo (%)
                int digito = valorTrabajo % 10;

                // Agregamos el dígito a nuestra cadena de salida seguido de un espacio
                digitosSalida += digito.ToString() + " ";

                // Eliminamos el último dígito del número dividiendo entre 10 (división entera)
                valorTrabajo /= 10;
            }

            // Si el número original era negativo, añadimos el signo menos al final
            if (resultado < 0)
            {
                digitosSalida += "-";
            }

            // Imprimimos la cadena final con los dígitos separados por espacio
            // Se usa Trim para eliminar el último espacio en blanco innecesario
            Console.WriteLine(digitosSalida.Trim());
        }
    }
}
