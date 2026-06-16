﻿/*Comprobar el funcionamiento del siguiente programa y dibujar el estado de la pila y la memoria
heap cuando la ejecución alcanza los puntos indicados (comentarios en el código)*/

using System.Text; // Necesario para StringBuilder
object[] v = new object[10]; // Array de referencias nulas (como 10 flechas que no apuntan a nada todavía)

// Crea un objeto (instancia de StringBuilder)
// Agregamos el texto "Net" y lo asignamos a la primera posición (índice 0) del array
// Nota: StringBuilder es un tipo de referencia, por lo que solo guardamos la dirección de memoria aquí.
v[0] = new StringBuilder("Net"); 

// Bucle for: Bucle que asigna la referencia del elemento anterior a la posición actual
// Al final son 10 flechas que señalan al MISMO objeto.
for (int i = 1; i < 10; i++)
{
    // Aquí v es el contenedor.
    // A la izquierda: se está guardando en la celda 'i'.
    // A la derecha: se está leyendo la referencia de la celda 'i-1'.
    // La 'flecha' actual (i) ahora apunta al mismo lugar que la 'flecha' anterior (i-1)
    v[i] = v[i - 1]; // En la primera iteración se lee la referencia de la celda 0 (que contiene "Net") y se guarda en la celda 1 y así sucesivamente ... 
}

// Modificación: Accede al objeto en la posición 5, lo castea a StringBuilder e inserta "Framework . " al inicio (índice 0)
// Como todas las 'flechas' apuntan al mismo objeto, este cambio se refleja en TODAS las posiciones del array.

(v[5] as StringBuilder)!.Insert(0, "Framework .");

// Recorre el array e imprime cada elemento
// Dado que todos son la misma referencia, imprimirá "Framework .Net" 10 veces.
foreach (StringBuilder s in v)
    Console.WriteLine(s);

/* PUNTO 1:

      STACK (Pila)                        HEAP (Montículo)
+----------------+                 +-----------------------+
| Variable 'v'   | --------------->|  Array 'v' (objeto)   |
| (Referencia)   |      0x100      |  +---+---+---+---+...+ |
+----------------+                 |  | 0 | 1 | 2 | 3 |...| |
                                   |  +---+---+---+---+...+ |
                                   |  | 0 | 0 | 0 | 0 |...| | <--- Todos apuntan a 0x200
                                   |  | x | x | x | x |...| |
                                   |  +---+---+---+---+...+ |
                                   +-----------+-----------+
                                               |
                                               | (Todas las flechas del array)
                                               v
                                   +-----------------------+
                                   | StringBuilder Objeto 1|
                                   | Dirección: 0x200      |
                                   | Contenido: "Framework |
                                   |       .Net"           |
                                   +-----------------------+

Explicación:
- La variable v en la Stack apunta al Array en el Heap (dirección 0x100).
- El Array tiene 10 celdas. Todas contienen la misma dirección (0x200).
- En el Heap, solo existe 1 objeto StringBuilder. Su contenido ha sido modificado a "Framework .Net".
- Como todas las celdas del array apuntan a este mismo objeto, cualquier lectura en cualquier índice devuelve "Framework .Net".

*/

Console.WriteLine("\n================================================\n"); // Imprimimos un separador


// Crea una NUEVA instancia de StringBuilder con el texto "CSharp" y la asigna a la posición 5
// Esto rompe la referencia compartida.
// Ahora, cambiamos la flecha número 5 para que apunte a un NUEVO objeto.
v[5] = new StringBuilder("CSharp");

// Recorre el array nuevamente e imprime cada elemento
// imprimirá "CSharp" en la posición modificada (posición 5 empezando desde 0 ).
// El resto de las posiciones imprimirán "Framework .Net" (el estado del objeto original).
foreach (StringBuilder s in v)
    Console.WriteLine(s);

/* PUNTO 2:

      STACK (Pila)                        HEAP (Montículo)
+----------------+                 +-----------------------+
| Variable 'v'   | --------------->|  Array 'v' (objeto)   |
| (Referencia)   |      0x100      |  +---+---+---+---+...+ |
+----------------+                 |  | 0 | 1 | 2 | 3 |...| |
                                   |  +---+---+---+---+...+ |
                                   |  | 0 | 0 | 0 | 0 |...| | <--- Apuntan a 0x200
                                   |  | x | x | x | x |...| |
                                   |  +---+---+---+---+...+ |
                                   |  | 5 | 6 | 7 | 8 | 9 | |
                                   |  +---+---+---+---+...+ |
                                   |      |                |
                                   |      | (Nueva flecha) |
                                   +------|----------------+
                                          v
                                   +-----------------------+
                                   | StringBuilder Objeto 2|
                                   | Dirección: 0x300      |
                                   | Contenido: "CSharp"   |
                                   +-----------------------+
                                          ^
                                          |
                                   +-----------------------+
                                   | StringBuilder Objeto 1|
                                   | Dirección: 0x200      |
                                   | Contenido: "Framework |
                                   |       .Net"           |
                                   +-----------------------+
                                          ^
                                          |
                                   (Todas las otras celdas 0,1,2,3,4,6,7,8,9
                                    siguen apuntando aquí)

Explicación:
- La variable v sigue apuntando al mismo Array (0x100).
- Cambio clave: La celda v en la posición 5 ahora contiene una dirección diferente (0x300).
- En el Heap ahora hay 2 objetos:
    Objeto 1 (0x200): Contiene "Framework .Net". Es apuntado por las celdas 0, 1, 2, 3, 4, 6, 7, 8, 9.
    Objeto 2 (0x300): Contiene "CSharp". Es apuntado únicamente por la celda 5.
- Esto demuestra visualmente cómo v[5] = new ... rompe la "cadena de flechas" solo para esa posición específica, dejando a las demás intactas.

*/
