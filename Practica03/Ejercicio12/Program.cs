/*Realizar un análisis sintáctico para determinar si los paréntesis en una expresión aritmética están
bien balanceados. Verificar que por cada paréntesis de apertura exista uno de cierre en la cadena
de entrada. Utilizar una pila para resolverlo. Los paréntesis de apertura de la entrada se
almacenan en una pila hasta encontrar uno de cierre, realizándose entonces la extracción del
último paréntesis de apertura almacenado. Si durante el proceso se lee un paréntesis de cierre y
la pila está vacía, entonces la cadena es incorrecta. Al finalizar el análisis, la pila debe quedar
vacía para que la cadena leída sea aceptada, de lo contrario la misma no es válida.*/

// Importamos el espacio de nombres System para acceder a las clases básicas como Console, Stack, etc.
using System;
// Importamos el espacio de nombres System.Collections.Generic para utilizar la clase Stack<T>
using System.Collections.Generic;

// Definimos la clase principal del programa
class Program
{
    // El método Main es el punto de entrada del programa
    static void Main()
    {
        // Pedimos al usuario que ingrese una expresión aritmética para analizar
        Console.Write("Ingresa una expresión aritmética: ");
        // Leemos la línea de texto ingresada por el usuario y la guardamos en la cadena expresion
        string? expresion = Console.ReadLine();
        // Llamamos al método esBalanceado pasando la expresión y guardamos el resultado en la variable esValido
        bool esValido = esBalanceado(expresion!);
        
        // Si el resultado de la validación es verdadero, mostramos que los paréntesis están balanceados
        if (esValido)
        {
            // Imprimimos en consola que la expresión es válida
            Console.WriteLine("Los paréntesis están bien balanceados.");
        }
        else
        {
            // Si el resultado es falso, imprimimos que la expresión no es válida
            Console.WriteLine("Los paréntesis NO están bien balanceados.");
        }
    }

    // Definimos un método estático llamado esBalanceado que recibe una cadena y devuelve un booleano
    static bool esBalanceado(string expresion)
    {
        // Creamos una instancia de la clase Stack de caractér para almacenar los paréntesis de apertura
        Stack<char> stack = new Stack<char>();
        
        // Iniciamos un bucle for que recorre cada carácter de la cadena de expresión
        for (int i = 0; i < expresion.Length; i++)
        {
            // Obtenemos el carácter actual en la posición i de la cadena y lo guardamos en charCurrent
            char charCurrent = expresion[i];
            
            // Si el carácter actual es un paréntesis de apertura, lo agregamos a la pila
            if (charCurrent == '(')
            {
                // Usamos el método Push para colocar el paréntesis de apertura en la cima de la pila
                stack.Push(charCurrent);
            }
            // Si el carácter actual es un paréntesis de cierre, verificamos el estado de la pila
            else if (charCurrent == ')')
            {
                // Si la pila está vacía, significa que no hay un paréntesis de apertura que coincida
                if (stack.Count == 0)
                {
                    // Devolvemos falso inmediatamente ya que la expresión es inválida
                    return false;
                }
                // Si la pila no está vacía, eliminamos el último paréntesis de apertura (el de la cima)
                stack.Pop();
            }
            // Si el carácter no es un paréntesis, lo ignoramos y continuamos con el siguiente
        }
        
        // Al finalizar el bucle, verificamos si la pila está vacía
        // Si está vacía, significa que todos los paréntesis se cerraron correctamente
        // Si no está vacía, quedan paréntesis de apertura sin cerrar
        return stack.Count == 0;
    }
}

/*Notas:
- Uso de Stack<char>: 
Esta estructura de datos es ideal porque sigue el principio LIFO (Last In, First Out), 
perfecto para coincidir el último ( con el primer ) encontrado.

- Validación inmediata: 
Si encontramos un ')' y la pila está vacía (stack.Count == 0), sabemos inmediatamente que
 la expresión es incorrecta y retornamos false.

- Validación final: Al terminar de leer la cadena, la pila debe estar vacía. 
Si quedan elementos, significa que hay '(' sin cerrar.

-Tabla de Ejemplo para pruebas del programa:
Expresión de Entrada	Resultado Esperado	¿Por qué?
(2 + 3) * (4 - 1)	    Bien balanceados	Cada ( tiene su ) correspondiente en el orden correcto.
((5 + 2)	            NO balanceados	    Falta un paréntesis de cierre al final. La pila quedará con un (.
3 * (4 + 5))	        NO balanceados	    Hay un ) extra al final. La pila estará vacía al llegar a este punto y fallará la validación.
1 + (2 * (3 + 4))	    Bien balanceados	Anidación correcta: el interior se cierra antes que el exterior.
)1 + 2(	                NO balanceados	    El primer carácter es ) y la pila está vacía, falla inmediatamente.
5 + 3 * 2	            Bien balanceados	No hay paréntesis, la pila permanece vacía y el conteo final es 0.
((1 + 2) * (3 + 4))	    Bien balanceados	Anidación múltiple correcta.

*/
