using System.Collections.Generic; // Para List<T>
using System.IO; // Para las clases de lectura/escritura de archivos (File, StreamWriter, etc.)
using Almacen.Aplicacion; // CRUCIAL: Permite ver la interfaz IRepositorioProducto y la entidad Producto definidas en el núcleo.

namespace Almacen.Repositorios
{
    // IMPLEMENTACIÓN CONCRETA: Esta clase sabe CÓMO guardar en un archivo de texto.
    // Implementa el contrato definido en la interfaz del núcleo.
    public class RepositorioProductoTXT : IRepositorioProducto
    {
        // CAMPO PRIVADO: Nombre del archivo donde se guardarán los datos.
        // Es un detalle técnico de esta capa específica.
        readonly string _nombreArch = "productos.txt";

        // IMPLEMENTACIÓN DE AgregarProducto:
        public void AgregarProducto(Producto producto)
        {
            // Crea un escritor de texto. 'true' indica que se appendea (agrega) al final del archivo.
            // 'using' asegura que el archivo se cierre automáticamente, liberando recursos.
            using var sw = new StreamWriter(_nombreArch, true);
            
            // Escribe el ID en una línea.
            sw.WriteLine(producto.Id);
            // Escribe el Nombre en la siguiente línea.
            sw.WriteLine(producto.Nombre);
        }

        // IMPLEMENTACIÓN DE ListarProductos:
        public List<Producto> ListarProductos()
        {
            // Inicializa una lista vacía para almacenar los productos leídos.
            var resultado = new List<Producto>();
            
            // Verificación de seguridad: Si el archivo no existe, retornamos la lista vacía.
            // Evita que el programa se rompa al intentar leer un archivo inexistente.
            if (!File.Exists(_nombreArch))
                return resultado;

            // Crea un lector de texto para el archivo.
            using var sr = new StreamReader(_nombreArch);
            
            // Bucle que se ejecuta mientras no se haya llegado al final del archivo.
            while (!sr.EndOfStream)
            {
                // Crea una nueva instancia de Producto para llenarla con los datos leídos.
                var producto = new Producto();
                
                // Lee la primera línea (el ID). 
                // El operador '?' maneja el caso de que la línea sea nula.
                string? lineaId = sr.ReadLine();
                // Lee la segunda línea (el Nombre).
                string? lineaNombre = sr.ReadLine();

                // Intenta convertir la línea del ID a un entero.
                // 'TryParse' evita excepciones si el dato está corrupto.
                if (int.TryParse(lineaId, out int id))
                {
                    // Asignamos los datos leídos a la entidad.
                    producto.Id = id;
                    producto.Nombre = lineaNombre ?? ""; // Si es nulo, asigna cadena vacía.
                    
                    // Añadimos el producto completo a nuestra lista de resultados.
                    resultado.Add(producto);
                }
            }
            // Retornamos la lista completa de productos recuperados.
            return resultado;
        }
    }
}
