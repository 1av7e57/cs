﻿/*Investigar acerca de la clase StringBuilder del espacio de nombre System.Text ¿En qué
circunstancias es preferible utilizar StringBuilder en lugar de utilizar string? 
Implementar un caso de ejemplo en el que el rendimiento sea claramente superior 
utilizando StringBuilder en lugar de string y otro en el que no.

Respuestas:

- La clase StringBuilder (System.Text.StringBuilder)
La clase StringBuilder es una herramienta diseñada para manipular cadenas de caracteres de manera eficiente cuando se realizan muchas modificaciones.
En C#, las cadenas (string) son inmutables. Esto significa que cada vez que se modifica una cadena (haciendo un +=, Concat, Replace, etc.), 
el sistema crea una nueva instancia de cadena en memoria y descarta la antigua. Si se hace esto en un bucle, se genera una gran cantidad de 
residuos de memoria y baja el rendimiento.
StringBuilder soluciona esto al ser mutable. Internamente usa un búfer de caracteres que puede expandirse dinámicamente. 
Puede agregarse, insertarse, eliminar o reemplazar texto en este objeto sin crear nuevas instancias en memoria en cada operación, 
lo que lo hace mucho más rápido y eficiente para operaciones intensivas de concatenación.

Características clave de StringBuilder:
- Mutabilidad: Puedes cambiar su contenido sin crear nuevos objetos.
- Capacidad Dinámica: Aumenta automáticamente su capacidad interna si el texto excede el límite actual.
Métodos Comunes:
.Append(): Agrega texto al final.
.AppendLine(): Agrega texto con un salto de línea.
.Insert(): Inserta texto en una posición específica.
.Remove(): Elimina una sección de texto.
.Replace(): Sustituye una cadena por otra.
.ToString(): Convierte el contenido final a una cadena inmutable string estándar.

¿Cuándo usar StringBuilder?
- SÍ: En bucles for o while donde concatenas texto muchas veces.
- SÍ: Cuando construyes queries SQL dinámicos o archivos de texto grandes programáticamente.
- NO: Para concatenaciones simples de 2 o 3 cadenas (ahí el compilador optimiza las cadenas normales mejor).

Casos de Ejemplo:
- Caso A: donde StringBuilder es superior: Concatenación en bucle
En este ejemplo, concatenamos 100,000 veces. Usar string aquí sería extremadamente lento 
porque el sistema crearía una nueva instancia de cadena en cada iteración, 
copiando todo el contenido acumulado. StringBuilder solo reserva memoria una vez y la reutiliza.

- Caso B: donde string es superior (o preferible): Comparaciones y Operaciones Simples
string es superior cuando necesitas inmutabilidad, seguridad en hilos (thread-safe) por defecto, o cuando realizas operaciones únicas 
como comparaciones, búsquedas de subcadenas o formateo simple. StringBuilder no tiene sentido aquí porque la sobrecarga de crear el objeto y
luego convertirlo a string al final añadiría tiempo innecesario para una operación que ya es rápida de por sí.*/

using System;             // Importamos el namespace System para usar la consola y tipos básicos
using System.Diagnostics; // Necesario para la clase Stopwatch
using System.Text;        // Necesario para StringBuilder

class Program // Definimos la clase principal del programa
{

