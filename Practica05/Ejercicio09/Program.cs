﻿/*¿Qué diferencia hay entre estas dos declaraciones?

a) public int X = 3;

y

b) public int X => 3;

*/

/*
Respuestas:
La diferencia fundamental es que la primera es una asignación de campo y la segunda es una propiedad 
con cuerpo de expresión (expression-bodied property).

a) public int X = 3;

Qué es: Es un campo (field).
Comportamiento: Asigna el valor 3 directamente a la variable de instancia.
Módificadores: Puede usar modificadores de solo lectura como readonly (ej. public readonly int X = 3;).
Lógica: No tiene lógica personalizada al leer o escribir 
(a menos que se cambie el modificador a private y se cree propiedades getter/setter aparte). 
Es almacenamiento directo.
Lectura:Lee el valor en memoria (3).

b) public int X => 3;

Qué es: Es una propiedad (property) definida con una sintaxis abreviada (introducida en C# 6).
Comportamiento: Equivale a tener un get que siempre devuelve 3.
Código equivalente:

public int X { get { return 3; } }

Limitaciones:
Es solo de lectura implícitamente. No se puede asignarle un valor desde fuera de la clase (no tiene set).
Lectura: Cada vez que se accede a X, ejecuta la lógica de retorno (en este caso, devuelve el literal 3).
No se puede marcar como readonly porque ya es inmutable por naturaleza de ser una propiedad de solo lectura.

Ejemplo práctico:
- Si se hiciera esto:

    var obj = new MiClase();
    obj.X = 5; // Funciona con (a), ERROR de compilación con (b)

- En la opción (a), obj.X será 5.
- En la opción (b), el compilador dará un error diciendo que NO se puede asignar un valor a una propiedad o índiceador de solo lectura.

--------------------------------------------------------------------------------------------------------------------------------------

Aclaración: 
Diferencias entre Expresión de Cuerpo de Miembro (Expression-bodied Member) y Expresión Lambda (Lambda Expression)

Aunque ambas usan la flecha => y parecen similares a simple vista, cumplen propósitos muy diferentes en C#.

La diferencia clave está en qué es lo que definen:

- Expresión de cuerpo (Expression-bodied member): 
Define el comportamiento de un miembro existente (como una propiedad, un método o un constructor) de forma ABREVIADA.

Se usa para ABREVIAR la sintaxis de miembros de una clase que solo tienen una instrucción. 
No crea una función nueva, sino que simplifica la definición de una función o propiedad que ya tiene nombre.

Sintaxis: NombreDelMiembro => Expresión;

- Expresión lambda (Lambda expression): 
Define una función ANÓNIMA (un bloque de código que NO tiene nombre) 
que se puede pasar como argumento a otro método o almacenar en una variable.

Se usa para crear una función SIN nombre (ANÓNIMA) al vuelo. Es fundamental en programación funcional, LINQ y eventos. 
La función NO pertenece directamente a la clase con un nombre fijo, sino que se asigna a una variable o se pasa directamente a otro método.
Su propósito es crear lógica temporal o funcional para delegar.

Sintaxis: (parámetros) => cuerpo

Para tener en cuenta:

- La similitud (lo que confunde): Ambos comparten el mecanismo subyacente. 
    El compilador convierte => en una invocación de método (un get oculto en propiedades/indexadores, o un método anónimo en lambdas). 
    Por eso la sintaxis es idéntica.

- La diferencia (lo que los separa):
  - Identidad: En propiedades/métodos con cuerpo, el "método" tiene un nombre público (A3, this[i]) que forma parte de la API de la clase. 
    En lambdas, la función es anónima y no tiene identidad propia fuera de su ámbito local.

  - Consumo:
    Propiedad: obj.A3 (Se accede como un dato o atributo).
    Lambda: miFuncion() (Se invoca como una acción o cálculo).
    
  - Esta distinción es fundamental porque define cómo el lenguaje trata al código:
    Si tiene nombre y está en la clase → Es un miembro (propiedad/método).
    Si no tiene nombre y es un valor → Es un delegado (Func, Action).
*/
