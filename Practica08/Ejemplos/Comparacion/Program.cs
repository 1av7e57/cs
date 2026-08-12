using Teoria8;

// 1. Crear el array original
var empleadosOriginales = new Empleado[] {
    new Empleado("Juan") { Legajo = 79 },
    new Empleado("Leo") { Legajo = 123 },
    new Empleado("Mateo") { Legajo = 12 }
};

// --- BLOQUE 1: Orden Alfabético ---
// Copiamos para no alterar el original (primera copia)
var empleadosPorNombre = (Empleado[])empleadosOriginales.Clone(); 

// Ordenamos por nombre usando el CompareTo implícito
Array.Sort(empleadosPorNombre); 

Console.WriteLine("--- Orden alfabético ---");
foreach (var e in empleadosPorNombre)
{
  e.Imprimir(); // Usa el método Imprimir() que solo muuestra Nombre
}

// --- BLOQUE 2: Orden por Legajo ---
// Copiamos el array original de nuevo (segunda copia)
var empleadosPorLegajo = (Empleado[])empleadosOriginales.Clone();

// Ordenamos por legajo usando el comparador externo
Array.Sort(empleadosPorLegajo, new ComparadorPorLegajo());

Console.WriteLine("\n--- Orden de legajo ---");
foreach (var e in empleadosPorLegajo)
{
    e.ImprimirCompleto(); // Usa el nuevo método que muestra Nombre y Legajo
}

/*NOTAS:
Sobre IComparable vs. IComparer

1. IComparable (Implementado en la CLASE 'Empleado'):
   - Está en el espacio de nombres System.
   - Función: Define el orden "natural" o por defecto del objeto.
   - Implementación: La clase Empleado implementa IComparable y define CompareTo() 
     para ordenarse ALFABÉTICAMENTE por Nombre.
   - Uso en este código: Se usa cuando llamamos a Array.Sort(empleadosPorNombre) 
     SIN pasar un comparador. El sistema sabe cómo ordenar los empleados por sí mismo.
   - Limitación: Solo permite UN criterio de ordenamiento por defecto (el que tú definas).

2. IComparer (Implementado en la CLASE 'ComparadorPorLegajo'):
   - Está en el espacio de nombres System.Collections.
   - Función: Define un criterio de ordenamiento "externo" o personalizado.
   - Implementación: Es una clase separada que implementa IComparer y define Compare().
   - Uso en este código: Se usa cuando llamamos a Array.Sort(empleadosPorLegajo, new ComparadorPorLegajo()).
     Aquí, el array no sabe ordenarse por Legajo por sí mismo, así que le "damos" una lógica externa.
   - Ventaja: Permite múltiples criterios de ordenamiento (por legajo, por salario, por fecha, etc.) 
     sin tener que modificar la clase original 'Empleado'.

Resumen visual :
Característica	      IComparable	                              IComparer
¿Quién lo implementa?	La clase que se va a ordenar (Empleado).	Una clase auxiliar externa (ComparadorPorLegajo).
Método clave	        CompareTo(object obj)	                    Compare(object x, object y)
Cantidad de órdenes	  Solo uno (orden natural).	                Múltiples (permite crear tantos comparadores como sea necesario).
Uso en Array.Sort	    Array.Sort(array) (sin parámetros extra).	Array.Sort(array, nuevoComparador) (requiere instanciarlo).

¿Qué sucederá al ejecutar?
El programa toma el array original.
Crea una copia, la ordena alfabéticamente (Juan, Leo, Mateo) e imprime solo los nombres.
Crea otra copia del original, la ordena por Legajo (12, 79, 123) e imprime nombre + legajo.

Salida esperada:
--- Orden alfabético ---
Soy el empleado Juan
Soy el empleado Leo
Soy el empleado Mateo

--- Orden de legajo ---
Soy el empleado Mateo, Legajo: 12
Soy el empleado Juan, Legajo: 79
Soy el empleado Leo, Legajo: 123
*/
