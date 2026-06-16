/*Modificar el programa anterior haciendo privados todos los campos. Definir un constructor adecuado y un
método público Imprimir() que escriba en la consola los campos del objeto con el formato requerido para el
listado.*/

using System; // Importamos el namespace System para funcionalidades básicas como Console, String, etc.
using System.IO; // Importamos el namespace System.IO para trabajar con archivos (StreamReader, StreamWriter)
using System.Collections.Generic; // Importamos el namespace System.Collections.Generic para acceder a la clase List<T>

// Definimos la clase Persona
public class Persona
{
    // Definimos campos privados para almacenar los datos de cada persona
    private string? _nombre; // Campo privado para el nombre
    private int _edad;       // Campo privado para la edad
    private string? _dni;    // Campo privado para el DNI

    // Constructor: Inicializa los campos privados con los valores pasados como argumentos
    public Persona(string nombre, int edad, string dni)
    {
        _nombre = nombre; // Asigna el valor del parámetro 'nombre' al campo privado '_nombre'
        _edad = edad;     // Asigna el valor del parámetro 'edad' al campo privado '_edad'
        _dni = dni;       // Asigna el valor del parámetro 'dni' al campo privado '_dni'
    }

    // Propiedades de solo lectura (Getters)
    // Permiten que otras clases accedan a los datos privados sin poder modificarlos directamente
    public string? Nombre => _nombre; // Retorna el valor de _nombre
    public int Edad => _edad;        // Retorna el valor de _edad
    public string? DNI => _dni;       // Retorna el valor de _dni

    // Método público Imprimir que muestra los datos en consola
    // Recibe el índice (número de orden) para formatear la salida correctamente
    public void Imprimir(int indice)
    {
        // Imprime los datos alineados:
        // {0,3}) alinea el índice a la derecha en 3 espacios
        // {1,-15} alinea el nombre a la izquierda en 15 espacios
        // {2,4} alinea la edad a la derecha en 4 espacios
        // {3,-10} alinea el DNI a la izquierda en 10 espacios
        Console.WriteLine("{0,3}) {1,-15} {2,4} {3,-10}", indice, _nombre, _edad, _dni);
    }
}

