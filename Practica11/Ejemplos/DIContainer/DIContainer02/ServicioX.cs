/*Lógica del Negocio con Dependencia:
Aquí es donde ocurre la Inyección de Dependencias: ServicioX necesita registrar información, 
pero no crea LoggerConsola manualmente con new. En su lugar, recibe una instancia de ILogger 
a través de su constructor.

El DI Container se encargará de:
-Ver que ServicioX necesita un ILogger.
-Buscar qué implementación está registrada (en este caso, asumimos que es LoggerConsola).
-Instanciar LoggerConsola (si aún no lo ha hecho, según el ciclo de vida).
-Inyectar esa instancia en el constructor de ServicioX.*/

namespace DiContainer;

// Clase concreta que implementa IServicioX.
// Esta clase contiene la lógica de negocio.
public class ServicioX : IServicioX
{
    // Campo privado readonly para almacenar la referencia al logger inyectado.
    // readonly es importante porque queremos asegurarnos de que esta referencia 
    // no cambie una vez que el objeto ha sido construido.
    private readonly ILogger _logger;

    // Constructor que recibe la dependencia (ILogger) como parámetro.
    // El DI Container (o manualmente) se encargará de pasarle una instancia de LoggerConsola 
    // cuando se solicite un ServicioX.
    // Esto se conoce como "Constructor Injection".
    public ServicioX(ILogger logger)
    {
        // Asignamos la instancia inyectada al campo privado.
        this._logger = logger;
    }

    // Método que ejecuta la lógica de negocio.
    public void Ejecutar()
    {
        // Utilizamos el logger inyectado para registrar el inicio del proceso.
        // No importa si el logger escribe en consola, archivo o red; 
        // nosotros solo sabemos que tiene un método 'Log'.
        _logger.Log("ServicioX comenzando su ejecución");

        // Bucle vacío para consumir tiempo de CPU y simular un proceso largo.
        // Esto permite observar en la consola el tiempo real de ejecución y las marcas de tiempo del log.
        for (int i = 1; i <= 100_000_000; i++) { /* Símbolo de vacío */ } 

        // Registamos la finalización del proceso.
        _logger.Log("ServicioX ejecución finalizada");
    }
}

/*NOTAS:
Puntos clave de este diseño:
    -Desacoplamiento: ServicioX no sabe nada sobre LoggerConsola. Solo sabe que necesita 
    algo que cumpla el contrato ILogger. Esto hace el código mucho más flexible y fácil de probar 
    (podría crearse un LoggerFalso para pruebas unitarias fácilmente).
    -Responsabilidad Única: ServicioX se enfoca en su lógica, y LoggerConsola se enfoca en cómo registrar.
    -Gestión de Dependencias: La instancia de ILogger se resuelve automáticamente 
    (si se configura en el contenedor), eliminando la necesidad de usar new LoggerConsola() dentro de ServicioX.
*/