﻿/*Dado el siguiente código:
-------Program.cs---------
Trabajador t1 = new Trabajador();
t1.Trabajando = T1Trabajando;
t1.Trabajar();
void T1Trabajando(object? sender, EventArgs e)
=> Console.WriteLine("Se inició el trabajo");
-------Trabajador.cs---------
class Trabajador
{
    public EventHandler? Trabajando; //No es necesario definir un tipo delegado propio
                                     //porque la plataforma provee el tipo EventHandler
                                     //que se adecua a lo que se necesita
    public void Trabajar()
    {
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        Console.WriteLine("Trabajo concluido");
    }
}

a) Ejecutar paso a paso el programa y observar cuidadosamente su funcionamiento. Para ejecutar
paso a paso colocar un punto de interrupción (breakpoint) en la primera línea ejecutable del
método Main()

Ejecutar el programa y una vez interrumpido, proseguir paso a paso, en general la tecla asociada
para ejecutar paso a paso entrando en los métodos que se invocan es F11, sin embargo también es
posible utilizar el botón de la barra que aparece en la parte superior del editor cuando el programa
está con la ejecución interrumpida.

b) ¿Qué salida produce por Consola?
*/

using System; // Importamos para funciónes básicas

class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // 1. Instanciación del objeto Trabajador.
        // Se crea una nueva instancia de la clase Trabajador.
        // En este momento, el evento 'Trabajando' es null (nadie está suscrito).
        Trabajador t1 = new Trabajador();

        // 2. Suscripción al evento.
        // Se asigna el método 'T1Trabajando' al evento 'Trabajando' del objeto t1.
            // Nota: Se usa '=' en este ejemplo, lo que reemplaza cualquier suscriptor previo.
            // Lo habitual en eventos es usar '+=' para agregar múltiples suscriptores.
        // Ahora, si t1.Trabajando es invocado, ejecutará el método T1Trabajando.
        t1.Trabajando = T1Trabajando;

        // 3. Disparador de la acción.
        // Se llama al método Trabajar(). 
        // Esto iniciará la lógica interna de la clase.
        // Invocando t1.Trabajando que a su vez ejecuta el método suscripto T1Trabajando.
        t1.Trabajar();

        // 4. Definición del método de respuesta (Handler).
        // Este método es el "suscriptor". Se ejecuta cuando el evento 'Trabajando' es invocado.
        // La firma (object? sender, EventArgs e) coincide con el delegado EventHandler estándar:
        // - sender: El objeto que disparó el evento (en este caso, 't1').
        // - e: Argumentos del evento (aquí vacíos, pero usados para datos personalizados).
        // El operador '=>' define una expresión lambda para el cuerpo del método.
        void T1Trabajando(object? sender, EventArgs e)
        {
            // Imprime un mensaje indicando que el evento se ha disparado.
            // Esto ocurre ANTES de que termine la ejecución de 'Trabajar()'.
            Console.WriteLine("Se inició el trabajo");
        }
    }
}

/*NOTAS:
Este ejercicio introduce el patrón de Eventos en C#. 
Utiliza el delegado estándar EventHandler para comunicar que algo ha sucedido 
(en este caso, que un trabajador ha comenzado/terminado de trabajar).

Análisis detallado:
El programa implementa un mecanismo de notificación sencillo:
    1. Instanciación: Se crea un objeto Trabajador (t1).
    2. Suscripción: En la línea t1.Trabajando = T1Trabajando;, el método Main se suscribe 
    al evento Trabajando del objeto t1. Esto significa que le dice al trabajador: 
    "Cuando inicies tu trabajo, ejecuta mi método T1Trabajando".
        - Nota: Aquí se usa el operador =. Si hubiera otra suscripción previa, esta la reemplazaría. 
        Lo ideal en eventos suele ser +=, pero en este caso de ejemplo funciona igual ya que 
        no hay otros suscriptores.
    3. Disparador (Trigger): Se llama al método t1.Trabajar().
    4. Ejecución del Evento: Dentro de Trabajar(), la línea Trabajando(this, EventArgs.Empty); 
    verifica si hay alguien suscrito al evento Trabajando.
        - Como SI hay una suscripción (T1Trabajando), el programa llama a ese método 
        pasando this (la referencia al objeto Trabajador) y un objeto EventArgs vacío.
    5. Respuesta del Suscriptor: Se ejecuta T1Trabajando, que imprime un mensaje en consola.
    6. Continuación: Una vez que el método del evento termina, el control vuelve a Trabajar(), 
    que continúa con el resto de su lógica e imprime el mensaje de finalización.

Conceptos clave: 
    - Sincronía: 
    Observar que "Trabajo concluido" no se imprime hasta que "Se inició el trabajo" ya se ha mostrado. 
    El método Trabajar espera a que termine la ejecución del evento.
    - Parámetros sender y e:
        - sender es útil si un mismo método maneja múltiples eventos de diferentes objetos, permitiéndo identificar 
        quién disparó el evento.
        - EventArgs es la clase base para pasar datos adicionales. Aquí se usas Empty porque no necesitamos 
        pasar información extra, pero podría crearse una clase heredando de EventArgs si se necesitara
        enviar datos (ej. "Hora de inicio", "Tipo de tarea").
    - Desacoplamiento:
        - La clase Trabajador no sabe ni le importa quién se suscribe ni qué hace el método 
        T1Trabajando. Solo se asegura de notificar.
        - El objeto Trabajador no necesita saber quién lo escucha ni qué hará con la notificación. 
        Solo sabe que debe invocar el evento cuando ocurre la acción.     
    Esto cumple con el principio de Inversión de Dependencias y Separación de Responsabilidades.

RESPUESTA:
b) ¿Qué salida produce por Consola?
    La salida será dos líneas en el orden siguiente:
        Se inició el trabajo
        Trabajo concluido

Explicación del orden:
    - La llamada a Trabajando(this, EventArgs.Empty) detiene momentáneamente la ejecución de Trabajar() para ejecutar el método suscrito.
    - El método suscrito (T1Trabajando) imprime "Se inició el trabajo".
    - Al terminar el método suscrito, la ejecución vuelve a Trabajar() justo después de la llamada al evento.
    - La siguiente línea en Trabajar() imprime "Trabajo concluido".

Ejecución paso a paso durante el Debugging:
    1. Breakpoint: Se Coloca el punto de interrupción en Trabajador t1 = new Trabajador();.
    2. F11 (Step Into):
        - Al presionar F11 la primera vez, se crea el objeto t1.
        - La siguiente F11 ejecuta la asignación t1.Trabajando = .... El depurador mostrará que t1.Trabajando ahora contiene una referencia al método T1Trabajando.
        - La siguiente F11 entra en t1.Trabajar().
        - Dentro de Trabajar(), la siguiente F11 entra en la invocación Trabajando(...). ¡El depurador salta dentro de la clase Trabajador y hacia la definición de T1Trabajando!
        - Se ejecuta la lína Console.WriteLine("Se inició el trabajo"); de Program.cs.
        - Al terminar esa línea, la siguiente F11 volverá automáticamente a la línea Console.WriteLine("Trabajo concluido"); dentro de Trabajar().
        - Finalmente, se imprime la segunda línea y el programa termina.
Este flujo visual confirma perfectamente cómo el evento "interrumpe" la lógica principal 
para ejecutar la respuesta del suscriptor y luego devuelve el control.
*/
