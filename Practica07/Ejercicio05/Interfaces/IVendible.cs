// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio05.Modelos;

// Definimos el espacio de nombres propio
namespace Ejercicio05.Interfaces;

// Interfaz para entidades que pueden ser vendidas a una persona
public interface IVendible
{
    // Método que indica la venta de la entidad a una persona
    void SeVendeA(Persona p);
}