// Importamos el espacio de nombres de la subcarpeta a utilizar
using Ejercicio02.Modelos;

// Definimos el espacio de nombres propio
namespace Ejercicio02.Interfaces;

// Interfaz para entidades que pueden ser alquiladas y devueltas
public interface IAlquilable
{
    // Método que indica que la entidad se alquila a una persona específica
    void SeAlquilaA(Persona p);
    // Método que indica que la entidad es devuelta por una persona específica
    void SeDevuelvePor(Persona p);
}
