﻿/*Responder sobre el siguiente código:
--- Program.cs ---
AccionInt a1 = (ref int i) => i = i * 2;
a1 += a1;
a1 += a1;
a1 += a1;
int i = 1;
a1(ref i);
--- AccionInt.cs --- 
delegate void AccionInt(ref int i);

¿Cuál es el tamaño de la lista de invocación de a1 y cual es el valor de la variable i luego de la
invocación a1(ref i)?
*/

        // 1. Inicialización:
        // Creamos la primera instancia del delegado 'a1' con una lambda que duplica el valor.
        // En este punto, la lista de invocación tiene 1 método.
        AccionInt a1 = (ref int i) => i = i * 2;

        // 2. Primer concatenado (+=):
        // 'a1 += a1' crea un NUEVO delegado que contiene la lista anterior + la misma lambda.
        // Lista actual: [Duplicar, Duplicar] -> Tamaño: 2
        a1 += a1;

        // 3. Segundo concatenado (+=):
        // Toma el delegado actual (tamaño 2) y lo concatena consigo mismo.
        // Lista actual: [Duplicar, Duplicar, Duplicar, Duplicar] -> Tamaño: 4
        a1 += a1;

        // 4. Tercer concatenado (+=):
        // Toma el delegado actual (tamaño 4) y lo concatena consigo mismo.
        // Lista actual: [Duplicar, Duplicar, Duplicar, Duplicar, Duplicar, Duplicar, Duplicar, Duplicar] -> Tamaño: 8
        a1 += a1;

        // 5. Preparación de datos:
        // Iniciamos la variable 'i' con valor 1.
        // Nota: Es crucial que esto ocurra DESPUÉS de construir el delegado, 
        // pero ANTES de la invocación.
        int i = 1;

        // 6. Invocación:
        // Ejecutamos la lista de 8 métodos secuencialmente.
        // Como el parámetro es 'ref', cada método modifica la misma variable 'i' en memoria.
        // Orden de ejecución:
        //   1. i = 1 * 2  -> i = 2
        //   2. i = 2 * 2  -> i = 4
        //   3. i = 4 * 2  -> i = 8
        //   4. i = 8 * 2  -> i = 16
        //   5. i = 16 * 2 -> i = 32
        //   6. i = 32 * 2 -> i = 64
        //   7. i = 64 * 2 -> i = 128
        //   8. i = 128 * 2 -> i = 256
        a1(ref i);

        // El valor final de 'i' es 256.
        // Para verificarlo en una consola real, se podría agregar:
        // Console.WriteLine(i); // Imprimiría: 256

/*NOTAS: 
¿Qué hace exactamente este programa? 
    Ejecuta una cadena de 8 operaciones de duplicación sobre la variable i.
        Explicación:
            El programa define un delegado llamado AccionInt que representa un método que recibe 
            un entero por referencia (ref int) y no devuelve nada (void).
        Ejecución:
            1. Se instancia a1 con una expresión lambda que duplica el valor del entero que recibe (i = i * 2).
            2. Se ejecutan tres operaciones += sobre a1. En C#, los delegados son inmutables; cada += crea 
            una nueva instancia del delegado que concatena la lista de invocación anterior con la nueva lambda.
            3. Finalmente, se declara la variable i con valor 1 y se invoca a1(ref i).
            4. Al invocar a1, se ejecuta la lista de invocación completa: el método original se ejecuta, luego 
            el resultado de ese método se pasa al siguiente en la cadena, y así sucesivamente.
        En resumen: 
            El programa toma el valor 1, lo duplica repetidamente tantas veces como delegados haya en la lista y devuelve el resultado final acumulado en la variable i. 

¿A qué llamamos "lista de invocación" en este contexto?
    Es la secuencia interna de métodos que se ejecutan en orden al invocar el delegado.
        Explicación:
            Una lista de invocación (invocation list) es la secuencia interna de métodos (o lambdas) que un delegado 
            está configurado para ejecutar cuando se llama.
            - Cuando se crea un delegado, su lista tiene un solo método.
            - Cuando se usa el operador += para combinar dos delegados del mismo tipo, C# no modifica el delegado original. 
            Crea un nuevo delegado cuya lista de invocación contiene todos los métodos del primer delegado, 
            seguidos de todos los métodos del segundo.
            - Al invocar el delegado resultante, C# recorre esta lista de izquierda a derecha y 
            ejecuta cada método en orden.

¿Cuál es el tamaño de la lista de invocación de a1?
    El tamaño es 8.
        Desglosando la construcción:
            El operador += en delegados funciona de esta manera: a1 = a1 + a1.
        Paso a paso:
            Inicio: a1 tiene 1 método (lambda original).
            Paso 1: a1 += a1. Se crea un nuevo delegado con la lista: [Original, Original]. Tamaño = 2.
            Paso 2: a1 += a1. Se crea un nuevo delegado con la lista: [Original, Original, Original, Original]. Tamaño = 4.
            Paso 3: a1 += a1. Se crea un nuevo delegado con la lista: [Original, Original, Original, Original, Original, Original, Original, Original]. Tamaño = 8.
        Tamaño final: 8.

¿Cuál es el valor de la variable i luego de la invocación a1(ref i)?
    El valor final de i es 256.
        Razonamiento: 
            - La variable i se inicializa en 1. 
            - La lista de invocación tiene 8 métodos idénticos. 
            - Cada método realiza la operación i = i * 2. 
            - Como el parámetro es ref, cada método modifica la misma variable i en memoria, 
            y el siguiente método en la lista recibe el valor ya modificado.
        El cálculo es:
            Inicio: i = 1
            Ejecución 1: 1 * 2 = 2
            Ejecución 2: 2 * 2 = 4
            Ejecución 3: 4 * 2 = 8
            Ejecución 4: 8 * 2 = 16
            Ejecución 5: 16 * 2 = 32
            Ejecución 6: 32 * 2 = 64
            Ejecución 7: 64 * 2 = 128
            Ejecución 8: 128 * 2 = 256
        Matemáticamente: 
            1 * 2^8 = 256$.

Conclusión:
    Puntos clave para recordar:
        - Inmutabilidad: Cada línea a1 += a1 NO modifica el a1 existente, sino que crea una nueva instancia 
        con una lista de invocación más larga.
        - Comportamiento ref: Si el parámetro fuera por valor (sin ref), cada método en la lista 
        recibiría una copia del valor inicial (1), y al final i seguiría siendo 1 
        (aunque el último método en la lista habría devuelto 256 localmente, ese valor no se propagaría al i original de Main). 
        Al usar ref, el cambio es persistente y acumulativo.
*/
