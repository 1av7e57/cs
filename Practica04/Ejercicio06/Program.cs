/*Implementar la clase Matriz que se utilizará para trabajar con matrices matemáticas. Implementar los dos
constructores y todos los métodos que se detallan a continuación:
public Matriz(int filas, int columnas)
public Matriz(double[,] matriz)
public void SetElemento(int fila, int columna, double elemento)
public double GetElemento(int fila, int columna)
public void imprimir()
public void imprimir(string formatString)
public double[] GetFila(int fila)
public double[] GetColumna(int columna)
public double[] GetDiagonalPrincipal()
public double[] GetDiagonalSecundaria()
public double[][] getArregloDeArreglo()
public void sumarle(Matriz m)
public void restarle(Matriz m)
public void multiplicarPor(Matriz m)*/
using System; // Importa la biblioteca base de .NET para operaciones básicas

// Define la clase Matriz que encapsula la lógica de matrices matemáticas
public class Matriz
{
    // Campo privado para almacenar los datos numéricos en una matriz bidimensional
    private double[,] datos;

    // Propiedad pública de solo lectura para obtener el número de filas
    public int Filas { get; private set; }
    // Propiedad pública de solo lectura para obtener el número de columnas
    public int Columnas { get; private set; }

    // Constructor 1: Crea una nueva matriz con dimensiones dadas
    public Matriz(int filas, int columnas)
    {
        // Valida que las dimensiones sean positivas
        if (filas <= 0 || columnas <= 0)
            // Lanza una excepción si los valores son inválidos
            throw new ArgumentException("Las dimensiones deben ser mayores a 0.");

        // Asigna los valores de filas y columnas a las propiedades
        Filas = filas;
        Columnas = columnas;
        // Inicializa el arreglo bidimensional con los tamaños especificados
        datos = new double[filas, columnas];
    }

    // Constructor 2: Crea una matriz copiando los datos de un arreglo existente
    public Matriz(double[,] matriz)
    {
        // Valida que el arreglo de entrada no sea nulo
        if (matriz == null)
            // Lanza excepción si se pasa un valor nulo
            throw new ArgumentNullException(nameof(matriz));

        // Cada índice pasado a GetLength representa una dimensión del arreglo, no una posición específica.
        // 0 representa la primera dimensión: que en matrices matemáticas corresponde a las Filas.
        // 1 representa la segunda dimensión: que en matrices matemáticas corresponde a las Columnas.

        // Obtiene el número de filas del arreglo de entrada
        Filas = matriz.GetLength(0);
        // Obtiene el número de columnas del arreglo de entrada
        Columnas = matriz.GetLength(1);

        // Crea una nueva matriz interna con las dimensiones obtenidas
        datos = new double[Filas, Columnas];
        // Recorre todas las filas
        for (int i = 0; i < Filas; i++)
            // Recorre todas las columnas
            for (int j = 0; j < Columnas; j++)
                // Copia el valor del arreglo externo al interno
                datos[i, j] = matriz[i, j];
    }

    // --- Métodos Principales ---

    // Método para establecer un valor en una posición específica
    public void SetElemento(int fila, int columna, double elemento)
    {
        // Valida que los índices de fila y columna sean correctos
        ValidarIndices(fila, columna);
        // Asigna el valor al arreglo interno en la posición indicada
        datos[fila, columna] = elemento;
    }

    // Método para obtener un valor de una posición específica
    public double GetElemento(int fila, int columna)
    {
        // Valida que los índices sean correctos
        ValidarIndices(fila, columna);
        // Retorna el valor almacenado en esa posición
        return datos[fila, columna];
    }

    // Método SOBRECARGADO para imprimir la matriz SIN formato específico
    // El código está redirigiendo la ejecución al otro método: Imprimir(string? formatString).
    // Pero pasa null como argumento de formato
    public void Imprimir()
    {
        // Llama al método de impresión pasando null para usar el formato por defecto
        Imprimir(null);
    }

