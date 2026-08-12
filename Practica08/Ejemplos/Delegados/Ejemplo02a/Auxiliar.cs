// forma 1 sin invocación explicita

// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // Método público que se encargará de ejecutar la lógica de procesamiento
    public void Procesar()
    {
        // Declaramos una variable 'f' del tipo delegado 'Funcion'
        // En este momento, 'f' no apunta a ningún método (es null), es solo un contenedor.
        Funcion f;

        // Asignamos la referencia al método SumaUno a la variable 'f'.
        // Nota: C# hace la conversión implícita.
        // Ahora 'f' sabe que debe llamar a SumaUno cuando se invoque.
        f = SumaUno;

        // Invocamos el delegado 'f' pasando 10.
        // Esto ejecuta internamente: SumaUno(10) -> Imprime 11.
        Console.WriteLine(f(10));

        // Ahora cambiamos la referencia. 'f' ya no apunta a SumaUno, sino a SumaDos.
        f = SumaDos;

        // Invocamos 'f' de nuevo.
        // Ahora ejecuta: SumaDos(10) -> Imprime 12.
        Console.WriteLine(f(10));
    }

    // Métodos de ejemplo que coinciden con la firma del delegado
    int SumaUno(int n) => n + 1;
    int SumaDos(int n) => n + 2;
}
