﻿// --- CASO 1: Intercambio de enteros usando Genéricos ---

// Inicializamos variables de tipo fuerte 'int'.
int a = 17;
int b = 23;

// Llamamos al método Swap especificando explícitamente el tipo de argumento <int>.
// El compilador genera una versión específica de Swap para 'int' en tiempo de compilación.
// No hay Boxing ni Unboxing, se trabaja directamente con el tipo de valor.
Swap<int>(ref a, ref b);

// Imprimimos los resultados.
// Como los tipos son fuertes, no se necesitan conversiones explícitas.
Console.WriteLine($"a={a} y b={b}");

// --- CASO 2: Intercambio de cadenas usando Genéricos ---

// Inicializamos variables de tipo fuerte 'string'.
string s1 = "hola";
string s2 = "mundo";

// Llamamos al mismo método Swap, pero esta vez especificando <string>.
// El compilador genera una versión específica para 'string' reutilizando la misma lógica.
Swap<string>(ref s1, ref s2);

// Imprimimos los resultados.
Console.WriteLine($"s1={s1} y s2={s2}");

// Definición del método Swap Genérico.
// '<T>' declara un parámetro de tipo genérico llamado 'T' (por Type).
// 'T' actúa como un marcador de posición que se reemplazará por el tipo real al llamar al método.
void Swap<T>(ref T i, ref T j)
{
    // Declaramos una variable temporal del tipo 'T'.
    // Si el tipo real es 'int', 'auxiliar' será un int. Si es 'string', será un string.
    T auxiliar = i;

    // Intercambio de valores.
    // Esta lógica es idéntica para todos los tipos, pero el compilador la optimiza para cada uno.
    i = j;
    j = auxiliar;
}

/*NOTAS:
Análisis de Ventajas y Limitaciones:
    Esta es la solución "estándar" y recomendada en C# para este tipo de problemas.

Ventajas Clave:
    1. Seguridad de Tipos en Tiempo de Compilación:
        -El compilador verifica que i y j sean del mismo tipo T. Si se intenta pasar un int y un string, 
        el compilador lanzará un error antes de que el programa se ejecute.
        -No hay riesgo de InvalidCastException en tiempo de ejecución.

    2. Rendimiento Óptimo (Sin Boxing/Unboxing):
        -A diferencia de object, los tipos de valor (int, double, struct) se manipulan directamente 
        sin envolverlos en objetos.
        -El compilador genera código nativo específico para cada tipo utilizado, logrando 
        el máximo rendimiento posible, igual que si se hubiera escrito la función manualmente para cada tipo.

    3. Reutilización de Código (DRY):
        - Se escribes la lógica una sola vez. El compilador se encarga de generar las versiones necesarias 
        para int, string, double, o cualquier clase personalizada que se use.

    4. Sintaxis Clara y Tipada:
        -El código es legible y las herramientas de IDE (IntelliSense) funcionan perfectamente, ofreciendo 
        autocompletado y navegación precisa.

Posibles limitaciones a tener en cuenta:
    1. Requisito de Tipo Homogéneo:
        -La firma Swap<T>(ref T i, ref T j) obliga a que ambos argumentos sean del mismo tipo exacto.
        -No se puede intercambiar un int con un long directamente (ambos son enteros, pero tipos distintos). 
        Se tendría que convertir uno primero.
        -Nota: Esto es a menudo una característica deseable para evitar errores, pero puede ser una limitación 
        si necesitas interoperar entre tipos relacionados.

    2. Código Generado (Bloat):
    -El compilador genera una versión del método para cada tipo de valor único que se use. 
    Si se usara Swap con 50 tipos de structs diferentes, el archivo .dll contendría 50 copias del código del método.
    -Nota: Para tipos de referencia (clases), solo se genera una versión compartida, por lo que el impacto es mínimo. 
    Para tipos de valor, el impacto en el tamaño del ejecutable suele ser despreciable a menos que se use 
    cientos de tipos.

    3. No hay Polimorfismo en la Lógica Interna:
        -Dentro del método Swap, no puede llamarse a métodos específicos del tipo T a menos que se añadan restricciones
        (usando where).
        -Por ejemplo, si se quisiera ordenar en lugar de intercambiar, y se necesitara comparar elementos, se tendría
        que añadir where T : IComparable<T> para que el compilador sepa que T tiene un método .CompareTo().

Conclusión:
    El uso de Métodos Genéricos (<T>) es la forma correcta, segura y eficiente de implementar esta funcionalidad 
    en C#. Combina la flexibilidad de reutilizar código con la seguridad y el rendimiento de los tipos fuertes.

Comparación Final
    Característica	int (Específico)  object	          dynamic	          Genérico <T>
    Seguridad	    ✅ Alta	         ❌ Baja (Runtime)   ❌ Baja (Runtime)   ✅ Alta (Compilación)
    Rendimiento	    ✅ Máximo	     ⚠️ Medio (Boxing)	 ⚠️ Bajo (Overhead)	 ✅ Máximo (Sin Boxing)
    Reutilización	❌ Nula	         ✅ Alta	            ✅ Alta	           ✅ Alta
    Sintaxis	    ✅ Limpia	     ❌ Verbosa (Casts)  ✅ Limpia	       ✅ Limpia
*/
