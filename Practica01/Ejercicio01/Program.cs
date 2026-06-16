﻿/*Consultar en la documentación de Microsoft y responder:
a)¿Cuál es la diferencia entre los métodos 'WriteLine()' y 'Write()' de la clase 'System.Console'?
b)¿Cómo funciona el método 'ReadKey()' de la misma clase?

Escribir un programa que imprima en la consola la frase “Hola Mundo”
haciendo una pausa entre palabra y palabra esperando a que el usuario presione una tecla para
continuar.
Tip: usar los métodos ReadKey() y Write() de la clase System.Console.*/

// Importar el espacio de nombres System para poder usar Console y otros tipos básicos
using System;

// Definir la clase principal del programa
class Program
{
    // El método Main es el punto de entrada donde comienza la ejecución del programa
    static void Main()
    {
        // Escribir la palabra "Hola" en la consola sin saltar a la nueva línea (usando Write)
        Console.Write("Hola");

        // Pausar la ejecución del programa hasta que el usuario presione cualquier tecla
        // El parámetro 'true' hace que la tecla pulsada no se muestre en pantalla (interceptada)
        Console.ReadKey(true);

        // Escribir la palabra "Mundo" en la consola, continuando en la misma línea
        Console.Write(" Mundo");

        // Pausar una última vez para que el usuario vea el resultado completo antes de que el programa termine
        Console.ReadKey(true);
    }
}

/*Respuestas:

a) Diferencia entre WriteLine() y Write()
La diferencia principal radica en el salto de línea al final de la salida:
-Console.Write(): Escribe los datos en la consola sin añadir un salto de línea al final. 
El siguiente texto que se escriba aparecerá justo después del último carácter, en la misma línea.
-Console.WriteLine(): Escribe los datos y añade automáticamente un salto de línea (carácter de nueva línea) al final. 
El cursor se mueve a la siguiente línea, de modo que la siguiente escritura comenzará en una nueva línea.

b) ¿Cómo funciona ReadKey()?
El método Console.ReadKey() sirve para leer la siguiente tecla pulsada por el usuario y devolverla como un objeto ConsoleKeyInfo. 
Este método tiene dos características clave:
-Es bloqueante: El programa se detiene y espera a que el usuario presione una tecla antes de continuar.
-Intercepta la tecla: Tiene un parámetro opcional bool intercept.
Si es true (predeterminado): La tecla pulsada no se muestra en la consola.
Si es false: La tecla pulsada se muestra en la consola ("echo").
Devuelve un objeto ConsoleKeyInfo que contiene información sobre la tecla, como el código de la tecla (Key), 
si se presionó Mayús, Ctrl o Alt (Modifiers), y el carácter Unicode correspondiente (KeyChar).
*/
