// Enfoque manual (Usando la clase ProovedorServicios.cs)

using DiContainer; // Importamos el namespace donde están definidas nuestras clases e interfaces.

// Instanciamos nuestro "Proveedor de Servicios" manual.
// Este objeto será nuestro punto de entrada para obtener todas las dependencias configuradas.
// En un escenario real con DI Container, esto equivaldría a obtener el IServiceProvider del host.
var proveedor = new ProveedorServicios();

// Solicitamos al proveedor una instancia de nuestro servicio principal (IServicioX).
// Internamente, esto ejecutará la lógica de ProveedorServicios:
// 1. El proveedor llamará a GetLogger().
// 2. Creará una nueva instancia de LoggerConsola.
// 3. Inyectará ese logger en el constructor de ServicioX.
// 4. Devolverá la instancia lista de ServicioX.
var servicioX = proveedor.GetServicioX();

// Ejecutamos la lógica de negocio del servicio.
// Em la consola se verán los mensajes de log con las marcas de tiempo generados por el LoggerConsola inyectado.
servicioX.Ejecutar();

// Ahora solicitamos explícitamente una instancia de ILogger al proveedor.
// Nota importante: Dado que nuestro método GetLogger() usa 'new LoggerConsola()',
// esta será una instancia NUEVA y DIFERENTE a la que usó ServicioX internamente.
// (Si quisiéramos que fuera la misma instancia, tendríamos que implementar lógica de Singleton en el proveedor).
var logger = proveedor.GetLogger();

// Usamos el logger directamente para registrar el final del programa.
// Esto demuestra que podemos obtener dependencias "a demanda" en cualquier momento.
logger.Log("Fin del programa");

/*NOTAS:
Observaciones importantes sobre este código:
    -Instancias Diferentes: servicioX tiene su propia instancia de ILogger (creada dentro de GetServicioX), 
    y la variable logger es otra instancia totalmente nueva (creada en la última línea).
        -Si se ejecuta este programa, se verá que el tiempo entre el inicio de ServicioX y el "Fin del programa" 
        usará dos relojes/líneas de tiempo diferentes en la consola, pero ambas funcionarán.
        -En un escenario real, a menudo queremos que ambos usen la misma instancia (Singleton) o la misma por petición 
        (Scoped), lo cual el ProveedorServicios actual no garantiza automáticamente sin cambios adicionales.

    -Flujo Secuencial: El código es completamente secuencial y bloqueante. Espera a que ServicioX.Ejecutar() 
    termine (con su bucle de 100 millones de iteraciones) antes de proceder a crear el logger 
    y escribir el mensaje final.
*/
