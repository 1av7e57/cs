﻿/*Implementar un programa que muestre todos los números primos entre 1 y un número natural
dado (pasado al programa como argumento por la línea de comandos). Definir el método bool
EsPrimo(int n) que devuelve true sólo si n es primo. Esta función debe comprobar si n es
divisible por algún número entero entre 2 y la raíz cuadrada de n. (Nota: Math.Sqrt(d)
devuelve la raíz cuadrada de d)*/

// Nota: Podemos verificar el funcionamiento de este programa abriendo una consola de comandos en la carpeta donde se encuentra el mismo y ejecutando: (en Linux)
// dotnet run -- n 
// Esto devolverá los números primos entre 1 y n (donde n sea un número que especifiquemos)
// O combinar comprobaciones de esta manera:
// dotnet run -- n1 && dotnet run -- n2
// Esto devolverá los números primos entre 1 y un número especificado (n1) y luego entre 1 y otro número especificado (n2)
// Para guardar los resultados de una comprobación en un archivo de texto en la carpeta del programa podemos usar:
// dotnet run -- n > nombreDelArchivo.txt

// Importamos el namespace System para acceder a métodos básicos como Console, Math y el array de argumentos
using System;

// Clase principal que contiene el programa
class Programa
{
    // Método estático que devuelve true si el número n es primo, y false en caso contrario
    // Recibe un entero 'n' como parámetro de entrada
    static bool EsPrimo(int n)
    {
        // Los números menores o iguales a 1 no se consideran primos por definición
        if (n <= 1)
        {
            // Retornamos false inmediatamente para estos casos
            return false;
        }

        // El número 2 es el único número par primo
        if (n == 2)
        {
            // Retornamos true ya que 2 es primo
            return true;
        }

        // Si el número es par y mayor que 2, no puede ser primo
        // Nota: La comprobación de "mayor que 2" es implícita porque ya descartamos el caso n == 2 
        // y verificamos si Si n es 1, 0 o negativo en los bloques anteriores
        if (n % 2 == 0)
        {
            // Retornamos false para cualquier otro número par
            return false;
        }

        // Calculamos la raíz cuadrada de n usando Math.Sqrt para optimizar el bucle de verificación
        // Convertimos el resultado a entero para usarlo como límite en el bucle 'for'
        int raiz = (int)Math.Sqrt(n);

        // Iteramos desde 3 hasta la raíz cuadrada de n ya que descartamos el número par 2 antes y 1 no es divisor útil (todos los números son divisibles por 1)
        // Incrementamos de 2 en 2 (i += 2) para verificar solo números impares 
        // Esto es eficiente porque ya descartamos los pares al inicio
        for (int i = 3; i <= raiz; i += 2)
        {
            // Verificamos si 'n' es divisible por el número actual 'i'
            // El operador % devuelve el residuo de la división
            if (n % i == 0)
            {
                // Si el residuo es 0, significa que 'i' divide a 'n' exactamente, por tanto no es primo
                return false;
            }
        }

        // Si el bucle termina sin encontrar ningún divisor, el número es primo
        return true;
    }

    // Método principal de entrada del programa, declarado con el parámetro string[] args
    // 'args' es un array de cadenas que contiene los valores pasados en la línea de comandos
    static void Main(string[] args)
    {
        // Verificamos si se ha proporcionado al menos un argumento en la línea de comandos
        // Si args.Length es 0, significa que el usuario no pasó ningún número
        if (args.Length == 0)
        {
            // Si no hay argumentos, mostramos un mensaje de error y terminamos el programa
            Console.WriteLine("Por favor, proporcione un número natural como argumento.");
            return;
        }

        // Intentamos convertir el primer argumento (args[0]) de la línea de comandos a un entero
        // 'limite' almacenará el número hasta el cual buscaremos primos
        if (int.TryParse(args[0], out int limite))
        {
            // Verificamos que el número sea natural (mayor o igual a 1)
            if (limite < 1)
            {
                // Si el número es menor a 1, mostramos un mensaje de error indicando el requisito
                Console.WriteLine("El número debe ser un natural (mayor o igual a 1).");
                return;
            }

            // Mostramos un mensaje introductorio indicando el rango de búsqueda que se va a realizar
            Console.WriteLine($"Números primos entre 1 y {limite}:");

            // Iteramos desde 1 hasta el número límite (inclusive) para verificar cada número
            for (int i = 1; i <= limite; i++)
            {
                // Llamamos al método EsPrimo para verificar si el número actual 'i' es primo
                // Si el método devuelve true, ejecutamos el bloque interno
                if (EsPrimo(i))
                {
                    // Si es primo, lo mostramos en la consola seguido de un salto de línea
                    Console.WriteLine(i);
                }
            }
        }
        else
        {
            // Si la conversión de string a entero falla (ej. el usuario escribió letras), mostramos error
            Console.WriteLine("El argumento proporcionado no es un número válido.");
        }
    }

}
