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

Solución b) Utilizando el método GetType() y el operador typeof()
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
        A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };

        // Recorremos el array
        foreach (A a in vector)
        {
            // Usamos GetType() y typeof()
            // a.GetType() devuelve el tipo exacto del objeto en tiempo de ejecución (ej: typeof(C), typeof(B), etc.)
            // typeof(B) devuelve el objeto de tipo que representa la clase B
            // La comparación == verifica si las dos referencias de tipo son idénticas
            if (a.GetType() == typeof(B))
            {
                // Si el tipo es exactamente B, lo convertimos (casting) para imprimirlo
                B objetoB = (B)a;
                objetoB.Imprimir();
            }
            // Si no es B, se ignora y el bucle pasa al siguiente objeto
        }

    }
}

/*NOTAS:

Sobre el uso de GetType() y typeof():

1. typeof(Tipo)
   - ¿Qué es? Es un operador que devuelve un objeto de tipo 'System.Type' que representa la definición de la clase en tiempo de compilación.
   - ¿Cuándo se evalúa? En tiempo de COMPILACIÓN.
   - Uso: Se usa para obtener la referencia al tipo de una clase conocida por el compilador.
   - Ejemplo: typeof(B) devuelve el objeto Type que representa la clase B.
   - Limitación: No puede cambiar dinámicamente; el tipo debe estar escrito en el código fuente.

2. obj.GetType()
   - ¿Qué es? Es un método heredado de System.Object (todas las clases en .NET heredan de Object) que devuelve un objeto 'System.Type' del objeto real en memoria.
   - ¿Cuándo se evalúa? En tiempo de EJECUCIÓN (Runtime).
   - Uso: Se usa para averiguar qué tipo exacto es un objeto en un momento dado.
   - Ejemplo: Si 'a' es una variable de tipo A que apunta a 'new C(1)', a.GetType() devuelve el objeto Type que representa la clase C (no A).

3. La Comparación: a.GetType() == typeof(B)
   - Al usar '==', comparamos si dos referencias de tipo son idénticas.
   - a.GetType(): Obtiene el tipo real del objeto (ej. C, D, o B).
   - typeof(B): Obtiene la referencia al tipo B.
   - Resultado: Devuelve TRUE solo si el objeto es EXACTAMENTE de tipo B en tiempo de ejecución.

Comparativa: is vs GetType() == typeof()

   | Característica          | Operador 'is' (a is B)                                        | GetType() == typeof(B)                                                  |
   |-------------------------|---------------------------------------------------------------|-------------------------------------------------------------------------|
   | Lógica                  | Verifica compatibilidad de herencia.                          | Verifica identidad de tipo exacta.                                      |
   | Resultado con 'C'       | TRUE (C hereda de B).                                         | FALSE (C != B).                                                         |
   | Resultado con 'B'       | TRUE.                                                         | TRUE.                                                                   |
   | Uso Ideal               | Cuando se quiere tratar el objeto como B (polimorfismo).      | Cuando se necesita filtrar SOLO instancias de B (excluyendo derivados). |
   | Escalabilidad           | Si se añade 'E', requiere lógica compleja (is B && !is C...). | Funciona automáticamente sin cambios.                                   |

Conclusión
   - Usar 'is' conviene cuando se quiera ejecutar código si el objeto es B O cualquier clase que herede de B.
   - Usar 'GetType() == typeof(B)' conviene cuando se necesite distinguir estrictamente entre B y sus clases hijas (C, D, etc.).
   - En este ejercicio, como el requisito era imprimir SOLO los objetos de tipo B (excluyendo C y D), la solución con GetType() es la más robusta, mientras que la solución con 'is' requiere el "truco" de negar los hijos.

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
