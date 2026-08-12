// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definición de la clase Auxiliar
class Auxiliar
{
    // Método público que se encargará de ejecutar la lógica de procesamiento
    public void Procesar()
    {
        // Llama al método privado SumaUno pasando 10 como argumento
        // El resultado (11) se imprime en la consola
        Console.WriteLine(SumaUno(10));

        // Llama al método privado SumaDos pasando 10 como argumento
        // El resultado (12) se imprime en la consola
        Console.WriteLine(SumaDos(10));
    }

    // Método privado que devuelve el número más uno
    // Utiliza sintaxis de expresión de cuerpo (arrow syntax) para una línea simple
    // Recibe un parámetro 'n' y retorna 'n + 1'
    int SumaUno(int n) => n + 1;

    // Método privado que devuelve el número más dos
    // Similar al anterior, recibe 'n' y retorna 'n + 2'
    int SumaDos(int n) => n + 2;
}