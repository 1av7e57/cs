﻿/*Codificar la clase Temporizador con un evento Tic que se genera cada cierto intervalo de tiempo
medido en milisegundos una vez que el temporizador se haya habilitado. La clase debe contar con
dos propiedades: Intervalo de tipo int y Habilitado de tipo bool. No se debe permitir establecer la
propiedad Habilitado en true si no existe ninguna suscripción al evento Tic. No se debe permitir
establecer el valor de Intervalo menor a 100. En el lanzamiento del evento, el temporizador debe
informar la cantidad de veces que se provocó el evento. Para detener los eventos debe establecerse la
propiedad Habilitado en false. A modo de ejemplo, el siguiente código debe producir la salida
indicada.

Temporizador t = new Temporizador();
t.Tic += (sender, e) =>
{
    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " ");
    if (e.Tics == 5)
    {
        t.Habilitado = false;
    }
};
t.Intervalo = 2000;
t.Habilitado = true;

Salida por consola
14:20:50
14:20:52
14:20:54
14:20:56
14:20:58
*/

using System; // Importamos para funciónes básicas.
using System.Threading; // Importamos para trabajar con hilos (Threads).

class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // Instanciamos el temporizador.
        Temporizador t = new Temporizador();

        // Suscripción al evento Tic usando una Lambda.
        t.Tic += (sender, e) =>
        {
            // Imprimimos la hora actual.
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            // Lógica de parada: Si se han disparado 5 veces, deshabilitamos el temporizador.
            // Esto cambiará la propiedad Habilitado a false, deteniendo el hilo.
            if (e.Tics == 5)
            {
                Console.WriteLine(">>> 5 tics alcanzados. Deteniendo temporizador. <<<");
                t.Habilitado = false;
            }
        };

        // Configuramos el intervalo (2 segundos = 2000 ms).
        t.Intervalo = 2000;

        // Activamos el temporizador.
        // Esto lanzará una excepción si no hubiera habido suscripción arriba.
        t.Habilitado = true;

        // Mantenemos el programa principal activo para que el hilo de fondo pueda ejecutarse.
        // En una app real, esto sería un bucle de mensajes o un await.
        Console.WriteLine("Contando tics...");
        Console.WriteLine("Presiona Enter para finalizar el programa.");
        Console.ReadLine();
    }
}

/*NOTAS:
Este ejercicio combina Delegados personalizados, Eventos, Propiedades con validación, 
Hilos (Threads) para la temporización y Lógica de estado.

Explicación de los Puntos Clave:
1. Validación de Habilitado:
        if (value && !VerificarSuscriptores()) { ... }
        Usamos Tic != null para saber si alguien se suscribió. 
            Si se intenta poner Habilitado = true sin suscriptores, el código lanza una InvalidOperationException. 
            Esto cumple con el requisito de seguridad.
2. Validación de Intervalo:
    if (value < 100) throw new ArgumentException(...);
        Evita tiempos de espera demasiado cortos que podrían sobrecargar el CPU.
3. El Hilo (Thread):
    - Usamos Thread.Sleep(Intervalo) para pausar el hilo sin bloquear el resto del programa.
    - El hilo se crea solo cuando Habilitado pasa a true y se detiene (o se deja morir) cuando pasa a false.
4. Contador de Tics:
    - La variable _contadorTics se incrementa en cada ciclo.
    - Se pasa al evento mediante TicEventArgs.
    - En el Main, la lambda lee e.Tics y decide cuándo parar.

Nota Importante sobre el uso de Hilo: 
    En un entorno real, Thread es un poco antiguo para temporizadores simples. 
    Se usaría System.Threading.Timer o System.Timers.Timer, que manejan 
    mejor la concurrencia y la limpieza de recursos. 
    Sin embargo, implementar el hilo manualmente 
    es la mejor manera de entender cómo funciona "por debajo".
*/
