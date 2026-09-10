/*Definición del Contrato:
Este archivo define el contrato (la interfaz) que todos los servicios de registro (log) deberán seguir. 
La ventaja principal aquí es que ServicioX no depende de una clase concreta, sino de esta abstracción.*/

namespace DiContainer;

// Definimos una interfaz que actúa como contrato.
// Esto permite que 'ServicioX' dependa de una abstracción (ILogger) y no de una implementación concreta.
// Si en el futuro queremos cambiar la forma de registrar (ej. a un archivo o a un servicio en la nube), 
// solo necesitamos crear una nueva clase que implemente esta interfaz, sin tocar 'ServicioX'.
public interface ILogger
{
    // Método que define la firma para registrar un mensaje.
    void Log(string mensaje);
}