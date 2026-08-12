// Declaramos el espacio de nombres para el programa
namespace Ejercicio04;

// Declaramos una Clase estática.
// Debe ser 'static' porque los métodos de extensión son siempre estáticos.
// También debe ser 'public' para ser accesible desde el programa principal.
static class VectorDeEnterosExtension
{
    // Método de extensión para imprimir el vector con una leyenda.
    // El modificador 'this' antes de 'int[] vector' indica que este método se aplica a arrays de enteros.
    public static void Print(this int[] vector, string leyenda)
    {
        // Inicializamos una variable de cadena 'st' con el texto de la leyenda.
        // Esta variable se usará para construir la línea completa de salida.
        string st = leyenda;

        // Verificamos si el vector tiene elementos para evitar errores si está vacío.
        if (vector.Length > 0)
        {
            // Recorremos cada elemento entero 'n' dentro del vector.
            foreach (int n in vector) 
                // Añadimos el valor del número actual y una coma y espacio a la cadena.
                // Ejemplo: si leyenda es "Valores: " y n es 1, st pasa a ser "Valores: 1, ".
                st += n + ", ";

            // Al finalizar el bucle, eliminamos los últimos dos caracteres de la cadena (la coma y el espacio extra al final).
            // Usamos Substring para tomar todo el texto desde el índice 0 hasta la longitud menos 2.
            // Esto asegura que el último número no tenga una coma al final.
            st = st.Substring(0, st.Length - 2);
        }
        // Escribimos la cadena final (leyenda + números limpios) en la consola.
        Console.WriteLine(st);
    }

    // Método de extensión 'Seleccionar' para transformar el vector.
    // Recibe el vector original y un delegado (funcion) que define cómo transformar cada elemento.
    public static int[] Seleccionar(this int[] vector, FuncionEntera funcion)
    {
        // Creamos un nuevo array de enteros con el mismo tamaño que el vector original.
        // Este será el array donde guardaremos los resultados transformados.
        int[] resultado = new int[vector.Length];

        // Iniciamos un bucle que recorre el array desde el índice 0 hasta el último elemento.
        for (int i = 0; i < vector.Length; i++)
        {
            // Aplicamos el delegado 'funcion' al elemento actual del vector (vector[i]).
            // El delegado ejecuta la lógica que se pasó (ej. n * 3) y devuelve el resultado.
            // Guardamos ese resultado en la posición correspondiente del nuevo array.
            resultado[i] = funcion(vector[i]);
        }

        // Retornamos el nuevo array que contiene los elementos transformados.
        return resultado;
    }
}