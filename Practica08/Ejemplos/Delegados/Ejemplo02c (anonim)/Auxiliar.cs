// Versión usando métodos anónimos

// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // Método público que ejecuta la nueva lógica con métodos anónimos
    public void Procesar()
    {
        // Declaramos e inicializamos un array de enteros con los valores 11, 5 y 90
        int[] v = new int[] { 11, 5, 90 };

        // Definimos una variable del tipo delegado 'Funcion' usando un método anónimo.
        // La sintaxis 'delegate (int n)' crea una función inline sin nombre.
        // Esta función recibe un entero 'n' y devuelve su valor multiplicado por 2.
        Funcion f = delegate (int n)
        {
            return n * 2;
        }; // Nota: El punto y coma es obligatorio al finalizar la asignación del delegado.

        // Llamamos al método 'Aplicar' pasando el array 'v' y el delegado 'f'.
        // 'Aplicar' iterará sobre 'v' y ejecutará la lógica del delegado (n * 2) en cada elemento.
        // El array 'v' se modificará en memoria: [22, 10, 180]
        Aplicar(v, f);

        // Imprimimos el estado del array después de la primera transformación.
        Imprimir(v);

        // Llamamos nuevamente a 'Aplicar', pero esta vez pasamos un método anónimo directamente como argumento.
        // No necesitamos asignarlo a una variable 'f' primero.
        // La lógica aquí es: recibir 'n' y devolver 'n + 10'.
        // Se aplica a cada elemento del array modificado: [22+10, 10+10, 180+10] -> [32, 20, 190]
        Aplicar(v, delegate (int n) { return n + 10; });

        // Imprimimos el estado final del array después de la segunda transformación.
        Imprimir(v);
    }

    // Método auxiliar que aplica el delegado a cada elemento del array
    // (Este método debe existir en el código para que el ejemplo funcione)
    void Aplicar(int[] array, Funcion operacion)
    {
        for (int i = 0; i < array.Length; i++)
        {
            // Ejecuta el delegado pasado como parámetro sobre el elemento actual
            array[i] = operacion(array[i]);
        }
    }

    // Método auxiliar que imprime el contenido del array
    // (Este método debe existir en el código para que el ejemplo funcione)
    void Imprimir(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }

    // Los métodos SumaUno y SumaDos ya no se usan en esta versión modificada.

}

/*NOTAS:
Conceptos Clave de este cambio:
-Método Anónimo: La sintaxis delegate (int n) { ... } permite definir una función "sobre la marcha" 
sin darle un nombre formal. Esto es muy útil para operaciones cortas que solo se usan una vez.
-Delegado como Argumento: En la línea Aplicar(v, delegate (int n) { return n + 10; });, 
pasamos el delegado directamente. El compilador infiere que este bloque de código coincide con la firma de Funcion.
-Modificación en Referencia: Como el array v es un tipo de referencia, los cambios realizados dentro de Aplicar 
se reflejan inmediatamente en la variable v original.

Salida en Consola:
Si se ejecuta este código (asumiendo que Aplicar e Imprimir están implementados), la consola mostrará:
22, 10, 180
32, 20, 190
*/