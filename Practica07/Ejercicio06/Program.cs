/*Modificar el ejercicio anterior para que el siguiente código produzca la salida indicada:
var vector = new INombrable[] {
    new Persona() {Nombre="Ana María"},
    new Perro() {Nombre="Sultán"},
    new Persona() {Nombre="Ana"},
    new Persona() {Nombre="José Carlos"},
    new Perro() {Nombre="Chopper"}
};
Array.Sort(vector, new ComparadorLongitudNombre()); //ordena por longitud de Nombre
foreach (INnombrable n in vector)
{
    Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
}

Salida por consola 
3: Ana 
6: Sultán
7: Chopper
9: Ana María
11: José Carlos
*/

// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 
using System.Collections.Generic; // Necesario para List<T>

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio06.Modelos;
using Ejercicio06.Servicios;
using Ejercicio06.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio06;

// --- Clase Principal (Entrada del programa) ---
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // Creamos un array (vector) de tipo INombrable
        var vector = new INombrable[] {
            new Persona() {Nombre="Ana María"},
            new Perro() {Nombre="Sultán"},
            new Persona() {Nombre="Ana"},
            new Persona() {Nombre="José Carlos"},
            new Perro() {Nombre="Chopper"}
        };

        // El cambio clave: Pasamos una instancia de nuestro comparador
        // Esto ignora el CompareTo() de las clases y usa la lógica de longitud
        Array.Sort(vector, new ComparadorLongitudNombre());

        // Recorremos el array
        foreach (INombrable n in vector)
        {
            // Mostramos: Longitud: Nombre
            Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
        }
    }
}

/*NOTAS:
Este ejercicio introduce un nuevo concepto: Separación de algoritmo y datos.
    -Antes: la lógica de ordenamiento estaba "pegada" dentro de las clases (CompareTo en Persona y Perro). 
    -Ahora: se crea una clase externa (ComparadorLongitudNombre) que contenga la lógica de ordenamiento.
Esto permite ordenar la misma lista de diferentes maneras (por nombre, por longitud, por tipo) 
sin tocar el código de las clases Persona o Perro.

¿Qué hace el código de la clase ComparadorLongitudNombre?
    -IComparer<INombrable> es la interfaz para comparadores externos.
    -El método Compare(x, y) recibe dos objetos.
    -x.Nombre.Length.CompareTo(y.Nombre.Length): Compara la longitud de los strings.
        Si x tiene 3 letras y y tiene 6, devuelve negativo (-3), así que x va primero.
        Si x tiene 9 letras y y tiene 11, devuelve negativo (-2), así que x va primero.

Explicación del Resultado:
    El algoritmo de ordenamiento usará ComparadorLongitudNombre:
        -Ana (Longitud 3) vs Sultán (Longitud 6): 3 < 6 -> Ana va primero.
        -Sultán (6) vs Chopper (7): 6 < 7 -> Sultán va antes que Chopper.
        -Chopper (7) vs Ana María (9, contando el espacio): 7 < 9 -> Chopper va antes.
        -Ana María (9) vs José Carlos (11, contando el espacio): 9 < 11 -> Ana María va antes.
    Salida esperada:
        3: Ana
        6: Sultán
        7: Chopper
        9: Ana María
        11: José Carlos

Mejoras de este enfoque:
    -Principio de Responsabilidad Única: Persona y Perro solo saben "ser" y "compararse por nombre" (si usáramos CompareTo interno). 
    El ComparadorLongitudNombre es el único responsable de la lógica de "ordenar por longitud".
    -Flexibilidad: Si se quisiera ordenar por "Nombre al revés" o "Longitud descendente", solo se crearía otra clase 
    (ej. ComparadorNombreDescendente) y se pasaría esa instancia a Array.Sort. No se tocaría Persona.cs ni Perro.cs.
    -Reutilización: Ese comparador se puede usar en cualquier lista de INombrable, incluso si en el futuro se agregase Gatos, por ejemplo.
*/
