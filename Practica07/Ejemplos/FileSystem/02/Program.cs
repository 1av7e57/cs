// 1. Obtiene la ruta absoluta del directorio actual donde se está ejecutando la aplicación.
string stDir = Environment.CurrentDirectory;

// 2. Crea una instancia de DirectoryInfo que representa el directorio encontrado en el paso anterior.
//    Esto nos permite usar métodos orientados a objetos para interactuar con esa carpeta.
DirectoryInfo dirInfo = new DirectoryInfo(stDir);

// 3. Obtiene un array de objetos FileInfo que representan todos los archivos en el directorio actual.
//    Nota: Esto NO incluye subdirectorios ni carpetas, solo archivos directos.
FileInfo[] archivos = dirInfo.GetFiles();

// 4. Inicia un bucle que recorre cada archivo encontrado en el array.
//    En cada iteración, 'archivo' representa un objeto FileInfo de un archivo específico.
foreach (FileInfo archivo in archivos)
{
    // 5. Construye una cadena de texto usando interpolación.
    //    - archivo.Name: Obtiene el nombre del archivo (ej: "Program.cs").
    //    - archivo.Length: Obtiene el tamaño del archivo en bytes (tipo long).
    string st = $"{archivo.Name} {archivo.Length} bytes";

    // 6. Imprime el resultado formateado en la consola.
    //    Ejemplo de salida: "Program.cs 1024 bytes"
    Console.WriteLine(st);
}

/*NOTAS:
Este código muestra una forma más robusta y orientada a objetos de trabajar con el sistema de archivos en C#, 
utilizando las clases DirectoryInfo y FileInfo en lugar de métodos estáticos de la clase Path, File o Directory.

Posible salida esperda:
Si el directorio actual contiene, por ejemplo, Ejemplo.csproj, Program.cs, obj (carpeta) y bin (carpeta), 
el resultado sería algo así (solo lista archivos, no carpetas):
    Ejemplo.csproj 293 bytes
    Program.cs 1261 bytes

Las carpetas (bin, obj) no aparecerán porque GetFiles() filtra por archivos.

Dato Curioso: Filtrado de Archivos
Es posible pasar un patrón de búsqueda a GetFiles() para filtrar resultados:
    // Solo archivos .txt
    FileInfo[] txtArchivos = dirInfo.GetFiles("*.txt"); 

    // Solo archivos que empiecen con "Log"
    FileInfo[] logs = dirInfo.GetFiles("Log*");
*/
