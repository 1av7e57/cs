using Aplicacion;     // Importa la capa de aplicación para registrar el servicio
using Infraestructura; // Importa la capa de infraestructura para registrar el repositorio
using Web.Components;  // Importa componentes de la capa Web (App.razor)

// Crea el builder para configurar la aplicación ASP.NET Core
var builder = WebApplication.CreateBuilder(args);

// Añade servicios de Razor a la contenedor de dependencias
// .AddInteractiveServerComponents() habilita Blazor Server (interactividad vía SignalR)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// === Gestión de Ciclo de Vida (Lifetime) de los servicios ===

// IRepositorioEmpleados → Singleton:
// Se comparte una única instancia para toda la aplicación.
// Es seguro porque el repositorio abre y cierra su conexión SQLite en cada método (no mantiene conexiones abiertas).
// Además, evita que la tabla se inicialice múltiples veces (CREATE TABLE IF NOT EXISTS es idempotente).
// "Cada vez que se necesite un IRepositorioEmpleados, usa la misma instancia de RepositorioEmpleadosSqlite."
// Ideal para un recurso compartido como el repositorio de datos.
builder.Services.AddSingleton<IRepositorioEmpleados>(_ =>
{
    // Construye la ruta absoluta a empleados.db, ubicada 5 directorios arriba de la carpeta de ejecución
    // Esto asegura que la base de datos se cree en la carpeta raíz del solución, accesible independientemente de dónde se ejecute
    var rutaDb = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..", "empleados.db"));
    return new RepositorioEmpleadosSqlite(rutaDb); // Crea y registra la única instancia del repositorio
});

// ServicioEmpleados → Scoped:
// Vive por cada circuito/blazor circuit (equivalente a una sesión de usuario en Blazor Server).
// Es el patrón recomendado para servicios de aplicación en ASP.NET Core.
// "Cada vez que se necesite un ServicioEmpleados, crea una nueva instancia por cada solicitud (Scoped)."
// Un recurso por sesión: el servicio.
builder.Services.AddScoped<ServicioEmpleados>();

// Construye la aplicación con toda la configuración aplicada
var app = builder.Build();

// === Configuración del Pipeline HTTP ===

// En producción: habilita manejo de excepciones genérico y HSTS (HTTP Strict Transport Security)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // Manejo seguro de errores
    app.UseHsts(); // Fuerza conexiones HTTPS
}

// Redirige automáticamente todas las peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Sirve archivos estáticos (CSS, JS, imágenes) desde wwwroot
app.UseStaticFiles();
// Activa la protección Anti-forgery para formularios POST (seguridad CSRF)
app.UseAntiforgery();

// Configura el enrutamiento de componentes Razor con interactividad Blazor Server
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // Habilita renderizado interactivo servidor

// Inicia la aplicación y escucha las peticiones entrantes
app.Run();