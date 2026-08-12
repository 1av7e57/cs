/// ejemplo 1
using System;            // Importamos 'System' para usar Console.WriteLine y tipos básicos
using System.Collections; // Importamos 'System.Collections' para usar la interfaz 'IEnumerator'

// Clase principal del programa
class Program
{
    // Método principal: Punto de entrada del programa
    static void Main()
    {
        // 1. Llamamos al método Numeros() para obtener un iterador.
        // IMPORTANTE: En este momento, el código DENTRO de Numeros() NO se ejecuta aún.
        // Solo se crea un objeto iterador "listo para usar" (punto de inicio).
        IEnumerator e = Numeros();

        // 2. Iniciamos un bucle 'while' que controla la iteración.
        // La condición 'e.MoveNext()' avanza el iterador al siguiente elemento.
        // Si hay un elemento válido, devuelve 'true' y entra al bloque.
        // Si se acabaron los elementos, devuelve 'false' y termina el bucle.
        while (e.MoveNext())
        {
            // 3. Accedemos a la propiedad 'Current' para obtener el valor que el iterador generó
            // en la última llamada a 'MoveNext()' (gracias al 'yield return').
            // Nota: Solo es seguro leer 'Current' si 'MoveNext()' devolvió 'true'.
            Console.WriteLine(e.Current);
        }
    }

    // Método que genera la secuencia de números.
    // La presencia de 'yield return' hace que el compilador transforme
    // este método normal en una clase que implementa 'IEnumerator' automáticamente.
    static IEnumerator Numeros()
    {
        // Variable local 'i' inicializada en 0.
        // Esta variable se guarda en el estado del iterador.
        // Su valor se "congela" cada vez que se llega a un 'yield return'.
        int i = 0;

        // Bucle infinito 'while(true)' que controla la generación de la secuencia.
        // Gracias a 'yield', este bucle no es infinito en la práctica,
        // porque se pausa en cada 'yield return' y solo reanuda si alguien llama a 'MoveNext()'.
        while (true)
        {
            // Verificamos si el valor actual de 'i' es menor o igual a 3.
            if (i <= 3)
            {
                // YIELD RETURN:
                // 1. Devuelve el valor actual de 'i' como el 'Current' del iterador.
                // 2. PAUSA la ejecución del método justo aquí.
                // 3. Guarda el estado actual de la variable 'i' y el punto de ejecución.
                // 4. El método retorna 'true' a quien llamó a 'MoveNext()'.
                //
                // El operador 'i++' (post-incremento) devuelve el valor actual de 'i'
                // y luego lo incrementa en 1, pero el incremento queda guardado para la próxima reanudación.
                yield return i++;
            }
            else
            {
                // YIELD BREAK:
                // Indica que no hay más elementos que generar.
                // Detiene la ejecución del método definitivamente.
                // El método retorna 'false' a quien llamó a 'MoveNext()', terminando el bucle 'while'.
                yield break;
            }
        }
    }
}

/*NOTAS:
Este ejemplo muestra la forma moderna y recomendada de crear iteradores en C#, utilizando la palabra clave yield.

La diferencia fundamental con el ejercicio de Enumeracion es que, 
mientras la primera implementación (EnumeradorEstaciones) requería 
que se escribiera manualmente toda la lógica de estado (actual, switch, MoveNext, Reset), 
aquí el compilador de C# hace todo el trabajo detrás de escena.

1. ¿Qué hace este código?
El método Numeros() genera una secuencia de números: 0, 1, 2, 3.
-Usa yield return i++ para devolver el valor actual e incrementar la variable i.
-Usa yield break para detener la iteración cuando i supera 3.
2. El Poder de yield: "Iteradores Automáticos"
Cuando el compilador ve un método que contiene yield return o yield break, no genera el código tal cual SE lee. 
En su lugar, genera automáticamente una clase oculta que implementa IEnumerator (o IEnumerable).

3. Comparativa: Manual vs. yield

Característica	Implementación Manual (IEnumerator)							                         Con yield return
Código		    Verboso, requiere escribir switch, Reset, Current, estado explícito.			     Limpio, conciso, parece un método normal.
Estado		    Deben gestionarse manualmente las variables de estado.					             El compilador lo gestiona automáticamente.
Legibilidad	    La lógica de flujo puede ser difícil de seguir.						                 La lógica es lineal y fácil de leer.
Mantenimiento	Difícil de modificar (cambiar lógica requiere ajustar switch).				         Muy fácil de modificar.
Rendimiento	    Ligeramente más rápido (sin overhead de generación de clases), pero insignificante.	 Ligeramente más lento por la generación de clases, pero inapreciable en la mayoría de casos.
*/
