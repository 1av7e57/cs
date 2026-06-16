/*Definir una clase Persona con 3 campos públicos: Nombre, Edad y DNI. Escribir un algoritmo que permita al
usuario ingresar en una consola una serie de datos de la forma Nombre,Documento,Edad<ENTER>. Una vez
finalizada la entrada de datos, el programa debe imprimir en la consola un listado con 4 columnas de la
siguiente forma:

Ejemplo de listado por consola:
Nro) Nombre      Edad DNI.
1)   Juan Perez  40   2098745
2)   José García 41   1965412

NOTA: Puede utilizar: Console.SetIn(new System.IO.StreamReader(nombreDeArchivo));
para cambiar la entrada estándar de la consola y poder leer directamente desde un archivo de texto.*/

using System; // Importamos el namespace System para funcionalidades básicas como Console, String, etc.
using System.IO; // Importamos el namespace System.IO para trabajar con archivos (StreamReader, StreamWriter)
using System.Collections.Generic; // Importamos el namespace System.Collections.Generic para acceder a la clase List<T>

// Definimos la clase Persona
public class Persona
{
    // Definimos 3 campos públicos que almacenarán los datos de cada persona
    // (usamos ? para evitar advertencias por posible null en C# moderno)
    public string? Nombre; // Campo público para almacenar el nombre de la persona 
    public int Edad; // Campo público para almacenar la edad de la persona como entero

    // Campo público para almacenar el DNI de la persona 
    // (string para mantener ceros a la izquierda)
    public string? DNI;
}

