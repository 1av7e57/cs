// Esta es una clase de infraestructura de bajo nivel. 
// Actualmente funciona bien, pero es una implementación concreta que no puede ser reemplazada fácilmente.

// Definimos el espacio de nombres
namespace CalculoSimple;

// Clase 'Logger' que implementa la lógica de registro en consola.
class Logger
{
    // Método público que escribe el mensaje en la consola.
    public void Log(string mensaje)
    {
        // Escribimos el mensaje en la salida estándar.
        Console.WriteLine(mensaje);
    }
}