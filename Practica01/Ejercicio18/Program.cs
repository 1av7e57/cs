﻿/*Para cada una de las siguientes líneas de código verificar cuáles son permitidas por el
compilador y en tal caso en qué estado quedan las variables involucradas en la declaración al
ejecutarse:*/

// 1. int a, b, c;
// ✅ VÁLIDO.
// Estado: Las variables a, b y c se declaran como int pero no se inicializan.
// En un método local, su valor es indefinido hasta que se les asigne algo.
// Si son campos de una clase, se inicializan automáticamente en 0.
int a, b, c;

// 2. int a; int b; int c, d;
// ✅ VÁLIDO. Estado: a, b, c, d = indefinidos (o 0 si son campos).
int a; int b; int c, d;

// 3. int a = 1; int b = 2; int c = 3;
// ✅ VÁLIDO. Estado: a=1, b=2, c=3.
int a = 1; int b = 2; int c = 3;

// 4. int b; int c; int a = b = c = 1;
// ❌ INVÁLIDO. Error: "Use of unassigned local variable 'b'" (no se puede leer 'b' antes de asignarla).
// en C# no se puede usar una variable no inicializada (b) en una expresión de asignación
// int a = b = c = 1; // Error

// 5. int c; int a, b = c = 1;
// ✅ VÁLIDO. Estado: c=1 (asignado en expresión), b=1, a=indefinido.
int c; int a, b = c = 1;

// 6. int c; int a = 2, b = c = 1;
// ✅ VÁLIDO. Estado: c=1, b=1, a=2.
int c; int a = 2, b = c = 1;

// 7. int a = 2, b, c, d = 2 * a;
// ✅ VÁLIDO. Estado: a=2, b=indefinido, c=indefinido, d=4.
int a = 2, b, c, d = 2 * a;

// 8. int a = 2, int b = 3, int c = 4;
// ❌ INVÁLIDO. Error: Sintaxis incorrecta (no repetir 'int' en declaración múltiple).
// int a = 2, int b = 3, int c = 4; // Error

// 9. int a = 2; b = 3; c = 4;
// ❌ INVÁLIDO. Error: 'b' y 'c' no declaradas en este contexto.
// b = 3; c = 4; // Error si no existen antes.

// 10. int a; int c = a;
// ❌ INVÁLIDO. Error: "Use of unassigned local variable 'a'" (no se puede leer 'a' antes de asignarla).
// int c = a; // Error

// 11. char c = 'A', string st = "Hola";
// ❌ INVÁLIDO. Error: No se pueden mezclar tipos (char y string) en una sola declaración.
// char c = 'A', string st = "Hola"; // Error

// 12. char c = 'A'; string st = "Hola";
// ✅ VÁLIDO. Estado: c='A', st="Hola".
char c = 'A'; string st = "Hola";

// 13. char c = 'A', st = "Hola";
// ❌ INVÁLIDO. Error: Conversión implícita de string a char no permitida (st hereda tipo char).
// char c = 'A', st = "Hola"; // Error