    // Método para imprimir la matriz con un formato de texto específico
    public void Imprimir(string? formatString)
    {
        // Recorre cada fila de la matriz
        for (int i = 0; i < Filas; i++)
        {
            // Recorre cada columna de la fila actual
            for (int j = 0; j < Columnas; j++)
            {
                string valorTexto; // Variable para almacenar el valor como texto

                // Verifica si se pasó un formato de texto
                if (formatString != null)
                {
                    // Convierte el número a texto usando el formato especificado (ej: "F0", "F2")
                    valorTexto = datos[i, j].ToString(formatString);
                }
                else
                {
                    // Convierte el número a texto usando el formato por defecto
                    valorTexto = datos[i, j].ToString();
                }

                // Imprime el valor seguido de un espacio en la misma línea
                Console.Write($"{valorTexto} ");
            }
            // Salta a la siguiente línea al terminar la fila
            Console.WriteLine();
        }
    }

    // Método para obtener una fila completa como un arreglo unidimensional
    public double[] GetFila(int fila)
    {
        // Valida que el índice de la fila sea correcto
        ValidarFila(fila);
        // Crea un nuevo arreglo del tamaño del número de columnas
        double[] filaArray = new double[Columnas];
        // Recorre cada columna de la fila especificada
        for (int j = 0; j < Columnas; j++)
        {
            // Copia el valor de la matriz a la nueva fila
            filaArray[j] = datos[fila, j];
        }
        // Retorna el arreglo con los valores de la fila
        return filaArray;
    }

    // Método para obtener una columna completa como un arreglo unidimensional
    public double[] GetColumna(int columna)
    {
        // Valida que el índice de la columna sea correcto
        ValidarColumna(columna);
        // Crea un nuevo arreglo del tamaño del número de filas
        double[] columnaArray = new double[Filas];
        // Recorre cada fila de la columna especificada
        for (int i = 0; i < Filas; i++)
        {
            // Copia el valor de la matriz a la nueva columna
            columnaArray[i] = datos[i, columna];
        }
        // Retorna el arreglo con los valores de la columna
        return columnaArray;
    }

    // Método para obtener la diagonal principal (de esquina superior izquierda a inferior derecha)
    public double[] GetDiagonalPrincipal()
    {
        // Valida que la matriz sea cuadrada (misma cantidad de filas y columnas)
        if (Filas != Columnas)
            // Lanza excepción si no es cuadrada
            throw new InvalidOperationException("La matriz debe ser cuadrada para obtener la diagonal principal.");

        // Crea un arreglo para almacenar los valores de la diagonal
        double[] diagonal = new double[Filas];
        // Recorre la matriz donde el índice de fila es igual al de columna
        for (int i = 0; i < Filas; i++)
        {
            // Guarda el valor en la posición (i, i)
            diagonal[i] = datos[i, i];
        }
        // Retorna el arreglo con la diagonal principal
        return diagonal;
    }

    // Método para obtener la diagonal secundaria (de esquina superior derecha a inferior izquierda)
    public double[] GetDiagonalSecundaria()
    {
        // Valida que la matriz sea cuadrada
        if (Filas != Columnas)
            // Lanza excepción si no es cuadrada
            throw new InvalidOperationException("La matriz debe ser cuadrada para obtener la diagonal secundaria.");

        // Crea un arreglo para almacenar los valores de la diagonal
        double[] diagonal = new double[Filas];
        // Recorre la matriz calculando el índice de columna inverso
        for (int i = 0; i < Filas; i++)
        {
            // Guarda el valor en la posición (i, Filas - 1 - i)
            diagonal[i] = datos[i, Filas - 1 - i];
        }
        // Retorna el arreglo con la diagonal secundaria
        return diagonal;
    }

