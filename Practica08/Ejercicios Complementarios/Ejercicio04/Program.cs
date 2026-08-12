﻿/*Codificar una clase Ingresador con un método público Ingresar() que permita al usuario
ingresar líneas por la consola hasta que se ingrese la línea con la palabra "fin". Ingresador debe
implementar dos eventos. Uno sirve para notificar que se ha ingresado una línea vacía ( "" ). El otro
para indicar que se ha ingresado un valor numérico (debe comunicar el valor del número ingresado
como argumento cuando se genera el evento). A modo de ejemplo observar el siguiente código que
hace uso de un objeto Ingresador.

Ingresador ingresador = new Ingresador();
ingresador.LineaVaciaIngresada += (sender, e) =>
    { Console.WriteLine("Se ingresó una línea en blanco"); };
ingresador.NroIngresado += (sender, e) =>
    { Console.WriteLine($"Se ingresó el número {e.Valor}"); };
ingresador.Ingresar();
*/

using System;

class Program
{
    static void Main()
    {
        // Instanciamos el ingresador.
        Ingresador ingresador = new Ingresador();

        // 1. Suscripción al evento de línea vacía.
        // Usamos una expresión lambda: (sender, e) => { ... }
        // para crear un delegado anónimo (un método sin nombre) y suscribirlo al evento.
        // Parámetros del método:
        // sender: El objeto que disparó el evento (el Ingresador).
        // e: Los datos del evento (en este caso, de tipo EventArgs y recibe el valor EventArgs.Empty).
        ingresador.LineaVaciaIngresada += (sender, e) =>
        {
            Console.WriteLine(">>> ¡Se ingresó una línea en blanco! <<<");
        };

        // 2. Suscripción al evento de número ingresado.
        // Similar al caso anterior, usando lambda.
        // Aquí 'e' es de tipo NumeroEventArgs, por lo que podemos acceder a 'e.Valor'.
        ingresador.NroIngresado += (sender, e) =>
        {
            Console.WriteLine($">>> Se ingresó el número: {e.Valor} <<<");
        };

        // Iniciamos el proceso de ingreso.
        ingresador.Ingresar();
    }
}

/*NOTAS:
Este ejercicio propone practicar la creación de clases de argumentos personalizados (para el número) 
y el manejo de múltiples eventos con diferentes propósitos.

Estructura del programa:
    - Clase NumeroEventArgs: 
        -Creamos una clase pequeña que hereda de EventArgs 
        para transportar el valor numérico del evento.
    - Clase Ingresador:
        -Define dos eventos: LineaVaciaIngresada (sin datos extra) y NroIngresado (con NumeroEventArgs).
        -En el método Ingresar(), lée la entrada.
        -Valida si es vacía o si es un número usando int.TryParse.
        -Dispara el evento correspondiente.

Puntos Clave:
    -Tipos de Eventos Diferentes:
        -LineaVaciaIngresada usa EventHandler. Es para eventos de "notificación simple".
        -NroIngresado usa EventHandler<NumeroEventArgs>. Es para eventos que requieren datos.
    -Validación de Datos:
        -Usamos int.TryParse para intentar convertir el string a entero de forma segura. 
        Si falla, no disparamos el evento numérico.
    -Expresiones Lambda:
        - En Main, no creamos métodos separados (ManejarVacio, ManejarNumero). Usamos lambdas 
        para definir la lógica de suscripción directamente en el lugar donde suscribimos. 
        Esto es común en C# moderno para eventos simples.
*/
