﻿/*Definir el tipo de datos enumerativo llamado Meses y utilizarlo para:
a) Imprimir en la consola el nombre de cada uno de los meses en orden inverso (diciembre,
noviembre, octubre ..., enero)
c) Solicitar al usuario que ingrese un texto y responder si el texto tipeado corresponde al
nombre de un mes
Nota: en todos los casos utilizar un for iterando sobre una variable de tipo Meses

Las enumeraciones (enums) son tipos de datos que permiten definir un conjunto de constantes con nombre. 
En este caso, Meses tendrá los valores de Enero a Diciembre.
*/

using System; // Importamos el namespace System para acceder a clases básicas como Console y Enum

// Definimos el tipo de datos enumerativo
enum Meses // Declaramos la enumeración con el nombre Meses
{
    Enero = 1, // Asignamos el valor 1 a la constante Enero
    Febrero = 2, // Asignamos el valor 2 a la constante Febrero
    Marzo = 3, // Asignamos el valor 3 a la constante Marzo
    Abril = 4, // Asignamos el valor 4 a la constante Abril
    Mayo = 5, // Asignamos el valor 5 a la constante Mayo
    Junio = 6, // Asignamos el valor 6 a la constante Junio
    Julio = 7, // Asignamos el valor 7 a la constante Julio
    Agosto = 8, // Asignamos el valor 8 a la constante Agosto
    Septiembre = 9, // Asignamos el valor 9 a la constante Septiembre
    Octubre = 10, // Asignamos el valor 10 a la constante Octubre
    Noviembre = 11, // Asignamos el valor 11 a la constante Noviembre
    Diciembre = 12 // Asignamos el valor 12 a la constante Diciembre
} 

class Program // Definimos la clase principal para el programa
{
    static void Main() // Definimos el método de entrada Main 
    { 
        // --- Parte A: Imprimir los meses en orden inverso ---
        Console.WriteLine("=== Lista de meses en orden inverso ==="); // Mostramos un mensaje de título en la consola

        // Obtenemos todos los valores del enum Meses y los convertimos en un array de tipo Meses
        Meses[] todosLosMeses = (Meses[])Enum.GetValues(typeof(Meses)); // Recuperamos los valores y los forzamos al tipo array de Meses

        // Iniciamos un bucle for para iterar desde el último índice hasta el primero (orden inverso)
        for (int i = todosLosMeses.Length - 1; i >= 0; i--) // Declaramos la variable i en el último índice y decrecemos hasta 0
        {
            // Asignamos el mes actual del array a una variable de tipo Meses
            Meses mesActual = todosLosMeses[i]; // Obtenemos el elemento del array en la posición i
            Console.WriteLine(mesActual.ToString()); // Imprimimos el nombre del mes convirtiendo el enum a texto
        }

        Console.WriteLine("\n"); // Imprimimos dos saltos de línea para separar secciones

        // --- Parte B: Verificar si un texto ingresado es un mes ---
        Console.WriteLine("=== Verificar si es un mes ==="); // Mostramos un mensaje de título para la parte B
        Console.Write("Ingresa el nombre de un mes: "); // Solicitamos al usuario que ingrese un texto

        // Leemos la línea de texto ingresada por el usuario desde la consola
        // Usamos ? para evitar advertencias por posible null en el string
        string? textoUsuario = Console.ReadLine(); // Almacenamos el ingreso del usuario en la variable textoUsuario

        // Declaramos una variable booleana para controlar si encontramos el mes
        bool esMes = false; // Inicializamos la bandera como falsa (no encontrado aún)

        // Iniciamos un bucle for para iterar sobre todos los meses y buscar coincidencia
        for (int i = 0; i < todosLosMeses.Length; i++) // Recorremos el array desde el índice 0 hasta el final
        {
            // Comparamos el nombre del mes actual con el texto del usuario ignorando mayúsculas/minúsculas
            // Usamos ! para evitar advertencias por posible null en el string
            if (textoUsuario!.Equals(todosLosMeses[i].ToString(), StringComparison.OrdinalIgnoreCase)) // Verificamos si son iguales sin importar el caso
            {
                esMes = true; // Cambiamos la bandera a verdadera indicando que sí es un mes
                break; // Salimos inmediatamente del bucle ya que encontramos la coincidencia
            }
        }

        // Evaluamos el valor de la variable booleana para mostrar el resultado
        if (esMes) // Verificamos si la bandera es verdadera
        {
            Console.WriteLine($"¡'{textoUsuario}' corresponde al nombre de un mes!"); // Mostramos mensaje de confirmación
        }
        else // Si la condición anterior fue falsa
        {
            Console.WriteLine($"'{textoUsuario}' NO corresponde al nombre de un mes."); // Mostramos mensaje de error
        }

        // Mensaje final para mantener la consola abierta
        Console.WriteLine("\nPresiona cualquier tecla para salir..."); // Indicamos al usuario que presione una tecla
        Console.ReadKey(); // Esperamos a que el usuario presione una tecla antes de cerrar
    }
}
