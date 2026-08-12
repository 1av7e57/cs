namespace Teoria5;
class Cuenta
{
    public int Monto;
    public static int s_Total;

    public static void ImprimirResumen()
    {
        Console.WriteLine($"Total acumulado: {s_Total}");
    }
}