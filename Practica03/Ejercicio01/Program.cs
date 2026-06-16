﻿/*Implementar un método para imprimir por consola todos los elementos de una matriz (arreglo
de dos dimensiones) pasada como parámetro. Debe imprimir todos los elementos de una fila en
la misma línea en la consola.
Ejemplo:
void ImprimirMatriz(double[,] matriz)
Ayuda: Si A es un arreglo, A.GetLength(i) devuelve la longitud del arreglo en la dimensión i.*/

using System; // Importamos el namespace System para usar la clase Console y otras utilidades básicas

class Program // Definimos la clase principal del programa
{
    // Método que recibe una matriz bidimensional de tipo double como parámetro
    static void ImprimirMatriz(double[,] matriz)
    {
        // Obtenemos la longitud de la primera dimensión (número de filas)
        int filas = matriz.GetLength(0);
        
        // Obtenemos la longitud de la segunda dimensión (número de columnas)
        int columnas = matriz.GetLength(1);
        
        // Iniciamos un bucle que recorre cada fila de la matriz desde el índice 0 hasta filas-1 (ajuste para compatibilizar con indices numerados desde 0)
        for (int i = 0; i < filas; i++)
        {
            // Iniciamos un bucle que recorre cada columna de la matriz desde el índice 0 hasta columnas-1 (ajuste para compatibilizar con indices numerados desde 0)
            for (int j = 0; j < columnas; j++)
            {
                // Imprimimos el elemento actual de la matriz seguido de un espacio para separarlo del siguiente
                Console.Write(matriz[i, j] + " ");
            }
            
            // Solo cuando terminamos de recorrer todas las columnas de una fila (fuera del bucle interno), 
            // damos un salto de línea para empezar a imprimir la siguiente fila.
            Console.WriteLine();
        }
    }

    // Método principal que se ejecuta al iniciar el programa
    static void Main()
    {
        // Creamos una matriz bidimensional de 3 filas y 4 columnas e inicializamos sus valores
        double[,] miMatriz = { 
            { 1.5, 2.3, 3.1, 4.7 }, 
            { 5.2, 6.8, 7.4, 8.9 }, 
            { 9.0, 10.5, 11.2, 12.6 } 
        };
        
        // Llamamos al método ImprimirMatriz pasando nuestra matriz como argumento
        ImprimirMatriz(miMatriz);
    }
}
