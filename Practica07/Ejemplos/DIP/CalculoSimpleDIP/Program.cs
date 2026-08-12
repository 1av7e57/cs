/* Se ha transformado correctamente el código para cumplir con el Principio de Inversión de Dependencias (DIP). 
Calculador ya no depende de una implementación concreta, sino de la abstracción ILogger.*/

//Ahora el punto de entrada es el responsable de crear las dependencias y ensamblarlas (esto es la inyección manual).

// Importamos el espacio de nombres.
using CalculoSimple;

// 1. Creamos una instancia de la implementación concreta 'Logger'.
//    Nota: Aquí es donde se "resuelve" la dependencia.
//    Podríamos cambiar esta línea por 'new FileLogger()' o 'new DbLogger()'
//    y el resto del código no tendría que cambiar.
ILogger logger = new Logger();

// 2. Creamos la instancia de 'Calculador'.
//    En lugar de 'new Calculador()', pasamos el 'logger' como argumento.
//    Esto es la Inyección de Dependencias (DI).
//    'Calculador' ahora es "agnóstico" a qué tipo de Logger se le está dando.
Calculador calc = new Calculador(logger);

// 3. Ejecutamos la lógica.
//    Internamente, 'Calculador' usará el 'logger' que le inyectamos.
calc.Calcular(3);

/*NOTAS:
¿Qué se ha logrado con estos cambios?
    -Inversión de Dependencias: Calculador ya no depende de Logger. Depende de ILogger. 
    La dirección de la dependencia fluye hacia la abstracción.
    -Bajo Acoplamiento: Si mañana se necesitara agregar un EmailLogger o FileLogger, 
    solo se crearía una nueva clase que implemente ILogger. No se tocaría ni una línea de código en Calculador.cs.
    -Pruebas Unitarias Facilitadas: Ahora se puede crear un MockLogger 
    (una clase que implemente ILogger y guarde los mensajes en una lista en memoria) 
    para probar Calculador sin escribir nada en la consola ni usar disco.
    -Open/Closed Principle: La clase Calculador está "abierta para extensión" (puedes añadir nuevos logs) 
    pero "cerrada para modificación" (no se necesita cambiar su código).
