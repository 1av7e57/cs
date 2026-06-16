/*Implementar los métodos GetDiagonalPrincipal y GetDiagonalSecundaria que
devuelven un vector con la diagonal correspondiente de la matriz pasada como parámetro. Si la
matriz no es cuadrada generar una excepción ArgumentException.
double[] GetDiagonalPrincipal(double[,] matriz)
double[] GetDiagonalSecundaria(double[,] matriz)*/

// Importar el espacio de nombres System para usar funcionalidades básicas de C#
using System;

// Clase principal del programa llamada Program
class Program
{
    // Método para obtener la diagonal principal de una matriz cuadrada
    // El valor de retorno es un array de tipo double
    static double[] GetDiagonalPrincipal(double[,] matriz)
    {
        // Obtener el número de filas de la matriz
        int filas = matriz.GetLength(0);
        // Obtener el número de columnas de la matriz
        int columnas = matriz.GetLength(1);

        // Verificar si la matriz es cuadrada (filas igual a columnas)
        if (filas != columnas)
        {
            // Si no es cuadrada, lanzar una excepción ArgumentException
            throw new ArgumentException("La matriz debe ser cuadrada para extraer la diagonal principal.");
        }

        // Crear un array para almacenar los elementos de la diagonal principal
        double[] diagonal = new double[filas];

        // Recorrer la matriz para extraer los elementos de la diagonal principal
        for (int i = 0; i < filas; i++)
        {
            // Asignar el elemento en la posición (i, i) al array de diagonal
            diagonal[i] = matriz[i, i];
        }

        // Retornar el array con la diagonal principal
        return diagonal;
    }

    // Método para obtener la diagonal secundaria de una matriz cuadrada
    // El valor de retorno es un array de tipo double
    static double[] GetDiagonalSecundaria(double[,] matriz)
    {
        // Obtener el número de filas de la matriz
        int filas = matriz.GetLength(0);
        // Obtener el número de columnas de la matriz
        int columnas = matriz.GetLength(1);

        // Verificar si la matriz es cuadrada (filas igual a columnas)
        if (filas != columnas)
        {
            // Si no es cuadrada, lanzar una excepción ArgumentException
            throw new ArgumentException("La matriz debe ser cuadrada para extraer la diagonal secundaria.");
        }

        // Crear un array para almacenar los elementos de la diagonal secundaria
        double[] diagonal = new double[filas];

        // Recorrer la matriz para extraer los elementos de la diagonal secundaria
        for (int i = 0; i < filas; i++)
        {
            // Asignar el elemento en la posición (i, columnas - 1 - i) al array de diagonal
            diagonal[i] = matriz[i, columnas - 1 - i];
        }

        // Retornar el array con la diagonal secundaria
        return diagonal;
    }

    // Método principal de entrada del programa
    static void Main(string[] args)
    {
        // Crear una matriz cuadrada de ejemplo de 3x3
        double[,] matrizEjemplo = {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 }
        };

        try
        {
            // Llamar al método GetDiagonalPrincipal y almacenar el resultado
            double[] diagonalPrincipal = GetDiagonalPrincipal(matrizEjemplo);
            // Llamar al método GetDiagonalSecundaria y almacenar el resultado
            double[] diagonalSecundaria = GetDiagonalSecundaria(matrizEjemplo);

            // Imprimir la diagonal principal en consola
            Console.WriteLine("Diagonal Principal:");
            // Recorrer el array de la diagonal principal para imprimir cada elemento
            foreach (double valor in diagonalPrincipal)
            {
                // Imprimir el valor seguido de un espacio
                // Nota: por defecto la conversión a texto decide que .0 es redundante 
                // y lo quita a menos que se indique un formato específico.
                Console.Write(valor + " ");
            }
            // Saltar a la siguiente línea después de imprimir la diagonal principal
            Console.WriteLine();

            // Imprimir la diagonal secundaria en consola
            Console.WriteLine("Diagonal Secundaria:");
            // Recorrer el array de la diagonal secundaria para imprimir cada elemento
            foreach (double valor in diagonalSecundaria)
            {
                // Imprimir el valor seguido de un espacio
                // Nota: por defecto la conversión a texto decide que .0 es redundante 
                // y lo quita a menos que se indique un formato específico.
                Console.Write(valor + " ");
            }
            // Saltar a la siguiente línea después de imprimir la diagonal secundaria
            Console.WriteLine();
        }
        catch (ArgumentException ex)
        {
            // Capturar y mostrar el mensaje de error si la matriz no es cuadrada
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

/*Notas:
Por convención:
- Diagonal Principal: De la esquina superior izquierda a la inferior derecha.
- Diagonal Secundaria: De la esquina superior derecha a la inferior izquierda.
En matemáticas y programación, las matrices se indexan como [fila, columna].
La fila 0 es la primera línea (arriba).
La fila n es la última línea (abajo).
Al iterar con un bucle for (int i = 0; i < filas; i++), i representa el índice de la fila.
Por lo tanto, el bucle procesa la matriz desde la parte superior hacia la inferior.

Representación visual:
       Col 0   Col 1   Col 2
Fila 0   1       2       3   
Fila 1   4       5       6   
Fila 2   7       8       9   
Diag. pri.: 1, 5, 9
Diag. sec.: 3, 5, 7

-Encontrar la diagonal principal:
La fórmula: i, i (filas, columnas)
En una matriz cuadrada, la diagonal principal es la línea que va desde la esquina superior izquierda hasta la esquina inferior derecha.
La característica fundamental de esta diagonal es que el número de fila es siempre igual al número de columna.
Si se está en la fila 0, el elemento de la diagonal también está en la columna 0.
Si se está en la fila 1, el elemento de la diagonal también está en la columna 1.
Si se está en la fila n, el elemento de la diagonal también está en la columna n.
Por lo tanto, usar el mismo índice i para ambos parámetros (matriz[i, i]) nos asegura que siempre estemos seleccionando los elementos 
que se alinean perfectamente en esa línea diagonal descendente.

-Encontrar la diagonal secundaria:
La fórmula: columnas - 1 - i  
Es la clave matemática para "moverse" desde la derecha hacia la izquierda a medida que se baja por las filas.
En una matriz cuadrada, para encontrar la diagonal secundaria, necesita emparejarse el índice de la fila (i)
con un índice de columna que sea su "opuesto" respecto al centro.
i: Representa la fila actual. Como el bucle comienza en 0 y sube, va de arriba a abajo.
columnas - 1: Es el índice de la última columna (el borde derecho).
    Nota: Se resta 1 porque los índices en programación empiezan en 0. 
    Si se tienen 3 columnas, los índices son 0, 1, 2. El último es 3 - 1 = 2.
- i: Se resta el índice de la fila actual para "moverse" hacia la izquierda.
En la primera fila (i=0), estamos en el borde derecho.
En la segunda fila (i=1), nos movemos 1 paso a la izquierda.
En la tercera fila (i=2), nos movemos 2 pasos a la izquierda.
La lógica: A medida que la fila aumenta (bajamos), la columna debe disminuir (movimiento a la izquierda) para mantenernos en la diagonal.
*/
