/*Utilizar la clase Queue<T> para implementar un programa que realice el cifrado de un texto
aplicando la técnica de clave repetitiva. La técnica de clave repetitiva consiste en desplazar un
carácter una cantidad constante de acuerdo a la lista de valores que se encuentra en la clave. Por
ejemplo: para la siguiente tabla de caracteres:

A B C D E F G H I  J  K  L  M  N  Ñ  O  P  Q  R  S  T  U  V  W  X  Y  Z sp
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28

Si la clave es {5,3,9,7} y el mensaje a cifrar “HOLA MUNDO”
Se cifra de la siguiente manera:

 H  O  L A sp  M  U  N D  O ← Mensaje original
 8 16 12 1 28 13 22 14 4 16 ← Código sin cifrar
 5  3  9 7  5  3  9  7 5  3 ← Clave repetida
13 19 21 8  5 16  3 21 9 19 ← Código cifrado
 M  R  T H  E  O  C  T I  R ← Mensaje cifrado

A cada carácter del mensaje original se le suma la cantidad indicada en la clave. En el caso que
la suma fuese mayor que 28 se debe volver a contar desde el principio, Implementar una cola
con los números de la clave encolados y a medida que se desencolen para utilizarlos en el
cifrado, se vuelvan a encolar para su posterior utilización. Programar un método para cifrar y
otro para descifrar.
*/

// Importamos el namespace System para tener acceso a las clases base como Console, String, etc.
using System;
// Importamos el namespace System.Collections.Generic para utilizar la clase Queue<T>
using System.Collections.Generic;

// Clase principal del programa
class Program
{
    // Método principal de entrada del programa
    static void Main(string[] args)
    {
        // Definimos la clave repetitiva como un arreglo de enteros (fija para este ejemplo)
        int[] clave = { 5, 3, 9, 7 };

        // Mostramos un título para que el usuario sepa qué hace el programa
        Console.WriteLine("=== Cifrador de Texto con Clave Repetitiva ===");
        Console.WriteLine("Clave utilizada: {5, 3, 9, 7}");
        Console.WriteLine(""); // Línea en blanco para separar

        // Solicitamos al usuario que ingrese la opción
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1. Cifrar un mensaje");
        Console.WriteLine("2. Descifrar un mensaje");

        // Leemos la opción del usuario
        string? opcion = Console.ReadLine();

        // Variable para almacenar el resultado
        string resultado = "";

        // Verificamos la opción seleccionada
        if (opcion == "1")
        {
            // Pedimos al usuario que ingrese el mensaje a cifrar
            Console.Write("Ingrese el mensaje a cifrar: ");
            // Leemos la línea completa ingresada por el usuario
            string? mensajeOriginal = Console.ReadLine();

            // Validamos que el usuario haya escrito algo
            if (string.IsNullOrWhiteSpace(mensajeOriginal))
            {
                Console.WriteLine("No se ingresó ningún mensaje. El programa finalizará.");
                Console.ReadKey();
                return; // Termina el programa aquí
            }

            // Llamamos al método de cifrado pasando el mensaje del usuario y la clave
            resultado = CifrarMensaje(mensajeOriginal, clave);

            // Mostramos el mensaje cifrado en consola
            Console.WriteLine(""); // Línea en blanco
            Console.WriteLine("Mensaje original: " + mensajeOriginal);
            Console.WriteLine("Mensaje cifrado:  " + resultado);
        }
        else if (opcion == "2")
        {
            // Pedimos al usuario el mensaje cifrado para demostrar el descifrado
            Console.Write("Ingrese el mensaje cifrado a descifrar: ");
            string? mensajeCifrado = Console.ReadLine();

            // Validamos que el usuario haya escrito algo
            if (string.IsNullOrWhiteSpace(mensajeCifrado))
            {
                Console.WriteLine("No se ingresó ningún mensaje. El programa finalizará.");
                Console.ReadKey();
                return; // Termina el programa aquí
            }

            // Llamamos al método de descifrado pasando el mensaje cifrado y la clave
            resultado = DescifrarMensaje(mensajeCifrado, clave);

            // Mostramos el mensaje descifrado en consola
            Console.WriteLine(""); // Línea en blanco
            Console.WriteLine("Mensaje cifrado:  " + mensajeCifrado);
            Console.WriteLine("Mensaje original: " + resultado);
        }
        else
        {
            // Mensaje de error si la opción no es válida
            Console.WriteLine("Opción no válida. Ingrese 1 o 2.");
        }

        // Pausa la consola para que el usuario pueda ver el resultado antes de que se cierre
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }

