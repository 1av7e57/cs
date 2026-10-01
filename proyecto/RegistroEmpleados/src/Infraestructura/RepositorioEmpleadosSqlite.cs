using Aplicacion;            // Acceso al contrato IRepositorioEmpleados que esta clase implementa
using Dominio;               // Acceso a la entidad Empleado
using Microsoft.Data.Sqlite; // Paquete NuGet con el proveedor ADO.NET para SQLite

namespace Infraestructura;

/* Capa de Infraestructura: implementación concreta del repositorio usando SQLite.
   Depende de las capas superiores (Aplicación y Dominio), nunca al revés,
   cumpliendo la regla de dependencias hacia adentro de la arquitectura limpia. */
public class RepositorioEmpleadosSqlite : IRepositorioEmpleados
{
    private readonly string _connectionString; // Cadena de conexión reutilizada por todas las operaciones

    // Constructor: permite personalizar la ruta de la base de datos (por defecto, empleados.db)
    public RepositorioEmpleadosSqlite(string rutaBaseDatos = "empleados.db")
    {
        // ConnectionString con DataSource relativo → se crea en la carpeta de ejecución
        _connectionString = $"Data Source={rutaBaseDatos}";
        InicializarBaseDeDatos(); // Garantiza que la tabla exista antes de cualquier operación
    }

    // Crea la tabla si no existe. Se ejecuta una sola vez al construir el repositorio.
    private void InicializarBaseDeDatos()
    {
        using var conexion = new SqliteConnection(_connectionString); // 'using' asegura cerrar la conexión al salir del ámbito
        conexion.Open(); // Abre la conexión a la base de datos (la crea en disco si no existe)

        /* Script DDL idempotente: CREATE TABLE IF NOT EXISTS evita errores
           si la tabla ya fue creada en ejecuciones anteriores.
           La restricción CHECK limita Sexo a los valores válidos a nivel de base de datos. */
        const string script = @"
            CREATE TABLE IF NOT EXISTS Empleados (
                Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                Nombre    TEXT NOT NULL,
                Apellido  TEXT NOT NULL,
                Edad      INTEGER NOT NULL,
                Direccion TEXT NOT NULL,
                Sexo      TEXT NOT NULL CHECK(Sexo IN ('M','F'))
            );";

        using var comando = new SqliteCommand(script, conexion); // Comando SQL asociado a la conexión
        comando.ExecuteNonQuery(); // Ejecuta el DDL (no devuelve filas, solo aplica el cambio)
    }

    // Implementación de CREATE: inserta un empleado y le asigna el ID generado por SQLite
    public void Agregar(Empleado empleado)
    {
        using var conexion = new SqliteConnection(_connectionString);
        conexion.Open();

        // No insertamos Id: AUTOINCREMENT lo genera solo
        /* Sentencia doble: INSERT + SELECT last_insert_rowid() permite obtener
           en una sola ida a la base el identificador autogenerado del nuevo registro. */
        const string sql = @"
            INSERT INTO Empleados (Nombre, Apellido, Edad, Direccion, Sexo)
            VALUES (@nombre, @apellido, @edad, @direccion, @sexo);
            SELECT last_insert_rowid();";

        using var comando = new SqliteCommand(sql, conexion);
        /* Se usan parámetros con nombre (@) en lugar de concatenar valores:
           esto previene inyección SQL y mejora el rendimiento mediante planes de consulta reutilizables. */
        comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@apellido", empleado.Apellido);
        comando.Parameters.AddWithValue("@edad", empleado.Edad);
        comando.Parameters.AddWithValue("@direccion", empleado.Direccion);
        comando.Parameters.AddWithValue("@sexo", empleado.Sexo.ToString()); // char se convierte a string para el tipo TEXT

        // Obtenemos el ID generado por SQLite y lo asignamos a la entidad
        var idGenerado = (long)comando.ExecuteScalar()!; // ExecuteScalar devuelve el primer valor (el rowid como long)
        empleado.AsignarId((int)idGenerado); // Sincroniza la entidad en memoria con el ID real de la base
    }

