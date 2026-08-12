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

a) Ejecutar paso a paso el programa y observar cuidadosamente su funcionamiento. 
Para ejecutar paso a paso colocar un punto de interrupción (breakpoint) en la primera línea ejecutable 
del método Main()

Ejecutar el programa y una vez interrumpido, proseguir paso a paso, en general la tecla 
asociada para ejecutar paso a paso entrando en los métodos que se invocan es F11, sin embargo 
también es posible utilizar el botón de la barra que aparece en la parte superior del editor 
cuando el programa está con la ejecución interrumpida.

b) ¿Qué salida produce por Consola?
c) Borrar (o comentar) la instrucción t1.Trabajando = T1Trabajando; del método Main y contestar:
    c.1) ¿Cuál es el error que ocurre? ¿Dónde y por qué?
    c.2) ¿Cómo se debería implementar el método Trabajar() para evitarlo? Resolverlo.
d) Eliminar el método T1Trabajando en Program.cs y suscribirse al evento con una expresión lambda.
e) Reemplazar el campo público Trabajando de la clase Trabajador, por un evento público 
generado por el compilador (event notación abreviada). ¿Qué operador se debe usar en la suscripción?
f) Cambiar en la clase Trabajador el evento generado automáticamente por uno implementado de manera explícita 
con los dos descriptores de acceso y haciendo que, al momento en que alguien se suscriba al evento, 
se dispare el método Trabajar(), haciendo innecesaria la invocación t1.Trabajar(); en Program.cs
*/
