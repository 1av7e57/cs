﻿// 1. Instancia de Par especificando explícitamente que T1 es int y T2 es int.
// El compilador sabe que aquí A y B serán enteros.
Par<int, int> p1 = new Par<int, int>(1, 15);

// Imprime los valores de A y B.
Console.WriteLine($"A = {p1.A} y B = {p1.B}");

// Suma A + B.
Console.WriteLine($"A + B = {p1.A + p1.B} ");

// 2. Instancia de Par con tipos diferentes: T1 es string y T2 es double.
// Esto demuestra la flexibilidad de los genéricos: la misma clase maneja tipos distintos.
Par<string, double> p2 = new Par<string, double>("ABC", 123);

// Imprime los valores. A es texto, B es número decimal.
Console.WriteLine($"A = {p2.A} y B = {p2.B}");

// IMPORTANTE:
// El operador '+' aquí actúa como concatenación de cadenas.
// C# convierte automáticamente el double (123) a string ("123") y concatena con "ABC".
// Resultado: "ABC123"
Console.WriteLine($"A + B = {p2.A + p2.B} "); 

/*NOTAS:
El programa define una clase genérica Par<T1, T2> capaz de almacenar dos valores de cualquier tipo 
(incluso tipos diferentes entre sí).
-Crea un par de enteros (p1) y muestra sus valores y su suma.
-Crea un par mixto (p2) con un texto y un número, y muestra sus valores.
-Concatena ambos valores diferentes como un string y los imprime.

Aclaración: En C#, el operador + tiene sobrecarga implícita para concatenación de cadenas. 
Cuando el compilador encuentra una expresión como:
    Console.WriteLine($"A + B = {p2.A + p2.B}");
Donde p2.A es un string y p2.B es un double, el compilador NO intenta sumar matemáticamente string + double. 
En su lugar:
    -Reconoce que uno de los operandos es un string.
    -Aplica la regla de concatenación: convierte automáticamente el double (123) a su representación de texto ("123").
    -Realiza la concatenación: "ABC" + "123" = "ABC123".
Por eso la salida es A + B = ABC123 (en lugar de provocar un error de compilación).

Ventajas:
    -Reutilización Máxima (DRY): con Par<T1, T2> escribimos la lógica de la clase una sola vez. 
    Ahora podemos usarla para Par<int, int>, Par<string, double>, Par<DateTime, decimal>, etc., sin reescribir código.
    -Flexibilidad: La clase no está atada a un tipo específico. Se adapta a las necesidades del momento.
    -Seguridad de Tipos en Tiempo de Compilación: A diferencia de usar object, los genéricos mantienen el tipo fuerte. 
    Si se intenta asignar un string donde se espera un int, el compilador avisará inmediatamente.
    -Rendimiento: Evita el boxing y unboxing (conversión de tipos de valor a referencia) que ocurriría si usáramos object para almacenar tipos como int o double.
    -Comportamiento inteligente del operador + con cadenas (concatenación automática).

Puntos a tener en cuenta:
    -El operador + cambia de significado según los tipos:
        -int + int → suma matemática (16)
        -string + double → concatenación ("ABC123")
    Esto puede llevar a resultados inesperados si el desarrollador no está atento a los tipos.

    -Falta de validación de operación: La clase genérica no sabe si la operación + tiene sentido semánticamente 
    para los tipos usados. Podría concatenar "Precio: " con 99.99, lo cual tiene sentido, o intentar "ABC" + 123 
    en un contexto donde se espera una suma numérica.

    Dependencia del contexto: El significado de A + B depende completamente de los tipos de T1 y T2, 
    lo que puede dificultar el mantenimiento si los tipos cambian.

Lección Clave:
Los genéricos en C# son potentes porque:
-Mantienen la seguridad de tipos en tiempo de compilación.
-Permiten polimorfismo de tipos sin sacrificar rendimiento.
-Aprovechan las sobrecargas de operadores de C# de manera inteligente (como la concatenación automática).

Sin embargo, la flexibilidad requiere responsabilidad porque 
puede significar un costo en la seguridad de las operaciones.
como desarrollador, se debe ser consciente de cómo se comportarán 
las operaciones con diferentes tipos para evitar errores.
*/
