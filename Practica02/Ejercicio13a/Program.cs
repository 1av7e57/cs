﻿/*Escribir una función (método int Fac(int n)) que calcule el factorial de un número n
pasado al programa como parámetro por la línea de comando
a) Definiendo una función NO recursiva*/

// Ejecutar desde la consola (Linux) con: 
// dotnet run n

// Importamos el namespace System para tener acceso a clases básicas como Console y Environment
using System;

// Importamos System.Numerics para usar BigInteger
using System.Numerics;

// Clase principal del programa
class Programa
{
    // Función que calcula el factorial de un número de forma NO recursiva
    // Usamos BigInteger para manejar números muy grandes
    static BigInteger Fac(int n)
    {
        // Inicializamos una variable para almacenar el resultado, empezando en 1
        // Esto cubre correctamente los casos base matemáticos ($0! = 1$ y $1! = 1$)
        BigInteger factorial = 1;

        // Usamos un bucle for para multiplicar desde 2 hasta n,
        // ya que multiplicar cualquier número por 1 no altera su valor
        for (int i = 2; i <= n; i++)
        {
            // Multiplicamos el valor actual de factorial por i
            // Como factorial es BigInteger, i se convierte automáticamente
            factorial *= i;
        }

        // Retornamos el valor calculado del factorial
        return factorial;
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
        // TryParse devuelve true si la conversión fue exitosa, false si falló (ej. letras)
        // Además, el valor convertido se guarda directamente en la variable 'n'
        if (!int.TryParse(args[0], out int n))
        {
            // Si la conversión falla (inputs como "abc", "12.5", etc.), mostramos error
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

        // Llamamos a la función Fac con el número n y guardamos el resultado como BigInteger
        BigInteger resultado = Fac(n);

        // Mostramos el resultado por consola usando interpolación de cadenas ($)
        // Esto permite insertar variables directamente entre llaves {n} y {resultado}
        Console.WriteLine($"El factorial de {n} es: {resultado}");
    }
}
