/*Comprobar el funcionamiento del siguiente fragmento de código, analizar el resultado y contestar las preguntas:
a)¿Qué se puede concluir respecto del operador de división “/” ?
b)¿Cómo funciona el operador + entre un string y un dato numérico?*/

// Aquí 10 y 3 son literales enteros (int)
// En C#, int / int resulta en int. La parte decimal se trunca (no se redondea).
// Resultado: 3.
// La operación de concatenación usando + para unir el string "10/3 = " con el número resultante de la operación (3)
Console.WriteLine("10/3 = " + 10 / 3);
// 10.0 es un literal double. Al haber un double en la operación, C# promueve el 3 a double también.
// Resultado: 3.3333333333333335 (aprox).
Console.WriteLine("10.0/3 = " + 10.0 / 3);
// 3.0 es un double. El 10 se promueve a double.
// Resultado: 3.3333333333333335 (aprox).
Console.WriteLine("10/3.0 = " + 10 / 3.0);
// Aquí se usan variable para almacenar los valores numéricos
// Al igual que en el primer caso, es división entera.
// Resultado: 3.
int a = 10, b = 3;
Console.WriteLine("Si a y b son variables enteras, si a=10 y b=3");
Console.WriteLine("entonces a/b = " + a / b);
// Se declara la variable c como double
double c = 3;
Console.WriteLine("Si c es una variable double, c=3");
// C# convierte la variable a en double para realizar la operación.
// Resultado: 3.3333333333333335 (aprox).
Console.WriteLine("entonces a/c = " + a / c);

/*Respuestas:

a) ¿Qué se puede concluir respecto del operador de división “/” ?
En C#, el operador de división / es sensitivo al tipo de dato de sus operandos:
- División Entera: Si ambos operandos son enteros (int, long, etc.), el resultado es un entero. La parte decimal se descarta (truncamiento hacia cero).
  Ejemplo: 10 / 3 resulta en 3, no 3.33.
- División en Punto Flotante: Si al menos uno de los operandos es de tipo decimal (float, double, decimal), el resultado será de ese tipo decimal, conservando la fracción.
  Ejemplo: 10.0 / 3 o 10 / 3.0 resultan en 3.333....
Conclusión: Para obtener un resultado decimal en C#, al menos uno de los números debe ser declarado o escrito como un tipo de punto flotante (ej. 10.0 o 3.0), o hacer un casting explícito (double)a / b.

b) ¿Cómo funciona el operador + entre un string y un dato numérico?
En C#, el operador + tiene un comportamiento sobrecargado dependiendo de los tipos involucrados:
- Si al menos uno de los operandos es un string: El operador + funciona como operador de concatenación.
- Conversión implícita: C# convierte automáticamente el operando numérico a su representación en texto (llamando implícitamente a .ToString()) y lo une al string.
En el código: "10/3 = " + 10 / 3
Primero se evalúa la división 10 / 3 (que da 3).
Luego se concatena: "10/3 = " + 3 → "10/3 = 3".
- Diferencia importante de orden de operaciones: El operador / (división) tiene mayor precedencia que el operador + (concatenación). 
Por eso, en "10/3 = " + 10 / 3:
Si se quisiera concatenar primero (lo cual no tendría sentido matemático aquí pero es posible), tendría que usarse paréntesis: "10/3 = " + (10 / 3).
*/
