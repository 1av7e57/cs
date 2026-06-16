﻿/*Investigar por las secuencias de escape \n, \t , \" y \\. 
Escribir un programa que las utilice
para imprimir distintos mensajes en la consola.*/

// Importar el espacio de nombres System para poder usar Console y otros tipos básicos
using System;

// Definir la clase principal del programa
class ProgramaSecuencias
{
        // El método Main es el punto de entrada donde comienza la ejecución del programa
    static void Main()
    {
        Console.WriteLine("=== Ejemplo de Secuencias de Escape en C# ===\n");

        // 1. Uso de \\n para saltos de línea y formato
        Console.WriteLine("Bienvenido al informe del sistema.\n");
        Console.WriteLine("Estado: Activo\n");

        // 2. Uso de \\t para tabulación y alineación
        Console.WriteLine("Detalles del usuario:");
        Console.WriteLine("\tNombre:\t\tJuan");
        Console.WriteLine("\tID:\t\t42589");
        Console.WriteLine("\tRol:\t\tAdministrador\n");

        // 3. Uso de \\" para incluir comillas dobles dentro del texto
        // Nota: La comilla simple (') no tiene ningún significado especial dentro de una cadena normal. 
        // NO requieren secuencias de escape especiales para mostrarse
        Console.WriteLine("Nota del sistema: El mensaje 'Hola mundo' fue procesado.");
        // Aquí SI usamos la secuencia de escape \" porque queremos mostrar las comillas dobles (") dentro de la cadena
        Console.WriteLine("El sistema registró: \"Error crítico detectado\".\n");

        // 4. Uso de \\ para mostrar una ruta de archivo literal
        Console.WriteLine("Ruta del log de errores:");
        Console.WriteLine("Path: C:\\Archivos\\Sistema\\Logs\\error.log\n");

        // Combinación de todas en una sola línea (ejemplo avanzado)
        Console.WriteLine("Resumen:\tUsuario \"Juan\" (ID: 42589) accedió a: C:\\Archivos\\Datos\\info.txt\n");
        
        Console.WriteLine("=== Fin del Programa ===");
        
        // Pausa para que el usuario vea la salida antes de cerrar
        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

/*Respuesta:

Las secuencias de escape en C# son combinaciones de caracteres especiales que comienzan con la barra invertida \ 
y permiten representar caracteres que no se pueden escribir directamente o que tienen un significado especial en el código.

Secuencia	Significado	                Ejemplo de código	                Resultado en pantalla
\n	        Salto de línea (Newline)	Console.WriteLine("Hola\nMundo");	Imprime "Hola" y luego "Mundo" en la siguiente línea.
\t	        Tabulación horizontal (Tab)	Console.Write("A\tB");	            Imprime "A", un espacio grande (tabulador), y luego "B".
\"	        Comilla doble (Quote)	    Console.WriteLine("Dijo \"Hola\"");	Imprime: Dijo "Hola" (la comilla se incluye en el texto).
\\	        Barra invertida (Backslash)	Console.WriteLine("C:\\Archivos");	Imprime: C:\Archivos (para que una sola barra \ sea visible, se escribe \\).

Nota: Cadenas Verbatim (@)
Para evitar escribir \\ constantemente (por ejemplo, en rutas de archivos), puedes usar el símbolo @ delante de la cadena. 
Esto le dice a C# que ignore las secuencias de escape y trate todo el texto literalmente.
Ejemplo:
string ruta = @"C:\Archivos\Datos";

*/
