/// ejemplo 2
using System;             // Importamos 'System' para usar Console.WriteLine
using System.Collections; // Importamos 'System.Collections' para usar la interfaz 'IEnumerable'

// Clase principal del programa
class Program
{
    // Método principal: Punto de entrada del programa
    static void Main()
    {
        // 1. Llamamos al método PoderesEstado().
        // Como el método devuelve un 'IEnumerable', el compilador genera automáticamente
        // una clase que implementa esta interfaz.
        // IMPORTANTE: El código dentro de PoderesEstado() NO se ejecuta aquí.
        // Solo se crea un objeto "enumerable" listo para ser recorrido.
        IEnumerable poderes = PoderesEstado();

        // 2. Iniciamos un bucle 'foreach' (bucle "por cada").
        // El 'foreach' es "azúcar sintáctico" (syntax sugar).
        // Internamente, el compilador traduce esto a:
        //   - Obtener un enumerador llamando a poderes.GetEnumerator().
        //   - Llamar a MoveNext() repetidamente.
        //   - Leer la propiedad Current.
        //   - Manejar la finalización cuando MoveNext() devuelve false.
        
        // "var p" declara una variable local 'p' que tomará el valor de cada elemento.
        // Como la interfaz es no genérica (IEnumerable), cada elemento es de tipo 'object'.
        foreach (var p in poderes)
        {
            // 3. Imprimimos el valor actual del bucle.
            // 'p' contiene el valor devuelto por el último 'yield return'.
            // Console.WriteLine llama automáticamente a .ToString() en el objeto 'p'.
            Console.WriteLine(p);
        }
    }

    // Método que genera la colección de poderes del estado.
    // La firma 'IEnumerable PoderesEstado()' indica que devuelve un objeto enumerable.
    // Al tener 'yield return' dentro, el compilador genera la lógica de enumeración automáticamente.
    static IEnumerable PoderesEstado()
    {
        // Primer YIELD RETURN:
        // Devuelve la cadena "Ejecutivo".
        // La ejecución se pausa aquí.
        // El siguiente elemento será devuelto la próxima vez que alguien pida el siguiente item.
        yield return "Ejecutivo";

        // Segundo YIELD RETURN:
        // Al reanudar, la ejecución continúa desde aquí.
        // Devuelve "Legislativo".
        // La ejecución se pausa de nuevo.
        yield return "Legislativo";

        // Tercer YIELD RETURN:
        // Reanuda y devuelve "Judicial".
        // La ejecución se pausa.
        yield return "Judicial";

        // Nota: Al llegar al final del método sin más 'yield return',
        // el compilador genera implícitamente un 'yield break' para indicar el fin.
    }
}

/*NOTAS:
Este segundo ejemplo es aún más elegante porque combina la potencia del yield return 
con la sintaxis foreach, que es el estándar en C# para recorrer colecciones.

1. Diferencias Clave: Ejemplo1 vs Ejemplo2

Característica		Ejemplo 1 (IEnumerator manual + while)				            Ejemplo 2 (IEnumerable + yield + foreach)
Sintaxis de uso		Requiere while y llamadas manuales a MoveNext().	            Usa foreach, mucho más limpio y legible.
Gestión de errores	Si se olvida llamar a MoveNext() antes de Current, falla.		El foreach maneja automáticamente la llamada a MoveNext() y Current.
Seguridad		    Si no se verifica MoveNext(), puede acceder a Current inválido.	El foreach garantiza que solo se itera sobre elementos válidos.
Legibilidad		    Verboso.							                            Muy conciso.


2. Diferencias Clave: IEnumerable vs IEnumerator

Característica	    IEnumerable (El "Contenedor")	                                        IEnumerator (El "Cursor")
Función Principal	Representa una colección de datos que puede ser enumerada.	            Representa el estado actual de la iteración (el cursor que se mueve).
Responsabilidad	    Proveer un enumerador para recorrer sus elementos.	                    Mantener el punto de posición y devolver el elemento actual.
Método Clave	    GetEnumerator() (Devuelve un IEnumerator).	                            MoveNext() (Avanza), Reset() (Vuelve al inicio).
Propiedad Clave	    NO tiene una propiedad Current.                         	            Current (Devuelve el elemento en la posición actual).
Analogía	        Es como un libro completo.	                                            Es como el dedo que señala la página actual mientra se lee.
Uso Común	        Se usa en la firma de métodos que generan secuencias (yield return).	Se usa internamente por el foreach o manualmente en bucles while.

3. Relación / Ciclo de Vida:
-Se tiene un objeto que implementa IEnumerable (ej. una lista, el método PoderesEstado).
-Para recorrerlo, se llama a su método GetEnumerator().
-Eso devuelve un objeto IEnumerator.
-Se Usa MoveNext() en el enumerador para avanzar.
-Se Lee Current para obtener el valor.
-Se repite hasta que MoveNext() devuelva false.

4. Ejemplo visual rápido:

    // IEnumerable: El objeto que puede ponerse en un foreach
    IEnumerable<string> datos = ObtenerDatos(); 

    // IEnumerator: El objeto que el foreach usa internamente
    IEnumerator<string> cursor = datos.GetEnumerator(); 

    // El cursor tiene la posición y el valor
    cursor.MoveNext(); 
    string valorActual = cursor.Current; 


5. Nota para C# Moderno (yield):
Cuando se usa yield return en un método que devuelve IEnumerable<T>, el compilador 
genera ambas clases automáticamente (una que implementa IEnumerable para ser el contenedor 
y otra que implementa IEnumerator para ser el cursor).

Por eso, en el código con yield, rara vez se ve IEnumerator escrito explícitamente. 
El foreach lo gestiona todo por detrás.
*/
