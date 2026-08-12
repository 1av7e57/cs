// Importa la colección genérica List para manejar listas de objetos
using System.Collections.Generic;

// Define el espacio de nombres para los contratos
namespace Ejercicio10.Contratos
{
    // Interfaz que define las propiedades que cualquier entidad "Auto" debe tener
    public interface IAuto
    {
        // Propiedad de solo lectura/escritura para la marca del auto (tipo cadena de texto)
        string Marca { get; set; }
        // Propiedad de solo lectura/escritura para el modelo del auto (tipo cadena de texto)
        string Modelo { get; set; }
    }

    // Interfaz que define las operaciones de persistencia (guardar y cargar)
    public interface IAutoRepositorio
    {
        // Método que recibe una lista de autos y los guarda en algún lugar (disco, DB, etc.)
        void Guardar(List<IAuto> autos);
        
        // Método que devuelve una lista de autos cargada desde algún lugar
        List<IAuto> Cargar();
    }
}