    // Método para cifrar un mensaje utilizando la clave repetitiva
    static string CifrarMensaje(string mensaje, int[] clave)
    {
        // Creamos una cola genérica de enteros y la inicializamos con los valores de la clave
        Queue<int> colaClave = new Queue<int>(clave);
        
        // Creamos un StringBuilder para construir el mensaje cifrado eficientemente
        System.Text.StringBuilder mensajeCifrado = new System.Text.StringBuilder();

        // Recorremos cada carácter del mensaje original
        foreach (char caracter in mensaje)
        {
            // Obtenemos el valor numérico del carácter actual según la tabla (A=1, ..., sp=28)
            int valorCaracter = ObtenerValor(caracter);

            // Si el carácter no está en la tabla (ej. puntos, comas), lo dejamos tal cual
            if (valorCaracter == 0)
            {
                // Agregamos el carácter sin cambios al resultado
                mensajeCifrado.Append(caracter);
                // Continuamos al siguiente carácter sin usar la clave
                continue;
            }

            // Sacamos el primer valor de la cola para usarlo en este carácter
            int valorClave = colaClave.Dequeue();

            // Calculamos la suma del valor del carácter más el valor de la clave
            int suma = valorCaracter + valorClave;

            // Si la suma es mayor a 28, aplicamos el módulo para volver al inicio del ciclo
            // Nota: usamos ((suma - 1) % 28) + 1 para mantener el rango 1-28 correctamente
            int valorCifrado = (suma > 28) ? ((suma - 1) % 28) + 1 : suma;

            // Convertimos el valor numérico cifrado de nuevo a carácter
            char caracterCifrado = ObtenerCaracter(valorCifrado);

            // Agregamos el carácter cifrado al resultado
            mensajeCifrado.Append(caracterCifrado);

            // Volvemos a encolar el valor de la clave para su uso en el siguiente carácter
            colaClave.Enqueue(valorClave);
        }

        // Convertimos el StringBuilder a string y lo retornamos
        return mensajeCifrado.ToString();
    }

    // Método para descifrar un mensaje utilizando la clave repetitiva
    static string DescifrarMensaje(string mensajeCifrado, int[] clave)
    {
        // Creamos una cola genérica de enteros e inicializamos con la clave
        Queue<int> colaClave = new Queue<int>(clave);
        
        // Creamos un StringBuilder para construir el mensaje descifrado
        System.Text.StringBuilder mensajeDescifrado = new System.Text.StringBuilder();

        // Recorremos cada carácter del mensaje cifrado
        foreach (char caracter in mensajeCifrado)
        {
            // Obtenemos el valor numérico del carácter cifrado
            int valorCaracter = ObtenerValor(caracter);

            // Si el carácter no está en la tabla, lo dejamos tal cual
            if (valorCaracter == 0)
            {
                // Agregamos el carácter sin cambios al resultado
                mensajeDescifrado.Append(caracter);
                // Continuamos al siguiente carácter
                continue;
            }

            // Sacamos el primer valor de la cola para usarlo en este carácter
            int valorClave = colaClave.Dequeue();

            // Calculamos la resta: valor cifrado menos la clave
            int resta = valorCaracter - valorClave;

            // Si la resta es menor o igual a 0, sumamos 28 para volver al final del ciclo
            // Esto maneja el caso de "bucle" inverso (ej. 1 - 5 = -4 -> 24)
            int valorDescifrado = (resta <= 0) ? resta + 28 : resta;

            // Convertimos el valor numérico descifrado de nuevo a carácter
            char caracterDescifrado = ObtenerCaracter(valorDescifrado);

            // Agregamos el carácter descifrado al resultado
            mensajeDescifrado.Append(caracterDescifrado);

            // Volvemos a encolar el valor de la clave para su uso en el siguiente carácter
            colaClave.Enqueue(valorClave);
        }

        // Convertimos el StringBuilder a string y lo retornamos
        return mensajeDescifrado.ToString();
    }

    // Método auxiliar para obtener el valor numérico de un carácter según la tabla definida
    static int ObtenerValor(char c)
    {
        // Convertimos el carácter a mayúscula para facilitar la comparación
        char cMayus = char.ToUpper(c);

        // Definimos la cadena con todos los caracteres válidos en orden
        string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ";

        // Buscamos la posición del carácter en la cadena (el índice empieza en 0)
        int indice = abecedario.IndexOf(cMayus);

        // Si el carácter no se encuentra, retornamos 0
        if (indice == -1) return 0;

        // Retornamos el índice + 1 (ya que la tabla empieza en 1, no en 0)
        return indice + 1;
    }

    // Método auxiliar para obtener el carácter correspondiente a un valor numérico
    static char ObtenerCaracter(int valor)
    {
        // Ajustamos el valor para que esté en el rango 1-28
        // Si el valor es 0 o negativo (por errores de lógica), lo normalizamos
        if (valor <= 0) valor = (valor % 28);
        if (valor == 0) valor = 28;
        if (valor > 28) valor = (valor - 1) % 28 + 1;

        // Definimos la cadena con todos los caracteres válidos en orden
        string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ";

        // Retornamos el carácter en la posición correspondiente (índice = valor - 1)
        return abecedario[valor - 1];
    }
}
