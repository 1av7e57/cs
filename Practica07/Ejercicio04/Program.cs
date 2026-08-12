/*Incorporar al ejercicio anterior las interfaces, propiedades y métodos necesarios 
para que el siguiente código produzca la salida indicada:
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
Chopper: Chopper es un perro 
Claudia: Claudia es una persona 
Sultán: Sultán es un perro 
Zulema: Zulema es una persona
*/

// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 
using System.Collections.Generic; // Necesario para List<T>

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio04.Modelos;
using Ejercicio04.Servicios;
using Ejercicio04.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio04;

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
Este ejercicio introduce dos conceptos fundamentales en C# para trabajar con colecciones y ordenamiento:
    -La interfaz INombrable: es la llave que permite tratar objetos heterogéneos (Persona, Perro) como una colección
    uniforme donde todos comparten una característica específica (Nombre). Esta interfaz actúa como una lupa que 
    dice al compilador: "aunque esto sea una base genérica, asegúra de que todo lo que pase por aquí tenga 
    obligatoriamente una propiedad llamada Nombre".
    -La interfaz IComparable: Para definir cómo se deben ordenar los objetos. Compra los nombres y los ordena alfabéticamente.
Además se implementa:
    -Sobrescritura de ToString(): Para personalizar la salida de texto cuando se convierte el objeto a cadena.

Explicación de la Salida
    -Ordenamiento: Array.Sort recorre el array. Cuando compara dos elementos (ej. "Carlos" vs "Zulema"), llama al método CompareTo de la clase Persona.
    -CompareTo usa string.CompareTo que compara alfabéticamente.
    -Resultado: Carlos < Claudia < Chopper < Sultán < Zulema.
Formato de Salida:
    - n.Nombre: Obtiene el nombre de la interfaz.
    - {n}: Como n es de tipo INombrable (una interfaz), C# busca automáticamente el método ToString() sobrescrito en la clase real (Persona o Perro).
    - Persona.ToString() devuelve "Carlos es una persona".
    - Perro.ToString() devuelve "Chopper es un perro".

¿Por qué usar IComparable<INombrable> y no solo IComparable?
    -IComparable es la versión antigua (no genérica) que usa object.
    -IComparable<T> es la versión moderna y segura. Al usar IComparable<INombrable>, el compilador sabe que other será siempre un INombrable 
    (o derivado), por lo que podemos acceder a other.Nombre directamente sin necesidad de hacer conversiones (cast) manuales como (INombrable)other.

Sobre la herencia en la interfaz INombrable
Al declarar INombrable : IComparable<INombrable>, establecemos que todo objeto que sea nombrable también debe saber compararse con otro.
    -Garantía de Contrato: Cualquier clase que implemente INombrable (como Persona o Perro) está obligada a implementar el método CompareTo.
    -Generación del Comparador: Al ejecutar Array.Sort sobre un arreglo de INombrable[], el sistema utiliza internamente Comparer<INombrable>.Default. Este comparador genérico sabe exactamente cómo invocar CompareTo en los elementos sin necesidad de verificaciones de tipo en tiempo de ejecución.
    -Resultado: El ordenamiento se realiza de manera segura, eficiente y sin ambigüedades, ya que el tipo de la interfaz ya define su propia lógica de comparación.
*/