    // Método para convertir la matriz interna a un arreglo de arreglos (estructura "jagged")
    public double[][] GetArregloDeArreglo()
    {
        // Crea un arreglo de arreglos del tamaño de las filas
        double[][] jaggedArray = new double[Filas][];
        // Recorre cada fila
        for (int i = 0; i < Filas; i++)
        {
            // Inicializa el arreglo interno para la fila actual
            jaggedArray[i] = new double[Columnas];
            // Recorre cada columna
            for (int j = 0; j < Columnas; j++)
            {
                // Copia el valor de la matriz a la estructura de arreglo de arreglos
                jaggedArray[i][j] = datos[i, j];
            }
        }
        // Retorna el arreglo de arreglos convertido
        return jaggedArray;
    }

    // Método para sumar otra matriz a esta (modificando el contenido actual)
    public void Sumarle(Matriz m)
    {
        // Valida que la matriz a sumar no sea nula y tenga las mismas dimensiones
        if (m == null || m.Filas != Filas || m.Columnas != Columnas)
            // Lanza excepción si las dimensiones no coinciden
            throw new ArgumentException("Las matrices deben tener las mismas dimensiones para sumar.");

        // Recorre cada fila
        for (int i = 0; i < Filas; i++)
        {
            // Recorre cada columna
            for (int j = 0; j < Columnas; j++)
            {
                // Suma el valor de la matriz externa al valor interno
                datos[i, j] += m.datos[i, j];
            }
        }
    }

    // Método para restar otra matriz a esta (modificando el contenido actual)
    public void Restarle(Matriz m)
    {
        // Valida que la matriz a restar no sea nula y tenga las mismas dimensiones
        if (m == null || m.Filas != Filas || m.Columnas != Columnas)
            // Lanza excepción si las dimensiones no coinciden
            throw new ArgumentException("Las matrices deben tener las mismas dimensiones para restar.");

        // Recorre cada fila
        for (int i = 0; i < Filas; i++)
        {
            // Recorre cada columna
            for (int j = 0; j < Columnas; j++)
            {
                // Resta el valor de la matriz externa al valor interno
                datos[i, j] -= m.datos[i, j];
            }
        }
    }

    // Método para multiplicar esta matriz por otra (modificando el contenido actual)
    public void MultiplicarPor(Matriz m)
    {
        // Valida que la matriz a multiplicar no sea nula
        if (m == null)
            // Lanza excepción si es nula
            throw new ArgumentNullException(nameof(m));

        // Valida que las columnas de esta matriz coincidan con las filas de la otra
        if (this.Columnas != m.Filas)
            // Lanza excepción si las dimensiones no permiten multiplicación
            throw new InvalidOperationException($"No se pueden multiplicar: Columnas de esta matriz ({this.Columnas}) no coinciden con Filas de la otra ({m.Filas}).");

        // Define el número de filas del resultado (filas de esta matriz)
        int filasResultado = this.Filas;
        // Define el número de columnas del resultado (columnas de la otra matriz)
        int columnasResultado = m.Columnas;

        // Crea una nueva matriz interna para almacenar el resultado
        double[,] nuevoDatos = new double[filasResultado, columnasResultado];

        // Recorre cada fila del resultado
        for (int i = 0; i < filasResultado; i++)
        {
            // Recorre cada columna del resultado
            for (int j = 0; j < columnasResultado; j++)
            {
                double suma = 0; // Variable acumuladora para el producto punto
                // Recorre la dimensión común (columnas de esta / filas de la otra)
                for (int k = 0; k < this.Columnas; k++)
                {
                    // Suma el producto de los elementos correspondientes
                    suma += this.datos[i, k] * m.datos[k, j];
                }
                // Guarda el resultado calculado en la nueva matriz
                nuevoDatos[i, j] = suma;
            }
        }

        // Reemplaza el arreglo interno con el nuevo resultado
        datos = nuevoDatos;
        // Actualiza la propiedad de columnas al nuevo tamaño
        Columnas = columnasResultado;
    }

    // --- Métodos auxiliares ---

