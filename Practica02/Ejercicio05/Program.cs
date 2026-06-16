﻿/*Analizar el siguiente código. ¿Qué líneas producen error de compilación y por qué?*/

char c;             // OK: Declaración de variable char (por valor)
char? c2;           // OK: Declaración de variable char nula (Nullable<char>)
string? st;         // OK: Declaración de variable string nula (si está habilitado Nullable Reference Types)

c = "";             // ERROR: No se puede convertir implícitamente de "string" a "char". "" es un string de 0 caracteres, no un char. La variable c se declaró antes como char.
c = '';             // ERROR: En C#, los literales de caractér deben usar comillas simples pero contener un carácter. '' está vacío. Se requiere un char como 'a'.
c = null;           // ERROR: c No puede ser null a menos que se declare como char? c; antes (No se usó ? en la declaración).

c2 = null;          // OK: c2 se declaró correctamente como char? c2; antes y por eso SI puede ser null (se usó ? en la declaración).

c2 = (65 as char?); // ERROR: No se puede usar el operador 'as' con el tipo 'int'.
                    // El operador 'as' solo funciona con tipos de referencia. int es un tipo de valor. 65 es int.                     

st = "";            // OK: Asignación de string literal.

st = '';            // ERROR: '' es un literal de caractér vacío, lo que es inválido en C#,
                    // Además, aquí se asigna a un string. No hay conversión implícita de char a string.

st = null;          // OK: string es un tipo de referencia y puede ser null (se declaró correctamente antes con string? st; ).

st = (char)65;      // ERROR: No se puede convertir implícitamente de 'char' a 'string'. Se necesita convertir explícitamente, ej: st = ((char)65).ToString();
                    // Nota: Aquí 65 es una variable de tipo 'char' que representa un ÚNICO carácter. Ese carácter específico es la letra mayúscula 'A' en ASCII/Unicode.
st = (string)65;    // ERROR: aquí 65 es un 'int', No se puede convertir explícitamente de 'int' a 'string'. No existe una conversión directa de int a string con cast.
                    // CORRECCIÓN: debería ser st = 65.ToString(); o st = Convert.ToString(65);

st = 47.89.ToString(); // OK: 47.89 es double, .ToString() devuelve un string, se asigna correctamente a st.
 
/* Puntos clave a recordar:
- char vs string: char es un tipo de valor que representa un solo carácter (ej. 'A'), mientras que string es un tipo de referencia para cadenas de texto (ej. "Hola").
- Literales: En C#, '' es inválido. Debe contener un carácter. Para strings vacíos se usa "".
- Anulables: Los tipos de valor (char, int, etc.) no pueden ser null a menos que se use '?' correctamente en la declaración. Ej; char? c;
- Operador as: Solo funciona con tipos de referencia o tipos anulables, no con tipos de valor como int directamente sin un cast previo.
- Conversión de tipos: No hay conversión implícita de char a string ni de int a string. Se deben usar métodos como .ToString() o Convert.ToString().
*/
