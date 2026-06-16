﻿/*Re-escribir la anterior función que calcula el factorial de un número n
pasado al programa como parámetro por la línea de comando definiendo una función NO recursiva
a) pero devolviendo el resultado en un parámetro de salida void Fac(int n, out int f)*/

// Ejecutar desde la consola (Linux) con: 
// dotnet run n

// Importamos el namespace System para tener acceso a clases básicas como Console y Environment
using System;
// Agregamos System.Numerics para tener acceso a la estructura BigInteger
using System.Numerics;

// Clase principal del programa
class Programa
{
    // Función que calcula el factorial de forma NO recursiva
    // Nota: El tipo de retorno es 'void' porque no usamos 'return' para el resultado.
    // El resultado se devuelve a través del parámetro de salida 'out BigInteger f'.
    // Cambiamos el tipo de 'f' es 'BigInteger' para soportar números grandes.
    static void Fac(int n, out BigInteger f)
    {
        // Inicializamos una variable local temporal para el cálculo, iniciando en 1
        // Esto cubre correctamente los casos base matemáticos ($0! = 1$ y $1! = 1$)
        // Usamos 'BigInteger' para evitar desbordamiento
        BigInteger factorial = 1;

        // Usamos un bucle for para multiplicar desde 2 hasta n,
        // ya que multiplicar cualquier número por 1 no altera su valor
        for (int i = 2; i <= n; i++)
        {
            // Multiplicamos el valor actual de factorial por i
            // Como factorial es BigInteger, i se convierte automáticamente
            factorial *= i;
        }

        // Asignamos el valor calculado al parámetro de salida 'f'
        // Esto es OBLIGATORIO: el compilador exige que 'f' esté asignado antes de salir.
        f = factorial;
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

        // Declaramos una variable para recibir el resultado.
        // Usamos 'BigInteger' para almacenar resultados grandes.
        // No es necesario inicializarla aquí porque la función 'Fac' la asignará obligatoriamente.
        BigInteger resultado;

        // Llamamos a la función Fac pasando 'n' y la variable 'resultado' con la palabra clave 'out'.
        // El resultado del cálculo se almacenará directamente en 'resultado'.
        Fac(n, out resultado);

        // Mostramos el resultado por consola usando interpolación de cadenas ($)
        // Esto permite insertar variables directamente entre llaves {n} y {resultado}
        Console.WriteLine($"El factorial de {n} es: {resultado}");
    }
}

/*Nota: ¿Por qué usar out?
Este enfoque es útil cuando una función necesita devolver múltiples valores 
(por ejemplo, si se calculara el factorial y también el tiempo que tardó en calcularlo) 
o cuando se busca seguir patrones de diseño específicos de ciertas librerías 
que usan out para indicar éxito/fracaso junto con un valor.*/