    // Método privado auxiliar para validar índices de fila y columna
    private void ValidarIndices(int fila, int columna)
    {
        // Valida que la fila no sea negativa ni mayor o igual al total de filas
        if (fila < 0 || fila >= Filas)
            // Lanza excepción si la fila está fuera de rango
            throw new IndexOutOfRangeException($"Fila {fila} fuera de rango. Debe estar entre 0 y {Filas - 1}.");
        // Valida que la columna no sea negativa ni mayor o igual al total de columnas
        if (columna < 0 || columna >= Columnas)
            // Lanza excepción si la columna está fuera de rango
            throw new IndexOutOfRangeException($"Columna {columna} fuera de rango. Debe estar entre 0 y {Columnas - 1}.");
    }

    // Método privado auxiliar para validar solo el índice de fila
    private void ValidarFila(int fila)
    {
        // Valida que la fila esté dentro del rango permitido
        if (fila < 0 || fila >= Filas)
            // Lanza excepción si la fila está fuera de rango
            throw new IndexOutOfRangeException($"Fila {fila} fuera de rango. Debe estar entre 0 y {Filas - 1}.");
    }

    // Método privado auxiliar para validar solo el índice de columna
    private void ValidarColumna(int columna)
    {
        // Valida que la columna esté dentro del rango permitido
        if (columna < 0 || columna >= Columnas)
            // Lanza excepción si la columna está fuera de rango
            throw new IndexOutOfRangeException($"Columna {columna} fuera de rango. Debe estar entre 0 y {Columnas - 1}.");
    }
}

// --- Inicio del Programa --- 


class Program // Clase principal, punto de entrada del programa
{
    static void Main() // Método principal, donde comienza la ejecución del programa
    {
        // --- Creación de de matrices ---

        // Crea una nueva instancia de Matriz de 2x2
        // Establece los valores en cada posición
        var m1 = new Matriz(2, 2);
        m1.SetElemento(0, 0, 1);
        m1.SetElemento(0, 1, 2);
        m1.SetElemento(1, 0, 3);
        m1.SetElemento(1, 1, 4);

        // Crea una nueva instancia de Matriz de 2x2
        // Establece los valores en cada posición
        var m2 = new Matriz(2, 2);
        m2.SetElemento(0, 0, 5);
        m2.SetElemento(0, 1, 6);
        m2.SetElemento(1, 0, 7);
        m2.SetElemento(1, 1, 8);

        // Imprime las matrices m1 y m2 con formato de 0 decimales
        Console.WriteLine("Matriz 1 (2x2):");
        m1.Imprimir("F0");
        Console.WriteLine("\nMatriz 2 (2x2):");
        m2.Imprimir("F0");

        // --- Prueba de suma, resta y multiplicación de matrices 1 y 2 ---

        // Imprime un encabezado en consola
        Console.WriteLine("\n--- Prueba de suma, resta y multiplicación de matrices ---");

        //Suma (m1 + m2):
        //Resultado esperado: 6 8 / 10 12

        m1.Sumarle(m2);
        Console.WriteLine("\nMatriz 1 + Matriz 2:");
        m1.Imprimir("F0");

        // Resta (m1actual - m2):
        // Como m1 ya fue modificada por la suma, ahora restamos m2 a ese resultado.
        // Esto debería devolvernos la matriz original de m1 (1, 2, 3, 4).
        // Resultado esperado: 1 2 / 3 4

        m1.Restarle(m2);
        Console.WriteLine("\nMatriz 1 - Matriz 2:");
        m1.Imprimir("F0");

        // Multiplicación (m1actual * m2):
        // En este punto, m1 vuelvió a ser la matriz original {1, 2, 3, 4}.
        // Resultado esperado: 19 22 / 43 50

        m1.MultiplicarPor(m2);
        Console.WriteLine("\nMatriz 1 * Matriz 2:");
        m1.Imprimir("F0");

        // --- Prueba de obtención de diagonales --- 

        // 1. Crear una matriz cuadrada 3x3
        // Usamos un arreglo bidimensional para inicializarla
        double[,] datos = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };
        // Crea una nueva instancia de Matriz usando el arreglo de datos
        Matriz m = new Matriz(datos);

