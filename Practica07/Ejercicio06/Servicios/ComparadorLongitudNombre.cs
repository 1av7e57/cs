// Importamos el espacio de nombres de las subcarpetas a utilizar
using Ejercicio06.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio06.Servicios;

// Implementamos IComparer<INombrable> para definir una lógica de comparación externa
public class ComparadorLongitudNombre : IComparer<INombrable>
{
    public int Compare(INombrable? x, INombrable? y)
    {
        // Manejo de nulos por seguridad
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        // Lógica principal: Comparar por la LONGITUD del Nombre
        // x.Nombre.Length vs y.Nombre.Length
        return x.Nombre.Length.CompareTo(y.Nombre.Length);
    }
}
