using Dominio; // Acceso a la entidad Empleado
using System;  // Necesario para KeyNotFoundException

namespace Aplicacion;

// Capa de Aplicación: orquesta los casos de uso y aplica las reglas de negocio.
// Depende del contrato IRepositorioEmpleados, no de una implementación concreta (DIP).
public class ServicioEmpleados
{
    private const int EdadMinima = 18;   // Edad legal para contratar
    private const int EdadMaxima = 100;  // Umbral defensivo contra errores de captura
    private readonly IRepositorioEmpleados _repositorio; // Inyección de dependencia vía constructor
    /* Delegado estático que agrupa todas las validaciones en un solo punto.
       Al ser static readonly se crea una única vez y evita repetir llamadas
       a los métodos de validación tanto en Registrar como en Modificar (DRY). */
    private static readonly Action<string, string, int, string, char> ValidarTodo =
    (nombre, apellido, edad, direccion, sexo) =>
    {
        ValidarEdad(edad);                          // Valida rango de edad permitido
        ValidarSexo(sexo);                          // Valida que el sexo sea 'M' o 'F'
        ValidarTexto(nombre, nameof(nombre));       // Valida que el nombre no esté vacío
        ValidarTexto(apellido, nameof(apellido));   // Valida que el apellido no esté vacío
        ValidarTexto(direccion, nameof(direccion)); // Valida que la dirección no esté vacía
    };
    // Constructor: recibe el repositorio desde fuera (Inversión de Dependencias, principio D de SOLID)
    public ServicioEmpleados(IRepositorioEmpleados repositorio)
    {
        _repositorio = repositorio;
    }

    // Caso de uso CREATE: valida los datos, construye la entidad y la persiste
    public void RegistrarEmpleado(string nombre, string apellido, int edad, string direccion, char sexo)
    {
        ValidarTodo(nombre, apellido, edad, direccion, sexo); // Aplica todas las reglas de negocio antes de crear

        var nuevo = new Empleado
        {
            Nombre = nombre,
            Apellido = apellido,
            Edad = edad,
            Direccion = direccion,
            Sexo = sexo
        };

        _repositorio.Agregar(nuevo); // Delega la persistencia al repositorio
    }

    // Caso de uso UPDATE: verifica existencia, valida datos y actualiza el registro
    public void ModificarEmpleado(int id, string nombre, string apellido, int edad, string direccion, char sexo)
    {
        if (_repositorio.ObtenerPorId(id) is null)
            throw new KeyNotFoundException($"No existe empleado con ID {id}"); // Falla rápido si el empleado no existe

        ValidarTodo(nombre, apellido, edad, direccion, sexo); // Revalida los nuevos datos con las mismas reglas

        var nuevoEstado = new Empleado
        {
            Nombre = nombre,
            Apellido = apellido,
            Edad = edad,
            Direccion = direccion,
            Sexo = sexo
        };

        nuevoEstado.AsignarId(id);            // Conserva el ID original en la nueva instancia
        _repositorio.Actualizar(nuevoEstado); // Persiste el estado modificado
    }

    // Caso de uso DELETE: elimina el empleado y lanza excepción si no existía
    public void EliminarEmpleado(int id)
    {
        if (!_repositorio.Eliminar(id))
            throw new KeyNotFoundException($"No existe empleado con ID {id}");
    }

    // Caso de uso READ (lista): devuelve todos los empleados delegando al repositorio
    public List<Empleado> ListarTodos()
    {
        return _repositorio.ObtenerTodos();
    }

    // Caso de uso READ (detalle): devuelve un empleado o null si no existe
    public Empleado? ObtenerPorId(int id)
    {
        return _repositorio.ObtenerPorId(id);
    }
    
    // --- Métodos de Validación (Reglas de Negocio) ---

    // Regla de negocio: la edad debe estar dentro del rango permitido
    private static void ValidarEdad(int edad)
    {
        if (edad < EdadMinima || edad > EdadMaxima)
            throw new ArgumentException($"La edad debe estar entre {EdadMinima} y {EdadMaxima} años.");
    }

    // Regla de negocio: el sexo solo admite los valores 'M' o 'F'
    private static void ValidarSexo(char sexo)
    {
        if (sexo != 'M' && sexo != 'F')
            throw new ArgumentException("El sexo debe ser 'M' o 'F'.");
    }

    // Regla de negocio genérica: ningún texto obligatorio puede quedar vacío o en espacios
    private static void ValidarTexto(string texto, string campo)
    {
        if (string.IsNullOrWhiteSpace(texto))
            throw new ArgumentException($"El campo {campo} no puede estar vacío.");
    }
}