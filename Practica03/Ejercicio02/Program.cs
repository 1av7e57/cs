/*Implementar el método ImprimirMatrizConFormato, similar al anterior pero ahora con un
parámetro más que representa la plantilla de formato que debe aplicarse a los números al
imprimirse. La plantilla de formato es un string de acuerdo a las convenciones de formato
compuesto, por ejemplo “0.0” implica escribir los valores reales con un dígito para la parte
decimal.

void ImprimirMatrizConFormato(double[,] matriz, string formatString)*/

using System; // Importamos el namespace System para usar la clase Console y utilidades de formato

class Program // Definimos la clase principal del programa
{
    // Método original para imprimir la matriz sin formato específico (usa el formato por defecto)
    static void ImprimirMatriz(double[,] matriz)
    {
        // Obtenemos la longitud de la primera dimensión (número de filas)
        int filas = matriz.GetLength(0);
        
        // Obtenemos la longitud de la segunda dimensión (número de columnas)
        int columnas = matriz.GetLength(1);
        
        // Iniciamos un bucle que recorre cada fila de la matriz desde el índice 0 hasta filas-1 
        // (ajuste para compatibilizar con indices numerados desde 0)
        for (int i = 0; i < filas; i++)
        {
            // Iniciamos un bucle que recorre cada columna de la matriz desde el índice 0 hasta columnas-1 
            // (ajuste para compatibilizar con indices numerados desde 0)
            for (int j = 0; j < columnas; j++)
            {
                // Imprimimos el elemento actual con un espacio después, sin saltar de línea
                Console.Write(matriz[i, j] + " ");
            }
            
            // Solo cuando terminamos de recorrer todas las columnas de una fila (fuera del bucle interno), 
            // damos un salto de línea para empezar a imprimir la siguiente fila.
            Console.WriteLine();
        }
    }

    // Nuevo método que recibe la matriz y una plantilla de formato (ej: "0.0", "0.00", "0.000")
    static void ImprimirMatrizConFormato(double[,] matriz, string formatString)
    {
        // Obtenemos la longitud de la primera dimensión (número de filas)
        int filas = matriz.GetLength(0);
        
        // Obtenemos la longitud de la segunda dimensión (número de columnas)
        int columnas = matriz.GetLength(1);
        
        // Iniciamos un bucle que recorre cada fila de la matriz desde el índice 0 hasta filas-1 
        // (ajuste para compatibilizar con indices numerados desde 0)
        for (int i = 0; i < filas; i++)
        {
            // Iniciamos un bucle que recorre cada columna de la matriz desde el índice 0 hasta columnas-1 
            // (ajuste para compatibilizar con indices numerados desde 0)
            for (int j = 0; j < columnas; j++)
            {
                // Usamos formato compuesto: {0:plantilla}
                // 'matriz[i, j]' es el valor, y 'formatString' es la plantilla (ej: "0.00")
                // '{0}' se refiere al primer argumento (el valor del número)
                // ':0.0' se refiere al formato que se le aplica a ese valor
                Console.Write("{0:" + formatString + "} ", matriz[i, j]);
            }
            
            // Solo cuando terminamos de recorrer todas las columnas de una fila (fuera del bucle interno), 
            // damos un salto de línea para empezar a imprimir la siguiente fila.
            Console.WriteLine();
        }
    }

    // Método principal que se ejecuta al iniciar el programa
    static void Main()
    {
        // Creamos una matriz bidimensional de 3 filas y 4 columnas con valores decimales
        double[,] miMatriz = { 
            { 1.5, 2.3, 3.1, 4.7 }, 
            { 5.2, 6.8, 7.4, 8.9 }, 
            { 9.0, 10.5, 11.2, 12.6 } 
        };
        
        // Definimos la plantilla de formato: "0.00" significa mostrar siempre 2 decimales
        string plantilla = "0.00";
        
        Console.WriteLine("Matriz original (formato predeterminado):");
        // Llamamos al método original para ver cómo se ve por defecto
        ImprimirMatriz(miMatriz);
        
        Console.WriteLine("\nMatriz con formato específico (plantilla '" + plantilla + "'):");
        // Llamamos al nuevo método pasando la matriz y la plantilla de formato
        ImprimirMatrizConFormato(miMatriz, plantilla);
        
    }
}

/*Nota: aclaraciónes de sintaxis
Console.Write("{0:" + formatString + "} ", matriz[i, j]);

En C#, todo texto a imprimir debe estar entre comillas dobles (" ")
- El primer set "{0:" Empieza la cadena literal con el texto {0:
- El segundo set "} ": Es una cadena literal que contiene solo un espacio y la llave de cierre }
- Entre esos dos sets de comillas, no hay texto, sino una variable (formatString).

El operador de Concatenación '+'
El operador + une (concatena) tres partes para formar una sola cadena de texto 
antes de enviarla a Console.Write:
- Parte 1 (Literal): "{0:"
Es el texto fijo que indica "aquí va el primer argumento, formateado con...".
- Parte 2 (Variable): formatString
Aquí se inserta el contenido de la variable. Si formatString vale "0.00", esto se convierte en 0.00.
- Parte 3 (Literal): "} "
Es el cierre de la sintaxis de formato (}) seguido de un espacio para separar los números en la consola.

Resultado de la concatenación: 
Si formatString es "0.00", lo que realmente le llega a Console.Write como primer argumento 
es la cadena: "{0:0.00} "

¿Qué hace Console.Write con esa cadena?
Console.Write tiene una sobrecarga especial que recibe:
- Un string de formato (donde aparecen {0}, {1}, etc.).
- Los argumentos que deben insertarse en esos huecos.
En la línea: Console.Write("{0:" + formatString + "} ", matriz[i, j]);
- Argumento 1 (El formato): "{0:0.0} " (el resultado de unir las partes).
- Argumento 2 (El valor): matriz[i, j] (el número a imprimir).
Console.Write ve el {0} en el primer argumento y dice: "El primer valor que debo formatear 
es el número que viene después de la coma". Luego aplica la regla 0.0 a ese número.

Resumen visual del proceso
Asumiendo que formatString = "0.00" y matriz[i, j] = 9.0.
- Código: "{0:" + "0.00" + "} "
- Ejecución de concatenación: Se crea la cadena "{0:0.00} ".
- Llamada a Console.Write
    Console.Write("{0:0.0} ", 9.0);
- Interpretación interna:
    Busca {0}.
    Toma el valor 9.0.
    Aplica el formato 0.00 (un cero obligatorio antes del punto y dos después).
    Imprime: 9.00.
*/
