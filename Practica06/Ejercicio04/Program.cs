﻿/*Contestar sobre el siguiente programa:

Taxi t = new Taxi(3);
Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");
class Auto
{
    public string Marca { get; private set; } = "Ford";
    public Auto(string marca) => this.Marca = marca;
    public Auto() { }
}
class Taxi : Auto
{
    public int Pasajeros { get; private set; }
    public Taxi(int pasajeros) => this.Pasajeros = pasajeros;
}

a)¿Por qué no es necesario agregar :base en el constructor de Taxi? 
b)Eliminar el segundo constructor de la clase Auto y modificar la clase Taxi para el programa siga funcionando
*/


/*NOTAS: Respuestas:

a) ¿Por qué no es necesario agregar :base en el constructor de Taxi? 
El motivo por el que no es necesario (y de hecho, no es posible) agregar : base en el constructor de Taxi 
es que el compilador inserta automáticamente una llamada al constructor por defecto de la clase base (Auto()) 
cuando no hay una llamada explícita.

Lo que ocurre internamente:
- Regla de Herencia: En C#, si un constructor de una clase derivada no llama explícitamente a un constructor específico de la clase base (usando : base(...)), el compilador asume que quieres llamar al constructor sin argumentos (default) de la clase base.
En la clase Auto, hay definido public Auto() { }. Este es un constructor por defecto válido.
En la clase Taxi, el constructor public Taxi(int pasajeros) no tiene : base(...).
El compilador transforma el código internamente en algo así:

    public Taxi(int pasajeros) : base() // ¡Esto se añade automáticamente!
    {
        this.Pasajeros = pasajeros;
    }

El Flujo de Ejecución:
-Se crea new Taxi(3).
-Se ejecuta primero el constructor de Auto (el base() implícito), que inicializa Marca con "Ford" (debido a la asignación inicial = "Ford").
-Luego, se ejecuta el cuerpo del constructor de Taxi, donde Pasajeros se establece en 3.
-Finalmente, la propiedad Marca permanece como "Ford" porque el constructor Taxi no recibió un argumento para cambiarla, y no hay una llamada a base("AlgunaMarca").

b) ¿Qué pasaría si se borra el segundo constructor Auto()?
Si se elimina public Auto() { } de la clase Auto, el compilador fallaría. 
¿Por qué? Porque si no hay un constructor sin argumentos explícito en la base, 
el compilador no puede insertar la llamada : base(). 
Por lo tanto, es obligatorio que el constructor de Taxi llame explícitamente al
constructor que sí existe en Auto, que es el que recibe un parámetro string marca.
Para que el programa siga funcionando y mantenga el comportamiento de "Ford" como marca por defecto, 
debemos pasar "Ford" (o cualquier otra marca) desde el constructor de Taxi hacia Auto usando : base(marca).

Ejemplo borrando el segundo constructor (vacío) de la clase Auto:
*/

using System;

class Auto
{
    // Propiedad de solo lectura externa (set solo accesible dentro de la clase)
    public string Marca { get; private set; } = "Ford";

    // Constructor con parámetro
    public Auto(string marca) => this.Marca = marca;
    
    // El constructor vacío (public Auto() { }) ha sido eliminado aquí.
}

class Taxi : Auto
{
    public int Pasajeros { get; private set; }

    // DEBEMOS usar : base(marca) porque el constructor vacío de Auto no existe.
    // Pasamos "Ford" explícitamente para mantener el valor original.
    public Taxi(int pasajeros) : base("Ford") 
    {
        this.Pasajeros = pasajeros;
    }
}

class Program
{
    static void Main()
    {
        Taxi t = new Taxi(3);
        Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");
    }
}
