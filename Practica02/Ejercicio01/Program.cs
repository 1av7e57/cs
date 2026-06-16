﻿/*¿Qué líneas del siguiente código provocan conversiones boxing y unboxing.?*/

char c1 = 'A';           // 1. Definición de tipo valor (char) en el stack.
string st1 = "A";        // 2. Definición de tipo referencia (string) en el heap.
object o1 = c1;          // 3. → BOXING: Conversión de char (valor) a object (referencia).
object o2 = st1;         // 4. Asignación de referencia. NO es boxing.
char c2 = (char)o1;      // 5. → UNBOXING: Conversión de object (que contiene char) a char.
string st2 = (string)o2; // 6. Cast de referencia. NO es unboxing.

/*Respuesta: 
- char c1 = 'A';: c1 es un tipo de valor. Se almacena directamente en la pila (stack).
- string st1 = "A";: st1 es un tipo de referencia. st1 es una referencia a un objeto en el montículo (heap).
- object o1 = c1;: BOXING:
    Aquí se está asignando un char (tipo de valor) a una variable de tipo object.
    El CLR debe crear un nuevo objeto en el heap, copiar el valor de c1 allí y que o1 apunte a ese nuevo objeto. Esto genera una asignación de memoria y un costo de rendimiento.
- object o2 = st1;: NO es Boxing.
    string ya es un tipo de referencia. Simplemente se está copiando la referencia de st1 a o2. Ambos apuntan al mismo objeto en el heap. No hay creación de nuevos objetos ni conversión de valor a referencia.
- char c2 = (char)o1;: UNBOXING:
    Estás extrayendo un char de la variable o1 (que es un object).
    El CLR verifica en tiempo de ejecución que el objeto dentro de o1 sea realmente un char. Si es así, copia el valor desde el heap de vuelta a la variable c2 en el stack. También tiene un costo de rendimiento.
- string st2 = (string)o2;: NO es Unboxing. Esto es un cast de referencia (cast de herencia):
    Como string hereda de object, simplemente se verifica que el objeto sea una string y se asigna la referencia a st2. No hay extracción de valores ni copias de memoria entre stack y heap.
*/