    // Método que ejecuta el 'Caso A' de alto rendimiento con StringBuilder vs String usando Stopwatch
    static void EjecutarCasoA()
    {
        string resultadoString = "";
        StringBuilder resultadoSb = new StringBuilder();
        int iteraciones = 100000;

        // --- Prueba con String (Inmutable) ---
        // Creamos y arrancamos el cronómetro
        Stopwatch cronometroString = Stopwatch.StartNew();

        // Bucle intensivo: cada iteración crea una nueva cadena en memoria
        for (int i = 0; i < iteraciones; i++)
        {
            resultadoString += i.ToString();
        }

        // Detenemos el cronómetro
        cronometroString.Stop();

        // --- Prueba con StringBuilder (Mutable) ---
        // Creamos y arrancamos el cronómetro
        Stopwatch cronometroSb = Stopwatch.StartNew();

        // Bucle intensivo: modifica el mismo objeto en memoria
        for (int i = 0; i < iteraciones; i++)
        {
            resultadoSb.Append(i.ToString());
        }

        // Detenemos el cronómetro
        cronometroSb.Stop();

        // --- Resultados ---
        // Mostramos el tiempo en milisegundos usando la propiedad ElapsedMilliseconds
        Console.WriteLine("Tiempo con String:        " + cronometroString.ElapsedMilliseconds + " ms");
        Console.WriteLine("Tiempo con StringBuilder: " + cronometroSb.ElapsedMilliseconds + " ms");
        
        // Calculamos la diferencia para ver la mejora
        double diferencia = cronometroString.ElapsedMilliseconds - cronometroSb.ElapsedMilliseconds;
        Console.WriteLine("Diferencia: " + diferencia + " ms (StringBuilder es más rápido)");
        
        // Mostrar precisión en ticks para ver la resolución del cronómetro
        // Muestra el número de "ticks" del contador de hardware. Es la unidad más básica de medición de Stopwatch.
        Console.WriteLine("Precisión (String): " + cronometroString.ElapsedTicks + " ticks");
        Console.WriteLine("Precisión (Sb):     " + cronometroSb.ElapsedTicks + " ticks");
    }

    // Método que ejecuta el 'Caso B' de operaciones simples con String usando Stopwatch
    static void EjecutarCasoB()
    {
        string nombreUsuario = "Carlos";
        string nombreIngresado = "Carlos";
        string textoCompleto = "Bienvenido al sistema de C#";

        // --- Prueba: Comparación y búsqueda ---
        // Creamos y arrancamos el cronómetro
        Stopwatch cronometro = Stopwatch.StartNew();

        // 1. Comparación directa (muy rápida)
        if (nombreUsuario == nombreIngresado)
        {
            // No hacemos nada, solo la comparación cuenta
        }

        // 2. Búsqueda de subcadena
        bool existeCSharp = textoCompleto.Contains("C#");

        // 3. Formateo de cadena simple
        string mensajeFinal = string.Format("Hola, {0}. Tu sesión ha comenzado.", nombreUsuario);

        // 4. Reemplazo simple (crea nueva cadena)
        string textoModificado = textoCompleto.Replace("sistema", "entorno");

        // Detenemos el cronómetro
        cronometro.Stop();

        // Calculamos la duración total de estas operaciones combinadas
        // Usamos TotalMilliseconds para ver decimales si es necesario
        double duracion = cronometro.Elapsed.TotalMilliseconds;

        // Mostrar resultados
        Console.WriteLine("Tiempo operaciones simples: " + duracion + " ms");
        Console.WriteLine("Resultado validación: " + (nombreUsuario == nombreIngresado ? "Válido" : "Inválido"));
        Console.WriteLine("¿Existe C#?: " + existeCSharp);
        Console.WriteLine("Mensaje: " + mensajeFinal);
        
        // Nota: El tiempo aquí será extremadamente bajo (probablemente < 0.01 ms).
        // Esto demuestra que usar StringBuilder aquí sería contraproducente.
    }
        static void Main() // El método Main es el punto de entrada donde comienza la ejecución
    {
        Console.WriteLine("=== CASO A: Concatenación masiva (100,000 iteraciones) ===");
        EjecutarCasoA();

        Console.WriteLine("\n=== CASO B: Operaciones simples y comparaciones ===");
        EjecutarCasoB();
    }
}

/*
Conclusión:
- Conviene usar StringBuilder cuando se va a modificar el texto muchas veces (bucles, construcción dinámica).
- Conviene usar string cuando el texto es fijo, se usa para comparar, buscar, o haces una única concatenación/formateo simple. 
La inmutabilidad de string lo hace más seguro y a menudo más rápido para operaciones puntuales.
*/
