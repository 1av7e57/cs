﻿/*Codificar un programa que permita al usuario escribir un texto por consola. 
El mismo puede constar de varios párrafos. 
Se considera el fin de la entrada cuando el usuario ingresa una línea vacía, 
en ese momento el programa solicitará al usuario el nombre del archivo para guardar el texto escrito. 
Si el usuario escribe un nombre de archivo válido, se guarda el texto ingresado en ese archivo, 
de lo contrario no se hace nada y termina el programa.
b) Sin utilizar la instrucción using
*/

using System; // Importamos para usar Console y tipos básicos.

// Usamos el espacio de nombres que definimos para el proyecto.
using GestionTextoArchivos;

// Clase principal del programa.
class Program
{
    // El método Main es el punto de entrada.
    static void Main()
    {
        // Mensaje inicial de bienvenida para el usuario.
        Console.WriteLine("=== Editor de Texto ===");
        // Línea en blanco para separar visualmente.
        Console.WriteLine("");

        // 1. INSTANCIACIÓN:
        // Creamos una nueva instancia (objeto) de la clase EditorTexto.
        // 'var' infiere el tipo automáticamente (es un EditorTexto).
        // Aquí se ejecuta el constructor de EditorTexto, inicializando la lista vacía.
        var editor = new EditorTexto();

        // 2. CAPTURA DE DATOS:
        // Llamamos al método del objeto para que el usuario escriba el texto.
        // Este método es el que contiene el bucle 'while' y la lógica de lectura.
        editor.CapturarTexto();

        // 3. VALIDACIÓN DE DATOS:
        // Llamamos al método para verificar si el usuario escribió algo.
        // Devuelve true si la lista no está vacía, false si lo está.
        if (!editor.TieneTexto())
        {
            // Si no hay texto, informamos y terminamos el programa inmediatamente.
            Console.WriteLine("\nNo se escribió ningún texto. Programa finalizado.");
            // 'return' sale del método Main, terminando la ejecución del programa.
            return;
        }

        // 4. SOLICITUD DE NOMBRE:
        // Pedimos al usuario que ingrese el nombre del archivo.
        Console.WriteLine("\nIntroduce el nombre del archivo para guardar el texto:");
        // Leemos la respuesta del usuario y la guardamos en una variable local.
        string? nombreArchivo = Console.ReadLine();

        // 5. EJECUCIÓN DE LA ACCIÓN:
        // Llamamos al método de guardado pasando el nombre ingresado.
        // El método internamente validará, creará el archivo y manejará errores.
        editor.GuardarEnArchivo(nombreArchivo!);

    }
}

/*NOTAS:
Es posible crear una versión sin 'using' del programa, 
manteniendo la misma funcionalidad (pero gestionando los recursos manualmente). 
Esto se debe a que la instrucción 'using' es simplemente "azúcar sintáctico" 
(una forma más corta y segura) de lo que se conoce como un bloque try-finally.

Sin using, uno es responsable explícito de cerrar el recurso (el archivo). 
Si se olvida hacerlo, el archivo podría quedar "bloqueado" o los datos podrían 
no guardarse completamente hasta que el recolector de basura (Garbage Collector) 
decida limpiarlo, lo cual es impredecible.

Puntos Clave de Diferenciación:
    Declaración de Variable (StreamWriter? escritor = null;):
        Con using: La variable se declara dentro del paréntesis using (...). Su alcance está limitado al bloque.
        Sin using: Debemos declararla fuera del try para poder acceder a ella dentro del finally.

    El Bloque finally:
        Con using: El compilador genera este bloque automáticamente.
        Sin using: 
            - try: Colocamos el código de escritura.
            - finally: Aquí es obligatorio poner la lógica de cierre (escritor.Dispose() o escritor.Close()). Este bloque se ejecuta siempre, haya error o no.

    Verificación de null:
        Con using: No es necesaria la verificación if (escritor != null) porque el using solo entra si la instancia fue exitosa.
        Sin using: Es crítico verificar if (escritor != null). Si el new StreamWriter(...) falla, la variable sigue siendo null. Intentar llamar a .Dispose() sobre null lanzaría una excepción, así que la verificación es obligatoria para evitar errores de ejecución.

Comparativa: ¿Qué pasa si algo sale mal?
    Imaginemos que el disco está lleno o el archivo está abierto por otro programa 
    justo cuando se intenta escribir.

    Versión con using (Recomendada)
        try {
            using (var escritor = new StreamWriter(...)) {
                // Si esto falla:
                escritor.WriteLine(línea); 
            }
        } catch { ... }
    Si WriteLine lanza una excepción, el flujo salta al catch.
    Antes de entrar al catch, el compilador inserta automáticamente un finally que llama a escritor.Dispose().
    El archivo se cierra correctamente. 
    Es Seguro.

    Versión sin using (Manual)
        StreamWriter? escritor = null;
        try {
            escritor = new StreamWriter(...);
            escritor.WriteLine(línea); // Si esto falla...
        } catch { ... }
        finally {
            if (escritor != null) w.Dispose(); // ... AQUÍ se cierra el archivo.
        }
    Si WriteLine lanza una excepción, el flujo salta al catch.
    Luego, obligatoriamente entra al finally.
    Ejecuta escritor.Dispose().
    El archivo se cierra correctamente. 
    También seguro, pero más verboso.
*/
