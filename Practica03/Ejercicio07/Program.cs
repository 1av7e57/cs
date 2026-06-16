/*¿Qué líneas del siguiente método provocan error de compilación y por qué?*/

// Inicialización de variables
var a = 3L;          // OK: 'a' es inferido como long (entero de 64 bits)
dynamic b = 32;      // OK: 'b' es dinámico, el tipo se resuelve en tiempo de ejecución
object obj = 3;      // OK: 'obj' es un objeto que contiene un entero (boxing)

// Operaciones matemáticas y asignaciones
a = a * 2.0;         // ERROR DE COMPILACIÓN: 
                     // 'a' es long. '2.0' es double. El resultado de long * double es double.
                     // C# no permite asignar implícitamente un double a un long (pérdida de precisión).
                     // Se requiere un cast explícito: a = (long)(a * 2.0);

b = b * 2.0;         // OK: 'b' es dynamic. La operación y la asignación se validan en tiempo de ejecución.
                     // Si el tipo en tiempo de ejecución soporta la operación, funciona.

b = "hola";          // OK: Al ser dynamic, puedes asignarle cualquier tipo de objeto.

obj = b;             // OK: Cualquier tipo se puede asignar a un 'object' (caja o conversión implícita).

b = b + 11;          // OK: dynamic. En tiempo de ejecución, b es "hola" (string).
                     // Intentará hacer "hola" + 11. En C#, esto funciona y resulta en "hola11" (concatenación).

obj = obj + 11;      // ERROR DE COMPILACIÓN:
                     // 'obj' es de tipo 'object'. El operador '+' no está definido para 'object' + int.
                     // El compilador no sabe si 'obj' es string, int, o algo más en tiempo de compilación.
                     // Se necesita hacer un cast: ((string)obj) + 11.

// Tipos anónimos (Anonymous Types)
// Son objetos que se caracterizan por agrupar múltiples propiedades
// de distintos tipos en una sola estructura inmutable
var c = new { Nombre = "Juan" };   
var d = new { Nombre = "María" };  
var e = new { Nombre = "Maria", Edad = 20 }; 
var f = new { Edad = 20, Nombre = "Maria" }; 

// Nota sobre tipos anónimos:
// Dos tipos anónimos son compatibles (intercambiables) SOLO si:
// 1. Tienen los mismos nombres de propiedades.
// 2. Tienen el mismo orden de propiedades.
// 3. Tienen los mismos tipos en esas propiedades.

f.Edad = 22;         // ERROR DE COMPILACIÓN: Las propiedades de tipos anónimos son de solo lectura.
                     // No se puede hacer f.Edad = 22.

d = c;               // OK. 'c' tiene propiedades { Nombre } (string).
                     //  y  'd' tiene propiedades { Nombre } (string).
                     // Por lo tanto: 'd' = 'c' es válido.
                     // Nota: Dado que los tipos anónimos son inmutables (sus propiedades no se pueden cambiar),
                     // no se puede modificar el valor de Nombre en ningún momento. Lo que se hace es cambiar
                     // a qué objeto apunta la variable. Por esto, tras la asignación d = c:
                     // ahora d.Nombre es "Juan" (porque d ahora referencia al mismo objeto que c)                   

e = d;               // ERROR DE COMPILACIÓN:
                     // 'e' tiene propiedades { Nombre, Edad }.
                     // 'd' tiene propiedades { Nombre }.
                     // Diferente número de propiedades. No se pueden asignar.

f = e;               // ERROR DE COMPILACIÓN:
                     // 'f' tiene propiedades { Edad, Nombre }
                     // 'e' tiene propiedades { Nombre, Edad }
                     // Aunque tienen las mismas propiedades, el ORDEN es diferente.
                     // No son compatibles.
