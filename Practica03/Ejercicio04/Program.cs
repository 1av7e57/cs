/*Implementar un método que devuelva un arreglo de arreglos con los mismos elementos que la
matriz pasada como parámetro:
double[][] GetArregloDeArreglo(double [,] matriz)*/

// Importamos el namespace System para tener acceso a las clases básicas de .NET
using System;

// Definimos la clase principal del programa
class Program
{
    // Definimos el método que convierte la matriz bidimensional en un arreglo de arreglos
    // Recibe como parámetro una matriz bidimensional de doubles llamada 'matriz'
    // Devuelve un arreglo de arreglos de doubles
    static double[][] GetArregloDeArreglo(double[,] matriz)
    {
        // Obtenemos el número de filas de la matriz bidimensional
        int filas = matriz.GetLength(0);

        // Obtenemos el número de columnas de la matriz bidimensional
        int columnas = matriz.GetLength(1);

        // Creamos el arreglo de arreglos (jagged array) con la cantidad de filas necesarias
        double[][] resultado = new double[filas][];

        // Iteramos a través de cada fila de la matriz original
        for (int i = 0; i < filas; i++)
        {
            // Inicializamos cada sub-array dentro del arreglo principal con el tamaño correcto de columnas
            resultado[i] = new double[columnas];

            // Iteramos a través de cada columna de la fila actual
            for (int j = 0; j < columnas; j++)
            {
                // Copiamos el valor de la posición (i, j) de la matriz bidimensional
                // a la posición (i, j) del nuevo arreglo de arreglos
                resultado[i][j] = matriz[i, j];
            }
        }

        // Devolvemos el arreglo de arreglos completamente poblado
        return resultado;
    }

    // Definimos el método principal de entrada del programa
    static void Main()
    {
        // Creamos un ejemplo de matriz bidimensional de tipo double con 3 filas y 3 columnas
        double[,] matrizDeEjemplo = { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } };

        // Llamamos al método GetArregloDeArreglo pasando la matriz de ejemplo y almacenamos el resultado
        double[][] arregloDeArreglos = GetArregloDeArreglo(matrizDeEjemplo);

        // Mostramos un mensaje indicando que vamos a imprimir el resultado
        Console.WriteLine("Resultado del arreglo de arreglos:");

        // Iteramos sobre las filas del arreglo de arreglos
        // La variable i representa el índice de la fila.
        // Cada vez que este bucle completa una vuelta, se pasa a la siguiente fila.
        for (int i = 0; i < arregloDeArreglos.Length; i++)
        {
            // Iniciamos una cadena de texto para construir la fila actual 
            // Esta cadena reinicia para cada fila nueva
            string filaTexto = "";

            // Itera sobre las columnas (dentro de la fila actual).
            // La variable j representa el índice de la columna.
            // Este bucle recorre todos los elementos de la fila actual 
            // antes de que el bucle externo (i) avance a la siguiente.
            for (int j = 0; j < arregloDeArreglos[i].Length; j++)
            {
                // Añadimos el valor actual seguido de un espacio a la cadena de texto
                filaTexto += arregloDeArreglos[i][j] + " ";
            }

            // Mostramos la fila completa en la consolaun salto de línea antes de pasar a la siguiente fila
            Console.WriteLine(filaTexto);
        }
    }
}

/*Notas:
arregloDeArreglos es el arreglo principal (filas).
arregloDeArreglos.Length nos dice cuántas filas hay.
arregloDeArreglos[i] es el sub-arreglo que corresponde a la fila i.
arregloDeArreglos[i].Length obtiene cuántos elementos tiene la fila número i (cuántas "columnas" hay)

Si bien en este ejemplo partimos de una matriz, que es siempre regular, y por tanto el arreglo de arreglos
resultante es siempre regular, un jagged array tiene, a diferencia de la matriz, la opción de ser "irregular". 
En un caso distinto, La fila 0 podría tener .Length = 3 y la fila 1 podría tener .Length = 5. 
En una matriz tradicional [,], esto no sería posible.
*/
