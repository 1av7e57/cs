namespace Teoria5;
static class FechaActual{

    public static void ImprimirHora() =>
        Console.WriteLine($"{DateTime.Now:hh: mm:ss}");

public static void ImprimirFecha() =>
    Console.WriteLine($"{DateTime.Today:dd / MM / yyyy}");

}