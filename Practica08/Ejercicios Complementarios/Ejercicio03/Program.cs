﻿/*Analizar el siguiente código:
-------Program.cs---------
ContadorDeLineas contador = new ContadorDeLineas();
contador.Contar();
-------ContadorDeLineas.cs-------- -
class ContadorDeLineas
{
    private int _cantLineas = 0;
    public void Contar()
    {
        Ingresador _ingresador = new Ingresador();
        _ingresador.Contador = this;
        _ingresador.Ingresar();
        Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
    }
    public void UnaLineaMas() => _cantLineas++;
}
-------Ingresador.cs---------
class Ingresador
{
    public ContadorDeLineas? Contador { get; set; }
    public void Ingresar()
    {
        string st = Console.ReadLine() ?? "";
        while (st != "")
        {
            Contador?.UnaLineaMas();
            st = Console.ReadLine() ?? "";
        }
    }
}

Existe un alto nivel de acoplamiento entre las clases ContadorDeLineas e Ingresador, habiendo una
referencia circular: un objeto ContadorDeLineas posee una referencia a un objeto Ingresador y éste
último posee una referencia al primero. Esto no es deseable, hace que el código sea difícil de
mantener. Eliminar esta referencia circular utilizando un evento, de tal forma que ContadorDeLineas
posea una referencia a Ingresador pero que no ocurra lo contrario.
*/

using System; // Importamos para funciónes básicas

class Program // Clase principal del programa
{
    static void Main() // Punto de entrada al programa
    {
        // Instanciamos el contador.
        ContadorDeLineas contador = new ContadorDeLineas();

        // Iniciamos el proceso.
        // Todo el trabajo de "saber quién llama a quién" ocurre internamente mediante eventos.
        contador.Contar();
    }
}

/*Notas:
El ejercicio propone ilustrar la importancia de desacoplar componentes usando Delegados y Eventos en C#.

¿Qué hace el programa? 
    El programa cuenta la cantidad de líneas de texto que el usuario ingresa por consola 
    hasta que presiona "Enter" en una línea vacía.

¿Cómo funciona? (Análisis del Código Original)
1. ContadorDeLineas:
    - Inicializa un contador interno _cantLineas en 0.
    - En su método Contar(), instancia un nuevo Ingresador.
    - Le asigna una referencia a sí mismo (this) a la propiedad Contador del Ingresador.
    - Llama a Ingresar().
    - Al finalizar, imprime el total.
    - Tiene el método UnaLineaMas() para incrementar su conteo.
2. Ingresador:
    - Tiene una propiedad Contador del tipo ContadorDeLineas (inicialmente nula).
    - En Ingresar(), lee líneas de la consola en un bucle while.
    - Por cada línea no vacía, llama explícitamente a Contador?.UnaLineaMas().

El Problema de Acoplamiento: 
- Existe un acoplamiento fuerte y circular:
    - ContadorDeLineas: sabe exactamente que está usando una clase llamada Ingresador y crea una instancia de ella.
    - Ingresador: sabe exactamente que debe llamar al método UnaLineaMas de una clase llamada ContadorDeLineas.
- Por qué es un problema: Si a futuro se quiere cambiar Ingresador para leer de un archivo en lugar de la consola, 
o si se quiere que ContadorDeLineas guarde los datos en una base de datos en lugar de imprimir, 
se tiene que modificar ambas clases. No se cumple con el Principio de Inversión de Dependencias (DIP).

Solución: Desacoplando con Eventos
    Para eliminar la referencia circular y el acoplamiento, se propone usar 
    el patrón Publisher-Subscriber (Publicador-Suscriptor) mediante Eventos.

La Estrategia:
    - Ingresador (El Publicador): 
        - No sabrá quién consume sus datos. 
        - Solo sabrá que algo está interesado en saber cuando se ha ingresado una línea. 
        - Definirá un evento (LineaIngresada).
    - ContadorDeLineas (El Suscriptor): 
        - Se suscribirá al evento de Ingresador. 
        - Cuando Ingresador dispare el evento, ContadorDeLineas recibirá la notificación y aumentará su contador.
Resultado: Ingresador ya no necesita conocer la clase ContadorDeLineas. Solo necesita conocer el evento.

Resumen de la Mejora:
    - Sin Referencia Circular: Ingresador ya no tiene la propiedad public ContadorDeLineas? Contador { get; set; }.
    - Inversión de Dependencias: Ingresador depende de una abstracción (el evento), no de una clase concreta. 
    Se podría crear un ContadorDeArchivos o un ContadorDeBaseDeDatos y ambos podrían suscribirse 
    al mismo Ingresador sin modificar su código.
    - Claridad: El flujo es: "Yo leo" -> "Avisó que leí" -> "Tú cuentas".

¿Por qué esto es mejor para la Arquitectura Limpia? 
    En una arquitectura limpia, la capa de Presentación o Interfaz de Usuario 
    (que en este caso es Ingresador leyendo de consola) no debe depender de la 
    lógica de Negocio o Dominio (ContadorDeLineas). 
    Al usar eventos, Ingresador se convierte en una pieza genérica de "Entrada de Datos" 
    que puede ser reutilizada en cualquier contexto, y ContadorDeLineas es una 
    regla de negocio pura que decide qué hacer con esos datos.
*/
