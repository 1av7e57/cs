
// Importa el namespace System para acceder a clases básicas como Console y Exception
using System;

// Define la clase principal del programa
class Programa
{
    // Define el método de entrada principal donde comienza la ejecución
    static void Main()
    {
        // Declara una variable de tipo string para almacenar temporalmente la entrada del usuario
        // Se usa ? para indicar que la entrada puede estar vacía (null)
        string? st;

        // Declara una variable de tipo entero para guardar el número válido una vez convertido
        int numero;

        // Muestra un mensaje inicial pidiendo al usuario que ingrese un número entero
        Console.WriteLine("Ingresa un número entero válido:");

        // Inicia un bucle infinito que solo se detendrá cuando se ingrese un número válido
        while (true)
        {
            // Lee la línea de texto ingresada por el usuario y la guarda en la variable 'st'
            st = Console.ReadLine();

            // Inicia un bloque de código donde se pueden lanzar excepciones (errores controlados)
            try
            {
                // Intenta convertir el texto de 'st' a un entero usando int.Parse
                // Si 'st' no es un número válido, este paso lanzará una excepción
                // Se usa ! para evitar la advertencia del compilador sobre null, confiando en el catch
                numero = int.Parse(st!);

                // Si la conversión fue exitosa, salimos del bucle infinito usando 'break'
                break;
            }
            // Captura cualquier excepción que sea una excepción de formato (texto no numérico) o desbordamiento
            catch (Exception)
            {
                // Muestra un mensaje de error indicando que la entrada no fue válida
                Console.WriteLine("Entrada inválida. Por favor, ingresa solo números enteros (sin letras ni decimales):");

                // El bucle continúa automáticamente, volviendo a pedir la entrada al usuario
            }
        }

        // Una vez fuera del bucle, 'numero' contiene un entero válido ingresado por el usuario
        // Muestra un mensaje indicando qué número se va a procesar
        Console.WriteLine($"Los divisores de {numero} son:");

        // Inicia un bucle for que recorre desde 1 hasta el número ingresado inclusive
        for (int i = 1; i <= numero; i++)
        {
            // Verifica si el residuo de la división entre 'numero' e 'i' es igual a cero
            // El operador '%' devuelve el residuo de una división entera
            if (numero % i == 0)
            {
                // Si el residuo es 0, significa que 'i' es un divisor, así que lo imprimimos
                // Seguido de un espacio en blanco para mayor legibilidad
                Console.Write(i + " ");
            }
        }

        // Imprime un salto de línea al final para separar la lista de la siguiente salida
        Console.WriteLine();

        // Muestra un mensaje indicando que el programa terminará y espera una tecla
        Console.WriteLine("Presiona cualquier tecla para salir...");

        // Detiene la ejecución del programa hasta que el usuario presione una tecla
        Console.ReadKey();
    }
}
