﻿/*Re-escribir la anterior función que calcula el factorial de un número n 
pasado al programa como parámetro por la línea de comando definiendo una función RECURSIVA
b) pero devolviendo el resultado en un parámetro de salida void Fac(int n, out int f)*/

// Ejecutar desde la consola (Linux) con: 
// dotnet run n

// Importamos el namespace System para tener acceso a clases básicas como Console y Environment
using System;
// Agregamos System.Numerics para tener acceso a la estructura BigInteger
using System.Numerics;

// Clase principal del programa
class Programa
{
    // Función que calcula el factorial de forma RECURSIVA con parámetro de salida
    // El tipo de retorno es 'void'. El resultado se entrega en 'f'.
    // El tipo de 'f' será 'BigInteger' para soportar números grandes.
    static void Fac(int n, out BigInteger f)
    {
        // Caso base: si n es 0 o 1, el factorial es 1
        if (n == 0 || n == 1)
        {
            // Asignamos directamente el valor 1 al parámetro de salida
            // El '1' se convierte implícitamente a BigInteger
            f = 1;
            return; // Terminamos la función aquí
        }

        // Paso recursivo: necesitamos calcular (n-1)! primero
        // Variable temporal para almacenar el resultado de la llamada recursiva
        BigInteger factorialAnterior; // El tipo de la variable será 'BigInteger'para evitar desbordamiento

        // Llamamos recursivamente a Fac con n-1, pasándole la variable temporal con 'out'
        Fac(n - 1, out factorialAnterior);

        // Una vez tenemos el resultado de (n-1)!, multiplicamos por n
        // 'n' (int) se convierte automáticamente a 'BigInteger' para la operación
        f = n * factorialAnterior;
        
        // Asignamos el resultado final al parámetro de salida 'f'
        // No usamos 'return' con valor, solo 'return' para salir del Caso base
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

        // Declaramos una variable para recibir el resultado
        // Usamos 'BigInteger' para almacenar resultados grandes.
        // No es necesario inicializarla aquí porque la función 'Fac' la asignará obligatoriamente
        BigInteger resultado;

        // Llamamos a la función recursiva Fac pasando 'n' y 'resultado' con 'out'
        Fac(n, out resultado);

        // Mostramos el resultado por consola usando interpolación de cadenas ($)
        // Esto permite insertar variables directamente entre llaves {n} y {resultado}
        Console.WriteLine($"El factorial de {n} es: {resultado}");
    }
}

/*Nota: 
Diferencias Clave en la Recursión con out:
- Variable Intermedia: En lugar de return n * Fac(n-1), creamos int factorialAnterior.
- Llamada Recursiva: Hacemos Fac(n - 1, out factorialAnterior). Esto "baja" la recursión hasta el caso base.
- Asignación: Una vez que la llamada recursiva devuelve el valor en factorialAnterior, hacemos la multiplicación y asignamos el resultado final a f.

Ejemplo de flujo con Fac(3, out f):
- Fac(3) llama a Fac(2, out temp1).
- Fac(2) llama a Fac(1, out temp2).
- Fac(1) (Caso base) asigna temp2 = 1 y termina.
- Vuelve a Fac(2): calcula f = 2 * temp2 (2 * 1 = 2) y termina.
- Vuelve a Fac(3): calcula f = 3 * temp1 (3 * 2 = 6) y termina.
El resultado en Main será 6.


Recordar que, si bien BigInteger nos permite manejar números grandes sin desbordar el tipo de dato, 
esta versión sigue siendo RECURSIVA. Si se intenta calcular el factorial de un número grande (ej. > 5000), 
el programa probablemente fallará con un StackOverflowException porque la pila de llamadas se agotará 
antes de que termine el cálculo.*/
