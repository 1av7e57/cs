using System;
using Teoria6;
class Program
{
    static void Main()
    {
        Auto a = new Auto("Ford", 2000, TipoAuto.Deportivo);
        Colectivo c = new Colectivo("Mercedes", 2010, 20);

        a.Imprimir();  // Ford 2005 (2000 se corrige a 2005 por Automotor)
        c.Imprimir();  // Mercedes 2015 (2010 se corrige a 2015 por Colectivo)
        Console.WriteLine(a.Marca + " " + a.Modelo); // Ford 2005
        Console.WriteLine(c.Marca + " " + c.Modelo); // Mercedes 2015

        // Polimorfismo: Lista de base
        Automotor[] parque = { a, c };

        foreach (var vehiculo in parque)
        {
            Console.WriteLine($"\n--- Vehículo: {vehiculo.Marca} ---");
            vehiculo.Imprimir();
            Console.WriteLine($"Precio: ${vehiculo.PrecioDeVenta}");
            Console.WriteLine($"Último Service: {vehiculo.FechaService:dd/MM/yyyy}");

            // Cada uno ejecuta su propia lógica
            vehiculo.HacerMantenimiento();
        }

        // --- Pruebas con el operador 'is' ---

        Console.WriteLine("\n--- Verificaciones de tipo para el objeto 'a' (Auto) ---");
        Console.WriteLine($"a is Auto: {a is Auto}");           // true (a es un Auto.)
        Console.WriteLine($"a is Colectivo: {a is Colectivo}"); // false (a es un Auto, no un Colectivo.)
        Console.WriteLine($"a is Automotor: {a is Automotor}"); // true (Auto hereda de Automotor. Por tanto, todo Auto es un Automotor.)
        Console.WriteLine($"a is object: {a is object}");       // true (Todas las clases en C# heredan implícitamente de System.Object.)
        Console.WriteLine($"a is string: {a is string}");       // false (Auto no tiene relación con string.)

        Console.WriteLine("\n--- Verificaciones de tipo para el objeto 'c' (Colectivo) ---");
        Console.WriteLine($"c is Auto: {c is Auto}");           // false
        Console.WriteLine($"c is Colectivo: {c is Colectivo}"); // true
        Console.WriteLine($"c is Automotor: {c is Automotor}"); // true
        Console.WriteLine($"c is object: {c is object}");       // true
        Console.WriteLine($"c is string: {c is string}");       // false

        // Ejemplo de uso práctico: Casting seguro ("Truco" de is con Declaración de Patrón (Pattern Matching))
        if (a is Auto miAuto) // No solo verifica si a es un Auto.
                              // Si es true, crea automáticamente una nueva variable llamada miAuto
                              // que ya está tipada como Auto.                       
        {
            // Dentro del if, puede usarse miAuto.Tipo directamente sin tener que hacer un casting manual (Auto)a.
            Console.WriteLine($"\n¡Éxito! Es un Auto. Su tipo es: {miAuto.Tipo}");
        }

    }
}

/*NOTAS:
¿Qué pasaría si 'a' fuera null?
Si a fuera null, todas las expresiones " a is Tipo " devolverían False (incluso a is object). 
El operador is es seguro contra nulos.
*/
