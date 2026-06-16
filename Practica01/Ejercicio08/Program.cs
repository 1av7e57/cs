/*Escribir un programa que lea dos palabras separadas por un blanco que terminan con <ENTER>,
y determinar si son simétricas (Ej: 'abbccd' y 'dccbba' son simétricas).
Tip: si st es un string, entonces st[0] devuelve el primer carácter de st, y st[st.Length-1] devuelve el último carácter de st.
*/

// Importar el namespace System para acceder a clases básicas como Console y String
using System;

// Clase principal donde se ejecuta el código
class Program
{
    // El método Main es el punto de entrada del programa
    static void Main()
    {
        // Declarar una variable de tipo string llamada 'entrada' para guardar lo que el usuario escriba
        // Se usa ? para evitar error en caso de vacío (null)
        string? entrada;

        // Mostrar un mensaje en la consola pidiendo al usuario que ingrese dos palabras separadas por un espacio
        Console.WriteLine("Ingrese dos palabras separadas por un espacio:");

        // Leer la línea completa ingresada por el usuario hasta que presione <ENTER> y asignarla a la variable 'entrada'
        entrada = Console.ReadLine();

        // Dividir la cadena 'entrada' en una matriz de palabras usando el espacio en blanco como separador
        // El método Split devuelve un array de strings con cada palabra encontrada
        // Se usa ! en caso de que el string sea nulo
        string[] palabras = entrada!.Split(' ');

        // Verificar si el usuario ingresó exactamente dos palabras (el array debe tener longitud 2)
        if (palabras.Length == 2)
        {
            // Asignar la primera palabra a una variable llamada 'st'
            string st = palabras[0];

            // Asignar la segunda palabra a una variable llamada 'st2' para comparar con la primera
            string st2 = palabras[1];

            // Declarar una variable booleana 'esSimetrica' e inicializarla en true, asumiendo que son simétricas hasta probar lo contrario
            bool esSimetrica = true;

            // Verificar si las longitudes de ambas palabras son diferentes, si es así no pueden ser simétricas (reverso exacto)
            if (st.Length != st2.Length)
            {
                // Si las longitudes no coinciden, cambiar el valor de 'esSimetrica' a false
                esSimetrica = false;
            }
            else
            {
                // Iniciar un bucle for que recorra desde el índice 0 hasta el penúltimo índice de la primera palabra
                // Usamos 'i' como contador de posición en la primera palabra
                for (int i = 0; i < st.Length; i++)
                {
                    // Obtener el carácter actual de la primera palabra en la posición 'i'
                    char char1 = st[i];

                    // Calcular la posición correspondiente en la segunda palabra para la simetría
                    // La posición en st2 debe ser: longitud total menos el índice actual menos 1 (st2.Length - 1 - i)
                    // Esto accede al carácter desde el final hacia el principio
                    char char2 = st2[st2.Length - 1 - i];

                    // Comparar si el carácter de la primera palabra es diferente al carácter correspondiente de la segunda
                    if (char1 != char2)
                    {
                        // Si hay alguna diferencia, las palabras no son simétricas
                        // Cambiar el valor de 'esSimetrica' a false
                        esSimetrica = false;

                        // Romper el bucle inmediatamente ya que ya encontramos una diferencia y no es necesario seguir revisando
                        break;
                    }
                }
            }

            // Verificar el valor final de la variable 'esSimetrica' para determinar el mensaje a mostrar
            if (esSimetrica)
            {
                // Si 'esSimetrica' es true, mostrar un mensaje confirmando que son simétricas
                Console.WriteLine("Las palabras son simétricas.");
            }
            else
            {
                // Si 'esSimetrica' es false, mostrar un mensaje indicando que no son simétricas
                // Nota: el programa tomará en cuenta mayúsculas y minúsculas para determinar la simetría
                Console.WriteLine("Las palabras NO son simétricas.");
            }
        }
        else
        {
            // Si el usuario no ingresó exactamente dos palabras, mostrar un mensaje de error
            Console.WriteLine("Error: Por favor ingrese exactamente dos palabras separadas por un espacio.");
        }
    }
}
