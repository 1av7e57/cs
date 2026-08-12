
using System; // Importamos para usar tipos básicos como Console, String, etc.

using System.Collections.Generic; // Importamos para usar la clase List<T> (Lista genérica).

using System.IO; // Importamos para trabajar con archivos (File, Path, Directory, StreamWriter).

using System.Text; // Importamos para definir la codificación de caracteres (UTF8).


// Definimos el espacio de nombres del proyecto.
namespace GestionTextoArchivos
{
    // Definimos una clase pública llamada EditorTexto.
    // Al ser 'public', puede ser instanciada y usada desde otros archivos del proyecto.
    public class EditorTexto
    {
        // Declaramos una variable privada de tipo List<string>.
        // 'private' significa que solo esta clase puede acceder a ella directamente.
        // Almacena todas las líneas de texto que el usuario ingrese.
        private List<string> lineasTexto;

        // Constructor de la clase.
        // Se ejecuta automáticamente cuando creamos una nueva instancia: new EditorTexto()
        public EditorTexto()
        {
            // Inicializamos la lista 'lineasTexto' creando un nuevo objeto List de cadenas.
            lineasTexto = new List<string>();
        }

        // Método público para capturar el texto desde la consola.
        public void CapturarTexto()
        {
            // Imprimimos un mensaje de bienvenida para el usuario.
            Console.WriteLine("Escribe tu texto (presiona Enter en una línea vacía para finalizar):");
            // Imprimimos una línea en blanco para mejorar la legibilidad en consola.
            Console.WriteLine("");

            // Iniciamos un bucle infinito que solo se romperá con la instrucción 'break'.
            while (true)
            {
                // Mostramos un indicador visual ('>>') y leemos una línea completa ingresada por el usuario.
                // Console.ReadLine() espera a que el usuario presione Enter.
                Console.Write(">> ");
                string? linea = Console.ReadLine();

                // Verificamos si la línea ingresada es nula, vacía o contiene solo espacios en blanco.
                if (string.IsNullOrWhiteSpace(linea))
                {
                    // Si la condición es verdadera (el usuario presionó Enter vacío), salimos del bucle.
                    break;
                }

                // Si no estaba vacía, agregamos la cadena 'linea' al final de nuestra lista interna.
                lineasTexto.Add(linea);
            }
        }

        // Método público para consultar si se ha ingresado algún texto.
        // Devuelve un valor booleano (true/false).
        public bool TieneTexto()
        {
            // Comparamos la cantidad de elementos en la lista con 0.
            // Si Count > 0, devuelve true (hay texto), si no, false (lista vacía).
            return lineasTexto.Count > 0;
        }

        // Método público para guardar el contenido en un archivo.
        // Recibe un parámetro 'nombreArchivo' (string) y devuelve un booleano indicando éxito o fracaso.
        public bool GuardarEnArchivo(string nombreArchivo)
        {
            // Validación de seguridad: verificamos que el nombre no sea nulo o vacío.
            if (string.IsNullOrWhiteSpace(nombreArchivo))
            {
                // Si es inválido, mostramos un mensaje de error.
                Console.WriteLine("El nombre del archivo no es válido. El programa termina.");
                // Retornamos false para indicar que la operación falló.
                return false;
            }

            // Verificamos si el nombre del archivo ya tiene una extensión (ej: .txt, .log).
            // Path.HasExtension retorna true si hay un punto seguido de caracteres al final.
            if (!Path.HasExtension(nombreArchivo))
            {
                // Si no tiene extensión, concatenamos ".txt" al nombre para asegurar un archivo de texto.
                nombreArchivo += ".txt";
            }

            // Obtenemos la ruta del directorio actual donde se está ejecutando el programa.
            // Path.Combine une de forma segura el directorio actual con el nombre del archivo,
            // manejando correctamente los separadores de ruta (/ o \) según el sistema operativo.
            string rutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), nombreArchivo);

            // Bloque 'try' para capturar posibles errores durante la escritura del archivo.
            try
            {
                // --- USO CRÍTICO DE 'using' ---
                // La instrucción 'using' garantiza que, al salir de este bloque, se llame automáticamente a
                // 'Dispose()' del StreamWriter, cerrando el archivo y liberando recursos del sistema (IDisposable).
                // Creamos un objeto StreamWriter para escribir en el archivo en la ruta especificada.
                // El segundo argumento 'false' significa que sobrescribiremos el archivo si ya existe.
                // El tercer argumento 'Encoding.UTF8' asegura que se guarden caracteres especiales (ñ, tildes, emojis).

                using (StreamWriter escritor = new StreamWriter(rutaCompleta, false, Encoding.UTF8))
                {
                    // Recorremos cada línea almacenada en nuestra lista interna.
                    foreach (string linea in lineasTexto)
                    {
                        // Escribimos la línea en el archivo y añadimos un salto de línea al final.
                        escritor.WriteLine(linea);
                    }
                }
                // El bloque 'using' termina aquí, el archivo se cierra automáticamente.

                // Mensaje de éxito para el usuario.
                Console.WriteLine($"\n¡Éxito! El texto se ha guardado en: {rutaCompleta}");
                // Mostramos cuántas líneas se guardaron (usamos interpolación de cadenas con $).
                Console.WriteLine($"Total de líneas guardadas: {lineasTexto.Count}");
                
                // Retornamos true para indicar que todo salió bien.
                return true;
            }
            // Capturamos la excepción específica si el usuario no tiene permisos para escribir en esa carpeta.
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("\nError: No tienes permisos para escribir en esa ubicación.");
                return false;
            }
            // Capturamos errores generales de E/S (ej: disco lleno, archivo bloqueado por otro proceso).
            catch (IOException ex)
            {
                // Imprimimos el mensaje de error específico que proporciona el sistema.
                Console.WriteLine($"\nError de E/S: {ex.Message}");
                return false;
            }
            // Capturamos cualquier otra excepción imprevista.
            catch (Exception ex)
            {
                Console.WriteLine($"\nError inesperado: {ex.Message}");
                return false;
            }
        }
    }
}