﻿/*¿Para qué sirve el método Split de la clase string? 
Usarlo para escribir en la consola todas las palabras (una por línea) 
de una frase cargada en una variable local.

El método Split de la clase string en C#:
se utiliza para dividir una cadena de texto en un arreglo de substrings (string[]) basándose en uno o más delimitadores especificados.

Básicamente, toma una cadena completa (por ejemplo, "manzana,pera,uva") y la separa cada vez que encuentra el carácter 
o conjunto de caracteres que le indiques (como la coma ',' ), devolviendo una lista con las partes resultantes.

Este método es fundamental para procesar datos estructurados como listas separadas por comas (CSV), direcciones 
o cualquier texto que necesite ser segmentado para su análisis.*/

using System; // Importa el namespace System para usar Console y otras clases base

class Program // Define la clase principal del programa
{
    static void Main() // Declara el método Main que es el punto de entrada a la ejecución del programa 
    {
        // Declarar una variable local de tipo string con la frase de ejemplo
        string frase = "CSharp es un lenguaje de programación potente y versátil";

        // Usar el método Split para dividir la frase en un arreglo de palabras
        // El parámetro ' ' indica que se separará cada vez que encuentre un espacio en blanco
        string[] palabras = frase.Split(' ');

        // Iniciar un bucle for que recorre cada elemento del arreglo de palabras
        for (int i = 0; i < palabras.Length; i++)
        {
            // Escribir en la consola la palabra actual seguida de un salto de línea
            // Usamos Console.WriteLine para que cada palabra aparezca en una línea distinta
            Console.WriteLine(palabras[i]);
        }
    }
}

