/*Modificar el ejercicio anterior para que el siguiente código produzca la salida indicada:
var vector = new INombrable[]
{
    new Persona() {Nombre="Zulema"},
    new Perro() {Nombre="Sultán"},
    new Persona() {Nombre="Claudia"},
    new Persona() {Nombre="Carlos"},
    new Perro() {Nombre="Chopper"},
};
Array.Sort(vector); //debe ordenar por Nombre alfabéticamente 
foreach (INombrable n in vector)
{
    Console.WriteLine($"{n.Nombre}: {n}");
}

Salida por consola:
Carlos: Carlos es una persona 
Claudia: Claudia es una persona 
Zulema: Zulema es una persona 
Chopper: Chopper es un perro 
Sultán: Sultán es un perro

NOTA: Es decir, el ordenamiento ahora da prioridad a las personas sobre los perros, 
primero se listan las personas, ordenadas alfabéticamente, y luego los perros, también ordenados alfabéticamente.
Tip: Sólo es necesario cambiar la forma en que un perro o una persona se sabe comparar contra otro objeto.
*/

// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 
using System.Collections.Generic; // Necesario para List<T>

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio05.Modelos;
using Ejercicio05.Servicios;
using Ejercicio05.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio05;

// --- Clase Principal (Entrada del programa) ---
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // Creamos un array (vector) de tipo INombrable
        // Esto permite mezclar Personas y Perros en la misma colección
        var vector = new INombrable[]
        {
            new Persona() { Nombre = "Zulema" },
            new Perro() { Nombre = "Sultán" },
            new Persona() { Nombre = "Claudia" },
            new Persona() { Nombre = "Carlos" },
            new Perro() { Nombre = "Chopper" },
        };

        // Ordena el array utilizando el método CompareTo implementado en las clases
        Array.Sort(vector); 

        // Recorremos y mostramos
        foreach (INombrable n in vector)
        {
            // n.Nombre accede a la propiedad de la interfaz (qué aquí funciona como nombre propio)
            // n (sin propiedad) llama implícitamente a ToString() imprimiendo el mensaje personalizado (gracias al override que hicimos en las clases)
            Console.WriteLine($"{n.Nombre}: {n}");
        }
    }
}

/*NOTAS:
El objetivo de este ejercicio es demostrar cómo controlar la lógica de comparación (CompareTo) 
para crear un ordenamiento personalizado que no sea simplemente alfabético puro, sino que priorice ciertos tipos de objetos.
Se propone ordenar de manera priorizada: primero todas las Personas (ordenadas entre sí), luego todos los Perros (ordenados entre sí).

Antes, CompareTo solo comparaba el Nombre. Para lograr el nuevo orden, se modifica el método CompareTo en Persona y Perro para que:
    1. Primero compare si los objetos son del mismo tipo (si ambos son Persona o ambos son Perro).
    Si los tipos son iguales, entonces se comparan los nombres.
    2. Si los tipos son diferentes, Persona debe ser "menor" que Perro (para que aparezca primero).

¿Cómo funciona la lógica de ordenamiento?
    El método CompareTo debe devolver:
        -Negativo (< 0): this va antes que other.
        -Cero (0): Son iguales.
        -Positivo (> 0): this va después que other.

Escenarios posibles:
    a.Persona vs Persona:
        CompareTo entra en el if (other is Persona).
        Compara nombres: "Carlos" vs "Zulema". "Carlos" es menor, devuelve negativo. Orden: Carlos, Zulema.

    b.Persona vs Perro:
        La llamada es persona.CompareTo(perro).
        En Persona.CompareTo: other es Perro. El if falla.
        Retorna -1.
        Resultado: Persona va antes que Perro.

    c.Perro vs Persona:
        La llamada es perro.CompareTo(persona).
        En Perro.CompareTo: other es Persona. El if falla.
        Retorna 1.
        Resultado: Perro va después que Persona.

    d.Perro vs Perro:
        CompareTo entra en el if (other is Perro).
        Compara nombres: "Chopper" vs "Sultán". Orden: Chopper, Sultán.
*/
