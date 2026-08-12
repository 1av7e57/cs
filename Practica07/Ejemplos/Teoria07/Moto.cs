namespace Teoria7;

class Moto : Automotor
{
    public Moto(string marca)
    => Marca = marca;
    public void Imprimir()
    => Console.WriteLine($"Soy una moto {Marca}");
}