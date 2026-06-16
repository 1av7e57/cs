/*Implementar un programa que permita al usuario ingresar números por la consola. Debe
ingresarse un número por línea finalizado el proceso cuando el usuario ingresa una línea vacía.
A medida que se van ingresando los valores el sistema debe mostrar por la consola la suma
acumulada de los mismos. Utilizar la instrucción try/catch para validar que la entrada
ingresada sea un número válido, en caso contrario advertir con un mensaje al usuario y
proseguir con el ingreso de datos.*/

using System; // Importamos el namespace System para usar clases básicas como Console y Convert

class Program // Definimos la clase principal del programa
{
    static void Main() // Definimos el método Main que es el punto de entrada del programa
    {
        double suma = 0; // Inicializamos la variable que acumulará la suma de los números ingresados

        while (true) // Iniciamos un bucle infinito que solo se romperá cuando el usuario ingrese una línea vacía
        {
            // Mostramos un mensaje pidiendo al usuario que ingrese un número
            Console.Write("Ingrese un número (o deje vacío para finalizar): ");
            string? entrada = Console.ReadLine(); // Leemos la línea ingresada por el usuario y la guardamos en la variable 'entrada'

            if (string.IsNullOrEmpty(entrada)) // Verificamos si la entrada está vacía o es null
            {
                break; // Si la entrada está vacía, salimos del bucle y terminamos el programa
            }

            try // Iniciamos el bloque try para intentar convertir la entrada a un número
            {
                double numero = Convert.ToDouble(entrada); // Intentamos convertir la cadena de texto a un número de tipo double

                suma += numero; // Si la conversión fue exitosa, sumamos el número a la variable acumuladora 'suma'
                
                // Verificamos si la suma se convirtió en infinito (o -infinito)
                if (double.IsInfinity(suma))
                {
                    // Mostramos un mensaje de advertencia al usuario
                    Console.WriteLine("Advertencia: La suma acumulada excedió el límite numérico y su valor es incorrecto.");
                    break;  // Salimos del bucle y terminamos el programa
                }
                 // Verificamos si la suma se convirtió en un valor no numérico (NaN)
                else if (double.IsNaN(suma))
                {
                    // Mostramos un mensaje de advertencia al usuario
                    Console.WriteLine("Advertencia: La suma acumulada es inválida (NaN).");
                    break; // Salimos del bucle y terminamos el programa
                }
                else
                {   
                    // De lo contrario, mostramos la suma acumulada actual en la consola
                    Console.WriteLine($"Suma acumulada: {suma}");
                }
            }
            // Capturamos la excepción si la conversión falla (es decir, si no es un número válido)
            catch (FormatException)
            {
                // Mostramos un mensaje de advertencia al usuario
                Console.WriteLine("Advertencia: La entrada no es un número válido. Por favor, intente nuevamente.");
            }
        }

        // Mostramos la suma total al finalizar el programa
        Console.WriteLine($"Programa finalizado. Suma total: {suma}");
    }
}

/*Notas:
Las operaciónes con punto flotante (double, float): 
NUNCA lanzan OverflowException por desborde aritmético simple. 
Siempre devuelven:
- Infinity (si es positivo) 
- o -Infinity (si es negativo)
- NaN (Not a Number) si la operación no tiene sentido (como 0/0).
Esto último suele ocurrir con operaciones como 0/0 o Inf - Inf.

Es por esta razón que se optó por verificar el estado de la suma 
en lugar de manejar una posible excepción de desbordamiento con 
catch (OverflowException)
*/
