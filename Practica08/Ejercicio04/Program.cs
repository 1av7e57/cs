﻿/*En este ejercicio, se requiere extender el tipo int[] con algunos métodos de extensión. Se presenta
el código del método de extensión Print(this int[] vector, string leyenda) que imprime en la
consola los elementos del vector precedidos por una leyenda que se pasa como parámetro. Se
requiere codificar el método de extensión Seleccionar(...) que recibe como parámetro un
delegado de tipo FuncionEntera y devuelve un nuevo vector de enteros producto de aplicar la
función recibida como parámetro a cada uno de los elementos del vector. El siguiente programa debe
producir la salida indicada.

-------Program.cs---------
int[] vector = new int[] { 1, 2, 3, 4, 5 };
vector.Print("Valores iniciales: ");
var vector2 = vector.Seleccionar(n => n * 3);
vector2.Print("Valores triplicados: ");
vector.Seleccionar(n => n * n).Print("Cuadrados: ");
-------FuncionEntera.cs---------
delegate int FuncionEntera(int n);

Salida por consola:
Valores iniciales: 1, 2, 3, 4, 5
Valores triplicados: 3, 6, 9, 12, 15
Cuadrados: 1, 4, 9, 16, 25

Para ello, completar el código de la siguiente clase estática VectorDeEnterosExtension:
static class VectorDeEnterosExtension
{
    public static void Print(this int[] vector, string leyenda)
    {
        string st = leyenda;
        if (vector.Length > 0)
        {
            foreach (int n in vector) st += n + ", ";
            st = st.Substring(0, st.Length - 2);
        }
        Console.WriteLine(st);
    }
    public static int[] Seleccionar(. . . )
    {
        . . .
    }
}
*/

using System; // Importamos para funciónes básicas
using Ejercicio04; // Importamos el espacio de nombres del programa

// Definimos la clase principal del programa
class Program
{
    // Punto de entrada principal de la aplicación
    static void Main()
    {
        // Creamos un array de enteros con los valores 1, 2, 3, 4, 5
        int[] vector = new int[] { 1, 2, 3, 4, 5 };

        // Llamamos al método de extensión 'Print' en el vector original.
        // Se pasa la leyenda "Valores iniciales: ".
        vector.Print("Valores iniciales: ");

        // Llamamos al método de extensión 'Seleccionar' pasando una expresión lambda.
        // La lambda 'n => n * 3' se convierte automáticamente en una instancia de FuncionEntera.
        // Multiplica cada elemento por 3 y devuelve un nuevo array en 'vector2'.
        var vector2 = vector.Seleccionar(n => n * 3);

        // Imprimimos el nuevo array 'vector2' con la leyenda "Valores triplicados: ".
        vector2.Print("Valores triplicados: ");

        // Ejemplo más compacto:
        // 1. Llamamos a 'Seleccionar' con la lambda 'n => n * n' (cuadrados).
        // 2. Inmediatamente llamamos a 'Print' sobre el resultado devuelto.
        // No guardamos el resultado en una variable intermedia, lo usamos directamente.
        vector.Seleccionar(n => n * n).Print("Cuadrados: ");
    }
}

/*NOTAS:
El ejercicio propone la aplicación de los delegados combinados con métodos de extensión en C#. 
Se necesita completar la firma del método Seleccionar() en la VectorDeEnterosExtension.cs 
para que acepte el Delegado FuncionEntera, y luego iterar sobre el array original 
aplicando esa función a cada elemento.

Puntos Clave:
1. Firma del Método: public static int[] Seleccionar(this int[] vector, FuncionEntera funcion)
    - this int[] vector: Indica que es un método de extensión para arrays de enteros.
    - FuncionEntera funcion: Aquí recibimos el Delegado. Gracias a esto, podemos pasar expresiones lambda 
    como n => n * 3 o n => n * n directamente al llamar al método.
    - int[]: Devuelve un nuevo array con los resultados transformados.

2. Lógica Interna:
    - Creamos un nuevo array resultado del mismo tamaño que el de entrada. 
    No podemos modificar el original porque el ejercicio pide "devolver un nuevo vector".
    - Usamos un bucle for para recorrer el array original.
    - La clave está en esta línea: resultado[i] = funcion(vector[i]);. Aquí invocamos el Delegado funcion 
    pasando el valor actual del array (vector[i]). El compilador sabe que funcion espera un int 
    y devuelve un int, por lo que la operación es segura.
*/
