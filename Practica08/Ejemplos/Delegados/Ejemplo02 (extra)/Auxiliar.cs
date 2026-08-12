// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // El método Procesar ahora RECIBE el delegado como parámetro.
    // Esto desacopla completamente la clase de la lógica específica.
    // 'f' es una "instrucción" que se trae desde afuera.
    public void Procesar(Funcion f)
    {
        // Verificamos si el delegado es nulo por seguridad (buena práctica)
        if (f == null)
        {
            Console.WriteLine("Error: No se proporcionó ninguna función para ejecutar.");
            return;
        }

        // Ejecutamos la lógica que se trajo.
        // Aquí no se sabe si es una suma, resta u otra.
        // Simplemente ejecutamos 'f' con el valor 10.
        Console.WriteLine($"Resultado de la operación: {f(10)}");
        
        // Podría ejecutarse varias veces con diferentes valores si se quisiéra
        Console.WriteLine($"Resultado de la operación (segunda vez): {f(20)}");
    }
}

/*NOTAS:
Auxiliar ya no tiene referencias a SumaUno ni SumaDos. Solo sabe que tiene una variable f que debe ejecutar.
*/