    // Implementación de UPDATE: modifica todos los campos del empleado identificado por su Id
    public bool Actualizar(Empleado empleado)
    {
        using var conexion = new SqliteConnection(_connectionString);
        conexion.Open();

        const string sql = @"
            UPDATE Empleados
            SET Nombre = @nombre,
                Apellido = @apellido,
                Edad = @edad,
                Direccion = @direccion,
                Sexo = @sexo
            WHERE Id = @id;";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@nombre", empleado.Nombre);
        comando.Parameters.AddWithValue("@apellido", empleado.Apellido);
        comando.Parameters.AddWithValue("@edad", empleado.Edad);
        comando.Parameters.AddWithValue("@direccion", empleado.Direccion);
        comando.Parameters.AddWithValue("@sexo", empleado.Sexo.ToString());
        comando.Parameters.AddWithValue("@id", empleado.Id); // Filtro por clave primaria

        // ExecuteNonQuery devuelve cantidad de filas afectadas
        return comando.ExecuteNonQuery() > 0; // true si existía el registro, false si el Id no coincide con ninguno
    }

    // Implementación de DELETE: elimina el empleado por su Id
    public bool Eliminar(int id)
    {
        using var conexion = new SqliteConnection(_connectionString);
        conexion.Open();

        const string sql = "DELETE FROM Empleados WHERE Id = @id;";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        return comando.ExecuteNonQuery() > 0; // true si se eliminó alguna fila, false si el Id no existía
    }

    // Implementación de READ (uno): busca un empleado por Id y lo mapea a la entidad
    public Empleado? ObtenerPorId(int id)
    {
        using var conexion = new SqliteConnection(_connectionString);
        conexion.Open();

        const string sql = "SELECT * FROM Empleados WHERE Id = @id;";

        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.AddWithValue("@id", id);

        using var lector = comando.ExecuteReader(); // Lector forward-only de resultados
        if (!lector.Read()) return null; // Si no hay filas, el empleado no existe

        return MapearEmpleado(lector); // Convierte la fila encontrada en una instancia de Empleado
    }

    // Implementación de READ (todos): devuelve la lista completa ordenada por Id
    public List<Empleado> ObtenerTodos()
    {
        var resultado = new List<Empleado>(); // Colección que acumula los resultados

        using var conexion = new SqliteConnection(_connectionString);
        conexion.Open();

        const string sql = "SELECT * FROM Empleados ORDER BY Id;";

        using var comando = new SqliteCommand(sql, conexion);
        using var lector = comando.ExecuteReader();

        while (lector.Read()) // Recorre cada fila del resultado
        {
            resultado.Add(MapearEmpleado(lector)); // Añade cada fila convertida a la lista
        }

        return resultado;
    }

    // Convierte una fila del reader en una instancia de Empleado.
    // Al ser una copia nueva, no hay fuga de encapsulamiento.
    private static Empleado MapearEmpleado(SqliteDataReader lector)
    {
        var emp = new Empleado
        {
            /* GetOrdinal obtiene la posición de cada columna por nombre:
               hace el mapeo resistente a cambios en el orden de las columnas del SELECT. */
            Nombre    = lector.GetString(lector.GetOrdinal("Nombre")),
            Apellido  = lector.GetString(lector.GetOrdinal("Apellido")),
            Edad      = lector.GetInt32(lector.GetOrdinal("Edad")),
            Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
            Sexo      = lector.GetString(lector.GetOrdinal("Sexo"))[0] // Toma el primer carácter del TEXT para recuperarlo como char
        };

        emp.AsignarId((int)lector.GetInt64(lector.GetOrdinal("Id"))); // INTEGER en SQLite se lee como long y se convierte a int
        return emp;
    }
}