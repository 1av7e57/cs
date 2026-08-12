using Almacen.Aplicacion; // Importa las entidades y casos de uso (Núcleo).
using Almacen.Repositorios; // Importa la implementación concreta del repositorio (Infraestructura).

// ---------------------------------------------------------
// FASE 1: CONFIGURACIÓN (Composition Root)
// Aquí es donde se "ensambla" la aplicación.
// ---------------------------------------------------------

// Creación de la instancia concreta del repositorio.
// Estamos instanciando un objeto de tipo concreto (RepositorioProductoTXT) 
// y asignándolo a una variable de tipo abstracto (IRepositorioProducto).
// Solo en esta capa sabemos que estamos usando TXT.
// Podríamos cambiar esto por 'new RepositorioSQL()' sin tocar el resto del código.
IRepositorioProducto repo = new RepositorioProductoTXT();

// Creación de los casos de uso, INYECTANDO la dependencia creada arriba.
// El caso de uso recibe la interfaz, no la clase concreta.
var agregarProducto = new AgregarProductoUseCase(repo);
var listarProducto = new ListarProductosUseCase(repo);

// ---------------------------------------------------------
// FASE 2: EJECUCIÓN
// Aquí interactuamos con el usuario y ejecutamos la lógica.
// ---------------------------------------------------------

// Ejecutamos el caso de uso para agregar un producto "Yerba".
// El flujo de control va: Consola -> Caso de Uso -> Repositorio (TXT).
agregarProducto.Ejecutar(new Producto() { Id = 1, Nombre = "Yerba" });

// Ejecutamos el caso de uso para agregar otro producto "Azúcar".
agregarProducto.Ejecutar(new Producto() { Id = 2, Nombre = "Azúcar" });

// Ejecutamos el caso de uso para listar.
// Devuelve una lista de entidades puras (Producto).
var lista = listarProducto.Ejecutar();

// Iteramos sobre la lista devuelta.
foreach (Producto p in lista)
{
    // Imprimimos en consola.
    // Se llama automáticamente al método ToString() de la entidad Producto.
    Console.WriteLine(p);
}

/*NOTAS:

Este código es un ejemplo didáctico de los conceptos de Arquitectura Limpia.

Análisis de la Arquitectura Limpia en este Ejemplo:
    A. La Regla de Dependencia (Sintaxis de Proyectos):
        -Almacen.Aplicacion: No tiene 'using' de otros proyectos propios. Contiene la entidad 'Producto' y la interfaz 'IRepositorioProducto'. Es el núcleo.
        -Almacen.Repositorios: Tiene un 'using' explícito a 'Almacen.Aplicacion'. Implementa la interfaz. Sabe de la abstracción, no viceversa.
        -Almacen.Consola: Tiene referencias a ambos. Aquí se "ensambla" el sistema.

    B. Inversión de Dependencias (DIP):
        -El Problema clásico: En una arquitectura tradicional, el 'AgregarProductoUseCase' tendría 'new RepositorioProductoTXT()' dentro de su código. Eso haría que el caso de uso dependiera de la implementación (violando la regla).
        -La Solución aquí:
            1.  El caso de uso ('Almacen.Aplicacion') espera una 'IRepositorioProducto'.
            2.  No sabe ni le importa si es TXT, SQL o una API externa.
            3.  La clase 'Program.cs' (fuera del núcleo) decide qué implementación real inyectar: 'new RepositorioProductoTXT()'.
        -Resultado: Si mañana se quiere guardar en Base de Datos, solo se crea 'RepositorioProductoSQL' en la carpeta de Repositorios y se cambia una línea en 'Program.cs'. El código de negocio no cambia.

    C. Separación de Responsabilidades:
        -Entidad ('Producto'): Solo sabe de datos. No sabe cómo se guarda.
        -Caso de Uso ('AgregarProductoUseCase'): Sabe el 'proceso' de agregar (orquestar), pero no el 'detalle' de guardar.
        -Repositorio ('RepositorioProductoTXT'): Solo sabe el 'detalle' técnico de escribir líneas en un archivo.
    
    Testabilidad: Gracias a esta separación, los casos de uso (AgregarProductoUseCase) se pueden probar unitariamente sin necesidad de un archivo de texto real. 
    En las pruebas, simplemente se inyectaría un "falso" repositorio (Mock) que devuelva datos simulados, haciendo las pruebas rápidas y fiables.

Resumen del Flujo de Ejecución:
    1-Program.cs inicia. Crea RepositorioProductoTXT (Infraestructura).
    2-Program.cs crea AgregarProductoUseCase (Lógica) pasando el repositorio.
    3-Llama a agregarProducto.Ejecutar(...).
    4-AgregarProductoUseCase llama a _repo.AgregarProducto(...).
        Nota: Aunque el tipo es IRepositorioProducto, en memoria se ejecuta el código de RepositorioProductoTXT.
    5-RepositorioProductoTXT abre el archivo y escribe las líneas.
    6-El control regresa a Program.cs, que luego llama a ListarProductos.
    7-El proceso se repite en reversa: Program → UseCase → Repositorio (lectura) → Product (objeto) → Console.

¿Cómo probarlo?
    En la terminal de VS Code, dentro de la carpeta 'Almacen', ejecutar:
        dotnet run --project Almacen.Consola

Salida esperada en consola:
    Yerba (ID: 1)
    Azúcar (ID: 2)

    Y en la misma carpeta se habrá creado el archivo 'productos.txt' con los datos.
*/
