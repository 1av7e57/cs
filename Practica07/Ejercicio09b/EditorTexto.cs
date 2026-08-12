using System; // Importamos para usar tipos básicos (Console, String, etc.).

using System.Collections.Generic; // Importamos para usar List<T>.

using System.IO; // Importamos para trabajar con archivos y rutas.

// Importamos System.Text para definir la codificación (UTF8).
using System.Text;

// Definimos el espacio de nombres del proyecto.
namespace GestionTextoArchivos
{
    // Clase pública que encapsula la lógica del editor.
    public class EditorTexto
    {
        // Variable privada para almacenar las líneas de texto leídas.
        // Es 'private' para que solo esta clase pueda modificarla directamente.
        private List<string> lineasTexto;

        // Constructor de la clase.
        // Se ejecuta al crear una nueva instancia: new EditorTexto().
        public EditorTexto()
        {
            // Inicializamos la lista. Sin esto, la variable sería null y daría error al agregar elementos.
            lineasTexto = new List<string>();
        }

        // Método para leer texto desde la consola.
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

        // Método público para guardar el contenido en un archivo (Versión SIN using).
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

            // --- GESTIÓN MANUAL DE RECURSOS ---
            // Declaramos la variable 'escritor' FUERA del bloque try.
            // Esto es crucial: necesitamos que la variable exista en el bloque 'finally' para poder cerrarla.
            // Inicializamos en null para evitar errores de compilación si el flujo no entra al try.
            StreamWriter? escritor = null;

            try
            {
                // 1. Instanciación del StreamWriter
                // Si esto falla (ej: ruta inválida, permisos), saltará al catch y 'escritor' seguirá siendo null.
                // false = sobrescribir si existe, Encoding.UTF8 = codificación correcta.
                escritor = new StreamWriter(rutaCompleta, false, Encoding.UTF8);

                // 2. Escritura de datos
                // Recorremos cada línea guardada en memoria
                foreach (string linea in lineasTexto)
                {
                    // Escribimos la línea en el archivo con salto de línea
                    escritor.WriteLine(linea);
                }
                
                // Flush() asegura que los datos se escriban en disco inmediatamente.
                // Aunque el cierre (Dispose) lo hace automáticamente, es buena práctica.
                escritor.Flush(); 
            }
            // 3. Manejo de excepciones específicas
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
            // 4. Bloque FINALLY (La clave de la seguridad sin 'using')
            finally
            {
                // Este bloque SE EJECUTA SIEMPRE, haya ocurrido un error o no.
                // Aquí es donde se reemplaza la funcionalidad del 'using'.
                
                // Verificamos que el objeto no sea null antes de intentar cerrarlo.
                // Si el constructor falló, 'escritor' es null y no debemos llamar a Dispose().
                if (escritor != null)
                {
                    // Llamamos a Dispose() manualmente.
                    // Esto libera los recursos del sistema (el descriptor de archivo) inmediatamente.
                    // Es equivalente a cerrar el archivo manualmente.
                    escritor.Dispose();
                    
                    // Nota: Close() también funcionaría, ya que internamente llama a Dispose().
                    // pero Dispose() es más explícito cuando se trabaja con IDisposable.
                    // escritor.Close(); 
                }
            }

            // Si la ejecución llega aquí, significa que:
            // 1. El nombre fue válido.
            // 2. El archivo se creó (o sobrescribió).
            // 3. Se escribió el contenido (o se intentó).
            // 4. El recurso se cerró correctamente en el 'finally'.
            
            // Mostramos mensaje de éxito (asumiendo que si no saltó a catch, fue exitoso).
            Console.WriteLine($"\n¡Éxito! El texto se ha guardado en: {rutaCompleta}");
            Console.WriteLine($"Total de líneas guardadas: {lineasTexto.Count}");
            
            // Retornamos true para indicar que todo salió bien.
            return true;
        }
    }
}