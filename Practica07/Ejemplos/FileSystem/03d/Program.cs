// El ejemplo anterior puede reescribirse de la siguiente manera
try
{
    // 1. Declaración e inicialización en una sola línea.
    //    La palabra clave 'using' se coloca ANTES de la declaración de la variable.
    //    Esto le dice al compilador: "Esta variable será gestionada automáticamente".
    using var sr = new StreamReader("fuente.txt");
    using var sw = new StreamWriter("destino.txt");

    // 2. Lógica de negocio.
    //    No se necesita verificar si son null porque si la línea anterior falló,
    //    se lanzaría una excepción y saltaría directamente al 'catch'.
    sw.Write(sr.ReadToEnd()); 
}
catch (Exception e)
{
    // 3. Manejo de errores.
    //    Si ocurre un error en la apertura o en la lectura/escritura, salta aquí.
    Console.WriteLine(e.Message);
}
// 4. Cierre automático.
//    Al salir del bloque 'try' (ya sea por éxito o por excepción),
//    el compilador genera código oculto que llama a sr.Dispose() y sw.Dispose()
//    en orden inverso (primero sw, luego sr).
//    ¡No es necesario escribir un bloque 'finally' ni llamar a .Dispose() manualmente!

/*NOTAS:
Puntos Importantes a Recordar
    -Ámbito de la variable: Con using var, la variable (sr o sw) solo existe dentro del bloque try. 
    No puedes acceder a ellas fuera de él, lo cual es bueno porque evita usar recursos ya cerrados por accidente.
    -Orden de liberación: Al igual que en el anidamiento clásico, se liberan en orden inverso a su declaración 
    (sw se libera antes que sr).
    -Compatibilidad: Esta sintaxis requiere C# 8.0 o superior. 
    Si se trabaja en un proyecto muy viejo (antiguo .NET Framework sin actualización), 
    podría necesitarse el anidamiento clásico o el try-finally. Pero en .NET Core, .NET 5/6/7/8+, 
    esta es la forma estándar.
*/
