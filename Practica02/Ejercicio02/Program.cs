﻿/*Sea el siguiente código:
El tipo object es un tipo referencia, por lo tanto luego de la sentencia o2 = o1 ambas
variables están apuntando a la misma dirección. ¿Cómo explica entonces que el resultado en la
consola no sea “Z Z”?*/

object o1 = "A";                  // Paso 1: Se crea el objeto de cadena "A" en el Heap. o1 apunta a él.
object o2 = o1;                   // Paso 2: o2 copia la dirección de o1. ¡Ambos apuntan al "A"!
o2 = "Z";                         // Paso 3: El compilador crea un nuevo objeto de cadena "Z" en una nueva dirección de memoria en el Heap.
                                  // La variable o2 deja de apuntar a la dirección del "A" y ahora apunta a la nueva dirección del "Z".

Console.WriteLine(o1 + " " + o2); // Paso 4: Se imprime: "A Z" en la consola

/*Respuesta: ¿Por qué no se imprime "Z Z"?

La clave está en tener en cuenta que las cadenas (strings "") son inmutables, al igual que lo son los caractéres (chars '').

La confusión surge de pensar que o2 = "Z" modifica el contenido del objeto al que apunta o2. 
Pero como las cadenas son inmutables (no se pueden cambiar), el compilador NO puede alterar el "A" existente en el Heap para convertirlo en un "Z".

Lo que realmente sucede es esto:

- Creación de nuevo objeto: El compilador crea un nuevo objeto de cadena "Z" en una nueva dirección de memoria en el Heap.
- Reasignación de referencia: La variable o2 deja de apuntar a la dirección del "A" y ahora apunta a la nueva dirección del "Z".
- o1 permanece intacto: La variable o1 sigue apuntando a la dirección original del "A". No se modifica.

Visualización Gráfica:

Antes de o2 = "Z":

   Stack           Heap
+-------+       +-----------+
| o1    | ----> | "A"       |
+-------+       +-----------+
| o2    | ----> | (Misma dirección)
+-------+

Después de o2 = "Z":

   Stack           Heap
+-------+       +-----------+
| o1    | ----> | "A"       |  <-- o1 sigue aquí
+-------+       +-----------+
| o2    | ----> | "Z"       |  <-- o2 apunta a un NUEVO lugar
+-------+       +-----------+

Como se puede apreciar, o1 y o2 ya no apuntan al mismo lugar. 
o1 mantiene el valor original "A" y o2 apunta al nuevo valor "Z". 
Por eso, al final la consola imprime: "A Z".

*/
