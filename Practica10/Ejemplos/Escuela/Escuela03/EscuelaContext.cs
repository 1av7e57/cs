// Esta clase es la encargada de orquestar toda la conexión y las operaciones con la base de datos.

// 1. Definimos el namespace para agrupar este contexto con nuestras clases de modelo
namespace Escuela;

// 2. Importamos el namespace necesario para tener acceso a DbContext y las opciones de configuración
using Microsoft.EntityFrameworkCore; 

// 3. Declaramos la clase pública EscuelaContext.
//    ': DbContext' indica que HEREDA de la clase base DbContext de EF Core.
//    Esto le da acceso a métodos como SaveChanges(), Query(), y propiedades como ChangeTracker.
public class EscuelaContext : DbContext
{
  // 4. Bloque de deshabilitación de advertencias nullable (#nullable disable).
  //    Las propiedades DbSet a veces no se inicializan en el constructor porque EF Core las crea dinámicamente al cargar la DB.
  //    Esto evita que el compilador de C# nos lance errores de "propiedad no inicializada".
  #nullable disable

  // 5. Propiedad DbSets.
  //    'DbSet<T>' es el tipo que representa una colección de entidades de un tipo específico en la base de datos.
  //    'Alumno' se mapeará automáticamente a la tabla 'Alumnos' en la DB.
  //    EF Core usará esto para hacer consultas (SELECT) y guardar (INSERT/UPDATE/DELETE).
  public DbSet<Alumno> Alumnos { get; set; }

  // 6. 'Examen' se mapeará a la tabla 'Examenes' en la DB.
  //    Notar el plural: Las convenciones de EF Core suelen usar el nombre de la propiedad en plural para la tabla.
  public DbSet<Examen> Examenes { get; set; }

  // 7. Mantenemos deshabilitada la verificación de nullables para evitar advertencias en las propiedades DbSet.
  #nullable disable

  // 8. Método OnConfiguring.
  //    'protected override': Es un método que HEREDA de DbContext pero que nosotros estamos INVALIDANDO (redefiniendo).
  //    Este método se llama automáticamente cada vez que EF Core necesita crear una instancia del contexto.
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    // 9. Configuración de la conexión.
    //    'optionsBuilder.UseSqlite(...)': Le dice a EF Core que use el proveedor de SQLite.
    //    'data source=Escuela.sqlite': Es la cadena de conexión.
    //    Indica que la base de datos es un archivo llamado "Escuela.sqlite" en la carpeta actual de ejecución.
    //    Si el archivo no existe, EF Core podría crearlo automáticamente (dependiendo de la configuración posterior).
    optionsBuilder.UseSqlite("data source=Escuela.sqlite");
  }
}