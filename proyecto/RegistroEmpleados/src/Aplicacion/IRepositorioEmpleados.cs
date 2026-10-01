using Dominio; // Acceso a la entidad Empleado

namespace Aplicacion;

// Capa de Aplicación: define el contrato (interfaz) para las operaciones CRUD de empleados.
// Permite sustituir la implementación sin afectar el resto del programa (principio de inversión de dependencias).
public interface IRepositorioEmpleados
{
    // Crea un nuevo empleado en el repositorio
    void Agregar(Empleado empleado);

    // Actualiza un empleado existente; devuelve true si se encontró y actualizó, false en caso contrario
    bool Actualizar(Empleado empleado);

    // Elimina un empleado por su ID; devuelve true si se encontró y eliminó, false en caso contrario
    bool Eliminar(int id);

    // Obtiene un empleado por su ID; devuelve null si no existe
    Empleado? ObtenerPorId(int id);

    // Obtiene la lista completa de empleados
    List<Empleado> ObtenerTodos();
}