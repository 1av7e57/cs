using Teoria7;

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        object[] vector = new object[]
        {
            new Moto("Zanella"),
            new Empleado("Juan"),
            new Moto("Gilera")
        };

        // veremos que esta solucion es poco efectiva más adelante
        foreach (object o in vector)
        {
            if (o is Empleado e)
            {
                e.Imprimir();
            }
            else if (o is Moto m)
            {
                m.Imprimir();
            }
        }
    }
}

/*NOTAS:
1. ¿Qué hace este proyecto?
    El programa crea una lista (vector) de objetos heterogéneos (diferentes tipos: Moto y Empleado) 
    almacenados todos como object. Luego, recorre esa lista y, para cada elemento, detecta manualmente 
    de qué tipo es (si es un Empleado o una Moto) y llama al método Imprimir() correspondiente.

    En resumen: Imprime la información de todos los objetos en la lista, pero requiere "adivinar" o comprobar
    el tipo de cada uno antes de actuar.

2. ¿Cómo lo hace? (Análisis paso a paso)

    A. La Jerarquía de Herencias
    El código usa dos jerarquías de clases separadas (dos árboles distintos que no se conectan):
    -Árbol de Personas:
        Persona (Clase base): Tiene el campo Nombre.
        Empleado (Hija): Hereda de Persona, inicializa Nombre y define Imprimir().
    -Árbol de Automotores:
        Automotor (Clase base): Tiene el campo Marca.
        Moto (Hija): Hereda de Automotor, inicializa Marca y define Imprimir().
    Nota importante: Empleado y Moto no comparten ninguna clase base común (excepto object implícitamente).
    Son "primos lejanos" en el mundo de C#.

    B. El Almacenamiento Heterogéneo
            object[] vector = new object[]
            {
                new Moto("Zanella"),
                new Empleado("Juan"),
                new Moto("Gilera")
            };
        -Se crea un array capaz de guardar cualquier cosa (object).
        -Esto permite mezclar Moto y Empleado en la misma lista, algo que no se podría hacer 
        con un array de Persona o de Automotor.

    C. La Lógica de Control (El "Gatillo")
        -El foreach recorre el array. Como el tipo estático de la variable o es object,
        no tiene acceso a Imprimir() directamente.
        -El código usa el operador is (patrón de coincidencia) para hacer un desenfoque de tipo (downcasting seguro):
            if (o is Empleado e)
            {
                e.Imprimir(); // Llama a la versión de Empleado
            }
            else if (o is Moto m)
            {
                m.Imprimir(); // Llama a la versión de Moto
            }

        Funcionamiento:
        1. o is Empleado e: ¿Es o un Empleado?
        -Sí: Crea una nueva variable e de tipo Empleado y ejecuta el bloque.
        -No: Pasa al siguiente else if.
        2. o is Moto m: ¿Es o una Moto?
        -Sí: Crea una variable m de tipo Moto y ejecuta el bloque.

    D. La Salida Esperada
        Soy una moto Zanella
        Soy el empleado Juan
        Soy una moto Gilera

3. La Limitación Oculta
Este proyecto tiene un problema de diseño conocido como "Explosión de Switch":
    -Si en el futuro se quiere agregar un nuevo tipo (ej. Auto, Camion, Vendedor), se tiene que ir a este código,
    añadir otro else if y añadir lógica.
    -Violación del principio de Abierto/Cerrado: El código de Main no está "cerrado" a la modificación. 
    Cada vez que se agrega un tipo, se rompe o modifica la lógica existente.
    -Acoplamiento: Main conoce los detalles de implementación de Empleado y Moto.

¿Cómo se resolvería esto más adelante? 
-Si Empleado e Imprimible heredaran de una interfaz común (ej. IImprimible),
 el código de Main sería mucho más limpio:
    // Solución futura teórica
    foreach (IImprimible item in vector) { // Si el array fuera de IImprimible
        item.Imprimir(); // ¡Nada más! Sin ifs ni elseifs.
    }

4. Conclusión:
    Este proyecto demuestra cómo manipular objetos de tipos diferentes usando herencia simple y 
    verificación de tipo manual. 
    Es funcional, pero escala mal y hace el código más frágil.
*/
