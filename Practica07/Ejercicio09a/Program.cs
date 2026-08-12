﻿/*Codificar un programa que permita al usuario escribir un texto por consola. 
El mismo puede constar de varios párrafos. 
Se considera el fin de la entrada cuando el usuario ingresa una línea vacía, 
en ese momento el programa solicitará al usuario el nombre del archivo para guardar el texto escrito. 
Si el usuario escribe un nombre de archivo válido, se guarda el texto ingresado en ese archivo, 
de lo contrario no se hace nada y termina el programa.
a) Utilizando la instrucción using
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
El ejercicio está diseñado para practicar el manejo de archivos con 'System.IO', 
el uso de la interfaz 'IDisposable' (a través de la instrucción 'using') 
y la validación básica de entradas.

¿Qué hace el programa?:
    1. Captura de texto: Lee líneas hasta que el usuario ingrese una línea vacía.
    2. Validación: Verifica si el nombre de archivo es válido (no vacío y con extensión opcional).
    3. Escritura segura: Usa 'StreamWriter' dentro de un bloque 'using' para garantizar que el archivo se cierre correctamente aunque ocurra un error.

Puntos clave:
    - 'using (StreamWriter ...)': Esta es la parte más importante. 'StreamWriter' implementa 'IDisposable'. El bloque 'using' asegura que el método 'Dispose()' se llame automáticamente al final del bloque, cerrando el archivo y liberando el descriptor del sistema operativo. Sin esto, el archivo podría quedarse "bloqueado" o no guardarse completamente.
    - 'Path.Combine' y 'Path.HasExtension': Ayudan a construir rutas de archivo de manera segura y a manejar extensiones sin depender de la lógica manual de cadenas.
    - 'Encoding.UTF8': Especificamos la codificación para asegurar que caracteres especiales (tildes, ñ, etc.) se guarden correctamente.
    -'string.IsNullOrWhiteSpace': Es más seguro que otras alternativas como 'string.Empty' porque también descarta líneas que solo contienen espacios.
    - Manejo de excepciones: El bloque 'try-catch' es buena práctica para capturar errores como permisos denegados o archivos abiertos por otro proceso.
*/
