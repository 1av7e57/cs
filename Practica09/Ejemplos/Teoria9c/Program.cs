﻿// --- CASO 1: Intercambio de enteros usando dynamic ---

// Declaramos variables de tipo 'dynamic'. 
// El compilador no verifica los tipos en tiempo de compilación, todo se resuelve en tiempo de ejecución.
dynamic a = 17;
dynamic b = 23;

// Llamamos al método Swap pasando las variables dinámicas.
// El compilador acepta esto, pero no sabe qué tipo real es 'a' o 'b' hasta que el código corre.
Swap(ref a, ref b);

// Imprimimos los resultados.
// El runtime resuelve el tipo real (int) y ejecuta la conversión implícita para la interpolación.
Console.WriteLine($"a={a} y b={b}");

// --- CASO 2: Intercambio de cadenas usando dynamic ---

// Declaramos variables de tipo 'dynamic' con cadenas.
dynamic s1 = "hola";
dynamic s2 = "mundo";

// Llamamos al mismo método Swap.
// El runtime ahora detecta que son cadenas y ejecuta la lógica sobre ellas.
Swap(ref s1, ref s2);

// Imprimimos los resultados.
Console.WriteLine($"s1={s1} y s2={s2}");

// Definición del método Swap usando 'dynamic'.
// Acepta referencias a objetos dinámicos.
void Swap(ref dynamic i, ref dynamic j)
{
    // Variable temporal dinámica para guardar el valor de 'i'.
    dynamic auxi = i;

    // Intercambio de valores.
    // Todo esto se resuelve en tiempo de ejecución mediante el binder dinámico.
    i = j;
    j = auxi;
}

/*NOTAS:
Análisis de Ventajas y Limitaciones:
El uso de dynamic es un enfoque interesante que se encuentra entre los genéricos y el object, 
pero con un costo de rendimiento diferente.

Ventajas:
    1. Sintaxis Limpia: No requiere casting explícito ((int)) como en la versión object. 
    El código del cliente se ve muy similar al código original con tipos fuertes.

    2. Flexibilidad Total: Funciona con cualquier tipo sin necesidad de declaraciones previas 
    de variables object ni conversiones manuales.

    3. Reutilización: Al igual que con object, un solo método sirve para todos los tipos.

Limitaciones:
    1. Pérdida de Seguridad de Tipos en Compilación:
        -El compilador NO verifica si los tipos son compatibles. Si se intenta pasar un int y un string a Swap, 
        el código compilará sin errores, pero fallará en tiempo de ejecución con un error RuntimeBinderException.
        -Se pierde la capacidad del compilador para atrapar errores antes de ejecutar el programa.

    2. Costo de Rendimiento (Overhead Dinámico):
        -Cada operación dentro del método y cada llamada al método implica una resolución dinámica en tiempo de ejecución. 
        El runtime debe inspeccionar el tipo real de los objetos y buscar la implementación correcta de las operaciones.
        -Esto es significativamente más lento que los genéricos (que se resuelven en tiempo de compilación) y a menudo 
        más lento que el uso directo de tipos fuertes.

    3. Dificultad para Mantenimiento y Refactorización:
        -Si se cambia el nombre de una variable o el tipo de un objeto, el compilador no avisará. 
        Los errores aparecerán solo cuando se ejecute el código y se llegue a esa línea específica.
        -Las herramientas de IDE (como IntelliSense) tienen menos capacidad para ofrecer sugerencias 
        o navegar por el código dinámico.
        
    4.No es Adecuado para C# Genérico Puro:
        -dynamic no es un tipo genérico en el sentido de C#. No genera código específico para cada tipo 
        (como hacen los genéricos <T>). Es más bien una "puerta trasera" al sistema de tipos de .NET 
        que delega todo al runtime.

Conclusión:
    Aunque dynamic ofrece una sintaxis muy cómoda, no es la solución recomendada para implementar métodos genéricos 
    como Swap en C#. Introduce riesgos de seguridad y costos de rendimiento que los Métodos Genéricos (<T>) evitan 
    por completo.
*/
