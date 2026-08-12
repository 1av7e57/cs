﻿/*¿Por qué no funciona el siguiente código? ¿Cómo se puede solucionar fácilmente?

class Auto
{
    double velocidad;
    public virtual void Acelerar()
    => Console.WriteLine("Velocidad = {0}", velocidad += 10);
}
class Taxi : Auto
{
    public override void Acelerar()
    => Console.WriteLine("Velocidad = {0}", velocidad += 5);
}
*/

// Definimos la clase base Auto
class Auto
{
    // Campo para almacenar el valor de la velocidad
    protected double velocidad; // Cambiado de private (implícito) a 'protected'

    // Método público virtual que imprime la velocidad con una acumulación de +10
    public virtual void Acelerar()
        => Console.WriteLine("Velocidad = {0}", velocidad += 10);
}

// Definimos la clase Taxi (Que hereda de Auto)
class Taxi : Auto
{
    // Método que sobreescribe el original imprimiendo la velocidad con una acumulación de +5
    public override void Acelerar()
        => Console.WriteLine("Velocidad = {0}", velocidad += 5);
}

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        // Pruebas para comprobar el funcionamiento

        // Imprimimos un encabezado
        Console.WriteLine("Probando clase Auto:");
        // Creamos el objeto Auto
        Auto auto = new Auto();
        // Invocamos al método Acelerar de Auto
        auto.Acelerar();
        auto.Acelerar();

        // Imprimimos un encabezado
        Console.WriteLine("\nProbando clase Taxi:");
        // Creamos el objeto Taxi
        Taxi taxi = new Taxi();
        // Invocamos al método Acelerar de Taxi
        taxi.Acelerar();
        taxi.Acelerar();
    }
}

/*NOTAS:
El código no compilaba porque el campo velocidad en la clase base Auto tenia modificador de acceso private 
implícito por defecto (al no especificar nada), y la clase derivada Taxi no puede acceder a él directamente.
Cuando Taxi intentaba usar velocidad en su método Acelerar(), el compilador lanzaba un error de accesibilidad, 
ya que los miembros de la clase base son privados a menos que se declare explícitamente lo contrario.
Solución fácil: Cambiar el modificador de velocidad a protected. 
Esto permite que la clase base y todas sus clases derivadas accedan al campo, pero lo mantiene oculto para el resto del mundo.

Detalle adicional: Si también se necesitara que el campo sea modificable desde fuera de la jerarquía de clases 
(por ejemplo, desde una instancia de Auto o Taxi), podría usarse public en lugar de protected, pero protected 
es la opción más segura y común cuando solo se necesita acceso en la herencia.
*/
