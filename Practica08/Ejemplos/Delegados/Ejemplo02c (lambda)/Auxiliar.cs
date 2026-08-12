// Versión usando expresiones Lambda

// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // Método público que ejecuta la lógica utilizando expresiones Lambda
    public void Procesar()
    {
        // Declaramos e inicializamos un array de enteros con los valores 11, 5 y 90
        int[] v = new int[] { 11, 5, 90 };

        // Llamamos a 'Aplicar' pasando el array y una expresión Lambda directamente.
        // Sintaxis: 'n => n * 2'
        // 'n' es el parámetro de entrada (inferido como int por el delegado 'Funcion').
        // 'n * 2' es el cuerpo de la función que se ejecuta y devuelve el resultado.
        // Esto es equivalente al método anónimo 'delegate (int n) { return n * 2; }' pero más breve.
        Aplicar(v, n => n * 2);

        // Imprimimos el array tras la primera transformación.
        // Los valores originales [11, 5, 90] se convierten en [22, 10, 180].
        Imprimir(v);

        // Llamamos nuevamente a 'Aplicar' con una segunda expresión Lambda.
        // Sintaxis: 'n => n + 10'
        // Aplica la operación de sumar 10 a cada elemento del array actualizado.
        // Los valores [22, 10, 180] se convierten en [32, 20, 190].
        Aplicar(v, n => n + 10);

        // Imprimimos el estado final del array.
        Imprimir(v);
    }

    // Método auxiliar que aplica la operación del delegado a cada elemento del array.
    // 'operacion' es una variable del tipo delegado 'Funcion' que recibimos como parámetro.
    void Aplicar(int[] array, Funcion operacion)
    {
        // Iteramos sobre cada índice del array
        for (int i = 0; i < array.Length; i++)
        {
            // Ejecutamos el delegado 'operacion' con el valor actual del array.
            // La expresión Lambda pasada desde 'Procesar' se ejecuta aquí.
            // El resultado reemplaza al valor original en el array.
            array[i] = operacion(array[i]);
        }
    }

    // Método auxiliar para imprimir el contenido del array en la consola.
    void Imprimir(int[] array)
    {
        // 'string.Join' concatena los elementos del array separados por una coma y un espacio.
        Console.WriteLine(string.Join(", ", array));
    }

    // Los métodos antiguos 'SumaUno' y 'SumaDos' ya no son necesarios para esta lógica,
  
}

/*NOTAS:
El archivo Auxiliar.cs ha sido actualizado con la sintaxis de expresiones Lambda. 
Esta es la forma más moderna, concisa y legible de trabajar con delegados en C#.

Diferencias Clave con la versión anterior (Métodos Anónimos):
-Sintaxis =>: El operador "flecha" (=>) separa los parámetros (izquierda) del cuerpo de la función (derecha). 
Es mucho más limpio que delegate (int n) { return ...; }.
-Inferencia de Tipos: En n => n * 2, no se necesita escribir int n. El compilador infiere que n es un int 
porque el delegado Funcion espera un entero.
-Expresión Implícita: Si el cuerpo de la función es una sola sentencia return, no se necesita escribir las llaves {}
ni la palabra return. El valor de la expresión se devuelve automáticamente.

Resultado Esperado en Consola:
22, 10, 180
32, 20, 190
*/