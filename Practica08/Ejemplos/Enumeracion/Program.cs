using System; // Necesario para usar Console.WriteLine
using System.Collections; // Necesario para usar la interfaz IEnumerator

// Clase principal del programa
class Program
{
    // Método principal: Punto de entrada del programa
    static void Main()
    {
        // Creamos una instancia de nuestra clase EnumeradorEstaciones
        // La declaramos como tipo 'IEnumerator' (interfaz) para mayor flexibilidad
        IEnumerator e = new EnumeradorEstaciones();

        // Iniciamos un bucle 'while':
        // 1. Primero llama a e.MoveNext() para avanzar al siguiente elemento.
        // 2. Si MoveNext() devuelve 'true', el bucle entra y ejecuta el cuerpo.
        // 3. Si MoveNext() devuelve 'false' (llegamos a "Fin"), el bucle termina.
        while (e.MoveNext())
        {
            // Accedemos a la propiedad Current para obtener el elemento actual (la estación)
            // Nota: Solo es seguro llamar a Current después de que MoveNext() haya devuelto true
            Console.WriteLine(e.Current);
        }

        // Una vez que el bucle termina (cuando MoveNext() devuelve false), imprimimos un mensaje de fin
        Console.WriteLine("Fin de la enumeración de estaciones.");
    }
}
