using Automotores; // 1. Importar la librería

// Clase principal del programa
class Program
{
    // Método principal de entrada del programa
    static void Main(string[] args)
    {
        Console.WriteLine("Probando la clase Auto desde la librería...");

        // 2. Instanciar (con el constructor de un solo parámetro)
        Auto a = new Auto("Chevrolet");

        // 3. Llamar al método
        Console.WriteLine(a.ObtenerDescripcion());

        // Resultado esperado: "Auto Chevrolet 2026" (o el año actual)

    }
}
