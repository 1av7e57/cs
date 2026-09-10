﻿// Inicializamos la variable 'a' con el valor entero 17
int a = 17;

// Inicializamos la variable 'b' con el valor entero 23
int b = 23;

// Llamamos al método Swap pasando las variables 'a' y 'b' por referencia (ref)
// Esto permite que el método modifique los valores originales en su lugar
Swap(ref a, ref b);

// Imprimimos en consola los valores resultantes después del intercambio
// Se espera que a=23 y b=17
Console.WriteLine($"a={a} y b={b}");

// Definición del método Swap
// Está estrictamente tipado para manejar solo variables de tipo 'int'
// El modificador 'ref' indica que se reciben referencias a las variables, no copias
void Swap(ref int i, ref int j)
{
    // Creamos una variable temporal 'auxiliar' para almacenar el valor de 'i'
    // Esto es necesario para no perder el dato original al sobrescribir 'i'
    int auxiliar = i;

    // Asignamos el valor de 'j' a 'i', completando la primera mitad del intercambio
    i = j;

    // Asignamos el valor guardado en 'auxiliar' (que era el original de 'i') a 'j'
    // Con esto, el intercambio de valores se ha completado
    j = auxiliar;
}

/*NOTAS:
Análisis del enfoque actual (No Genérico)

Ventajas:
    -Sencillez: Es muy fácil de entender y leer para un solo tipo.
    -Rendimiento: Al ser un tipo de valor (int), no hay overhead de referencias en este caso específico.

Limitaciones y Problemas:
    -Falta de Reutilización: Si mañana se necesitara intercambiar dos variables de tipo double, string, 
    o un objeto personalizado Cliente, se tendría que escribir otro método idéntico cambiando solo el tipo:
        void Swap(ref double i, ref double j) { ... }
        void Swap(ref string i, ref string j) { ... }
    Esto violaría el principio DRY (Don't Repeat Yourself).

    -Mantenimiento: Si se encuentra un bug en la lógica de intercambio (por ejemplo, si se quisiera añadir un log o una validación), 
    tendría que corregirse en cada versión del método para cada tipo.

    -Seguridad de Tipos: Si se intenta pasar un int y un double por error, el compilador lo impedirá 
    (lo cual es bueno), pero la rigidez impide crear una solución única que acepte cualquier tipo compatible.
*/
