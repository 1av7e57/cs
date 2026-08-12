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

c) Borrar (o comentar) la instrucción t1.Trabajando = T1Trabajando; del método Main y
contestar:
c.1) ¿Cuál es el error que ocurre? ¿Dónde y por qué?
c.2) ¿Cómo se debería implementar el método Trabajar() para evitarlo? Resolverlo.
*/

using System; // Importamos para funciónes básicas
class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // 1. Instanciación del objeto Trabajador.
        Trabajador t1 = new Trabajador();

        // 2. Suscripción al evento.
        // t1.Trabajando = T1Trabajando; // Comentamos esta línea para omitir su ejecución.

        // 3. Disparador de la acción.
        t1.Trabajar();

        // 4. Definición del método de respuesta (Handler). Nota: en este caso nunca se usa.
        void T1Trabajando(object? sender, EventArgs e)
        {
            Console.WriteLine("Se inició el trabajo");
        }
    }
}

/*NOTAS:
RESPUESTAS:
c.1) ¿Cuál es el error que ocurre? ¿Dónde y por qué?
    Si se borra (o se comenta) la línea t1.Trabajando = T1Trabajando;, el error que ocurre 
    es una excepción de tiempo de ejecución (NullReferenceException o InvalidOperationException 
    dependiendo de la versión de C# y cómo se defina el evento).
    - ¿Dónde ocurre? 
        - En la línea Trabajando(this, EventArgs.Empty); dentro del método Trabajar() de la clase Trabajador.
    - ¿Por qué ocurre?
        - Al no haber suscripción en Main, el evento Trabajando permanece en su valor inicial, que es null.
        - En C#, intentar invocar un método delegado que es null (hacer null()) lanza una excepción.
        - El código original intenta llamar directamente al delegado sin verificar si existe algo que ejecutar: 
        Trabajando(...) es equivalente a Trabajando.Invoke(...). Si Trabajando es null, el sistema lanza la excepción.

    Nota: En versiones modernas de C# (C# 6.0+), si el evento está definido como public EventHandler? Trabajando; 
    (con el ? para nullable), intentar invocarlo sin verificar puede generar advertencias del compilador 
    o lanzar la excepción más explícitamente.

c.2) ¿Cómo se debería implementar el método Trabajar() para evitarlo? Resolverlo.
    La solución estándar y recomendada en C# es verificar si el evento no es null antes de invocarlo. 
    Esto se puede hacer de dos formas principales:
        - Verificación explícita: Comprobar if (Trabajando != null).
        - Operador de invocación segura (null-conditional operator): Usar ? antes del punto de invocación (Trabajando?.Invoke(...)).
    Para la resolución de este ejercicio se ha modificado el código de la clase Trabajador,
    optando por la segunda opción ya que es más moderna, concisa y segura.

¿Cómo funciona ahora el programa modificado?
    -Si no hay suscripción (t1.Trabajando = null), 
    la línea Trabajando?.Invoke(...) simplemente se salta y el programa continúa.
    -La salida por consola sería únicamente: Trabajo concluido.
    -No hay interrupciones ni excepciones.

Resumen del concepto de seguridad en eventos:
    En C#, la regla de oro para eventos (que son delegados especiales) es: 
    Nunca invocues un evento directamente si no estás seguro de que tiene suscriptores.
        - Incorrecto (Viejo C#): MiEvento(sender, e); (Riesgo de NullReferenceException si no hay suscriptores).
        - Correcto (Moderno): MiEvento?.Invoke(sender, e); (Si es null, no pasa nada).
        - Correcto (Clásico): if (MiEvento != null) MiEvento(sender, e);
*/
