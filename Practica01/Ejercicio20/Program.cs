﻿/*Analizar el siguiente código. ¿Cuál es la salida por consola?*/

int i = 1;
if (--i == 0)
{
Console.WriteLine("cero");
}
if (i++ == 0)
{
Console.WriteLine("cero");
}
Console.WriteLine(i);

/*Respuesta: la salida por consola será:
cero
cero
1

¿Por qué ocurre esto?
- Inicialización: int i = 1; La variable i comienza con el valor 1.
- Primer if (--i == 0):
    El operador --i es un decremento PREVIO (notar que '--' está antes que 'i'). Primero resta 1 a i, y luego usa el nuevo valor para la comparación.
    i pasa de 1 a 0.
    La condición se evalúa como 0 == 0, que es verdadero (true).
    Acción: Se ejecuta Console.WriteLine("cero");.
- Segundo if (i++ == 0):
    Ahora i vale 0.
    El operador i++ es un incremento POSTERIOR (notar que 'i' está antes que '++'). Primero usa el valor actual de i para la comparación, y después suma 1 a i.
    La comparación usa el valor 0 (antes de incrementarse).
    La condición se evalúa como 0 == 0, que es verdadero (true).
    Acción: Se ejecuta Console.WriteLine("cero");.
    Efecto secundario: Inmediatamente después de la comparación, i se incrementa y pasa de 0 a 1.
- Última línea (Console.WriteLine(i);):
    Se imprime el valor actual de i, que es 1.

Conclusión:
La clave aquí es entender la diferencia entre pre-incremento/decremento (el operador está antes de la variable, se modifica antes de usar) 
y post-incremento/decremento (el operador está después, se usa el valor actual y luego se modifica).
--i (Pre-decremento): Primero cambia el valor, luego lo usa.
i++ (Post-incremento): Primero usa el valor actual, luego lo cambia.
*/
