// Definición del namespace que agrupa la lógica de la teoría 8
using Teoria8;

//Clase principal del programa
class Program
{
    // Método principal donde inicia la ejecución del programa
    static void Main()
    {
        // 1. Creamos una instancia de la clase genérica
        Auxiliar aux = new Auxiliar();

        // 2. Definimos métodos locales que coinciden con la firma del delegado.
        // Estos métodos podrían estar en cualquier clase, o ser lambdas.

        // Método que suma 1
        int SumaUno(int n) => n + 1;

        // Método que suma 2
        int SumaDos(int n) => n + 2;

        // --- CASO A: Pasamos el método SumaUno ---
        Console.WriteLine("--- Ejecutando SumaUno ---");
        // Invocamos Procesar pasando la referencia al método 'SumaUno'.
        // C# infiere automáticamente que SumaUno coincide con 'Funcion'.
        aux.Procesar(SumaUno); 
        // Salida esperada: 11 (10+1) y 21 (20+1)

        // --- CASO B: Pasamos el método SumaDos ---
        Console.WriteLine("\n--- Ejecutando SumaDos ---");
        // No tocamos la clase Auxiliar, solo le pasamos una instrucción distinta.
        aux.Procesar(SumaDos);
        // Salida esperada: 12 (10+2) y 22 (20+2)

        // --- CASO C: Usando una Función Anónima (Lambda) ---
        Console.WriteLine("\n--- Ejecutando Lambda (Resta 5) ---");
        // Podemos pasar una función directamente sin definirla antes.
        // (n) => n - 5 es una expresión lambda que coincide con 'Funcion'.
        aux.Procesar((n) => n - 5);
        // Salida esperada: 5 (10-5) y 15 (20-5)
    }
}

/*NOTAS:
Se modificó Procesar() para que reciba el delegado como parámetro (public void Procesar(Funcion f)), 
y que Auxiliar no sepa qué va a calcular. Desde Program.cs se decide si pasa SumaUno(), SumaDos() u otro.
Los métodos son creados directamente (o se usa lambda) y se los "inyecta" a Auxiliar.

Puntos Clave de esta versión:
    -Principio de Inversión de Dependencia: Auxiliar depende de una abstracción (Funcion), 
    no de implementaciones concretas (SumaUno, SumaDos).
    -Extensibilidad: Si mañana se necesitara que Auxiliar haga una división, no haría falta tocar el código de Auxiliar.
    Solo se crearía el método Dividir en Program.cs (o en otra clase) y se pasaría como parámetro.
    -Reutilización: La clase Auxiliar es ahora un componente de uso general que podría usarse en 
    otros contextos diferentes con comportamientos distintos.
*/
