using System; // Necesario para 'double'
using EjRombo;

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        Rombo r1 = new Rombo();
        Figura r2 = new Rombo();
        IAgrandable r3 = new Rombo();
        IImprimible r4 = new Rombo();

        r3.TamañoMaximo = 100;
        r3.Agrandar(1.2);
        r4.Imprimir();
        (r3 as IImprimible)?.Imprimir();

        // Ambas opciones son igual de válidas
        object o = new Rombo(); // 'o' es imprimible;

        // En versiones anteriores al C#7.0
        if (o is IImprimible)
        {
            (o as IImprimible)?.Imprimir();
        }

        // En la version c#7.0 se agrega una facilidad
        if (o is IImprimible imp)
        {
            imp.Imprimir();
        }

        // Esto no está permitido, porque estamos queriendo instanciar un objeto
        // IImprimible imp = new IImprimible(); 

        // En cambio lo siguiente si es válido
        IImprimible[] vector = new IImprimible[10];
        // Acá no instanciamos ningún 
        // objeto IImprimible. 
        // Los elementos que agreguemos al 
        // vector (inicialmente todos null) 
        // tendrán que implementar la 
        // interface IImprimible.

    }
}

/*NOTAS:
1.¿Qué hace este proyecto?
El objetivo del código es demostrar que una sola clase (Rombo) puede cumplir múltiples roles simultáneamente:
-Ser un objeto concreto (Rombo).
-Ser vista como su clase base (Figura).
-Ser vista como un objeto "agrandable" (IAgrandable).
-Ser vista como un objeto "imprimible" (IImprimible).

El programa crea una sola instancia real (new Rombo()), pero la asigna a variables de diferentes tipos
para probar cómo se comporta el acceso a sus métodos dependiendo de la "etiqueta" (tipo de variable) que se use.
Además, demuestra casting seguro y patrones de tipo (is) para interactuar con objetos de tipo object
o variables de interfaz.

2.¿Cómo lo hace? (Análisis Paso a Paso)

A. La Jerarquía y el Contrato
    Figura: Es una clase que sirve para establecer una relación de "es un" (un Rombo es una Figura).
    IAgrandable e IImprimible: Son interfaces que definen capacidades.
        IAgrandable: Exige que quien la implemente tenga una propiedad TamañoMaximo y un método Agrandar.
        IImprimible: Exige un método Imprimir.
    Rombo: Es la clase que une todo.
        class Rombo : Figura, IImprimible, IAgrandable
    Al heredar de Figura e implementar ambas interfaces, Rombo obliga a tener el código real para Imprimir() y Agrandar(), además de la propiedad TamañoMaximo.

B. El Polimorfismo en Main
    La parte más interesante está en cómo se crea y usa el objeto r1, r2, r3, r4:
        Rombo r1 = new Rombo();   // Tipo concreto: Acceso a TODO (público)
        Figura r2 = new Rombo();  // Tipo base: Solo ve lo que 'Figura' tiene
        IAgrandable r3 = new Rombo(); // Tipo interfaz: Solo ve 'Agrandar' y 'TamañoMaximo'
        IImprimible r4 = new Rombo(); // Tipo interfaz: Solo ve 'Imprimir'

    - Por qué funciona: En C#, una variable de tipo IAgrandable puede apuntar 
    a cualquier objeto que implemente esa interfaz. Aunque el objeto en memoria es un Rombo, 
    la variable r3 solo "ve" la cara de IAgrandable.

    - Límite de acceso: Si se intenta r3.Imprimir() (llamando a la interfaz que no tiene ese método), 
    el compilador dará error. Esto es intencional: las interfaces 
    ocultan detalles que no son relevantes para ese contexto específico.

C. Casting y Verificación de Tipo (Partes Avanzadas)
    El código muestra cómo manejar objetos que podrían ser de cualquier tipo (como object o):
        object o = new Rombo();
    Como o es de tipo object, no tiene acceso a ningún método de Rombo o las interfaces directamente. 
    Se necesita "convertirlo" (cast) primero.

    Enfoque Legacy (Antes de C# 7.0):
        if (o is IImprimible) {
            (o as IImprimible)?.Imprimir();
        }
    -Primero verifica con is si es de ese tipo.
    -Luego usa as para convertirlo. Si falla, devuelve null.
    -El ?. (operador de propagación nula) evita errores si la conversión falló.

    Enfoque Moderno (C# 7.0+):
        if (o is IImprimible imp) {
            imp.Imprimir();
        }
    Esta es la forma más limpia. Declara la variable imp solo si la conversión es exitosa. 
    Si o no es imprimible, el if es falso y no se entra.

D. Arrays de Interfaces
        IImprimible[] vector = new IImprimible[10];
    -Aquí se crea un array que solo acepta objetos que implementen IImprimible.
    -Se podría guardar ahí un Rombo, pero también una clase Circulo o Triangulo (si existieran y tuvieran Imprimir()).
    -Esto demuestra la flexibilidad: el array no se preocupa por qué clase es, solo por qué puede hacer (imprimirse).

3. Conclusión: 
    Puntos Clave:
        -Una clase, múltiples caras: Rombo es la implementación concreta,
        pero se comporta de forma diferente según desde qué "lente" (tipo de variable) se lo mire.
        -Seguridad del compilador: Si se intenta acceder a algo que la variable no "conoce" (ej. r3.Imprimir()),
        C# lo detiene antes de ejecutar.
        -Interfaces como filtros: Las interfaces no solo agregan funcionalidad, 
        sino que ocultan la complejidad interna de la clase, exponiendo solo lo necesario.
*/
