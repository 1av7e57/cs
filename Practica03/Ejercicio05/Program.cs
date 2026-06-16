/*Implementar los siguientes métodos que devuelvan la suma, resta y multiplicación de matrices
pasadas como parámetros. Para el caso de la suma y la resta, las matrices deben ser del mismo
tamaño, en caso de no serlo devolver null. Para el caso de la multiplicación la cantidad de
columnas de A debe ser igual a la cantidad de filas de B, en caso contrario generar una
excepción ArgumentException.
double[,]? Suma(double[,] A, double[,] B)
double[,]? Resta(double[,] A, double[,] B)
double[,] Multiplicacion(double[,] A, double[,] B)*/

using System; // Importamos el namespace System para usar Console y Exception

class Program // Definimos la clase principal del programa
{
    // Método estático para sumar dos matrices de tipo double
    // Retorna null si las dimensiones no coinciden, de lo contrario retorna la matriz resultante
    static double[,]? Suma(double[,] A, double[,] B)
    {
        // Obtenemos el número de filas de la matriz A
        int filasA = A.GetLength(0);
        // Obtenemos el número de columnas de la matriz A
        int colA = A.GetLength(1);
        // Obtenemos el número de filas de la matriz B
        int filasB = B.GetLength(0);
        // Obtenemos el número de columnas de la matriz B
        int colB = B.GetLength(1);

        // Verificamos si las filas y columnas de ambas matrices son diferentes
        if (filasA != filasB || colA != colB)
        {
            // Si las dimensiones no coinciden, devolvemos null
            return null;
        }

        // Creamos una nueva matriz para almacenar el resultado con las mismas dimensiones
        double[,] resultado = new double[filasA, colA];

        // Iniciamos un bucle para recorrer cada fila de la matriz
        for (int i = 0; i < filasA; i++)
        {
            // Iniciamos un bucle anidado para recorrer cada columna de la fila actual
            for (int j = 0; j < colA; j++)
            {
                // Sumamos los elementos en la posición (i, j) de ambas matrices
                resultado[i, j] = A[i, j] + B[i, j];
            }
        }

        // Retornamos la matriz resultante con los valores sumados
        return resultado;
    }

    // Método estático para restar dos matrices de tipo double
    // Retorna null si las dimensiones no coinciden, de lo contrario retorna la matriz resultante
    static double[,]? Resta(double[,] A, double[,] B)
    {
        // Obtenemos el número de filas de la matriz A
        int filasA = A.GetLength(0);
        // Obtenemos el número de columnas de la matriz A
        int colA = A.GetLength(1);
        // Obtenemos el número de filas de la matriz B
        int filasB = B.GetLength(0);
        // Obtenemos el número de columnas de la matriz B
        int colB = B.GetLength(1);

        // Verificamos si las filas y columnas de ambas matrices son diferentes
        if (filasA != filasB || colA != colB)
        {
            // Si las dimensiones no coinciden, devolvemos null
            return null;
        }

        // Creamos una nueva matriz para almacenar el resultado con las mismas dimensiones
        double[,] resultado = new double[filasA, colA];

        // Iniciamos un bucle para recorrer cada fila de la matriz
        for (int i = 0; i < filasA; i++)
        {
            // Iniciamos un bucle anidado para recorrer cada columna de la fila actual
            for (int j = 0; j < colA; j++)
            {
                // Sustraemos los elementos en la posición (i, j) de la matriz B de los de la matriz A
                resultado[i, j] = A[i, j] - B[i, j];
            }
        }

        // Retornamos la matriz resultante con los valores restados
        return resultado;
    }

    // Método estático para multiplicar dos matrices de tipo double
    // Lanza una excepción ArgumentException si las dimensiones no son compatibles
    static double[,] Multiplicacion(double[,] A, double[,] B)
    {
        // Obtenemos el número de filas de la matriz A
        int filasA = A.GetLength(0);
        // Obtenemos el número de columnas de la matriz A (debe coincidir con filas de B)
        int colA = A.GetLength(1);
        // Obtenemos el número de filas de la matriz B
        int filasB = B.GetLength(0);
        // Obtenemos el número de columnas de la matriz B
        int colB = B.GetLength(1);

        // Verificamos si el número de columnas de A es igual al número de filas de B
        if (colA != filasB)
        {
            // Si no coinciden, lanzamos una excepción ArgumentException con un mensaje descriptivo
            throw new ArgumentException("La multiplicación no es posible: Las columnas de A deben ser iguales a las filas de B.");
        }

        // Creamos una nueva matriz para el resultado con filas de A y columnas de B
        double[,] resultado = new double[filasA, colB];

        // Iniciamos un bucle para recorrer cada fila de la matriz A
        for (int i = 0; i < filasA; i++)
        {
            // Iniciamos un bucle para recorrer cada columna de la matriz B
            for (int j = 0; j < colB; j++)
            {
                // Inicializamos la posición actual del resultado en 0 antes de sumar los productos
                // (Convención de claridad lógica en bucles acumulativos)
                resultado[i, j] = 0;
                
                // Iniciamos el bucle interno para recorrer las columnas de A (o filas de B)
                for (int k = 0; k < colA; k++)
                {
                    // Sumamos al acumulador el producto de los elementos correspondientes
                    // Elemento (i, k) de A por elemento (k, j) de B
                    resultado[i, j] += A[i, k] * B[k, j];
                }
            }
        }

        // Retornamos la matriz resultante con los valores multiplicados
        return resultado;
    }

