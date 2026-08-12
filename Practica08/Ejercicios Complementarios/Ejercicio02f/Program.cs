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

f) Cambiar en la clase Trabajador el evento generado automáticamente por uno implementado de
manera explícita con los dos descriptores de acceso y haciendo que, al momento en que alguien se
suscriba al evento, se dispare el método Trabajar(), haciendo innecesaria la invocación
t1.Trabajar(); en Program.cs
*/

using System; // Importamos para funciónes básicas
class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // 1. Instanciación.
        Trabajador t1 = new Trabajador();

        // 2. Suscripción con Expresión Lambda (Anónima).
        // Al ejecutar esta línea, se activa el descriptor 'add' del evento en Trabajador.
        // Dentro de 'add', se llama a Trabajar(), que a su vez invoca el evento.
        // Por lo tanto, el trabajo comienza AQUÍ y AHORA.
        t1.Trabajando += (sender, e) => 
        {
            Console.WriteLine("¡Trabajo iniciado automáticamente al suscribirse!");
        };

        // 3. NO necesitamos llamar a t1.Trabajar(); aquí.
        // Si lo hiciéramos, se ejecutaría el trabajo UNA VEZ MÁS (ya que Trabajar() invoca el evento).
        // t1.Trabajar(); // <-- ESTO SE ELIMINA.

        Console.WriteLine("Programa finalizado (sin llamar a Trabajar manualmente).");
    }
}

/*NOTAS:
Este es un ejercicio avanzado de C# que combina eventos explícitos (explicit events) 
con lógica de negocio personalizada dentro de los descriptores de acceso (add y remove).

Normalmente, un evento se dispara manualmente llamando a un método (como Trabajar()). 
En este caso, se propone inyectar la lógica de ejecución dentro del descriptor add. 
Esto significa que en el momento exacto en que alguien se suscribe, el evento se ejecutará automáticamente.

Cambios Clave:
    1. Evento Explícito: En lugar de public event EventHandler? Trabajando;, usaremos la sintaxis 
    public event EventHandler? Trabajando { add { ... } remove { ... } }.
    2. Lógica en add: Dentro de add, además de guardar el delegado, llamaremos a Trabajar().
    3. Eliminación de llamada en Main: En Program.cs, ya no llamaremos a t1.Trabajar(), 
    porque el trabajo se hará solo al suscribirse.

¿Qué sucede ahora al ejecutar este código?
    1. El programa inicia Main.
    2. Se crea t1.
    3. Se ejecuta t1.Trabajando += ....
        - El compilador llama al bloque add del evento.
        - El bloque add guarda la lambda.
        - El bloque add llama a Trabajar().
        - Trabajar() invoca _trabajando?.Invoke(...).
        - Se ejecuta la lambda: "¡Trabajo iniciado automáticamente al suscribirse!".
        - Trabajar() continúa: "Trabajo concluido".
    4. El programa llega a Console.WriteLine("Programa finalizado...").

Análisis de esta Solución:
    - Ventaja: Elimina la necesidad de recordar llamar al método de disparo. 
    La acción es reactiva a la suscripción.
    - Desventaja (y por qué no se usa siempre): Rompe el principio de "Separación de Responsabilidades" 
    de una forma un poco extraña. El acto de escuchar un evento ahora tiene el efecto secundario de 
    ejecutar la acción. En diseños reales, generalmente queremos separar "cuándo se suscribe" de 
    "cuándo ocurre la acción", pero para este ejercicio, es una excelente demostración de 
    cómo funcionan los descriptores de acceso (add/remove) a nivel de compilador.
    - Eventos Explícitos: Esta técnica es muy útil cuando queremos controlar completamente 
    la lógica de suscripción (ej. validar si el usuario tiene permisos para suscribirse, o como en este caso, 
    disparar una acción).
*/
