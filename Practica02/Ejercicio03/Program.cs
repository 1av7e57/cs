﻿/*Analizar la siguiente porción de código para calcular la sumatoria de 1 a 10. ¿Cuál es el error?
¿Qué hace realmente?

int sum = 0;
int i = 1;
while (i <= 10);    // El error está en esta línea, es el uso de ; después del bucle while
{
sum += i++;
}

Respuestas: 

¿Cuál es el error?

El uso de punto y coma (;) al final de la línea de while. En C#, las llaves { } cierran un bloque de código. 
El lenguaje ya sabe que el bloque terminó al encontrar la llave de cierre por lo que no es necesario usar punto y coma (;)

El error se produce aquí porque el punto y coma (;) innecesario actúa como una instrucción vacía, 
es decir que el cuerpo {} se convierte en un bloque independiente que no pertenece al bucle.
Esto significa que el bucle while se ejecutará infinitamente con una instrucción vacía, siempre y cuando i sea menor o igual a 10.

¿Qué hace realmente?

- Bucle Infinito (Freeze): El programa entra en el while, verifica si i <= 10 (lo cual es verdadero porque i es 1), 
y ejecuta el cuerpo vacío (la línea con el punto y coma).

- Ninguna actualizaci�n: Como el punto y coma termina el bucle inmediatamente, el código dentro de las llaves { sum += i++; } 
nunca se ejecuta como parte del bucle. Además, la variable i nunca se incrementa dentro del bucle.

- Resultado: El programa se queda "congelado" o en un bucle infinito (hang) en la línea del while, consumiendo CPU, 
y nunca llega a sumar nada ni a imprimir el resultado. La variable sum permanecerá en 0.

Código Corregido: 
*/

int sum = 0;    // sum Es la variable que se usará para almacenar el resultado de la suma, que se estará acumulando en cada iteración.
int i = 1;      // i Es el iterador, se encarga de recorrer los números del 1 al 10. Su valor es independiente de la suma total.

while (i <= 10) // Se eliminó el punto y coma aquí

{
    sum += i;   // Se suma el valor actual de i a la variable sum
    i++;        // Se incrementa i en 1
}

/*Nota: En el código original, la lógica sum += i++; funciona correctamente en C# (suma el valor actual y luego incrementa), 
pero es más legible separar la suma y el incremento de esta manera.*/

Console.WriteLine($"El bucle terminó cuando i valía: {i}");     // Salida: El bucle terminó cuando i valía: 11
                                                                //  (cuando la condición i menor o igual a 10 pasa a ser falsa)

Console.WriteLine($"El resultado final de la suma es: {sum}");  // El resultado impreso será 55, 
                                                                // que es la suma de todos los enteros del 1 al 10 (1+2+3+4+5+6+7+8+9+10),
                                                                // como resultado del proceso que se da en sum += i durante cada iteración
