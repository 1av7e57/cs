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

d) Eliminar el método T1Trabajando en Program.cs y suscribirse al evento con una expresión
lambda.
*/

using System; // Importamos para funciónes básicas
class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // 1. Instanciación del objeto Trabajador.
        Trabajador t1 = new Trabajador();

        // 2. Suscripción con Expresión Lambda (Anónima).
        // En lugar de llamar a un método definido previamente (t1.Trabajando = T1Trabajando),
        // definimos la lógica "al vuelo" (inline).
        // La expresión lambda tiene la misma firma que el evento: (object sender, EventArgs e).
        // NOTA: Al usar '=', para agregar este suscriptor al evento se reemplaza cualquier otro suscriptor existente.
        t1.Trabajando = (sender, e) => 
        {
            // Lógica del suscriptor definida directamente aquí.
            // 'sender' es el objeto que disparó el evento (t1).
            // 'e' son los argumentos del evento (vacíos en este caso).
            Console.WriteLine("Se inició el trabajo (desde Lambda)");
        };

        // 3. Disparador de la acción.
        // Al llamar a Trabajar(), se ejecutará la lógica definida en la lambda anterior.
        t1.Trabajar();
    }
}

/*NOTAS:
El código se ha actualizado,eliminado el método T1Trabajando y reemplazándo la suscripción 
por una expresión lambda directamente en la línea de suscripción. 
Esto demuestra la flexibilidad de los eventos para aceptar lógica anónima sin necesidad 
de definir métodos separados.

Cambios clave y beneficios de este enfoque:
    - Eliminación de método extra: Ya no se necesita definir void T1Trabajando(...). La lógica vive donde se usa.
    - Legibilidad: Para acciones simples (como imprimir una línea), mantener el código junto a la suscripción hace que el flujo sea más fácil de leer.
    - Flexibilidad: Si en el futuro se necesita suscribir lógica diferente para diferentes instancias de Trabajador, 
    se puede definir una lambda única para cada una sin llenar la clase con muchos métodos auxiliares.
    - Sintaxis: Observar que (sender, e) => { ... } es equivalente a la definición de método anterior. 
    El compilador infiere los tipos object y EventArgs porque el evento Trabajando ya los espera.
*/
