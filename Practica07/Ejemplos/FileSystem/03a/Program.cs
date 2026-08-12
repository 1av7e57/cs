// Abre el archivo fuente.txt para lectura.
StreamReader sr = new StreamReader("fuente.txt");

// Abre (o crea si no existe) el archivo destino.txt para escritura.
// Si el archivo ya existía, se sobrescribirá por defecto.
StreamWriter sw = new StreamWriter("destino.txt");

// Declara una variable nullable (el ? indica que puede ser null, aunque aquí ReadLine devuelve null solo al final, 
// pero como el bucle verifica EndOfStream, en la práctica siempre tendrá texto o la excepción se evitaría).
// Nota: En versiones modernas de C#, ReadLine devuelve string? porque si el archivo está vacío o hay un error, 
// podría ser null.
string? linea;

//El bucle continúa mientras NO se haya llegado al final del archivo (EndOfStream es false).
// Esta es una forma segura de leer hasta agotar el contenido.
while (!sr.EndOfStream)
{
    // Lee la siguiente línea del archivo fuente.
    //El puntero interno avanza al final de esa línea.
    linea = sr.ReadLine();

    // Escribe el contenido leído en el archivo destino, añadiendo automáticamente 
    // el carácter de nueva línea (\r\n en Windows y \n en Linux).
    sw.WriteLine(linea);
}

// Cierre explícito: Libera los recursos del sistema (descriptores de archivo, buffers de memoria).
//  Al llamar a Close(), internamente se invoca al método Dispose(). Esto implementa el patrón IDisposable, 
// asegurando que los recursos no se queden "huérfanos" esperando al Garbage Collector.
sr.Close(); sw.Close();

/*NOTAS:
Mejor Práctica: using Statement
Aunque el código funciona y libera los recursos correctamente con Close(), la forma recomendada en C# es 
usar la declaración using.

¿Por qué? 
Si ocurre un error (excepción) durante la lectura o escritura (ej. el archivo fuente.txt se corrompe a la mitad), 
el código saltaría al catch (si lo hubiera) o terminaría abruptamente, y las líneas sr.Close(); sw.Close(); 
nunca se ejecutarían. Esto dejaría los archivos bloqueados o los recursos sin liberar.

Con using, el sistema garantiza que Dispose() (y por tanto Close()) se ejecute siempre, incluso si hay un error.
*/
