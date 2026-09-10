// Enfoque que usa DI Container oficial de .NET.

﻿﻿using DiContainer; // Importamos el namespace donde están definidas nuestras clases e interfaces.

// Importamos el namespace que contiene las clases clave del contenedor de servicios:
// ServiceCollection (para registrar) y ServiceProvider (para resolver).
using Microsoft.Extensions.DependencyInjection;

// 1. CONFIGURACIÓN (Registro de Servicios)
// Creamos una instancia de ServiceCollection. Esto actúa como un registro
// donde decimos al contenedor qué servicios existen y cómo deben instanciarse.
var servicios = new ServiceCollection();

// Registramos la dependencia ILogger.
// Sintaxis: AddTransient<Interfaz, Implementación>();
// Esto le dice al contenedor: "Cuando alguien pida un ILogger, crea una NUEVA instancia de LoggerConsola".
// El ciclo de vida 'Transient' significa que cada vez que se solicite (GetService), se crea uno nuevo.
servicios.AddTransient<ILogger, LoggerConsola>();

// Registramos el servicio IServicioX.
// Le decimos: "Cuando alguien pida un IServicioX, crea una nueva instancia de ServicioX".
// Lo importante aquí es que el contenedor es "inteligente": sabe que ServicioX necesita un ILogger en su constructor.
// Al momento de crear ServicioX, el contenedor:
// 1. Ve que necesita ILogger.
// 2. Busca en su registro qué implementación usar (LoggerConsola).
// 3. Crea esa instancia (o la reutiliza si fuera Singleton/Scoped).
// 4. La inyecta automáticamente en el constructor de ServicioX.
// Obervar: No necesitamos escribir nada para conectarlos manualmente!
servicios.AddTransient<IServicioX, ServicioX>();

// 2. CONSTRUCCIÓN DEL CONTENEDOR (Proveedor de Servicios)
// Una vez registrados todos los servicios, llamamos a BuildServiceProvider().
// Esto "compila" la configuración y crea el objeto final (el contenedor real) que podrá resolver dependencias.
// Este objeto es el equivalente moderno a nuestra clase manual 'ProveedorServicios'.
var proveedor = servicios.BuildServiceProvider();

// 3. RESOLUCIÓN (Obtención de servicios)
// Solicitamos una instancia de IServicioX al contenedor.
// El contenedor ejecuta automáticamente toda la cadena de dependencias:
// - Crea LoggerConsola.
// - Crea ServicioX inyectando el Logger.
// - Devuelve la instancia de ServicioX.
// El operador '?.' (null-conditional) se usa por seguridad: 
// si por alguna razón no devuelve nada, no lanza excepción.
var servicioX = proveedor.GetService<IServicioX>();
servicioX?.Ejecutar();

// Solicitamos una instancia de ILogger directamente.
// Observar: dado que registramos como Transient, ¡esto creará una SEGUNDA instancia diferente de LoggerConsola!
// (La que usó ServicioX y esta son objetos distintos en memoria).
var logger = proveedor.GetService<ILogger>();
logger?.Log("Fin del programa");

/*Notas:
Con esta modificación a Program.cs se ha dado el salto desde la "fábrica manual" al DI Container oficial de .NET. 
Esto es lo que se usa en la gran mayoría de las aplicaciones modernas (ASP.NET Core, Worker Services, etc.).

Cambios Clave respecto al enfoque manual:
    1. Declarativo vs. Imperativo:
    -Antes (Manual): Tenía que escribirse el código new LoggerConsola() y new ServicioX(logger) dentro de los métodos Get....
    -Ahora (Container): Solo se declara qué se quiere (AddTransient<ILogger, LoggerConsola>()). 
    El contenedor se encarga de escribir el código de creación y conexión automáticamente.

    2. Resolución Automática de Dependencias:
    -En ProveedorServicios, se tenía que escribir explícitamente new ServicioX(this.GetLogger()).
    -Con el contenedor, si ServicioX tuviera 3 dependencias, 5 dependencias, o dependencias de dependencias, 
    el contenedor las resuelve todo solo. Solo necesitas registrar la "raíz".

    3. Flexibilidad de Ciclos de Vida:
    Si mañana se quiere que ILogger sea un Singleton (una sola instancia para toda la app), 
    solo se cambia una palabra:
        servicios.AddSingleton<ILogger, LoggerConsola>();
    Y automáticamente, tanto servicioX como la variable logger compartiran la misma instancia. 
    Sin tocar ninguna otra línea de código.

Aclaraciónes sobre los tres ciclos de vida estándar en .NET:

1. Transient:
    -Definición: Se crea una nueva instancia cada vez que el servicio se solicita 
    (inyecta en el constructor, se llama mediante GetService, etc.).
    -Uso: Servicios ligeros e inmutables que no mantienen estado interno. Son muy rápidos de crear.
    -Ejemplo: Un servicio de logging o un validador de datos simple.
    -Comportamiento:
        // Si se inyecta el mismo servicio Transient en dos clases diferentes, son objetos distintos.
        // Si se pides dos veces en el mismo método, también son objetos distintos.

2. Scoped:
    -Definición: Se crea una única instancia por cada "alcance" o contexto.
    -Uso: En aplicaciones web ASP.NET Core, el "alcance" es típicamente una sola solicitud HTTP (request). 
    Todos los componentes que se resuelven dentro de esa misma petición comparten la misma instancia.
    -Ejemplo: Un contexto de base de datos (DbContext). Se quiere que todas las operaciones en esa petición 
    usen el mismo contexto, pero que se descarte al finalizar la petición.
    -Comportamiento:
        // En una misma petición web, todas las inyecciones de este servicio devuelven el mismo objeto.
        // En una nueva petición, se crea una instancia completamente nueva.

3. Singleton:
    -Definición: Se crea una única instancia en la vida útil de la aplicación. 
    Esta instancia se comparte en todas las solicitudes y componentes.
    -Uso: Servicios pesados que son costosos de crear o cuyo estado global es deseable y seguro 
    (ej. caché, configuraciones). Deben ser hilos seguros (thread-safe).
    -Ejemplo: Un gestor de conexiones a una base de datos externa, un servicio de caché o un logger central.
    -Comportamiento:
        // La primera vez que se pide, se crea. A partir de ahí, siempre se devuelve la misma instancia.
*/