    // Método Main que ejecuta el programa
    static void Main()
    {
        // Definimos una matriz A de 2x3 (2 filas, 3 columnas) con valores double
        double[,] matrizA = {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 }
        };

        // Definimos una matriz B de 2x3 (2 filas, 3 columnas) para pruebas de suma/resta
        double[,] matrizB = {
            { 6.0, 5.0, 4.0 },
            { 3.0, 2.0, 1.0 }
        };

        // Definimos una matriz C de 3x2 (3 filas, 2 columnas) para pruebas de multiplicación
        // Esto cumple la regla: columnas de A (3) == filas de C (3)
        double[,] matrizC = {
            { 1.0, 2.0 },
            { 3.0, 4.0 },
            { 5.0, 6.0 }
        };

        Console.WriteLine("=== Prueba de Suma de Matrices A (2x3) y B (2x3) ===");
        // Llamamos al método Suma con A y B
        double[,]? resultadoSuma = Suma(matrizA, matrizB);
        
        // Verificamos si el resultado no es null
        if (resultadoSuma != null)
        {
            // Imprimimos el resultado de la suma
            ImprimirMatriz(resultadoSuma, "Resultado Suma");
        }
        else
        {
            // Mensaje por si las dimensiones no coinciden (no ocurrirá en este ejemplo)
            Console.WriteLine("No se pudo sumar: Dimensiones incompatibles.");
        }

        Console.WriteLine("\n=== Prueba de Resta de Matrices A (2x3) y B (2x3) ===");
        // Llamamos al método Resta con A y B
        double[,]? resultadoResta = Resta(matrizA, matrizB);
        
        // Verificamos si el resultado no es null
        if (resultadoResta != null)
        {
            // Imprimimos el resultado de la resta
            ImprimirMatriz(resultadoResta, "Resultado Resta");
        }
        else
        {
            Console.WriteLine("No se pudo restar: Dimensiones incompatibles.");
        }

        Console.WriteLine("\n=== Prueba de Multiplicación de Matrices A(2x3) * C(3x2) ===");
        try
        {
            // Llamamos al método Multiplicacion con A y C
            // A es 2x3 y C es 3x2, el resultado será 2x2
            double[,] resultadoMult = Multiplicacion(matrizA, matrizC);
            // Imprimimos el resultado de la multiplicación
            ImprimirMatriz(resultadoMult, "Resultado Multiplicación");
        }
        catch (ArgumentException ex)
        {
            // Capturamos la excepción si las dimensiones no son válidas para multiplicar
            Console.WriteLine("Error en multiplicación: " + ex.Message);
        }

        Console.WriteLine("\n=== Prueba de Multiplicación Inválida ===");
        try
        {
            // Intentamos multiplicar A (2x3) por B (2x3)
            // Esto debería fallar porque columnas de A (3) != filas de B (2)
            double[,] resultadoInv = Multiplicacion(matrizA, matrizB);
            ImprimirMatriz(resultadoInv, "Resultado Inválido");
        }
        catch (ArgumentException ex)
        {
            // Mostramos el mensaje de error esperado
            Console.WriteLine("Error capturado (como se esperaba): " + ex.Message);
        }
    }

    // Método auxiliar para imprimir una matriz en consola de forma legible
    static void ImprimirMatriz(double[,] matriz, string titulo)
    {
        // Imprimimos el título de la sección
        Console.WriteLine(titulo + ":");
        // Obtenemos filas y columnas de la matriz recibida
        int filas = matriz.GetLength(0);
        int cols = matriz.GetLength(1);

        // Recorremos las filas
        for (int i = 0; i < filas; i++)
        {
            // Recorremos las columnas
            for (int j = 0; j < cols; j++)
            {
                // Imprimimos el elemento formateado a 2 decimales con tabulación
                Console.Write(matriz[i, j].ToString("F2") + "\t");
            }
            // Salto de línea al final de cada fila
            Console.WriteLine();
        }
    }
}

/*Nota:
Regla de Multiplicación de matrices: 
Para calcular el valor en la posición (i, j) del resultado, 
debemos tomar la fila i de la matriz A y multiplicarla 
elemento por elemento con la columna j de la matriz C, sumando los productos. 
El resultado será una matriz de 2 filas x 2 columnas.

Ejemplo de Cálculo Paso a Paso:
Para la posición (0, 0) del Resultado
Fila 0 de A vs Columna 0 de C
- Fila 0 de A: 1.0, 2.0, 3.0
- Columna 0 de C: 1.0, 3.0, 5.0 (los primeros valores de cada fila de C)
Cálculo: (1.0 * 1.0) + (2.0 * 3.0) + (3.0 * 5.0) = 1.0 + 6.0 + 15.0 = 22.0

Resumen Visual del Proceso en Código:
En bucle anidado en el método Multiplicacion del código anterior:
i (filas de A) recorre 0 y 1.
j (columnas de C) recorre 0 y 1.
k (columnas de A / filas de C) recorre 0, 1 y 2 para hacer la suma de productos.
*/
