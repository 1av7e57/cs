using System;                     // Importa operaciones básicas del sistema
using System.Collections.Generic; // Importa colecciones genéricas
using System.IO;                  // Importa clases para leer y escribir archivos (File, StreamWriter)
using Ejercicio10.Contratos;      // Importa los contratos necesarios para usar IAuto
using Ejercicio10.Modelos;        // Importa la clase concreta Auto para instanciar objetos

// Define el espacio de nombres para la infraestructura
namespace Ejercicio10.Infraestructura
{
    // Clase que implementa la interfaz IAutoRepositorio usando archivos de texto
    public class ArchivoAutoRepositoio : IAutoRepositorio
    {
        // Define una ruta constante para el archivo de datos en el directorio actual
        private readonly string _rutaArchivo = "autos.txt";

        // Implementación del método Guardar
        public void Guardar(List<IAuto> autos)
        {
            try
            {
                // Crea un StreamWriter para escribir en el archivo, asegurando que se cierre al terminar (using)
                using (StreamWriter writer = new StreamWriter(_rutaArchivo))
                {
                    // Recorre cada auto en la lista recibida
                    foreach (var auto in autos)
                    {
                        // Escribe la marca del auto en una línea
                        writer.WriteLine(auto.Marca);
                        // Escribe el modelo del auto en la siguiente línea
                        writer.WriteLine(auto.Modelo);
                    }
                }
                // Muestra un mensaje de éxito al usuario
                Console.WriteLine("Lista guardada exitosamente.");
                // Pausa la ejecución esperando una tecla para que el usuario lea el mensaje
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Si ocurre un error (ej. permisos), captura la excepción
                Console.WriteLine($"Error al guardar: {ex.Message}");
                // Pausa para que el usuario vea el error
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
        }

        // Implementación del método Cargar
        public List<IAuto> Cargar()
        {
            // Crea una nueva lista vacía para almacenar los autos cargados
            var autos = new List<IAuto>();
            
            // Verifica si el archivo de datos existe físicamente en el disco
            if (!File.Exists(_rutaArchivo))
            {
                // Si no existe, informa al usuario
                Console.WriteLine("No se encontró archivo de datos.");
                // Pausa la ejecución
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                // Devuelve la lista vacía
                return autos;
            }

            try
            {
                // Lee todas las líneas del archivo y las guarda en un array de strings
                string[] lineas = File.ReadAllLines(_rutaArchivo);

                // Verificación de integridad antes de procesar
                if (lineas.Length % 2 != 0)
                {
                    Console.WriteLine("Advertencia: El archivo tiene un número impar de líneas.");
                    Console.WriteLine("La última marca se encontró sin modelo y ha sido ignorada.");
                    Console.Write("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }
                
                // Recorre el array de líneas de dos en dos (Marca, Modelo)
                // Se usa "lineas.Length - 1" para evitar errores si el archivo tiene un número impar de líneas
                for (int i = 0; i < lineas.Length - 1; i += 2)
                {
                    // Toma la línea actual como Marca
                    string marca = lineas[i];
                    // Toma la siguiente línea como Modelo
                    string modelo = lineas[i + 1];
                    // Crea un nuevo objeto Auto con esos datos y lo agrega a la lista
                    autos.Add(new Auto(marca, modelo));
                }
                
                // Informa que la carga fue exitosa
                Console.WriteLine("\n Lista cargada exitosamente.");
                // Pausa para el usuario
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Captura errores de lectura (ej. archivo corrupto)
                Console.WriteLine($"Error al cargar: {ex.Message}");
                // Pausa para el usuario
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }

            // Devuelve la lista llena de autos
            return autos;
        }
    }
}
