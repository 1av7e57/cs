/*Señalar errores de ejecución en el siguiente código*/


List<int> a = new List<int>() { 1, 2, 3, 4 };

// Intenta eliminar EL VALOR 5.
// Como 5 no existe en la lista, este método NO lanza una excepción.
// Simplemente devuelve false y la lista permanece igual: { 1, 2, 3, 4 }
a.Remove(5); 

// Intenta eliminar el elemento en el ÍNDICE 4.
// ERROR DE EJECUCIÓN (ArgumentOutOfRangeException):
// La lista actual tiene 4 elementos, por lo que los índices válidos son 0, 1, 2 y 3.
// El índice 4 está fuera de los límites, lo que lanza una excepción en tiempo de ejecución.
a.RemoveAt(4);


/*Nota:
Conclusión:
Intentar acceder o eliminar en el índice 4 provoca un ArgumentOutOfRangeException.
Para evitar esto, siempre verificar que el índice exista antes de usar RemoveAt, 
o manejar la excepción con un bloque try-catch.
*/

// POSIBLE CORRECCIÓN 1:
// Usando validación
/*
using System;
using System.Collections.Generic; // Donde se encuentra la definición de la clase List<T>

class Program
{
    static void Main()
    {
        List<int> a = new List<int>() { 1, 2, 3, 4 };

        // Intentamos eliminar el VALOR 5 (si es que existe)
        if (a.Contains(5))
        {
            a.Remove(5);
            Console.WriteLine("Valor 5 eliminado.");
        }
        else
        {
            Console.WriteLine("El valor 5 no está en la lista. No se eliminó nada.");
        }

        // Ahora intentamos eliminar por ÍNDICE (índice 4)
        int indiceAEliminar = 4;

        // Validación: el índice debe ser mayor o igual a 0 y menor que la cuenta (Count)
        if (indiceAEliminar >= 0 && indiceAEliminar < a.Count)
        {
            a.RemoveAt(indiceAEliminar);
            Console.WriteLine($"Elemento en el índice {indiceAEliminar} eliminado con éxito.");
            Console.WriteLine("Lista actual: " + string.Join(", ", a));
        }
        else
        {
            Console.WriteLine($"Error: El índice {indiceAEliminar} está fuera de los límites.");
            Console.WriteLine($"La lista tiene {a.Count} elementos (índices válidos: 0 a {a.Count - 1}).");
        }
    }
}
*/

// POSIBLE CORRECCIÓN 2:
// Usando try-catch
// NOTA: en C# la validación previa suele ser más eficiente
// para evitar el costo de lanzar y capturar una excepción.
/*
using System;
using System.Collections.Generic; // Donde se encuentra la definición de la clase List<T>

class Program
{
    static void Main()
    {
        List<int> a = new List<int>() { 1, 2, 3, 4 };
        int indiceAEliminar = 4;

        try
        {
            // Intentamos eliminar directamente sin validar antes
            // Si el índice es inválido, el programa salta inmediatamente al bloque 'catch'
            a.RemoveAt(indiceAEliminar);
            
            Console.WriteLine("Eliminado con éxito.");
            Console.WriteLine("Lista actual: " + string.Join(", ", a));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Se ejecuta SOLO si el índice estaba fuera de los límites
            Console.WriteLine($"¡Error detectado: {ex.Message}");
            Console.WriteLine($"No se pudo eliminar el índice {indiceAEliminar}.");
            Console.WriteLine($"La lista tiene {a.Count} elementos (índices válidos: 0 a {a.Count - 1}).");
        }
        catch (Exception ex)
        {
            // Captura cualquier otro error inesperado (buena práctica general)
            Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
        }

        // El programa continúa ejecutándose aquí después del try-catch
        Console.WriteLine("El programa sigue ejecutándose normalmente.");
    }
}
*/