// Clase principal del programa
public class Program
{
    // Método Main: Punto de entrada donde inicia la ejecución del programa
    public static void Main()
    {
        // Creamos una lista dinámica para almacenar objetos de tipo Persona
        List<Persona> personas = new List<Persona>();

        // Variable para el lector de archivos (inicializada en null)
        StreamReader? lectorArchivo = null;

        // Bandera booleana para indicar si los datos vinieron de un archivo
        bool fueCargaDeArchivo = false;

        // --- Inicio de la interacción con el usuario ---

        // Preguntamos al usuario si desea cargar datos desde un archivo
        Console.WriteLine("¿Desea cargar los datos desde un archivo de texto? (s/n):");

        // Leemos la respuesta del usuario
        string? respuesta = Console.ReadLine();

        // --- Lógica de carga desde archivo ---

        // Verificamos si la respuesta es válida y es 's' o 'S'
        if (respuesta != null && respuesta.Trim().ToLower() == "s")
        {
            // Pedimos al usuario el nombre del archivo
            Console.WriteLine("Ingrese el nombre del archivo (ejemplo: datos.txt):");
            string? nombreDeArchivo = Console.ReadLine();

            // Validamos que el nombre no esté vacío
            if (!string.IsNullOrWhiteSpace(nombreDeArchivo))
            {
                try
                {
                    // Intentamos abrir el archivo para lectura
                    lectorArchivo = new StreamReader(nombreDeArchivo);

                    // Redirigimos la entrada estándar (Console.In) para que lea desde el archivo
                    // Esto permite usar Console.ReadLine() para leer el archivo sin cambiar la lógica del bucle
                    Console.SetIn(lectorArchivo);

                    // Informamos al usuario del éxito de la carga
                    Console.WriteLine($"\nDatos cargados desde el archivo: {nombreDeArchivo}\n");

                    // Activamos la bandera de carga de archivo
                    fueCargaDeArchivo = true;
                }
                catch (FileNotFoundException)
                {
                    // Capturamos el error si el archivo no existe
                    Console.WriteLine($"Error: El archivo '{nombreDeArchivo}' no se encontró.");
                    Console.WriteLine("Continuando con la entrada manual...\n");
                    lectorArchivo = null; // Aseguramos que la variable esté limpia
                }
                catch (Exception ex)
                {
                    // Capturamos cualquier otro error
                    Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                    Console.WriteLine("Continuando con la entrada manual...\n");
                    lectorArchivo = null;
                }
            }
            else
            {
                // Si el nombre del archivo estaba vacío
                Console.WriteLine("Nombre de archivo no válido. Continuando con la entrada manual...\n");
            }
        }
        else
        {
            // Si el usuario no eligió cargar archivo, iniciamos modo manual
            Console.WriteLine("\nIngresando datos manualmente desde la consola...\n");
        }

        // --- Instrucciones para entrada manual ---

        // Mostramos las instrucciones solo si estamos en modo manual
        if (!fueCargaDeArchivo)
        {
            Console.WriteLine("Ingrese los datos separados por una coma en el formato:");
            Console.WriteLine("Nombre,Edad,Documento");
            Console.WriteLine("Presione ENTER para escribir una nueva línea");
            Console.WriteLine("(O presione ENTER sobre una línea vacía para finalizar)\n");
        }

        // --- Bucle principal de lectura de datos ---

        // Bucle infinito que se rompe cuando se encuentra una línea vacía o fin de archivo
        while (true)
        {
            // Leemos una línea de entrada (desde teclado o archivo redirigido)
            string? linea = Console.ReadLine();

            // Verificamos si es fin de archivo (null) o línea vacía (fin de entrada manual)
            if (linea == null || string.IsNullOrWhiteSpace(linea))
            {
                // Salimos del bucle
                break;
            }

            // Dividimos la línea por comas para obtener los tres campos
            string[] datos = linea.Split(',');

            // Verificamos que se hayan obtenido exactamente 3 campos
            if (datos.Length == 3)
            {
                // Extraemos y limpiamos el nombre
                string nombre = datos[0].Trim();

                // Intentamos convertir la edad a entero de forma segura
                if (int.TryParse(datos[1].Trim(), out int edad))
                {
                    // Extraemos y limpiamos el DNI
                    string dni = datos[2].Trim();

                    // Creamos un nuevo objeto Persona usando el constructor
                    Persona persona = new Persona(nombre, edad, dni);

                    // Agregamos el objeto a la lista
                    personas.Add(persona);
                }
                else
                {
                    // Si la edad no es válida, mostramos error y saltamos a la siguiente línea
                    Console.WriteLine($"Error: La edad '{datos[1]}' no es un número válido en la línea: {linea}");
                    continue;
                }
            }
            else
            {
                // Si el formato no tiene 3 campos, mostramos error
                Console.WriteLine($"Error: Formato incorrecto en la línea: {linea}");
            }
        }

        // --- Limpieza de recursos ---

        // Si se abrió un archivo, lo cerramos manualmente para liberar recursos
        if (lectorArchivo != null)
        {
            lectorArchivo.Close();
            lectorArchivo = null;
        }

        // --- Opción de guardado de datos ---

        // Verificamos dos condiciones: que los datos NO vinieran de un archivo (para evitar bucles de guardado) 
        // y que exista al menos una persona en la lista.
        if (!fueCargaDeArchivo && personas.Count > 0)
        {
            // Informamos que el proceso de ingreso ha terminado
            Console.WriteLine("\n--- Ingreso finalizado ---");

            // Preguntamos al usuario si desea guardar los datos a texto
            Console.WriteLine("¿Desea guardar los datos ingresados en un archivo de texto? (s/n):");

            // Leemos la respuesta del usuario y la almacenamos en la variable
            string? guardarRespuesta = Console.ReadLine();

            // Verificamos que la respuesta no sea null y que sea 's' o 'S' (ignorando mayúsculas/minúsculas y espacios)
            if (guardarRespuesta != null && guardarRespuesta.Trim().ToLower() == "s")
            {
                // Solicitamos el nombre para el archivo de salida
                Console.WriteLine("Ingrese el nombre del archivo para guardar (ejemplo: datos.txt):");

                // Advertimos al usuario sobre el comportamiento del proceso de creación / sobrescritura
                Console.WriteLine("ATENCIÓN: Esto creará un archivo nuevo o sobrescribirá uno existente!");

                // Leemos el nombre del archivo ingresado
                string? nombreArchivoSalida = Console.ReadLine();

                // Validamos que el nombre del archivo no esté vacío ni sea solo espacios
                if (!string.IsNullOrWhiteSpace(nombreArchivoSalida))
                {
                    try
                    {
                        // Usamos la sentencia 'using' con StreamWriter para gestionar automáticamente los recursos.
                        // Esto garantiza que el archivo se cierre y libere incluso si ocurre una excepción durante la escritura.
                        // Si el archivo no existe, se crea; si existe, se sobrescribe su contenido.
                        using (StreamWriter writer = new StreamWriter(nombreArchivoSalida))
                        {
                            // Iteramos sobre cada objeto Persona almacenado en la lista
                            foreach (var p in personas)
                            {
                                // Escribimos los datos de la persona en una línea separada, separados por comas (formato CSV)
                                // Accedemos a las propiedades públicas de solo lectura para obtener los valores privados
                                writer.WriteLine($"{p.Nombre},{p.Edad},{p.DNI}");
                            }
                        } // El bloque 'using' finaliza aquí, cerrando el archivo automáticamente.

                        // Confirmamos al usuario que la operación de guardado se realizó con éxito
                        Console.WriteLine($"\n¡Datos guardados correctamente en: {nombreArchivoSalida}!");
                    }
                    catch (Exception ex)
                    {
                        // Capturamos cualquier excepción inesperada (ej. falta de permisos, disco lleno)
                        // y mostramos un mensaje de error al usuario
                        Console.WriteLine($"\nError al guardar el archivo: {ex.Message}");
                    }
                }
                else
                {
                    // Si el usuario ingresó un nombre vacío o inválido, informamos que no se guardó nada
                    Console.WriteLine("Nombre de archivo no válido. Datos no guardados.");
                }
            }
            else
            {
                // Si el usuario respondió algo diferente a 's' (o dejó la respuesta vacía), informamos que no se guardó nada
                Console.WriteLine("\nDatos no guardados.");
            }
        }

        // --- Listado final de personas ---

        // Solo mostramos el listado si hay personas registradas
        if (personas.Count > 0)
        {
            Console.WriteLine("\n--- Listado de Personas ---");
            Console.WriteLine("Nro) Nombre          Edad DNI");

            // Recorremos la lista y llamamos al método Imprimir de cada objeto
            for (int i = 0; i < personas.Count; i++)
            {
                // Llamamos al método Imprimir pasando el índice + 1 para el número de orden
                personas[i].Imprimir(i + 1);
            }
        }
        else
        {
            // Si no hay datos, informamos al usuario
            Console.WriteLine("\nNo se ingresaron datos válidos.");
        }
    }
}
