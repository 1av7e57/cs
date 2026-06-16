﻿/*Escribir una función (método int Fac(int n)) que calcule el factorial de un número n
pasado al programa como parámetro por la línea de comando
c) Definiendo una función RECURSIVA pero 
con expression-bodied methods 
(Tip: utilizar el operador condicional ternario)*/

// Ejecutar desde la consola (Linux) con: 
// dotnet run n*/

// Importamos el namespace System para tener acceso a clases básicas como Console y Environment
using System;
// Agregamos System.Numerics para tener acceso a la estructura BigInteger
using System.Numerics;

// Clase principal del programa
class Programa
{
    // Función que calcula el factorial de forma RECURSIVA
    // Usamos expression-bodied method (=>) y operador ternario (? :)
    // La flecha => indica que el método devuelve el resultado de la expresión que sigue
    // El tipo de retorno es 'BigInteger' para manejar números grandes
    // En lugar de un if-else tradicional con llaves, usamos la sintaxis condición ? valor_si_verdadero : valor_si_falso.
    // Nota: 'n' sigue siendo int, pero al multiplicarlo por el resultado de la llamada recursiva (BigInteger), 
    // el resultado se convierte implícitamente en BigInteger.
    static BigInteger Fac(int n) => n == 0 || n == 1 ? 1 : n * Fac(n - 1);


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

        // Llamamos a la función recursiva Fac con el número n y guardamos el resultado como 'BigInteger'
        BigInteger resultado = Fac(n);

        // Mostramos el resultado por consola usando interpolación de cadenas ($)
        // Esto permite insertar variables directamente entre llaves {n} y {resultado}
        // El método ToString() de BigInteger se usa implícitamente aquí
        Console.WriteLine($"El factorial de {n} es: {resultado}");
    }
}

/*Nota: Esta es una versión más concisa y moderna en C# para la versión recursiva del programa, 
utilizando expression-bodied methods (=>) y el operador ternario condicional (? :).
Esta versión elimina las llaves { } y condensa la lógica if-else del método Fac, resumiéndolo todo en una sola línea.

Recordar que, si bien BigInteger nos permite manejar números grandes sin desbordar el tipo de dato, 
esta versión sigue siendo RECURSIVA. Si se intenta calcular el factorial de un número grande (ej. > 5000), 
el programa probablemente fallará con un StackOverflowException porque la pila de llamadas se agotará 
antes de que termine el cálculo.*/
