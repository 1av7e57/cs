﻿/*Escribir una función (método int Fib(int n)) que calcule el término n de la serie de Fibonacci.
Fib(n) = 1, si n <=2
Fib(n) = Fib(n-1) + Fib(n-2), si n > 2
Nota: la regla fundamental de la sucesión de Fibonachi define que cada número es la suma de los dos anteiores*/


// Importamos la biblioteca básica del sistema para usar Console (entrada/salida)
using System;
// Importamos la biblioteca System.Numerics para poder usar el tipo BigInteger
// BigInteger permite manejar números enteros de cualquier tamaño, limitados solo por la memoria
using System.Numerics;
// Definimos la clase principal de nuestro programa
class Program
{

    // Método que imprime la serie de Fibonacci desde 1 hasta 'n'
    // Recibe un entero 'n' que indica hasta qué término queremos llegar
    static void GenerarSerieFibonacci(int n)
    {
        // Imprimimos un encabezado indicando cuántos números se van a mostrar
        Console.WriteLine($"Serie de Fibonacci del 1 al {n}:");
        // Caso especial: si n es 1, solo mostramos el primer número
        if (n == 1)
        {
            Console.WriteLine(1);
            return; // Terminamos la función aquí porque no hay más números que calcular
        }
        // Inicializamos las variables para el cálculo iterativo usando BigInteger
        // 'anterior2' guarda el término n-2 (inicialmente corresponde a Fib(1))
        BigInteger anterior2 = 1;

        // 'anterior1' guarda el término n-1 (inicialmente corresponde a Fib(2))
        BigInteger anterior1 = 1;
        // Imprimimos los dos primeros términos directamente (1 y 1)
        Console.Write(anterior2 + " " + anterior1);
        // Iniciamos un bucle for que comienza en i = 3 (ya que los dos primeros ya los mostramos)
        // La condición matemática 'si n > 2' se traduce directamente en la lógica del bucle 
        // El bucle continúa mientras 'i' sea menor o igual a 'n'
        for (int i = 3; i <= n; i++)
        {
            // Calculamos el término actual sumando los dos anteriores
            // Gracias a BigInteger, esto funcionará incluso para números gigantescos
            BigInteger actual = anterior1 + anterior2;
            // Imprimimos el número actual seguido de un espacio
            Console.Write(" " + actual);
            // Actualizamos las variables para la siguiente iteración:
            // El valor anterior1 se convierte en el nuevo anterior2
            anterior2 = anterior1;

            // El valor actual calculado se convierte en el nuevo anterior1
            anterior1 = actual;
        }
        // Imprimimos un salto de línea al final para que el cursor baje y el texto no quede pegado
        Console.WriteLine();
    }

    // El método Main es el punto de entrada donde comienza el programa
    static void Main()
    {
        // Definimos el límite máximo de términos a calcular (para evitar congelar la consola)
        int limiteMaximo = 10000;

        // Variable de control para el bucle: 'false' significa que aún no tenemos una entrada válida
        bool entradaValida = false;

        // Variable para guardar el número ingresado por el usuario
        // En C#, no puede usarse una variable local antes de haberle asignado un valor inicial explícito
        // Inicializada en 0 por relleno, será reescrita por el input del usuario si es válido 
        int n = 0;
        // Iniciamos un bucle 'while' que se repite mientras 'entradaValida' sea falso
        // Esto asegura que el programa no termine hasta que el usuario acierte una entrada correcta
        while (!entradaValida)
        {
            // Mostramos un mensaje pidiendo al usuario que ingrese un número
            Console.Write($"Ingrese un número entre 1 y {limiteMaximo}: ");

            // Leemos la línea de texto ingresada por el usuario
            // Usamos ? para evitar advertencias por posible entrada nula (confiando en el manejo a continuación)
            string? entrada = Console.ReadLine();
            // Verificamos primero si la entrada está vacía, es solo espacios o es nula
            // 'string.IsNullOrWhiteSpace' devuelve true si no hay texto real
            if (string.IsNullOrWhiteSpace(entrada))
            {
                // Si está vacía, mostramos un mensaje de error específico
                Console.WriteLine("Error: No ingresaste ningún valor. Por favor, escribe un número.\n");

                // 'continue' salta el resto del código en este ciclo y vuelve al inicio del 'while'
                // Esto hace que la pregunta se repita inmediatamente
                continue;
            }
            // Intentamos convertir el texto ingresado a un número entero (int)
            // TryParse devuelve 'true' si la conversión fue exitosa y 'false' si falló
            // Si es exitoso, el valor convertido se guarda en la variable 'n' (reescribiendo el valor de 0 original)
            if (int.TryParse(entrada, out n))
            {
                // Si la conversión fue exitosa, verificamos si el número está dentro del rango válido
                if (n >= 1 && n <= limiteMaximo)
                {
                    // Si el número es válido, cambiamos la bandera a 'true'
                    // Esto hará que la condición del 'while' (!entradaValida) sea falsa y el bucle termine
                    entradaValida = true;
                }
                else
                {
                    // Si el número está fuera de rango (menor a 1 o mayor a limiteMaximo)
                    // Mostramos un mensaje de error específico indicando el rango correcto
                    Console.WriteLine($"Error: El número debe estar entre 1 y {limiteMaximo}. Intenta de nuevo.\n");
                    // No cambiamos 'entradaValida' a true, así que el bucle se repetirá
                }
            }
            else
            {
                // Si la conversión falló (el usuario escribió letras o símbolos extraños)
                // Mostramos un mensaje de error indicando que no es un número
                Console.WriteLine("Error: Lo que ingresaste no es una entrada válida (ej. 'abc'). Intenta de nuevo.\n");
                // No cambiamos 'entradaValida' a true, así que el bucle se repetirá
            }
        }
        // Este código solo se ejecuta una vez que el bucle 'while' termina
        // Es decir, solo cuando el usuario ingresó un número válido
        Console.WriteLine("\n¡Número válido! Calculando la serie...\n");

        // Llamamos al método para generar e imprimir la serie de Fibonacci hasta 'n'
        GenerarSerieFibonacci(n);
        // Al llegar al final de Main, el programa termina naturalmente
    }
}

/*Nota: Si bien un enfoque recursivo hubiera útil para entender la lógica matemática, NO es eficiente para valores grandes de n 
(por ejemplo, Fib(50) podría tardar minutos o colapsar la memoria). 
Como NO se especifica un rango exacto (ej: calcular solo la sucesión de Fibonachi en un rango de 1 a 10),
se opta por usar este enfoque iterativo (con bucle for ) que es mucho más rápido y eficiente a la hora de manejar números grandes*/
