namespace Almacen.Aplicacion
{
    // CASO DE USO: Contiene la lógica específica de "Listar productos".
    public class ListarProductosUseCase
    {
        // CAMPO PRIVADO: Referencia al repositorio vía la interfaz (Inversión de Dependencia).
        private readonly IRepositorioProducto _repo;

        // CONSTRUCTOR: Inyección de la dependencia.
        public ListarProductosUseCase(IRepositorioProducto repo)
        {
            _repo = repo;
        }

        // MÉTODO EJECUTAR: Obtiene los datos y los devuelve.
        public List<Producto> Ejecutar()
        {
            // Llama al repositorio para obtener la lista.
            // Nuevamente, no sabe si viene de un archivo, DB o memoria.
            return _repo.ListarProductos();
        }
    }
}