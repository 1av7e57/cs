string archivo = "/Documentos/notas.txt";

// 1. Obtiene la ruta completa absoluta basada en la ruta actual del directorio de trabajo.
// Nota: Como la ruta empieza con '/', en sistemas Unix/Linux se interpretará como raíz.
// En Windows, podría comportarse de forma dependiente del directorio actual.
Console.WriteLine(Path.GetFullPath(archivo)); 

// 2. Extrae solo el nombre del archivo con la extensión.
// Resultado esperado: "notas.txt"
Console.WriteLine(Path.GetFileName(archivo));

// 3. Obtiene la extensión del archivo (incluyendo el punto).
// Resultado esperado: ".txt"
Console.WriteLine(Path.GetExtension(archivo));

// 4. Obtiene el directorio que contiene la ruta especificada.
// Resultado esperado: "/Documentos" o "\Documentos" según el entorno
Console.WriteLine(Path.GetDirectoryName(archivo));

// 5. Cambia la extensión del archivo por la nueva especificada.
// Resultado esperado: "/Documentos/notas.doc"
Console.WriteLine(Path.ChangeExtension(archivo, "doc"));

// 6. Obtiene el nombre del archivo sin la extensión.
// Resultado esperado: "notas"
Console.WriteLine(Path.GetFileNameWithoutExtension(archivo));

// 7. Obtiene la ruta del directorio temporal del sistema actual.
// Resultado esperado: Algo como "/tmp" (Linux/Mac) o "C:\Users\...\AppData\Local\Temp\" (Windows).
Console.WriteLine(Path.GetTempPath());

/*NOTAS:
La clase Path incluye un conjunto de miembros estáticos diseñados para realizar cómodamente 
las operaciones más frecuentes relacionadas con rutas y nombres de archivos.

Con los campos públicos 
VolumeSeparatorChar, DirectorySeparatorChar, AltDirectorySeparatorChar y PathSeparator, 
se obtiene el carácter especifico de la plataforma que se utiliza para separar 
unidades, carpetas y archivos y el separador de múltiples rutas. 
Ejemplos.
En Windows son :, /, \ y ;
En Linux son /, /, / y :
*/
