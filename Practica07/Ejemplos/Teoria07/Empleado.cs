namespace Teoria7;

class Empleado : Persona
{
    public Empleado(string nombre)
    => Nombre = nombre;
    public void Imprimir()
    => Console.WriteLine($"Soy el empleado {Nombre}");
}