/*Definición del Contrato para el Servicio Principal:
Al igual que con el logger, definimos el contrato para el servicio principal de nuestra aplicación. 
Esto asegura que el código que consume ServicioX (por ejemplo, un controlador web) solo necesite 
conocer la interfaz.*/

namespace DiContainer;

// Interfaz que define el comportamiento esperado de 'ServicioX'.
// Cualquier clase que implemente IServicioX deberá tener el método 'Ejecutar'.
public interface IServicioX
{
    // Método que representa la operación principal del servicio.
    void Ejecutar();
}