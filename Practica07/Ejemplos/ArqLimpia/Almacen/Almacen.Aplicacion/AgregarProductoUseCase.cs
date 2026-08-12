namespace Almacen.Aplicacion
{
    // CASO DE USO: Contiene la lógica específica de "Agregar un producto".
    // Orquesta el flujo: recibe un producto y delega la persistencia.
    public class AgregarProductoUseCase
    {
        // CAMPO PRIVADO: Guarda la referencia al repositorio.
        // NOTA CLAVE: El tipo es la INTERFAZ (IRepositorioProducto), NO la clase concreta.
        // Esto permite que este código funcione con cualquier implementación (TXT, SQL, etc.).
        private readonly IRepositorioProducto _repo;

        // CONSTRUCTOR: Recibe la dependencia desde afuera (Inyección de Dependencias).
        // Esto asegura que el caso de uso no cree sus propias dependencias.
        public AgregarProductoUseCase(IRepositorioProducto repo)
        {
            this._repo = repo;
        }

        // MÉTODO EJECUTAR: La lógica principal del caso de uso.
        public void Ejecutar(Producto producto)
        {
            // Delega la tarea de guardar en el repositorio inyectado.
            // El caso de uso sabe QUÉ hacer, pero no CÓMO se guarda el dato.
            _repo.AgregarProducto(producto);
        }
    }
}