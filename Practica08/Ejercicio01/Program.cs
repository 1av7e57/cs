﻿/*Declarar los tipos delegados necesarios para que el siguiente programa compile y produzca la
salida en la consola indicada:

Del1 d1 = delegate (int x) { Console.WriteLine(x); };
d1(10);
Del2 d2 = x => Console.WriteLine(x.Length);
d2(new int[] { 2, 4, 6, 8 });
Del3 d3 = x =>
{
    int sum = 0;
    for (int i = 1; i <= x; i++)
    {
        sum += i;
    }
    return sum;
};
int resultado = d3(10);
Console.WriteLine(resultado);
Del4 d4 = new Del4(LongitudPar);
Console.WriteLine(d4("hola mundo"));
bool LongitudPar(string st)
{
    return st.Length % 2 == 0;
}

Salida por consola:
10
4
55
True

*/


// Aquí el código en Main solo orquesta el uso de los delegados.

using System; // Importamos el espacio de nombres System para usar Console.WriteLine

// Clase principal que contiene el punto de entrada de la aplicación
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // --- BLOQUE 1: Delegado Del1 ---
        // Creamos una instancia del delegado Del1.
        // Usamos un "método anónimo" (delegate { ... }) para definir su comportamiento inline.
        // El parámetro 'x' será el entero que recibirá el método.
        // Dentro del bloque, imprimimos el valor de 'x' en la consola.
        Del1 d1 = delegate (int x) { Console.WriteLine(x); };
        
        // Ejecutamos el delegado pasando el número 10.
        // Esto llama internamente al método anónimo definido arriba.
        d1(10); 
        // Salida esperada: 10

        // --- BLOQUE 2: Delegado Del2 ---
        // Creamos una instancia del delegado Del2.
        // Usamos una "expresión lambda" (x => ...).
        // El compilador infiere que 'x' es un 'int[]' porque el delegado Del2 espera un array.
        // Accedemos a la propiedad .Length del array para obtener su tamaño y lo imprimimos.
        Del2 d2 = x => Console.WriteLine(x.Length);
        
        // Ejecutamos el delegado pasando un nuevo array de enteros { 2, 4, 6, 8 }.
        // El array tiene 4 elementos, por lo que se imprimirá 4.
        d2(new int[] { 2, 4, 6, 8 });
        // Salida esperada: 4

        // --- BLOQUE 3: Delegado Del3 ---
        // Creamos una instancia del delegado Del3.
        // Usamos una lambda con cuerpo de múltiples líneas { ... }.
        // 'x' es el entero de entrada (el límite de la suma).
        Del3 d3 = x =>
        {
            // Inicializamos una variable acumuladora 'sum' en 0.
            int sum = 0;
            
            // Bucle 'for' que va desde 1 hasta 'x' (inclusive).
            // 'i' es el contador que se incrementa en 1 en cada iteración.
            for (int i = 1; i <= x; i++)
            {
                // En cada iteración, sumamos el valor actual de 'i' a 'sum'.
                sum += i;
            }
            
            // Devolvemos el resultado final de la suma.
            // Esto coincide con el tipo de retorno 'int' de Del3.
            return sum;
        };
        
        // Ejecutamos el delegado pasando 10.
        // Calcula la suma de 1 a 10 (1+2+3+...+10 = 55).
        int resultado = d3(10);
        
        // Imprimimos el resultado guardado en la variable 'resultado'.
        Console.WriteLine(resultado);
        // Salida esperada: 55

        // --- BLOQUE 4: Delegado Del4 ---
        // Creamos una instancia del delegado Del4.
        // Usamos el constructor explícito 'new Del4(...)' (opcional en versiones modernas, pero válido).
        // Como argumento, pasamos la referencia al método estático 'LongitudPar' de la clase 'Calcular'.
        // El compilador verifica que la firma del método coincida con el delegado (string -> bool).
        Del4 d4 = new Del4(Calcular.LongitudPar);
        
        // Ejecutamos el delegado pasando la cadena "hola mundo".
        // "hola mundo" tiene 10 caracteres (9 letras + 1 espacio).
        // 10 es par, por lo que LongitudPar devuelve true.
        Console.WriteLine(d4("hola mundo"));
        // Salida esperada: True
    }
}

/*NOTAS:
Conceptos Clave:
    - Métodos Anónimos (delegate { }): Se usan en d1. Permiten definir lógica sin crear un método con nombre separado.
    - Expresiones Lambda (x => ...): Se usan en d2 y d3. Es una sintaxis más corta y moderna para definir métodos anónimos.
    - Inferencia de Tipos: En d2, no se necesita escribir (int[] x) =>. C# deduce el tipo de x basándose en la definición de Del2.
    - Métodos como Objetos: En d4, pasamos Calcular.LongitudPar como si fuera una variable. El delegado "envuelve" ese método para poder invocarlo más tarde.
*/
