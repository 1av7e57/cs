// 1. Declaramos las variables como nulas inicialmente.
//    Usamos el operador '?' (nullable) porque no sabemos si se asignarán un valor
//    antes de que el código intente usarlas (por ejemplo, si falla la creación del archivo).
StreamReader? sr = null;
StreamWriter? sw = null;
try
{
    // 2. Intentamos abrir el archivo de origen para lectura.
    //    Si "fuente.txt" no existe o no hay permisos, se lanzará una excepción aquí.
    sr = new StreamReader("fuente.txt");
    // 3. Intentamos abrir (o crear) el archivo de destino para escritura.
    //    Si se lanza una excepción en el paso anterior, esta línea nunca se ejecutará.
    sw = new StreamWriter("destino.txt");
    // 4. Diferencia principal:
    //    - sr.ReadToEnd(): Lee TODO el contenido del archivo origen y lo guarda en una variable de string (en memoria).
    //    - sw.Write(...): Escribe ese string completo en el archivo destino de una sola vez.
    //    Esto es mucho más rápido que leer línea por línea para archivos pequeños/medianos,
    //    pero consume más memoria RAM si el archivo es muy grande.    
    sw.Write(sr.ReadToEnd()); // aqui se hace todo el trabajo
}
catch (Exception e)
{
    // 5. Bloque de captura de errores.
    //    Si ocurre cualquier problema (archivo no encontrado, permiso denegado, disco lleno, etc.),
    //    el flujo salta aquí inmediatamente, evitando que el programa se cierre abruptamente.
    //    Imprimimos el mensaje de error para diagnosticar qué falló.    
    Console.WriteLine(e.Message);
}
// 6. Bloque de limpieza OBLIGATORIO.
    //    El bloque 'finally' se ejecuta SIEMPRE, sin importar si el código en 'try' tuvo éxito o hubo un error.
    //    Esto garantiza que los recursos del sistema (manejadores de archivos) se liberen aunque haya fallado.
finally // Es recomendable proveer un manejo de excepciones y liberar los recursos con un bloque finally
{
    // 7. Liberación de recursos.
    //    El operador '?.' (null-conditional operator) verifica si la variable no es nula antes de llamar a Dispose().
    //    Si 'sr' o 'sw' fallaron al crearse (son null), esto evita un error de "NullReferenceException".
    //    sr?.Dispose(); es equivalente a sr?.Close(); pero más explícito con la interfaz IDisposable.
    sr?.Dispose();
    sw?.Dispose();
}// podemos usar Dispose en vez de Close

/*NOTAS:
 Esta variante muestra una forma más concisa y potente de copiar archivos: 
 -En lugar de leer y escribir línea por línea, lee todo el contenido a la vez en memoria y lo escribe de golpe. 
 También introduce el uso explícito de bloques try-catch-finally para la gestión de recursos.

Podríamos haber usado 'Close()' en lugar de 'Dispose()' porque ambos liberan el recurso.
Sin embargo, Dispose() es el método estándar de la interfaz IDisposable para liberar recursos no gestionados.
En el código moderno, se prefiere el bloque 'using' para evitar tener que escribir este bloque finally manualmente.
*/