        // Imprime un encabezado
        Console.WriteLine("\n--- Prueba de obtención de diagonales ---:");
        Console.WriteLine("Matriz 3 (3x3) CUADRADA:");
        m.Imprimir("F0"); // F0 para mostrar enteros sin decimales

        // 2. Probar Diagonal Principal
        // Esperado: [1, 5, 9] (de arriba-izquierda a abajo-derecha)
        double[] diagonalPrincipal = m.GetDiagonalPrincipal();
        Console.WriteLine("\nDiagonal Principal:");
        ImprimirArreglo(diagonalPrincipal);

        // 3. Probar Diagonal Secundaria
        // Esperado: [3, 5, 7] (de arriba-derecha a abajo-izquierda)
        double[] diagonalSecundaria = m.GetDiagonalSecundaria();
        Console.WriteLine("\nDiagonal Secundaria:");
        ImprimirArreglo(diagonalSecundaria);

        // 4. Prueba de Error
        // Intentar obtener diagonal de una matriz NO cuadrada
        Console.WriteLine("\n--- Probando error con matriz no cuadrada ---");
        try
        {
            // Crea una matriz de 2 filas y 3 columnas (NO cuadrada)
            Matriz noCuadrada = new Matriz(2, 3); // 2 filas, 3 columnas
            // Establece los valores en cada posición
            noCuadrada.SetElemento(0, 0, 1);
            noCuadrada.SetElemento(0, 1, 2);
            noCuadrada.SetElemento(0, 2, 3);
            noCuadrada.SetElemento(1, 0, 4);
            noCuadrada.SetElemento(1, 1, 5);
            noCuadrada.SetElemento(1, 2, 6);

            // Imprime la matriz No cuadrada con un encabezado
            Console.WriteLine("Matriz 4 (2X3) NO Cuadrada(!):");
            noCuadrada.Imprimir("F0");

            // Intenta obtener la diagonal principal de la matriz No cuadrada
            // Esto debería lanzar una excepción
            noCuadrada.GetDiagonalPrincipal();
        }
        catch (InvalidOperationException ex)
        {
            // Captura la excepción lanzada y muestra el mensaje de error
            Console.WriteLine($"Excepción capturada correctamente: {ex.Message}");
        }
    }

    // --- Métodos Auxiliares ---

    // Método auxiliar estático para imprimir arreglos unidimensionales de forma legible
    static void ImprimirArreglo(double[] arr)
    {
        // Imprime el caractér de apertura de arreglo
        Console.Write("[");
        // Recorre cada elemento del arreglo
        for (int i = 0; i < arr.Length; i++)
        {
            // Imprime el valor del elemento actual
            Console.Write($"{arr[i]}");
            // Si no es el último elemento, imprime una coma y un espacio
            if (i < arr.Length - 1) Console.Write(", ");
        }
        // Imprime el caractér de cierre de arreglo y salta a la siguiente línea
        Console.WriteLine("]");
    }
}

/*Notas: 
Desglose de Operaciónes Matemáticas (Suma, Resta, Multiplicación)

Suma (m1 + m2):
(1+5, 2+6) = (6, 8) y (3+7, 4+8) = (10, 12).
Resultado: 
6  8 
10 12.

Resta ((m1+m2) - m2):
Como m1 ya fue modificada por la suma, ahora restamos m2 a ese resultado.
Esto debería devolvernos la matriz original de m1 (1, 2, 3, 4).
(6-5, 8-6) = (1, 2) y (10-7, 12-8) = (3, 4).
Resultado: 
1 2 
3 4.

Multiplicación ((m1Actual) * m2):
En este punto, m1 volvió a ser la matriz original {1, 2, 3, 4}.
Multiplicamos {1, 2, 3, 4} por {5, 6, 7, 8}.
Cálculos:
1*5 + 2*7 = 19
1*6 + 2*8 = 22
3*5 + 4*7 = 43
3*6 + 4*8 = 50
Resultado: 
19 22 
43 50.
*/
