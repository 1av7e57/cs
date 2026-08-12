using System; // Importamos para funciónes básicas
using System.Collections.Generic; // Importamos para usar List<T>

// Declaramos el espacio de nombres para el programa
namespace Ejercicio05;

// Declaramos una Clase estática.
// Debe ser 'static' porque los métodos de extensión son siempre estáticos.
// También debe ser 'public' para ser accesible desde el programa principal.
static class VectorDeEnterosExtension
{
    // Método existente: Imprime el vector con una leyenda.
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

    // Método existente: Transforma cada elemento del vector usando el Delegado FuncionEntera.
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

    // NUEVO: Método de extensión 'Donde' para filtrar elementos.
    // Recibe el vector y un predicado (condición booleana).
    public static int[] Donde(this int[] vector, Predicado condicion)
    {
        // Usamos una lista dinámica para guardar los elementos que cumplen la condición.
        // No conocemos el tamaño final del array filtrado, por eso usamos List.
        List<int> elementosFiltrados = new List<int>();

        // Recorremos cada elemento del vector original.
        foreach (int n in vector)
        {
            // Invocamos el delegado 'condicion' pasando el elemento actual.
            // Si el predicado devuelve true, el elemento cumple la condición.
            if (condicion(n))
            {
                // Agregamos el elemento a la lista temporal.
                elementosFiltrados.Add(n);
            }
        }

        // Convertimos la lista dinámica a un array de enteros (int[]) antes de retornar.
        // El método 'ToArray()' crea un nuevo array con los elementos de la lista.
        return elementosFiltrados.ToArray();
    }
}