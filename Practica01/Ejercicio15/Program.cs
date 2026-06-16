﻿/*Si a y b son variables enteras, identificar el problema (y la forma de resolverlo) de la siguiente
expresión (tip: observar qué pasa cuando b = 0):

if ((b != 0) & (a/b > 5)) Console.WriteLine(a/b);

Respuesta:

El problema principal de la expresión if ((b != 0) & (a/b > 5)) es el uso del operador & (AND lógico no abreviado) en lugar de && (AND lógico abreviado o de cortocircuito).

1) ¿Por qué es un problema?
En C#, el operador & evalúa siempre ambos lados de la expresión, sin importar el resultado del primero.

Si se usa &, el compilador ejecutará (b != 0) Y TAMBIÉN (a/b > 5).
Si la primera parte es falsa (es decir, b es 0), la segunda parte (a/b > 5) se ejecutará de todos modos.
Esto provoca una división por cero (DivideByZeroException) en tiempo de ejecución, incluso si estás intentando proteger la operación con la condición b != 0.

2) ¿Qué pasa cuando b = 0?
Si b = 0:

La primera condición (b != 0) es false.
Como se usa &, el código no se detiene aquí.
Evalúa la segunda parte: a / 0.
El programa lanza una excepción System.DivideByZeroException y se detiene (crash), nunca llega a imprimir nada.

3) La Solución
Debe cambiarse & por &&. El operador && realiza evaluación de cortocircuito. Si la primera condición es falsa (b == 0), saltará inmediatamente la segunda parte, evitando la división por cero y protegiendo el programa.

Código de ejemplo para ilustrar el problema: */

using System; // Importa la biblioteca estándar para usar la clase Console

class Program // Define la clase principal del programa
{
    static void Main() // Método de entrada donde inicia la ejecución del programa
    {
        int a = 10; // Declara una variable entera 'a' y le asigna el valor 10
        int b = 0;  // Declara una variable entera 'b' y le asigna el valor 0 (el caso problemático)

        Console.WriteLine("--- Prueba con operador & (INCORRECTO) ---"); // Imprime un encabezado para distinguir la prueba

        try // Inicia un bloque de código que puede lanzar excepciones (errores en tiempo de ejecución)
        {
            // Intenta evaluar la condición usando el operador & (AND lógico completo)
            // Nota: & evalúa SIEMPRE ambos lados, sin importar el resultado del primero.
            if ((b != 0) & (a / b > 5)) 
            {
                // Esta línea solo se imprimiría si la condición anterior fuera verdadera
                Console.WriteLine(a / b); 
            }
        }
        catch (DivideByZeroException) // Captura específicamente el error de dividir por cero
        {
            // Si ocurre una división por cero, se ejecuta este bloque
            Console.WriteLine("¡ERROR DETECTADO: División por cero con operador &!");
        }

        Console.WriteLine("\n--- Prueba con operador && (CORRECTO) ---"); // Imprime un nuevo encabezado para la prueba correcta

        try // Inicia otro bloque de protección para la segunda prueba
        {
            // Intenta evaluar la condición usando el operador && (AND lógico de cortocircuito)
            // Nota: && evalúa el primer lado primero; si es falso, salta la evaluación del segundo lado.
            if ((b != 0) && (a / b > 5)) 
            {
                // Si b es 0, la condición (b != 0) es falsa, por lo que && detiene la evaluación aquí
                // y NUNCA intenta calcular a / b.
                Console.WriteLine($"Resultado correcto: {a / b}");
            }
            else
            {
                // Se ejecuta si la condición es falsa O si la evaluación se detuvo por cortocircuito
                Console.WriteLine("Condición falsa o protegida correctamente. No se ejecuta la división.");
            }
        }
        catch (Exception ex) // Captura cualquier otro tipo de error que no sea el de división por cero
        {
            // Esta línea se ejecutará solo si ocurre un error "inesperado" dentro del try
            // Ejemplo: si el programa se quedara sin memoria (OutOfMemoryException) justo en ese instante.
            // En este ejemplo simple con b=0, este bloque NO se ejecutará porque el error fue capturado arriba
            Console.WriteLine($"Error inesperado: {ex.Message}");
        }
    }
}

