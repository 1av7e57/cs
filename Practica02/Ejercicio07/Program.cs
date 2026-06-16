﻿/*Investigar sobre el tipo DateTime y usarlo para medir el tiempo de ejecución de los algoritmos
implementados en el ejercicio anterior.

El tipo DateTime en C# 
Ubicado en el espacio de nombres System, es una estructura de valor (struct) que representa instantes de tiempo específicos, 
con fecha y hora, desde el 1 de enero del año 1 del calendario gregoriano hasta el 31 de diciembre del año 9999.

Características principales:
- Precisión: Representa el tiempo con una precisión de 100 nanosegundos (un "tallo").
- Inmutabilidad: Al igual que string, DateTime es inmutable. Cualquier operación que parezca modificarlo (como AddDays) en realidad devuelve una nueva instancia con el valor actualizado.
- Kinds: Puede representar tiempo en diferentes contextos mediante la propiedad Kind:
- Unspecified: No se especifica la zona horaria.
- Utc: Tiempo Universal Coordinado.
- Local: Hora local del equipo donde se ejecuta el código.
Operaciones Comunes:
-Propiedades: Now (fecha/hora actual), Today (fecha actual a las 00:00), Year, Month, Day, Hour, etc.
-Métodos: AddDays(), AddHours(), Subtract(), Compare(), ToString() (para formatear la salida).
-Comparación: Se pueden usar operadores como ==, <, > para comparar fechas.

Ejemplo:
El siguiente código integra las dos implementaciones anteriores:
- Caso A(string vs StringBuilder) 
- Caso B(operaciones simples con string)
utilizando DateTime para medir el tiempo de ejecución
*/

using System; // Importamos el namespace System para usar la consola y tipos básicos como DateTime
using System.Text; // Necesario para StringBuilder

class Program // Definimos la clase principal del programa
{

    // Método que ejecuta el escenario de alto rendimiento con StringBuilder vs String
    static void EjecutarCasoA()
    {
        string resultadoString = "";
        StringBuilder resultadoSb = new StringBuilder();
        int iteraciones = 100000;

        // --- Prueba con String (Inmutable) ---
        // Capturamos el momento de inicio usando DateTime.Now
        DateTime inicioString = DateTime.Now;

        // Bucle intensivo: cada iteración crea una nueva cadena en memoria
        for (int i = 0; i < iteraciones; i++)
        {
            resultadoString += i.ToString();
        }

        // Capturamos el momento de fin
        DateTime finString = DateTime.Now;

        // Calculamos la diferencia restando los dos objetos DateTime
        // El resultado es un objeto TimeSpan que contiene la duración
        TimeSpan duracionString = finString - inicioString;

        // --- Prueba con StringBuilder (Mutable) ---
        // Capturamos el momento de inicio
        DateTime inicioSb = DateTime.Now;

        // Bucle intensivo: modifica el mismo objeto en memoria
        for (int i = 0; i < iteraciones; i++)
        {
            resultadoSb.Append(i.ToString());
        }

        // Capturamos el momento de fin
        DateTime finSb = DateTime.Now;

        // Calculamos la diferencia
        TimeSpan duracionSb = finSb - inicioSb;

        // --- Resultados ---
        // Mostramos el tiempo en milisegundos usando la propiedad TotalMilliseconds
        Console.WriteLine("Tiempo con String:        " + duracionString.TotalMilliseconds + " ms");
        Console.WriteLine("Tiempo con StringBuilder: " + duracionSb.TotalMilliseconds + " ms");
        
        // Calculamos la diferencia absoluta para ver la mejora
        double diferencia = duracionString.TotalMilliseconds - duracionSb.TotalMilliseconds;
        Console.WriteLine("Diferencia: " + diferencia + " ms (StringBuilder es más rápido)");
    }

    // Método que ejecuta el escenario de operaciones simples con String
    static void EjecutarCasoB()
    {
        string nombreUsuario = "Carlos";
        string nombreIngresado = "Carlos";
        string textoCompleto = "Bienvenido al sistema de C#";

        // --- Prueba: Comparación y búsqueda ---
        // Inicia el cronómetro
        DateTime inicio = DateTime.Now;

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

        // Finaliza el cronómetro
        DateTime fin = DateTime.Now;

        // Calculamos la duración total de estas operaciones combinadas
        TimeSpan duracion = fin - inicio;

        // Mostrar resultados
        Console.WriteLine("Tiempo operaciones simples: " + duracion.TotalMilliseconds + " ms");
        Console.WriteLine("Resultado validación: " + (nombreUsuario == nombreIngresado ? "Válido" : "Inválido"));
        Console.WriteLine("¿Existe C#?: " + existeCSharp);
        Console.WriteLine("Mensaje: " + mensajeFinal);
        
        // Nota: El tiempo aquí será casi 0 ms (o < 0.1 ms) porque las operaciones son triviales.
        // Usar StringBuilder aquí sería más lento por la sobrecarga de crear el objeto.
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
Nota: 
Aunque Stopwatch es más preciso para benchmarks de alto rendimiento (usa el contador de hardware), DateTime es 
perfectamente funcional para ver diferencias drásticas como las de concatenar 100,000 veces.
*/
