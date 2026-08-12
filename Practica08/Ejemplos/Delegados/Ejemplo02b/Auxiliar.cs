// forma 2 con invocación explicita (Invoke)

// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // Método público que se encargará de ejecutar la lógica de procesamiento
    public void Procesar()
    {
        // Declaramos la variable del tipo delegado 'Funcion'
        Funcion f;

        // Asignamos el método 'SumaUno' a la variable 'f'
        f = SumaUno;

        // Invocación EXPLÍCITA del delegado.
        // 'f' es un objeto, y 'Invoke' es el método que ejecuta la lógica encapsulada.
        // Esto es funcionalmente idéntico a escribir solo 'f(10)'.
        Console.WriteLine(f.Invoke(10)); 

        // Cambiamos la referencia del delegado para que apunte a 'SumaDos'
        f = SumaDos;

        // Nuevamente, llamamos explícitamente al método 'Invoke'
        // Esto ejecuta SumaDos(10) y muestra el resultado (12)
        Console.WriteLine(f.Invoke(10));
    }

    // Métodos de ejemplo que coinciden con la firma del delegado

    int SumaUno(int n) => n + 1;
    int SumaDos(int n) => n + 2;
}

/*NOTAS:
 Esta versión introduce un detalle importante sobre cómo funciona internamente un delegado en .NET.
La diferencia principal es el uso explícito del método .Invoke(). En C#, cuando se escribe f(10), 
el compilador lo traduce automáticamente a f.Invoke(10). Sin embargo, usarlo explícitamente 
nos recuerda que un delegado es, en realidad, un objeto con métodos.

Puntos clave de esta variante:
Sintaxis vs. Semántica:
- f(10) es syntactic sugar (azúcar sintáctica) de C#. Es más limpio y legible.
- f.Invoke(10) es lo que realmente ocurre en el CLR (Common Language Runtime). 
*/