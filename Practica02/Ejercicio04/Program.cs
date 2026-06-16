﻿/*¿Qué hace la siguiente instrucción?
¿Asigna a la variable vector el valor null?

// int[]? vector = new int[0];

Respuestas:

¿Qué hace la instrucción? 
Esta instrucción declara una variable llamada vector que puede almacenar un arreglo de enteros (int[]) o ser null (gracias al signo ?), 
y le asigna inmediatamente un nuevo arreglo de enteros con longitud cero (new int).
En resumen, se está creando un arreglo vacío (sin elementos) y asignándolo a la variable.

¿Asigna a la variable vector el valor null? 
No. Aunque el tipo de la variable (int[]?) permite que sea nula (es una referencia nullable), en esta línea específica no se le asigna null.
Se le asigna una instancia válida de un arreglo (new int). New int crea un objeto de tipo arreglo que tiene 0 elementos. 
No es lo mismo que null; es un objeto real en memoria, solo que vacío.

Para que vector fuera null, la línea tendría que ser:
int[]? vector = null;



Nota: una manera alternativa de escribir esta línea sería:*/

int[]? vector = Array.Empty<int>(); // Declaración y asignación en una línea, al igual que en el ejemplo

/*Ya que al escribir new int en el código original se está creando una nueva instancia de un arreglo en la memoria del sistema cada vez que se ejecuta esa línea,
si se hace esto muchas veces, se estaría generando "basura" (objetos basura) que el Garbage Collector tendría que limpiar, lo cual puede consumir recursos innecesarios.
- La alternativa: Array.Empty<int>() devuelve una referencia a una única instancia estática de un arreglo vacío que ya existe en memoria.
- Beneficio: En lugar de crear un arreglo nuevo, simplemente se apunta a un arreglo "compartido" y seguro que ya existe. 
Esto puede resultar mucho más eficiente en rendimiento y memoria.
*/
