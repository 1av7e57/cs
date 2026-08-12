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

e) Reemplazar el campo público Trabajando de la clase Trabajador, por un evento público
generado por el compilador (event notación abreviada). ¿Qué operador se debe usar en la
suscripción?
*/

using System; // Importamos para funciónes básicas
class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // 1. Instanciación del objeto Trabajador.
        Trabajador t1 = new Trabajador();

        // 2. Suscripción con Expresión Lambda (Anónima).

        // CORRECCIÓN:
        // NO SE PUEDE usar '=' (igual) aquí porque 'Trabajando' ahora es un evento, no un campo.
        // El compilador lanzará un error: "Operator '=' cannot be applied to operand of type 'EventHandler'".
        // t1.Trabajando = ... // <-- ESTO DARÍA ERROR

        // DEBE usarse '+=' (agregar) para suscribirse.
        // Esto añade la lambda a la lista interna de suscriptores del evento.
        t1.Trabajando += (sender, e) => 
        {
            // Lógica del suscriptor definida directamente aquí.
            Console.WriteLine("Se inició el trabajo (desde Lambda)");
        };

        // Opcional: Si se quisiera eliminar el suscriptor más tarde:
        // t1.Trabajando -= (sender, e) => { ... }; 

        // 3. Disparador de la acción.
        // Al llamar a Trabajar(), se ejecutará la lógica definida en la lambda anterior.
        t1.Trabajar();
    }
}

/*NOTAS:
¿Cómo cambiar el campo por un evento?
Para declarar un evento público que el compilador gestione, se usa la palabra clave event,
seguida del tipo de delegado y el nombre.

Cambio en Trabajador.cs:
    - Antes: public EventHandler? Trabajando; (Un campo público cualquiera).
    - Ahora: public event EventHandler? Trabajando; (Un evento protegido).

¿Qué operador se debe usar en la suscripción? 
Debido a que el compilador genera una clase de "envoltura" (wrapper) para el evento, 
no se puede usar = para asignar o reemplazar el evento.
    - Si se usa t1.Trabajando = ..., el compilador dará un error.
    - Deben usarse los operadores += (para agregar) y -= (para eliminar).
        += agrega un nuevo suscriptor a la lista.
        -= elimina un suscriptor.
Esto garantiza que el evento no pueda ser sobrescrito accidentalmente por nada que no sea 
la lógica de suscripción, manteniendo la integridad de la lista de suscriptores.

Resumen de la diferencia:
Característica	    Campo Público (EventHandler?)	                                    Evento (event EventHandler?)
Declaración	        public EventHandler? x;	                                            public event EventHandler? x;
Uso en suscripción	Se puede usar = o +=	                                            Solo += y -=
Seguridad	        Cualquiera puede hacer x = null y borrar todos los suscriptores.	El usuario solo puede agregar/quitar suscriptores. Nunca puede borrar la lista completa ni sobrescribirla.
Encapsulamiento	    Bajo (expone la implementación interna).	                        Alto (oculta la lista de suscriptores).

Este es el estándar de la industria en C#: los eventos siempre se declaran con la palabra clave event para proteger la integridad de la cadena de notificaciones.
*/
