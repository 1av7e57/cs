/*Esta clase, actúa como un Manual Factory o Manual Dependency Resolver. 
Su responsabilidad es centralizar la lógica de creación de objetos.*/

namespace DiContainer;

// Clase que actúa como un "Proveedor de Servicios" manual.
// Su único propósito es centralizar la creación y configuración de instancias.
// En un sistema real con un DI Container (como el de .NET), esta clase a menudo
// no sería necesaria o se reemplazaría por los registros del contenedor,
// pero entenderla es clave para ver qué hace el contenedor "por detrás" 
// o cómo se podría configurar manualmente antes de usar el contenedor automático de .NET.
class ProveedorServicios
{
    // Método que se encarga de crear una instancia de ILogger.
    // Aquí decidimos explícitamente que la implementación concreta será 'LoggerConsola'.
    // El DI Container haría lo mismo pero de forma declarativa (ej: services.AddScoped<ILogger, LoggerConsola>()).
    public ILogger GetLogger()
    {
        // Creamos una nueva instancia de la clase concreta que implementa la interfaz.
        return new LoggerConsola();
    }

    // Método que se encarga de crear una instancia de IServicioX.
    // Observar cómo resuelve la dependencia de forma manual.
    public IServicioX GetServicioX()
    {
        // 1. Primero, solicita la dependencia necesaria (ILogger) llamando a su propio método.
        //    Esto demuestra que ProveedorServicios se puede "autoproporcionar" las dependencias básicas.
        //    En un escenario real, se podría necesitar loggear en un archivo, y aquí se cambiaría
        //    'new LoggerConsola()' por 'new LoggerArchivo()' sin tocar 'ServicioX'.
        var loggerDependencia = this.GetLogger();

        // 2. Luego, pasa esa instancia como argumento al constructor de 'ServicioX'.
        //    Esto es exactamente lo que el DI Container haría: inyectar la dependencia resuelta.
        return new ServicioX(loggerDependencia);
    }
}

/*NOTAS:

Análisis de este enfoque:
    -Centralización: Todo el conocimiento sobre "qué clase concreta usar para ILogger" y "cómo instanciar ServicioX" vive aquí. 
    Si mañana se decide cambiar el logger a uno de archivo, solo se modifica GetLogger().
    -Acoplamiento Manual: Aunque ServicioX está desacoplado de LoggerConsola, ProveedorServicios sí está acoplado 
    a ambas clases concretas (LoggerConsola y ServicioX). Debe conocer sus constructores y saber qué instanciar.
    -Simulación del Container: Este patrón imita lo que hace un DI Container, 
    pero de forma imperativa (Uno mismo decide cómo hacerlo), en lugar de declarativa 
    (Uno mismo dice qué necesita y el container decide el cómo).
        -Container: services.AddScoped<ILogger, LoggerConsola>(); (Declarativo).
        -Proveedor: return new LoggerConsola(); (Imperativo).


Diagrama de Flujo Lógico:

    [Inicio: GetServicioX()]
        |
        v
    [¿Necesito un ILogger?] --> SÍ
        |
        v
    [Llamar a GetLogger()]
        |
        +---> [GetLogger: new LoggerConsola()]
        |           |
        |           v
        |      [Crear objeto en memoria]
        |           |
        |           v
        +<-- [Devolver instancia de ILogger]
        |
        v
    [Crear nuevo ServicioX(inyectando el ILogger recibido)]
        |
        +---> [Constructor de ServicioX]
        |           |
        |           v
        |      [Guardar _logger = instancia_recibida]
        |
        v
    [Devolver instancia de ServicioX]


Puntos Clave de esta Lógica Manual:
    -Resolución Recursiva: Observar cómo GetServicioX no puede terminar su trabajo hasta que GetLogger 
    termina el suyo. El contenedor hace esto recursivamente: si ServicioX necesitara otro servicio 
    que a su vez necesitara un logger, el contenedor (o ProveedorServicios) tendría que "desenredar" 
    esa cadena hasta llegar a las dependencias base (como el logger).

    -Ciclo de Vida Implícito (Transient):
        -En este código específico, cada vez que se llama a GetServicioX(), se crea un nuevo LoggerConsola 
        (porque GetLogger siempre hace new).
        -Esto equivale al ciclo de vida Transient (Se crea cada vez que se pide/Múltiples instancias por solicitud).
        -¿Qué pasaría si quisiéramos un Singleton? Se tendría que añadir una variable privada 
        private ILogger? _loggerSingleton; y modificar GetLogger para que solo cree el objeto 
        la primera vez que se llame. El DI Container hace esto automáticamente según la configuración.

¿Por qué usar esto en lugar de new directo?
Si en Program.cs se hiciera esto:
    // Enfoque sin proveedor (Acoplado)
    var servicio = new ServicioX(new LoggerConsola());
Y mañana se quisiera cambiar a un LoggerArchivo, tendría que buscarse cada lugar en el código 
donde se instancia ServicioX y cambiar new LoggerConsola() por new LoggerArchivo().
Con ProveedorServicios, solo se cambia una línea en GetLogger(), y todo el sistema se actualiza.
*/