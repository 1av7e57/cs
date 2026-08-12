using System; // Importamos para funciónes básicas
class Trabajador
{
    // 1. Declaración del evento.
    // Se define un evento público llamado 'Trabajando'.
    // Usa el delegado genérico 'EventHandler', que es el estándar en .NET para eventos.
    // - EventHandler espera métodos con firma: void Method(object sender, EventArgs e).
    // - El '?' en 'EventHandler?' indica que el evento puede ser null si nadie se suscribe.
    public EventHandler? Trabajando; //No es necesario definir un tipo delegado propio
                                     //porque la plataforma provee el tipo EventHandler
                                     //que se adecua a lo que se necesita

    // 2. Método que realiza la acción y dispara el evento.
    public void Trabajar()
    {
        // 3. Invocación del evento.
        // (Si no es null) invoca el método(s) suscrito(s), pasando:
        // - 'this': La referencia al objeto actual (el Trabajador).
        // - 'EventArgs.Empty': Un objeto de argumentos vacío.
        // El flujo de ejecución se desvía AQUÍ hacia el método suscriptor (T1Trabajando).
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        
        // Nota: En el código original se usó 'Trabajando(this, EventArgs.Empty);' 
        // lo cual lanzaría una excepción si nadie se suscribe, pero en este caso 
        // sabemos que sí se suscribió en Main.

        // 4. Continuación de la lógica del trabajo.
        // Esta línea se ejecuta SOLO DESPUÉS de que el método(s) suscrito(s) termine(n).
        // Esto demuestra que el evento es síncrono: el código espera a que termine el evento.
        Console.WriteLine("Trabajo concluido");
    }
}
