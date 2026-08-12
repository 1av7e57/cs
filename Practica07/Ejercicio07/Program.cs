﻿/*Proponer una forma para conseguir un ordenamiento aleatorio de todos los elementos de un vector de objetos 
(object[]) utilizando Array.Sort(). Cada vez que se invoque debe producir un ordenamiento aleatorio diferente. 
(Investigar la clase System.Random)*/

using System; // Para System.Random y funciónes básicas
using Ejercicio07; // Utilizamos el espacio de nombres definido

// --- Clase Principal (Entrada del programa) ---
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // Creamos un array de prueba con objetos de diferentes tipos (string, int, double, char, bool).
        // Esto demuestra que el método funciona con un array de tipo 'object'.
        object[] datos = { "Manzana", 42, 3.14, 'C', true, "Zanahoria", 7 };

        // Imprimimos un encabezado
        Console.WriteLine("=== Prueba de Ordenamiento Aleatorio ===\n");
        Console.WriteLine("Array Original:");
        
        // Llamar al método auxiliar para imprimir el estado inicial.
        ImprimirArray(datos);

        // Ejecutar el ordenamiento varias veces para demostrar que el resultado cambia cada vez.
        int iteraciones = 5;
        for (int i = 1; i <= iteraciones; i++)
        {
            // Llamamos al método que realiza la mezcla (shuffling) desde la clase.
            OrdenamientoAleatorio.OrdenarAleatoriamente(datos);
            
            // Mostramos el resultado de esta iteración.
            Console.WriteLine($"\nOrdenamiento {i}:");
            ImprimirArray(datos);
        }
        
        // Imprimimos una nota al pié
        Console.WriteLine("\n=== Fin de las pruebas ===");
    }

    // Método auxiliar para imprimir el array de forma legible en consola.
    // Formatea cada elemento entre comillas y los separa por comas.
    static void ImprimirArray(object[] array)
    {
        Console.Write("[ "); // Imprime el inicio del array.
        
        for (int i = 0; i < array.Length; i++)
        {
            // Convierte el objeto a string. El operador "?." maneja nulls (si el elemento es null, devuelve null).
            // El operador "??" asigna "null" si el valor es nulo.
            string valor = array[i]?.ToString() ?? "null";
            
            // Imprime el valor envuelto en comillas dobles.
            Console.Write($"\"{valor}\"");
            
            // Si no es el último elemento, imprime una coma y un espacio.
            if (i < array.Length - 1) 
                Console.Write(", ");
        }
        
        Console.WriteLine(" ]"); // Imprime el cierre del array y un salto de línea.
    }
}

