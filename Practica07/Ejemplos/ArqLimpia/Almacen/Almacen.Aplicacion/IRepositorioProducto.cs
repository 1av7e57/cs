using System.Collections.Generic; // Necesario para usar la lista genérica List<T>

namespace Almacen.Aplicacion
{
    // INTERFAZ: Define EL CONTRATO de cómo se deben guardar/listar los datos.
    // Esta interfaz vive en el núcleo (Alto Nivel).
    // La implementación concreta (la que escribe en el archivo) vivirá afuera y 
    // se comprometerá a cumplir este contrato.
    public interface IRepositorioProducto
    {
        // Firma del método para agregar un producto.
        void AgregarProducto(Producto producto);

        // Firma del método para obtener todos los productos.
        List<Producto> ListarProductos();
    }
}