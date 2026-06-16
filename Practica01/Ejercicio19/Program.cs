﻿/*¿Cuál es el problema del código siguiente y cómo se soluciona?

int i = 0;
for (int i = 1; i <= 10;)
{
Console.WriteLine(i++);
}

Respuesta: los problemas principales son: 

- Repetición de variable i: Se declara int i = 0; antes del bucle, y luego dentro del for se intenta declarar int i = 1; de nuevo. 
En C#, esto genera un error de compilación porque la variable i ya existe en ese ámbito.

- Lógica del incremento: Aunque i++ dentro de Console.WriteLine funciona, es más limpio y convencional poner el incremento 
en la parte de actualización del for (tercera sección) para evitar confusión, aunque la sintaxis actual es técnicamente válida 
si se corrige el punto anterior.

Código corregido:
*/

// Opción 1: Eliminar la declaración inicial redundante
for (int i = 1; i <= 10; i++) // Se coloca el incremento 'i++' en la tercera sección del bucle for
{
    Console.WriteLine(i);
}

/*
// Opción 2: Si se necesita usar la variable fuera del bucle, declarar 'i' antes
// pero NO debe redeclarse dentro del for
int i = 0; 
for (i = 1; i <= 10; i++) // Notar que usamos la asignación 'i = 1' dentro del for pero NO 'int i = 1' (que sería la redeclaración)
{
    Console.WriteLine(i);
}
*/

/*En ambas opciónes la salida en consola es igual:
1
2
3
4
5
6
7
8
9
10
*/