/*NOTAS:
¿Qué hace este código?
 Main():
    - Crea un array object[] con datos variados (string, int, double, char, bool).
    - Muestra el array original.
    - Llama a OrdenarAleatoriamente() 5 veces, mostrando el resultado cada vez para demostrar que el orden cambia aleatoriamente.
    - Usa una función auxiliar ImprimirArray para que la salida sea limpia y fácil de leer.
 OrdenarAleatoriamente() en OrdenamientoAleatorio.cs:
    - Paso 1: Crea el array de índices [0, 1, 2, 3...].
    - Paso 2: Crea un solo objeto Random (crucial para evitar semillas repetidas).
    - Paso 3: Genera un número aleatorio (NextDouble) para cada posición y lo guarda en claves.
    - Paso 4: Instancia el comparador. Crea un objeto de la clase ComparadorAleatorioConClaves, 
    pasando el array de claves al constructor. Luego, llama a Array.Sort(indices, comparador).
        - Aquí, comparador es una instancia que implementa la interfaz IComparer<int>.
        - Al ordenar, Array.Sort invoca internamente el método Compare(x, y) definido, el cual 
        devuelve el resultado de comparar claves[x] con claves[y].
    - Paso 5 y 6: Reconstruye el array original usando el nuevo orden de los índices y lo copia de vuelta al array original.

    Nota: El comparador (x, y) => _claves[x].CompareTo(_claves[y]) es el "cerebro" 
    que le dice al algoritmo de ordenamiento cómo comparar dos elementos basándose en datos externos 
    (nuestra tabla de claves aleatorias).

=======================================================================================================================
=======================================================================================================================

Simulación del proceso con valores concretos de ejemplo:

Usando el array original (de 7 elementos):
    ["Manzana", 42, 3.14, 'C', true, "Zanahoria", 7]

Imaginaremos que new Random() genera la siguiente secuencia de números aleatorios (usando NextDouble()) para las claves:
    0.85, 0.23, 0.91, 0.05, 0.67, 0.42, 0.12

Simulación paso a paso detallada:

Paso A: Estado Inicial
Tenemos el array 'datos' y creamos el array de 'indices' y el array de 'claves'.

-----------------------------------------------------------------------------------------------------------
| Índice ('i') | 'datos[i]' (Valor Original) | 'indices[i]' (Inicial) | 'claves[i]' (Generado por Random) |
| :----------- | :-------------------------  | :--------------------- | :-------------------------------  |
| 0    	       | "Manzana" 		             | 0 		              | 0.85 				              |
| 1    	       | 42 			             | 1 		              | 0.23 				              |
| 2    	       | 3.14 			             | 2 		              | 0.91 				              |
| 3    	       | 'C' 			             | 3 		              | 0.05 				              |
| 4    	       | true 			             | 4 		              | 0.67 				              |
| 5    	       | "Zanahoria" 		         | 5 		              | 0.42 				              |
| 6    	       | 7 			                 | 6 		              | 0.12 				              |
-----------------------------------------------------------------------------------------------------------

---

Paso B: Ordenar los índices ('Array.Sort')
Ahora ejecutamos 'Array.Sort(indices, comparador)', donde comparador es una instancia de 
ComparadorAleatorioConClaves. Internamente, este objeto ejecuta la lógica: comparar claves[x] con claves[y].

El algoritmo de ordenamiento comparará las claves asociadas a cada índice y reorganizará el array 'indices' 
para que las claves estén en orden ascendente(de menor a mayor).

Orden de las claves:
1.  0.05 (Índice 3) -> Menor
2.  0.12 (Índice 6)
3.  0.23 (Índice 1)
4.  0.42 (Índice 5)
5.  0.67 (Índice 4)
6.  0.85 (Índice 0)
7.  0.91 (Índice 2) -> Mayor

Resultado del array 'indices' después de sort:
El array 'indices' ya no es '[0, 1, 2, 3, 4, 5, 6]'. Ahora es:
'[3, 6, 1, 5, 4, 0, 2]'

Nota: Esto significa que el primer elemento del nuevo orden será el que estaba en la posición 3 original, 
el segundo el de la posición 6, etc.

---

Paso C: Reconstruir el array de resultados
Ahora creamos el array 'resultado' y rellenamos copiando los elementos de 'datos' 
basándonos en el nuevo orden de 'indices'.

Fórmula: 'resultado[i] = datos[indices[i]]'

-------------------------------------------------------------------------------------------------------------------------------
| 'i' (Posición nueva) | 'indices[i]' (Índice original) | 'datos[indices[i]]' (Valor a copiar) | 'resultado[i]' (Valor final) |
| :------------------- | :----------------------------- | :----------------------------------- | :--------------------------- |
| 0 		           | 3                              | 'datos[3]' = ''C''                   | ''C''                        |
| 1 		           | 6                              | 'datos[6]' = '7'                     | '7'                          |
| 2 		           | 1                              | 'datos[1]' = '42'                    | '42'                         |
| 3 		           | 5                              | 'datos[5]' = '"Zanahoria"'           | '"Zanahoria"'                |
| 4 		           | 4                              | 'datos[4]' = 'true'                  | 'true'                       |
| 5 		           | 0                              | 'datos[0]' = '"Manzana"'             | '"Manzana"'                  |
| 6 		           | 2                              | 'datos[2]' = '3.14'                  | '3.14'                       |
-------------------------------------------------------------------------------------------------------------------------------

---

Paso D: Copia final
Se ejecuta 'Array.Copy(resultado, datos, n)'.
El array 'datos' original se sobrescribe con el contenido de 'resultado'.

**Array Final Resultante:**
'['C', 7, 42, "Zanahoria", true, "Manzana", 3.14]'

---

¿Por qué es aleatorio?
Si se vuelve a ejecutar el código, 'Random' genera una secuencia diferente de claves 
(por ejemplo, '0.50, 0.99, 0.10...'), lo que resulta en un ordenamiento de índices completamente distinto 
y, por tanto, un array final diferente.

=======================================================================================================================
=======================================================================================================================

Investigación: System.Random
    La clase System.Random en C# es fundamental para generar números pseudoaleatorios.

Conceptos Básicos:
    -Propósito: Genera números pseudoaleatorios (no verdaderamente aleatorios, ya que dependen de una semilla inicial).
    -Instanciación: Se debe crear una instancia de la clase; no es estática.
        Random aleatorio = new Random();

Métodos Principales:
    1. Next(): Genera un entero no negativo aleatorio.
        - aleatorio.Next() (cualquier valor int positivo).
        - aleatorio.Next(10) (valor entre 0 y 9).
        - aleatorio.Next(5, 10) (valor entre 5 y 9, el límite superior es exclusivo).
    2. NextDouble(): Genera un número de punto flotante entre 0.0 y 1.0.
        double valor = aleatorio.NextDouble();
    3. NextBytes(byte[]): Rellena un array de bytes con valores aleatorios.
    4. NextDouble() y escalado: Para obtener un valor en un rango específico (ej. 10 a 50), se suele usar:
        int valor = aleatorio.Next(10, 51); // 51 es exclusivo, así que llega a 50

Consideraciones Importantes
    - Semilla (Seed): Si no se especifica, usa el reloj del sistema. 
    Crear múltiples instancias en rápida sucesión puede generar la misma secuencia de números.
    - Solución: Reutilizar la misma instancia de Random en toda la aplicación o usar una semilla fija 
    si se necesita reproducibilidad.
    - No es seguro para criptografía: Si se necesita aleatoriedad segura (ej. contraseñas, tokens), 
    se usa System.Security.Cryptography.RandomNumberGenerator en lugar de Random.

Ejemplo de uso:
    using System;

    class Programa
    {
        static void Main()
        {
            Random rnd = new Random();
            
            int numero = rnd.Next(1, 100); // 1 a 99
            double decimalNum = rnd.NextDouble(); // 0.0 a 1.0
            
            Console.WriteLine($"Entero: {numero}");
            Console.WriteLine($"Decimal: {decimalNum}");
        }
    }

Acerca de las semillas:
    1. La semilla es privada: 
    La semilla se almacena en un campo interno (privado) dentro de la clase. 
    No existe una propiedad como .Seed ni un método GetSeed() para acceder  a ella en la API pública.
2. Comportamiento al instanciar
    - Si se crea new Random() sin argumentos, el constructor utilizará el reloj del sistema 
    (Environment.TickCount o DateTime.Now dependiendo de la versión) para generar una semilla única 
    basada en el momento exacto de la creación.
    -Si se crea new Random(12345), se usa esa semilla fija. En este caso, uno sabe cuál es la semilla porque 
    uno mismo la define, pero el objeto Random no la devuelve.
3. ¿Por qué no se puede leer? 
    El diseño de System.Random está pensado para que la semilla sea un detalle de implementación interna. 
    Una vez que el generador comienza a producir números, el estado interno cambia (evolucciona) y la semilla original 
    ya no es directamente accesible ni necesaria para la generación de los siguientes números.

Si se necesitara saber o controlar la semilla, lo recomendable es definirla uno mismo. Esto puede ser útil 
para pruebas que requieran reproducibilidad (por ejemplo, para depurar o tests). Se debe instanciar la clase
con una semilla conocida y guardar ese número en una variable propia.
Ejemplo:
    long miSemilla = 42;
    Random rnd = new Random(miSemilla);
    // Se Puede guardar 'miSemilla' en un log para reproducir el resultado después
    Console.WriteLine($"Semilla usada: {miSemilla}");
*/
