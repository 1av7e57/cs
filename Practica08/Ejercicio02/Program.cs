﻿/*¿Qué obtiene un método anónimo (o expresión lambda) cuando accede a una variable definida en
el entorno que lo rodea, una copia del valor de la variable o la referencia a dicha variable? Tip:
Observar la salida por consola del siguiente código:
*/

// Definimos la variable 'i' en el ámbito local con valor inicial 10
int i = 10;

// Creamos un delegado 'Action' que asigna un método anónimo.
// Este método captura la variable 'i' por referencia (no por valor).
Action a = delegate ()
{
    // Accedemos al valor actual de 'i' a través de la referencia capturada
    Console.WriteLine(i);
};

// Primera invocación: 'i' es 10, por lo tanto imprime: 10
a.Invoke();

// Modificamos la variable original 'i' en el ámbito externo.
// Como el delegado tiene una referencia a 'i', este cambio es visible dentro del método.
i = 20;

// Segunda invocación: Ahora 'i' es 20.
// El delegado imprime el nuevo valor porque lee la variable actual, no una copia antigua.
// Por lo tanto imprime: 20
a.Invoke();

// Salida esperada:
// 10
// 20

/*NOTAS:
Respuesta:
Al acceder a una variable definida en el entorno que lo roder, el método anónimo (o expresión lambda) 
obtiene la referencia a dicha variable.

Los delegados que capturan variables de su entorno (lo que se conoce como closure o clausura) 
NO toman una copia del valor en el momento de la creación. En su lugar, capturan una referencia 
a la variable original almacenada en el stack (o en un objeto generado por el compilador en el heap).

Esto explica la salida que se observa:
- Primera llamada (a.Invoke()): La variable i tiene el valor 10, por lo que imprime 10.
- Modificación (i = 20): Se cambia el valor de la variable original i a 20.
- Segunda llamada (a.Invoke()): Como el delegado tiene una referencia a i, ve el nuevo valor 20 e imprime 20.

Si se hubiera capturado una copia del valor, la segunda impresión habría sido 10, 
ya que la copia NO se habría visto afectada por el cambio posterior de i.

Este comportamiento es crucial en C# porque permite que los delegados mantengan 
el estado actual de las variables del ámbito donde fueron definidos, 
incluso después de que ese ámbito haya terminado su ejecución (la variable se "eleva" al heap).
*/