// Clase principal del programa
public class Program
{
    // Método Main, punto de entrada del programa
    public static void Main()
    {
        // Creamos una lista 'personas' para almacenar objetos de tipo 'Persona' de manera dinámica
        List<Persona> personas = new List<Persona>();

        // Variable para almacenar el lector de archivo si se usa en modo carga
        StreamReader? lectorArchivo = null;
        // Bandera booleana para saber si los datos vinieron de un archivo o fueron ingresados manualmente
        bool fueCargaDeArchivo = false;

        // Preguntamos al usuario si desea cargar datos desde un archivo de texto
        Console.WriteLine("¿Desea cargar los datos desde un archivo de texto? (s/n):");
        
        // Leemos la respuesta que el usuario escribe en la consola
        string? respuesta = Console.ReadLine();

        // --- Carga de datos desde archivo ---

        // Si el usuario responde 's' o 'S', procedemos a intentar cargar el archivo
        if (respuesta != null && respuesta.Trim().ToLower() == "s")
        {
            // Pedimos al usuario que ingrese el nombre del archivo a cargar
            Console.WriteLine("Ingrese el nombre del archivo (ejemplo: datos.txt):");
            string? nombreDeArchivo = Console.ReadLine();

            // Verificamos que el usuario no haya ingresado un nombre de archivo vacío o solo espacios
            if (!string.IsNullOrWhiteSpace(nombreDeArchivo))
            {
                try
                {
                    // Creamos un objeto StreamReader para leer el archivo especificado
                    lectorArchivo = new StreamReader(nombreDeArchivo);
                    
                    // Redirigimos la entrada estándar de la consola (Console.In) para que lea desde el archivo
                    Console.SetIn(lectorArchivo);
                    
                    // Informamos al usuario que los datos se cargaron correctamente desde el archivo
                    Console.WriteLine($"\nDatos cargados desde el archivo: {nombreDeArchivo}\n");
                    // Establecemos la bandera en true para indicar que los datos vinieron de un archivo
                    fueCargaDeArchivo = true;
                }
                catch (FileNotFoundException)
                {
                    // Capturamos el error si el archivo no se encuentra en la ruta especificada
                    Console.WriteLine($"Error: El archivo '{nombreDeArchivo}' no se encontró.");
                    // Informamos que continuaremos con la entrada manual
                    Console.WriteLine("Continuando con la entrada manual...\n");
                    // Aseguramos que la variable del lector sea nula para no intentar cerrarlo después
                    lectorArchivo = null;
                }
                catch (Exception ex)
                {
                    // Capturamos cualquier otro error relacionado con el archivo (permisos, formato, etc.)
                    Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                    // Informamos que continuaremos con la entrada manual
                    Console.WriteLine("Continuando con la entrada manual...\n");
                    // Aseguramos que la variable del lector sea nula
                    lectorArchivo = null;
                }
            }
            else
            {
                // Si el nombre del archivo estaba vacío, informamos al usuario y pasamos a modo manual
                Console.WriteLine("Nombre de archivo no válido. Continuando con la entrada manual...\n");
            }
        }
        else
        {
            // Si el usuario no respondió 's', indicamos que iniciará la entrada manual desde la consola
            Console.WriteLine("\nIngresando datos manualmente desde la consola...\n");
        }

        // --- Ingreso manual de datos ---

        // Mostramos las instrucciones de formato SOLO si los datos van a ser ingresados manualmente
        if (!fueCargaDeArchivo)
        {
             // Indicamos el formato esperado para cada línea de entrada
             Console.WriteLine("Ingrese los datos separados por una coma en el formato:");
             Console.WriteLine("Nombre,Edad,Documento");
             // Indicamos cómo ingresar una nueva entrada
             Console.WriteLine("Presione ENTER para escribir una nueva línea");
             // Indicamos cómo finalizar la entrada de datos
             Console.WriteLine("(O presione ENTER sobre una línea vacía para finalizar)\n");
        }

        // Bucle infinito para leer la entrada, ya sea desde el teclado o desde el archivo redirigido
        while (true)
        {
            // Leemos una línea de entrada desde la consola (o del archivo si se redirigió)
            string? linea = Console.ReadLine();

            // Verificamos si llegamos al final del archivo (null) o si la línea está vacía (fin de entrada manual)
            if (linea == null || string.IsNullOrWhiteSpace(linea))
            {
                // Rompemos el bucle para terminar de leer entradas
                break;
            }

            // Dividimos la línea ingresada por comas para obtener los tres campos (Nombre, Edad, DNI)
            string[] datos = linea.Split(',');

            // Verificamos que se hayan separado exactamente 3 datos en el array
            if (datos.Length == 3)
            {
                // Creamos una nueva instancia de la clase Persona para almacenar esta entrada
                Persona persona = new Persona();

                // Asignamos el primer campo (Nombre) al objeto Persona, eliminando espacios extra al inicio y final
                persona.Nombre = datos[0].Trim();

                // Intentamos convertir el segundo campo (Edad) a un número entero
                if (int.TryParse(datos[1].Trim(), out int edad))
                {
                    // Si la conversión es exitosa, asignamos el valor numérico a la propiedad Edad del objeto
                    persona.Edad = edad;
                }
                else
                {
                    // Si la conversión falla, mostramos un mensaje de error indicando el valor inválido y la línea original
                    Console.WriteLine($"Error: La edad '{datos[1]}' no es un número válido en la línea: {linea}");
                    // Usamos continue para saltar al inicio del bucle y no agregar una persona con datos incompletos
                    continue; 
                }

                // Asignamos el tercer campo (DNI) al objeto Persona, eliminando espacios extra
                persona.DNI = datos[2].Trim();

                // Agregamos el objeto persona completamente cargado a la lista de personas
                personas.Add(persona);
            }
            else
            {
                // Si el número de campos no es 3, mostramos un error indicando el formato incorrecto y la línea
                Console.WriteLine($"Error: Formato incorrecto en la línea: {linea}");
            }
        }

        // Cerramos manualmente el archivo si se abrió en modo carga para liberar recursos del sistema
        if (lectorArchivo != null)
        {
            // Cerramos el flujo de lectura del archivo
            lectorArchivo.Close();
            // Asignamos null para indicar que ya no hay un lector activo
            lectorArchivo = null;
        }

        // --- Guardado de datos: (Este bloque solo se ejecuta si fue ingreso manual y hay datos a guardar) ---
        if (!fueCargaDeArchivo && personas.Count > 0)
        {
            // Informamos al usuario que el ingreso de datos ha finalizado
            Console.WriteLine("\n--- Ingreso finalizado ---");
            // Preguntamos si desea guardar los datos ingresados en un archivo de texto
            Console.WriteLine("¿Desea guardar los datos ingresados en un archivo de texto? (s/n):");
            
            // Leemos la respuesta del usuario sobre el guardado
            string? guardarRespuesta = Console.ReadLine();
            
            // Si el usuario responde 's' o 'S', procedemos a guardar
            if (guardarRespuesta != null && guardarRespuesta.Trim().ToLower() == "s")
            {
                // Pedimos el nombre del archivo donde se guardarán los datos
                Console.WriteLine("Ingrese el nombre del archivo para guardar (ejemplo: datos.txt):");
                Console.WriteLine("ATENCIÓN: Esto crerá un archivo nuevo o sobrescribirá uno existente!");
                string? nombreArchivoSalida = Console.ReadLine();

                // Verificamos que el nombre del archivo no esté vacío
                if (!string.IsNullOrWhiteSpace(nombreArchivoSalida))
                {
                    try
                    {
                        // Usamos 'using' con StreamWriter para escribir en el archivo de forma segura
                        // Esto crea el archivo si no existe, o lo sobrescribe si ya tiene contenido
                        using (StreamWriter writer = new StreamWriter(nombreArchivoSalida))
                        {
                            // Iteramos sobre cada persona en la lista
                            foreach (var p in personas)
                            {
                                // Escribimos cada persona en una nueva línea con el formato: Nombre,Edad,DNI
                                writer.WriteLine($"{p.Nombre},{p.Edad},{p.DNI}");
                            }
                        }
                        // Confirmamos al usuario que los datos se guardaron correctamente
                        Console.WriteLine($"\n¡Datos guardados correctamente en: {nombreArchivoSalida}!");
                    }
                    catch (Exception ex)
                    {
                        // Capturamos cualquier error que ocurra al intentar escribir en el archivo (ej. permisos)
                        Console.WriteLine($"\nError al guardar el archivo: {ex.Message}");
                    }
                }
                else
                {
                    // Si el nombre del archivo estaba vacío, informamos que no se guardaron datos
                    Console.WriteLine("Nombre de archivo no válido. Datos no guardados.");
                }
            }
            else
            {
                // Si el usuario no respondió 's', informamos que los datos no se guardaron
                Console.WriteLine("\nDatos no guardados.");
            }
        }

        // Imprimimos el resumen en consola SOLO si hay datos válidos en la lista
        if (personas.Count > 0)
        {
            // Mostramos un título para el listado final
            Console.WriteLine("\n--- Listado de Personas ---");
            // Imprimimos el encabezado de la tabla con formato alineado
            Console.WriteLine("Nro) Nombre          Edad DNI");

            // Recorremos la lista de personas usando un bucle for para controlar el índice
            for (int i = 0; i < personas.Count; i++)
            {
                // Obtenemos la persona actual en la posición i de la lista
                Persona p = personas[i];
                // Imprimimos el número de orden (i + 1), nombre, edad y DNI con formato de columnas alineadas
                // {0,3}) alinea el número a la derecha en 3 espacios, {1,-15} alinea nombre a la izquierda, etc.
                Console.WriteLine("{0,3}) {1,-15} {2,4} {3,-10}", i + 1, p.Nombre, p.Edad, p.DNI);
            }
        }
        else
        {
            // Si la lista está vacía (no se ingresaron o validaron datos), informamos al usuario
            Console.WriteLine("\nNo se ingresaron datos válidos.");
        }
    }
}
