﻿/*Escribir una función (método int Fac(int n)) que calcule el factorial de un número n
pasado al programa como parámetro por la línea de comando
b) Definiendo una función RECURSIVA*/

// Ejecutar desde la consola (Linux) con: 
// dotnet run n

// Importamos el namespace System para tener acceso a clases básicas como Console y Environment
using System;
// Agregamos System.Numerics para tener acceso a la estructura BigInteger
using System.Numerics;

// Clase principal del programa
class Programa
{
    // Función que calcula el factorial de un número de forma RECURSIVA
    // El tipo de retorno es 'BigInteger' para manejar números grandes
    static BigInteger Fac(int n)
    {
        // Caso base: si n es 0 o 1, el factorial es 1 (detenemos la recursión)
        if (n == 0 || n == 1)
        {
            return 1; // Retorna 1 como BigInteger implícitamente
        }

        // Paso recursivo: n! = n * (n-1)!
        // La función se llama a sí misma con el valor n-1
        return n * Fac(n - 1);
    }

    // Método principal que entra en ejecución al iniciar el programa
    static void Main(string[] args)
    {
        // Verificamos si se ha pasado un argumento en la línea de comandos
        if (args.Length == 0)
        {
            // Si no hay argumentos, mostramos un mensaje de error y salimos
            Console.WriteLine("Error: Debes proporcionar un número como argumento.");
            return;
        }

        // Intentamos convertir el argumento a un número entero usando TryParse
        // TryParse devuelve true si la conversión fue exitosa, false si falló (ej. letras o decimales)
        // El valor convertido se guarda directamente en la variable 'n'
        // Nota: 'n' sigue siendo int para el límite de entrada, pero el cálculo interno usará BigInteger
        if (!int.TryParse(args[0], out int n))
        {
            // Si la conversión falla (inputs como "abc", "5.5", etc.), mostramos error
            Console.WriteLine("Error: El argumento proporcionado no es un número entero válido.");
            return;
        }

        // Verificamos que el número sea no negativo, ya que el factorial no está definido para negativos
        if (n < 0)
        {
            // Mostramos mensaje de error si el número es negativo
            Console.WriteLine("Error: El factorial no está definido para números negativos.");
            return;
        }

        // Llamamos a la función recursiva Fac con el número n 
        // y guardamos el resultado como 'BigInteger'
        BigInteger resultado = Fac(n);

        // Mostramos el resultado por consola usando interpolación de cadenas ($)
        // Esto permite insertar variables directamente entre llaves {n} y {resultado}
        // El método ToString() de BigInteger se usa implícitamente aquí
        Console.WriteLine($"El factorial de {n} es: {resultado}");
    }
}

/*¿Cómo funciona la recursión aquí?
Si se llama a Fac(4), el flujo interno sería así:

Fac(4) devuelve 4 * Fac(3)
Fac(3) devuelve 3 * Fac(2)
Fac(2) devuelve 2 * Fac(1)
Fac(1) devuelve 1 (Caso base, se detiene aquí)

Luego, el programa "desenrolla" la pila de llamadas:
Fac(2) = 2 * 1 = 2
Fac(3) = 3 * 2 = 6
Fac(4) = 4 * 6 = 24

Nota importante sobre la recursión:
Aunque la solución recursiva es más elegante y matemáticamente directa, tiene una limitación: 
el desbordamiento de pila (Stack Overflow). 
Si bien el tipo de dato BigInteger nos permite manejar factoriales de números muy grandes 
(por ejemplo, 100! o 1000!), sigue habiendo un límite práctico debido a la memoria 
y al tiempo de procesamiento de la recursión profunda. Si el número es extremadamente grande 
(como 5000+), el programa podría cerrarse porque se agota la memoria de la pila de llamadas
(StackOverflowException). 
La versión iterativa (con bucle for) es más segura para números muy grandes.*/
