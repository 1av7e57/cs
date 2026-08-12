using System.Collections; // Necesario para usar IComparer

namespace Teoria8;

// Implementamos IComparer
class ComparadorPorLegajo : IComparer 
{
    public int Compare(object? x, object? y)
    {
        // Caso 1: Ambos son null -> son iguales
        if (x == null && y == null) return 0;
        
        // Caso 2: Solo uno es null (x null es "menor", y null es "mayor")
        if (x == null) return -1;
        if (y == null) return 1;

        // Caso 3: Asegurarse de que son Empleado
        if (x is Empleado empX && y is Empleado empY)
        {
            return empX.Legajo.CompareTo(empY.Legajo);
        }

        // Caso 4: Si son tipos diferentes (No deberíamos llegar aquí en un array homogéneo)
        // pero por seguridad devolvemos 0.
        return 0;
    }
}
