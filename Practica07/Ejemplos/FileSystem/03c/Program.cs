
// Bloque de protección por si ocurre algún error durante la apertura o lectura/escritura.
try
{
    // 1. Primer recurso: Abrir el archivo de origen para LECTURA.
    //    Al usar 'using', si algo falla abajo, este se cerrará automáticamente.
    using (StreamReader sr = new StreamReader("fuente.txt"))
    {
        // 2. Segundo recurso: Abrir el archivo de destino para ESCRITURA.
        //    Está "dentro" del primer using, lo que significa que:
        //    - Solo se intenta abrir si el primero se abrió con éxito.
        //    - Se cerrará ANTES que el primero cuando salga del bloque interno.
        using (StreamWriter sw = new StreamWriter("destino.txt"))
        {
            // 3. Operación: Leer TODO el contenido de 'sr' y escribirlo en 'sw'.
            //    Como ambos están abiertos y gestionados por 'using', es seguro.
            sw.Write(sr.ReadToEnd());
        } 
        // <--- Al salir de aquí, sw.Dispose() se llama AUTOMÁTICAMENTE.
        //      El archivo destino queda cerrado y liberado.
    } 
    // <--- Al salir de aquí, sr.Dispose() se llama AUTOMÁTICAMENTE.
    //      El archivo fuente queda cerrado y liberado.
}
catch (Exception e)
{
    // 4. Captura cualquier error (archivo no encontrado, permisos, disco lleno, etc.)
    //    Si ocurre un error, los bloques 'using' aún se ejecutarán (su limpieza) 
    //    antes de entrar aquí, asegurando que no queden archivos abiertos.
    Console.WriteLine(e.Message);
}

/*NOTAS:
Este ejemplo ilustra una práctica muy común antes de la sintaxis moderna de C#: 
el anidamiento de sentencias using.

Puntos Clave del Anidamiento:

  Orden de Cierre (LIFO - Last In, First Out):
    -Los recursos se cierran en orden inverso al que se abrieron.
    -Primero se cierra sw (el más interno).
    -Luego se cierra sr (el externo).
  ¿Por qué importa? A veces el destino depende del origen, o viceversa. 
  En este caso específico no es crítico, pero es buena práctica.

  Seguridad y Excepciones:
    Si new StreamWriter falla (ej. por falta de permisos), sr se cerrará automáticamente 
    gracias al using externo, y el código saltará al catch. Nunca se deja un archivo abierto.

  Importante!: sobre la legibilidad:
    El anidamiento excesivo puede crear código "pyramidal" (muchas llaves a la derecha), 
    lo que hace que el código sea difícil de leer si hay muchos recursos.
    */
