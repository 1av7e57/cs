/*Incorporar al ejercicio anterior las interfaces y métodos necesarios 
para que el siguiente código produzca la salida indicada:
var lista = new List<object>() 
{
    new Persona(),
    new Auto()
};
foreach (IComercial c in lista)
{
    c.Importa();
}
foreach (IImportante i in lista)
{
    i.Importa();
}
(lista[0] as Persona)?.Importa(); 
(lista[1] as Auto)?.Importa();

Salida por consola:
Persona vendiendo al exterior 
Auto que se vende al exterior
Persona importante
Auto importante
Método Importar() de la clase Persona
Método Importar() de la clase Auto
*/


// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 
using System.Collections.Generic; // Necesario para List<T>

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio03.Modelos;
using Ejercicio03.Servicios;
using Ejercicio03.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio03;

// --- Clase Principal (Entrada del programa) ---
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // Crear una lista genérica de objetos
        var lista = new List<object>()
        {
            new Persona(),
            new Auto()
        };

        // 1. Iterar como IComercial
        // El compilador filtra los objetos que implementan IComercial
        foreach (IComercial c in lista)
        {
            c.Importa();
        }

        // 2. Iterar como IImportante
        foreach (IImportante i in lista)
        {
            i.Importa();
        }

        // 3. Casting directo y llamada al método
        (lista[0] as Persona)?.Importar();
        (lista[1] as Auto)?.Importar();
    }
}

/*NOTAS:
Este ejercicio introduce conceptos clave de  polimorfismo a través de interfaces, 
el uso de listas genéricas con el tipo object, y la conversión segura de tipos 
(casting con el operador as y el operador de navegación de nulo ?.).

El objetivo es crear dos nuevas interfaces (IComercial e IImportante) que ambas tengan un método Importa(), 
y hacer que Persona y Auto implementen ambas interfaces (usando implemenación explícita 
para diferenciar métodos con el mismo nombre en ambas interfaces).

Resumen de la Lógica
- Polimorfismo con Interfaces: Los bucles foreach (IComercial c) y foreach (IImportante i) 
iteran sobre la lista de object, pero el compilador solo permite entrar si el objeto implementa 
la interfaz específica. Gracias a la implementación explícita, el método Importa() se ejecuta 
con el comportamiento correcto para esa interfaz.
-Casting Seguro: (lista[0] as Persona) intenta convertir el object a Persona. Si es Persona, devuelve el objeto; 
si no, devuelve null. El operador ?. evita el error si es null.
-Método Público: Para que el último bloque funcione, necesitamos un método público en la clase Persona 
(llamado Importar()  para diferenciar de los explícitos).

Cabe aclarar que, si se quisiera, sería incluso posible nombrar este último método público "Importa()" 
al igual que los demás. El programa aún funcionaría sin conflictos 
(renombrando las llamadas correspondientes para que coincidan). 

A continuación se detallan las razones:

    "Shadowing" y Resolución de Métodos
    En C#, cuando una clase implementa una interfaz de forma explícita (ej. void IComercial.Importa()), 
    ese método se vuelve privado para el exterior de la clase. Solo es accesible si se tiene una referencia 
    del tipo de la interfaz.

    Además, C# permite definir un método público con el mismo nombre (public void Importa()) en la misma clase. 
    El compilador los trata como entidades completamente separadas:

    Métodos Explícitos: void IComercial.Importa() y void IImportante.Importa().
        Visibilidad: Solo accesibles a través de una variable tipada como IComercial o IImportante.
        Propósito: Cumplen el contrato de la interfaz.

    Método Público: public void Importa().
        Visibilidad: Accesible directamente desde la instancia de la clase (Persona p = new Persona(); p.Importa()).
        Propósito: Actúa como el "método base" de la clase.

    ¿Cómo decide el compilador cuál llamar?
    La decisión se toma en tiempo de compilación 
    basándose en el tipo de la variable con la que estás llamando al método:

    Caso 1: foreach (IComercial c en lista)
        Tipo de variable: IComercial.
        Llamada: c.Importa().
        Lógica: El compilador mira la variable c. Sabe que es de tipo IComercial. 
        Busca en la clase Persona la implementación explícita de IComercial.Importa.
        Resultado: Ejecuta el código dentro de void IComercial.Importa().
        Salida: Persona vendiendo al exterior.

    Caso 2: foreach (IImportante i en lista)
        Tipo de variable: IImportante.
        Llamada: i.Importa().
        Lógica: El compilador mira la variable i. 
        Busca la implementación explícita de IImportante.Importa.
        Resultado: Ejecuta el código dentro de void IImportante.Importa().
        Salida: Persona importante.

    Caso 3: (lista[0] as Persona)?.Importa()
        Tipo de variable: Persona (después del casting as Persona).
        Llamada: Importa().
        Lógica: El compilador mira la variable. Sabe que es de tipo Persona. 
        Busca un método público llamado Importa en la clase Persona.
        Resultado: Encuentra public void Importa(). 
        Ignora las implementaciones explícitas porque la variable no es de tipo interfaz.
        Salida: Método Importa() de la clase Persona.

    ¿Por qué no da error de "Método duplicado"?
        Incluso si hay tres métodos con el mismo nombre "Importa()"
        no hay duplicidad porque tienen firmas de acceso diferentes en el contexto de la clase:
            - void IComercial.Importa() es un método explícito de IComercial (sin acceso público directo).
            - void IImportante.Importa() es otro método explícito, esta vez de IImportante (sin acceso público directo).
            - public void Importa() es un método público estándar.
        En la tabla de métodos de la clase Persona, estos coexisten sin chocar porque el compilador 
        sabe exactamente cuál usar según el tipo de referencia con la que se interactúa.

    Resumen Visual
    Variable Tipo	Método Llamado	Implementación Ejecutada	Salida
    IComercial c	c.Importa()	    void IComercial.Importa()	"Persona vendiendo al exterior"
    IImportante i	i.Importa()	    void IImportante.Importa()	"Persona importante"
    Persona p	    p.Importa()	    public void Importa()	    "Método Importa() de la clase Persona"
*/
