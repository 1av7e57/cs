﻿/*Agregar al ejercicio anterior el método de extensión Donde(...) para el tipo int[] que recibe
como parámetro un delegado de tipo Predicado y devuelve un nuevo vector de enteros con los
elementos del vector que cumplen ese predicado. El siguiente programa debe producir la salida
indicada.

-------Program.cs---------
int[] vector = new int[] { 1, 2, 3, 4, 5 };
vector.Print("Valores iniciales: ");
vector.Donde(n => n % 2 == 0).Print("Pares: ");
vector.Donde(n => n % 2 == 1).Seleccionar(n => n * n).Print("Impares al cuadrado: ");
-------Predicado.cs---------
delegate bool Predicado(int n);
-------FuncionEntera.cs---------
delegate int FuncionEntera(int n);

Salida por consola:
Valores iniciales: 1, 2, 3, 4, 5
Pares: 2, 4
Impares al cuadrado: 1, 9, 25
*/

using System; // Importamos para funciónes básicas
using Ejercicio05; // Importamos el espacio de nombres del programa

// Definimos la clase principal del programa
class Program
{
    // Punto de entrada principal de la aplicación
    static void Main()
    {
         // Creamos el vector original
        int[] vector = new int[] { 1, 2, 3, 4, 5 };

        // Imprime una leyenda junto con todos los valores iniciales
        vector.Print("Valores iniciales: ");

        // Filtra solo los números pares (n % 2 == 0) e imprime una leyenda junto con el resultado.
        // El Delegado Predicado (que devuelve un valor booleano) se infiere de 
        // la lambda n => n % 2 == 0 (condicion de filtrado)
        // Resultado: {2, 4}
        vector.Donde(n => n % 2 == 0).Print("Pares: ");

        // Encadena dos métodos:
        // 1. Donde: Filtra los impares (n % 2 == 1). Resultado: {1, 3, 5}
        // 2. Seleccionar: Eleva al cuadrado cada uno de esos impares. Resultado: {1, 9, 25}
        // 3. Print: Imprime la leyenda junto con el resultado final.
        vector.Donde(n => n % 2 == 1).Seleccionar(n => n * n).Print("Impares al cuadrado: ");
    }
}

/*NOTAS:
El ejercicio propone implementar el método de extensión 'Donde'.

A diferencia de 'Seleccionar' (que transforma todos los elementos), 
'Donde' filtra elementos. Por eso, no se sabe desde un principio cuántos elementos cumplirán la condición.
Esto plantea un pequeño reto.

Análisis del Reto:
    - Entrada: Un int[] vector y un delegado Predicado (que devuelve true o false).
    - Proceso: Recorrer el vector y guardar solo los elementos donde Predicado(elemento) sea true.
    - Salida: Un nuevo int[] con los elementos filtrados.
    - Desafío: Como no es posible saber de entrada cuántos elementos pasarán el filtro, 
    no se puede crear el array de resultados con un tamaño fijo al principio.

Estrategia de Solución:
    Se propone usar una lista temporal (List<int>) para ir guardando los elementos que cumplen la condición. 
    Una vez terminado el recorrido, se convierte esa lista a un array (int[]) y se retorna.

Puntos Clave de la Implementación:
    - List<int>: Es fundamental usar una lista aquí porque los arrays en C# tienen tamaño fijo. 
    Si intentáramos crear int[] resultado = new int[vector.Length] y luego solo llenar algunas posiciones, 
    tendríamos que contar cuántos elementos cumplen la condición primero, o terminar con ceros al final del array. 
    La lista crece dinámicamente.
    - ToArray(): Al final, se convierte la lista a array porque la firma del método exige que retorne int[].
    - Encadenamiento: Como 'Donde' devuelve un int[], es posible llamar inmediatamente a 'Seleccionar' en el resultado, 
    demostrando la potencia de los métodos de extensión.
*/
