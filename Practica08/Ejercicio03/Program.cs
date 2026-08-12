﻿/*Teniendo en cuenta lo respondido en el ejercicio anterior, 
¿Qué salida produce en la consola la ejecución del siguiente programa?
*/

// 1. Declaración del contenedor
// Creamos un array de 10 delegados de tipo Action (Array de 10 slots vacíos en este momento de creación)
// Nota: El tipo de dato Action es un delegado genérico que no toma parámetros y no devuelve nada (void).
Action[] acciones = new Action[10];

// Bucle for: La variable 'i' se declara AQUÍ.
// En C#, la variable de control del bucle 'for' se comparte en todas las iteraciones
// si se captura en un cierre. Es una sola variable en memoria.
for (int i = 0; i < 10; i++)
{
    // 2. Asignación (Aquí se crea el objeto delegado real)
    // Asignamos un lambda al índice i del array.
    // NOTA: esto equivale a la Sintaxis delegate (Antigua):
    // acciones[i] = delegate(int x) { Console.WriteLine(x); };
    // El lambda captura la variable 'i' POR REFERENCIA.
    // No guarda el valor de 'i' (0, luego 1, luego 2...), guarda la dirección de 'i'.
    acciones[i] = () => Console.WriteLine(i + " ");
    //                  ^^^^^^^^^^^^^^^^^^^^^^^^^^^ Cuerpo del método.

}

// Una vez que el bucle termina, la variable 'i' tiene el valor 10.
// (El bucle se detiene cuando i es 10, porque 10 < 10 es falso).

// Recorremos el array de acciones
foreach (var a in acciones)
{
    // 3. Invocación (Ejecuta el cuerpo del método guardado)
    // Al invocar, cada delegado lee el valor ACTUAL de la variable 'i'.
    // Como todos apuntan a la misma variable 'i', y su valor es 10,
    // todos imprimen "10 ".
    a.Invoke();
}

// Salida observada:
// 10 
// 10 
// 10 
// 10 
// 10 
// 10 
// 10 
// 10 
// 10 
// 10

/*NOTAS:
Respuesta:
    La salida es diez veces el número 10.

¿Por qué ocurre esto?
    Al igual que en el ejercicio anterior, el delegado captura la referencia a la variable i, 
    no su valor en el momento de la creación del delegado.

    - El Bucle for: En cada iteración, se crea un delegado que apunta a la misma variable i 
    (la variable del bucle i es una sola en memoria).
    - Final del Bucle: Cuando el bucle termina, la variable i tiene el valor 10 (porque la condición i < 10 falló cuando i llegó a 10).
    - Ejecución: Cuando se invocan los delegados dentro del foreach, cada uno de ellos lee 
    el valor actual de la variable i, que ya es 10. Como todos comparten la misma referencia a esa única variable, 
    todos imprimen 10.

Esto es un clásico "problema de cierre" en C# (y otros lenguajes). 
Si se quisiera que cada delegado capturara el valor actual de i en cada iteración (0, 1, 2... 9), 
se necesitaría crear una variable local temporal dentro del bucle para que cada iteración tenga su propia 
copia en memoria.

Simulación Paso a Paso:
1. Fase de Creación (El Bucle for):
    En este momento, el programa recorre del 0 al 9. 
    Lo crucial es entender que la variable i es única. 
    No se crea una nueva i por cada iteración; es la misma variable que se actualiza.

    Iteración	Valor de i en este momento	Acción realizada	Estado de los delegados en memoria
    i = 0	    0	                        Crea acciones[0]	acciones[0] apunta a la variable i (valor actual 0)
    i = 1	    1	                        Crea acciones[1]	acciones[1] apunta a la variable i (valor actual 1)
    ...	        ...	                        ...	                ...
    i = 9	    9	                        Crea acciones[9]	acciones[9] apunta a la variable i (valor actual 9)

    Punto clave: Todos los delegados (acciones[0] a acciones[9]) guardan la dirección de memoria de la variable i. 
    No guardan los números 0, 1, 2... guardan el "lugar (en memoria)" donde está i.

2. Fin del Bucle (i llega a 10)
    El bucle intenta hacer i++ (hacer 10) y verifica i < 10. Como 10 < 10 es falso, el bucle termina.
    Estado final de i en memoria: 10.

3. Fase de Ejecución (foreach)
    Ahora el programa ejecuta los delegados uno por uno. 
    Como todos apuntan a la misma dirección de memoria (i), 
    todos leen el valor que tiene i en ese preciso instante.

    Acción Invocada	        ¿Qué lee?	        Valor leído (en memoria)	Salida en consola
    acciones[0].Invoke()	Lee la variable i	10	                        10 
    acciones[1].Invoke()	Lee la variable i	10	                        10 
    acciones[2].Invoke()	Lee la variable i	10	                        10 
    ...	                    ...	                ...	                        ...
    acciones[9].Invoke()	Lee la variable i	10	                        10 

Conclusión:
    - El error comùn: Pensar que cada delegado "congeló" el valor de i en ese momento.
    - La realidad: El delegado es una "ventana" a la variable i. Si i cambia, la ventana muestra el nuevo valor.
    - La solución: Crear una variable local (int j = i;) dentro del bucle obliga al compilador 
    a crear una nueva instancia de variable para cada iteración, rompiendo la referencia compartida.

Posible alternativa (para mostrar los distintos valores de i):

    // Creamos el array de 10 delegados
    Action[] acciones = new Action[10];

    // Bucle for: La variable 'i' es compartida, pero...
    for (int i = 0; i < 10; i++)
    {
        // SOLUCIÓN: Declaramos una variable local 'j' DENTRO del bucle.
        // El compilador de C# crea una INSTANCIA NUEVA de 'j' para CADA iteración.
        // Esto rompe la referencia compartida.
        int j = i; 

    // Aquí hacemos que el lambda capture la referencia a 'j'.
    // No se captura la referencia a la variable 'i' (que es compartida), 
    // sino la referencia a la variable 'j' que es distinta, al ser creada 
    // nuevamente en cada iteración con un valor único.
        acciones[i] = () => Console.WriteLine(j + " ");
    }

    // El bucle ha terminado. 'i' vale 10, pero eso ya no importa.
    // Cada delegado tiene su propia copia de 'j' guardada en memoria.

    // Ejecutamos los delegados
    foreach (var a in acciones)
    {
        a.Invoke();
    }

    // SALIDA ESPERADA:
    // 0 
    // 1 
    // 2 
    // 3 
    // 4 
    // 5 
    // 6 
    // 7 
    // 8 
    // 9 
*/
