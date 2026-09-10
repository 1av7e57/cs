﻿// 1. Creamos una lista de enteros con valores iniciales.
//    Esta es nuestra fuente de datos original.
var numeros = new List<int>() { 1, 10, 7, 3, 11 };

// 2. Llamamos a Mostrar para imprimir la lista original.
//    Esto fuerza la iteración sobre 'numeros' y muestra: 1 10 7 3 11
Mostrar(numeros);

// 3. Aplicamos el filtro 'Where'.
//    Selecciona solo los elementos donde la condición (n > 5) es verdadera.
//    Nota: Esto NO crea una nueva lista inmediata ni itera sobre los datos.
//          Solo guarda la "receta" de cómo filtrar.
var mayoresA5 = numeros.Where(n => n > 5);

// 4. Llamamos a Mostrar con 'mayoresA5'.
//    Aquí es donde LINQ ejerce la ejecución diferida: itera sobre 'numeros',
//    aplica el filtro y devuelve los elementos que cumplen la condición.
//    Resultado esperado: 10 7 11
Mostrar(mayoresA5);

// 5. Aplicamos el operador 'Reverse'.
//    Invierte el orden de la secuencia que recibe.
//    Importante: 'Reverse' es un operador de "materialización diferida".
//    No invierte nada todavía; solo define que el resultado debe ser el inverso.
var reversa = mayoresA5.Reverse();

// 6. Llamamos a Mostrar con 'reversa'.
//    Ejecuta la cadena: Primero filtra (>5), luego invierte el orden.
//    Resultado esperado: 11 7 10 (el orden original de los mayores pero ahora invertido)
Mostrar(reversa);

// 7. Aplicamos 'OrderBy'.
//    Clasifica la secuencia en orden ascendente (de menor a mayor).
//    Al igual que los anteriores, esto es solo una definición de regla.
var ordenada = reversa.OrderBy(n => n);

// 8. Llamamos a Mostrar con 'ordenada'.
//    Ejecuta la cadena completa: Filtra (>5) -> Invierte -> Ordena.
//    Resultado esperado: 7 10 11
Mostrar(ordenada);

// 9. Calculamos la suma de los elementos de la secuencia 'ordenada'.
//    La operación 'Sum' fuerza la iteración sobre la secuencia para sumar los valores.
var sumados = ordenada.Sum();

// 10. Calculamos el promedio de los elementos de la secuencia 'ordenada'.
//     La operación 'Average' fuerza otra iteración sobre la secuencia.
//     Nota: Como 'ordenada' es IEnumerable, al iterarlo dos veces (Sum y Average),
//           se recorre la fuente original dos veces, pero el resultado lógico es el mismo.
var promedioLista = ordenada.Average();

// 11. Imprimimos el resultado final de los cálculos.
//     Usamos interpolación de strings para formatear el promedio con 2 decimales.
Console.WriteLine($"Suma = {sumados} , promedio = {promedioLista:0.00}");
// Resultado esperado: Suma = 28 , promedio = 9.33

// 12. Definición del método genérico 'Mostrar'.
//     Recibe cualquier secuencia de tipo T.
void Mostrar<T>(IEnumerable<T> secuencia)
{
    // 13. El bucle 'foreach' es el "disparador" final.
    //     Cuando llegamos aquí, LINQ ejecuta todas las operaciones pendientes
    //     definidas en la cadena (Where, Reverse, OrderBy, etc.) paso a paso.
    foreach (T elemento in secuencia)
    {
        Console.Write(elemento + " ");
    }
    // 14. Salto de línea al finalizar la impresión de la secuencia.
    Console.WriteLine();
}

/*NOTAS:
Puntos clave de este ejercicio:
  1. Cadena de Transformaciones: Observar cómo mayoresA5, reversa y ordenada se construyen una encima de la otra. 
  Cada variable contiene una "consulta" que depende de la anterior.

  2. Ejecución Diferida en Acción: Si se quitan todas las llamadas a Mostrar y solo se ejecuta Sum() y Average(), 
  LINQ recorre la lista original numeros, filtra, invierte y ordena una sola vez para obtener los datos necesarios 
  para ambos cálculos (o dos veces si se llama a métodos que fuerzan iteraciones separadas, 
  aunque en este caso el compilador optimiza el flujo).

  3. Flujo de Datos:
    - Original: 1, 10, 7, 3, 11
    - Tras Where: 10, 7, 11
    - Tras Reverse: 11, 7, 10
    - Tras OrderBy: 7, 10, 11
    - Suma: 28
    - Promedio: 9.33
*/
