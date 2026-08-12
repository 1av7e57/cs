﻿/*Sin borrar ni modificar ninguna línea, completar la definición de las clases B, C y D:

class A
{
protected int _id;
public A(int id) => _id = id;
public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
}
class B : A
{
. . .
}
class C : B
{
. . .
}
class D : C
{
. . .
public override void Imprimir()
{
. . .
base.Imprimir();
}
}

Para que el siguiente código produzca la salida indicada:

A[] vector = new A[] { new A(3), new B(5), new C(15), new D(41) };
foreach (A a in vector)
{
    a.Imprimir();
}

Salida por consola:

A_3
B_5 --> A_5
C_15 --> B_15 --> A_15
D_41 --> C_41 --> B_41 --> A_41
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
        // Creamos un array polimórfico con instancias de las diferentes clases
        A[] vector = new A[] { new A(3), new B(5), new C(15), new D(41) };
        
        // Recorremos el array
        foreach (A a in vector)
        {
            // Llamamos a Imprimir. El polimorfismo ejecuta la lógica específica de cada clase
            // construyendo la cadena desde la clase más derivada hasta la base.
            a.Imprimir();
        }
    }
}

/*NOTAS:
El objetivo del ejercicio es crear una jerarquía de herencia,
donde cada clase derivada agregue su propia línea de salida
antes de llamar a la implementación de la clase base, 
logrando una cadena de impresión acumulativa.

Explicación del funcionamiento:
-Herencia en Cascada: Cada clase (B, C, D) hereda de la anterior.
-Sobrescritura (override): Cada clase derivada sobrescribe el método Imprimir().
-Llamada a base: La clave está en base.Imprimir().
Cuando se llama a D.Imprimir(), imprime D_41 y luego llama a C.Imprimir().
C.Imprimir() imprime C_41 y llama a B.Imprimir().
B.Imprimir() imprime B_41 y llama a A.Imprimir().
A.Imprimir() imprime A_41.
-Resultado: Esto genera la cadena acumulativa D_41 --> C_41 --> B_41 --> A_41

Aclaraciónes de formato (salida):
Para lograr que la salida aparezca en una sola línea por objeto separada por --> :
Las clases intermedias (B, C) deben usar Console.Write para imprimir sin salto de línea.
La última llamada en la cadena (la clase base A) o la clase que inicia la cadena debe manejar el salto de línea final.
Para mantener la estructura de "llamar a base", la clase A imprime con WriteLine (saltando al final), 
y las clases derivadas usan Write para la parte actual y luego llaman a base.Imprimir().
*/
