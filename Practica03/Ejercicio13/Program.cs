/*Utilizar la clase Stack<T> (pila) para implementar un programa que pase un número en base
10 a otra base realizando divisiones sucesivas. Por ejemplo para pasar 35 en base 10 a binario
dividimos sucesivamente por dos hasta encontrar un cociente menor que el divisor, luego el
resultado se obtiene leyendo de abajo hacia arriba el cociente de la última división seguida por todos los restos.

                         35/2
Último dígito binario →   1 17/2
                             1 8/2
                               0 4/2
                                 0 2/2
                                   0 1  ← Primer dígito binario

El resultado es: 100011 */

// Importamos el espacio de nombres System para usar tipos básicos como Console, int, string
using System;
// Importamos System.Collections.Generic para poder usar la clase Stack<T> (Pila)
using System.Collections.Generic;

// Definimos la clase principal del programa
class Program
{
  // El método Main es el punto de entrada del programa.  
  static void Main()
  {
    // Mostramos un mensaje en consola pidiendo al usuario que introduzca un número
    Console.Write("Introduce un número decimal: ");

    // Leemos la entrada del usuario como texto y tratamos de convertirla a un entero (int).
    // int.TryParse devuelve true si la conversión fue exitosa y guarda el número en la variable 'numero'.
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
      // Verificamos si el número es negativo.
      // La conversión binaria por divisiones sucesivas funciona para números naturales (>= 0).
      if (numero < 0)
      {
        // Si es negativo, mostramos un mensaje de error y salimos del programa.
        Console.WriteLine("Por favor, introduce un número entero no negativo.");
        return; // Termina la ejecución del método Main
      }

      // Llamamos a nuestra función personalizada para convertir el número y guardamos el resultado en una variable string.
      string binario = ConvertirADecimal(numero);

      // Mostramos el resultado final en la consola.
      Console.WriteLine($"El número {numero} en binario es: {binario}");
    }
    else
    {
      // Si la conversión falla (el usuario escribió letras o símbolos), ejecutamos este bloque.
      Console.WriteLine("Entrada no válida.");
    }
  }

  // Definimos un método estático que recibe un entero y devuelve un string.
  static string ConvertirADecimal(int numero)
  {
    // Caso especial: si el número es 0, su representación binaria es "0".
    // El bucle while de abajo no se ejecutaría si numero es 0, así que lo manejamos aquí.
    if (numero == 0) return "0";

    // Creamos una nueva instancia de la clase Stack (pila) que almacenará enteros (int).
    // La pila sigue el principio LIFO (Last In, First Out): el último elemento que entra es el primero en salir.
    Stack<int> pila = new Stack<int>();

    // Iniciamos un bucle while que se ejecutará mientras el número sea mayor que 0.
    while (numero > 0)
    {
      // Calculamos el resto de la división de 'numero' entre 2.
      // El operador % (módulo) nos da el residuo. En binario, esto será 0 o 1.
      int resto = numero % 2;

      // Añadimos el resto a la pila usando el método Push.
      // Este elemento quedará en la "parte superior" de la pila.
      pila.Push(resto);

      // Actualizamos el valor de 'numero' dividiéndolo entre 2 (división entera).
      // Esto nos da el cociente para la siguiente iteración.
      numero = numero / 2;
    }

    // Inicializamos una cadena vacía para ir construyendo el resultado binario.
    string resultadoBinario = "";

    // Iniciamos un bucle while que se ejecutará mientras la pila tenga elementos (Count > 0).
    while (pila.Count > 0)
    {
      // Extraemos el elemento superior de la pila usando Pop().
      // Como los restos se guardaron del menos significativo al más significativo,
      // al sacarlos con Pop() los obtenemos en el orden inverso (del más significativo al menos),
      // que es el orden correcto para leer un número binario.
      int bit = pila.Pop();

      // Convertimos el entero 'bit' a texto y lo concatenamos al final de nuestra cadena de resultado.
      resultadoBinario += bit.ToString();
    }

    // Devolvemos la cadena completa que representa el número en binario.
    return resultadoBinario;
  }
}

/*
Notas:

- Uso de Stack<int>: 
Es fundamental usar una pila porque el algoritmo genera los bits "al revés" 
(primero el bit menos significativo). La pila invierte el orden automáticamente al sacar los elementos.

- Explicación paso a paso para el caso de ejemplo (35):
35 / 2: Cociente 17, Resto 1 → Se apila 1.
17 / 2: Cociente 8, Resto 1 → Se apila 1.
8 / 2: Cociente 4, Resto 0 → Se apila 0.
4 / 2: Cociente 2, Resto 0 → Se apila 0.
2 / 2: Cociente 1, Resto 0 → Se apila 0.
1 / 2: Cociente 0, Resto 1 → Se apila 1.
El bucle termina porque el cociente es 0.
Estado de la pila (de abajo a arriba): 1, 0, 0, 0, 1, 1

Al leer desde arriba (hacer Pop):
Sacamos 1 → Resultado: "1"
Sacamos 1 → Resultado: "11"
Sacamos 0 → Resultado: "110"
Sacamos 0 → Resultado: "1100"
Sacamos 0 → Resultado: "11000"
Sacamos 1 → Resultado: "110001"

Resultado final concatenado: 100011.

*/

