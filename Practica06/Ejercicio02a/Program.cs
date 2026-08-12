﻿/*Aunque consultar en el código por el tipo de un objeto indica habitualmente un diseño ineficiente,
por motivos didácticos vamos a utilizarlo. Completar el siguiente código, que utiliza las clases
definidas en el ejercicio anterior, para que se produzca la salida indicada:

A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };
foreach (A a in vector)
{
...
}

Salida por consola
B_3 --> A_3
B_5 --> A_5

Es decir, se deben imprimir sólo los objetos cuyo tipo exacto sea B
a) Utilizando el operador is
b) Utilizando el método GetType() y el operador typeof() (investigar sobre éste último en
la documentación en línea de .net)

Solución a) Utilizando el operador is
*/

using System; // Importamos el namespace System necesario para funciones básicas

// Clase base A
class A
{
    protected int _id; // Campo protegido para almacenar el ID

    // Constructor que inicializa el campo _id
    public A(int id) => _id = id;

    // Método virtual: Es el final de la cadena, imprime el ID de A y salta de línea
    public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
}

// Clase B hereda de A
class B : A
{
    // Constructor que pasa el ID a la clase base A
    public B(int id) : base(id) { }

    // Sobrescribimos Imprimir para agregar la etiqueta de B
    public override void Imprimir()
    {
        Console.Write($"B_{_id} --> "); // Imprimimos B y el separador sin salto de línea
        base.Imprimir(); // Llamamos a A para imprimir "A_{_id}" y el salto de línea final
    }
}

// Clase C hereda de B
class C : B
{
    // Constructor que pasa el ID a la clase base B
    public C(int id) : base(id) { }

    // Sobrescribimos Imprimir para agregar la etiqueta de C
    public override void Imprimir()
    {
        Console.Write($"C_{_id} --> "); // Imprimimos C y el separador sin salto de línea
        base.Imprimir(); // Llama a B, que imprime "B_{_id} --> " y luego llama a A
    }
}

// Clase D hereda de C
class D : C
{
    // Constructor que pasa el ID a la clase base C
    public D(int id) : base(id) { }

    // Sobrescribimos Imprimir para agregar la etiqueta de D
    public override void Imprimir()
    {
        Console.Write($"D_{_id} --> "); // Imprimimos D y el separador sin salto de línea
        base.Imprimir(); // Llama a C, que encadena B y A
    }
}

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        // Creamos el array polimórfico
        // Contiene instancias de C, D y B en diferente orden
        A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };

        // Recorremos el array
        foreach (A a in vector)
        {
            // Para simular tipo exacto con 'is',
            // negamos explícitamente los tipos derivados (!(a is C) y !(a is D)).
            if (a is B && !(a is C) && !(a is D))
            {
                // Solo será true si es B Y no es C Y no es D
                B objetoB = (B)a; // Declaramos una nueva variable llamada objetoB que es del tipo B 
                                  // y le asignamos la variable a que ahora será del tipo B
                objetoB.Imprimir();
            }
            // Si no es B, se ignora y el bucle pasa al siguiente objeto

        }
    }
}

/*NOTAS:
El problema:
    if (a is B)
    {
        B objetoB = (B)a;
        objetoB.Imprimir();
    }
En C#, el operador is SÍ devuelve verdadero si el objeto es de un tipo que hereda de la clase verificada.
C hereda de B.
Por lo tanto, new C(1) is B DEVUELVE TRUE.
C# considera que "todo C es un B" (por la herencia).
La lógica de if (a is B) por si sola acepta no solo los objetos B, 
sino también los C y los D (porque ambos heredan de B).

La solución:
Para verificar el tipo exacto (que sea B y nada más), convencionalmente NO debería usarse is en este caso específico 
si se quiere excluir las clases derivadas. Debería usarse la combinación de GetType() == typeof(B).
-El operador is verifica "¿Es este objeto o alguno de sus ancestros de este tipo?". 
-El método GetType() verifica "¿Es este objeto exactamente de este tipo?".

Truco para lograr el resultado con is de todos modos:
Para usar is y verificar el tipo exacto, la única forma de lograrlo es verificar 
que el objeto NO sea de una clase derivada de B, modificando la condición if de esta forma:

    if (a is B && !(a is C) && !(a is D))
    {
        B objetoB = (B)a;
        objetoB.Imprimir();
    }

Pero lo recomendable en esta situación sería usar la la combinación de GetType() == typeof(B).

¿Por qué?
Aunque la solución es correcta, el "truco" !(a is C) && !(a is D) tiene una desventaja de escalabilidad: 
si mañana se añade una clase E : D, tendría que modificarse el if para añadir && !(a is E).
La solución con GetType() no tiene este problema, ya que GetType() siempre verifica el tipo exacto 
sin importar cuántos niveles de herencia haya.

¿Por qué hacemos el casting (B)a ?
-La variable a es de tipo A: Aunque en memoria el objeto sea realmente un B, 
la variable a (que viene del foreach (A a in vector)) "solo sabe" que es un A.
-El compilador es estricto: El compilador de C# permite llamar a a.Imprimir() porque A tiene ese método. 
-El Casting: Al hacer (B)a, se está diciendo al compilador: 
"sé que esta variable se llama a y es de tipo A, pero en este momento concreto trátalo como un B".
Esto es seguro porque ya verificamos con if que sí es un B. Pero si se intentara hacer este cast 
sin la verificación previa y el objeto fuera un C o A, el programa se detendría con un error 
InvalidCastException en tiempo de ejecución.

Sin el casting, usar solo a.Imprimir() funcionaría igual porque Imprimir() está definido en A (y sobrescrito en B),
pero el casting es una buena práctica para desbloquear funcionalidades específicas de B si las hubiera.
*/
