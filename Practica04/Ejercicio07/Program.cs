/*Prestar atención a los siguientes programas (ninguno funciona correctamente):*/

//Programa 1: Campo de Clase (Error en Tiempo de Ejecución)

/*
// Instancia la clase Foo. 
// Al crearse 'f', el CLR (Common Language Runtime) asigna memoria para todos sus campos.
Foo f = new Foo();

// Llama al método Imprimir.
f.Imprimir();

class Foo
{
    // Campo de instancia.
    // Como es un tipo referencia (nullable string) y no se le asigna valor,
    // C# lo inicializa AUTOMÁTICAMENTE con 'null'.
    // Este es el comportamiento por defecto de los campos.
    string? _bar; 

    public void Imprimir()
    {
        // Intentamos acceder a la propiedad 'Length'.
        // Como _bar es 'null' (fue inicializado así automáticamente),
        // esto lanza una excepción: System.NullReferenceException.
        // El programa compila correctamente, pero falla al ejecutarse.
        Console.WriteLine(_bar.Length); 
    }
}
*/

// Programa 2: Variable Local (Error en Tiempo de Compilación)

/*
// Instancia la clase Foo.
Foo f = new Foo();

// Llama al método Imprimir.
f.Imprimir();

class Foo
{
    public void Imprimir()
    {
        // Variable local.
        // A diferencia de los campos, las variables locales NO se inicializan automáticamente.
        // El compilador no asigna 'null' ni '0' aquí. La variable está "sin definir".
        string? _bar; 

        // Intentamos acceder a la propiedad 'Length'.
        // El compilador detecta que estás leyendo '_bar' antes de asignarle un valor.
        // Esto genera un ERROR DE COMPILACIÓN: 
        // "The local variable '_bar' may not be used before it is assigned a value".
        // El programa NUNCA llega a ejecutarse.
        Console.WriteLine(_bar.Length); 
    }
}
/*

// a)¿Qué se puede decir acerca de la inicialización de los objetos? 
// b)¿En qué casos son inicializados automáticamente y con qué valor?

/*Respuestas:

a) ¿Qué se puede decir acerca de la inicialización de los objetos en base a estos ejemplos?
En C#, la inicialización automática depende estrictamente del ámbito de la variable:

- En el Programa 1: La variable _bar es un campo de la clase Foo. 
Los campos de clase (y de estructura) siempre reciben un valor por defecto
si no se les asigna uno explícitamente. Como _bar es de tipo string? (un tipo referencia nullable), 
su valor por defecto es null.

El error: El programa compila, pero al ejecutar Console.WriteLine(_bar.Length), como _bar es null, 
el programa se romperá en tiempo de ejecución (NullReferenceException o System.NullReferenceException) 
porque no puedes acceder a la propiedad .Length de algo que no existe.

- En el Programa 2: La variable _bar es una variable local dentro del método Imprimir. 
Las variables locales no tienen inicialización automática.

El error: El compilador de C# es muy estricto. Detecta que estás intentando usar _bar (leer .Length) 
sin haberle asignado un valor primero. Esto genera un error de compilación inmediato 
(The local variable '_bar' may not be used before it is assigned a value). 
El programa nunca llegará a ejecutarse.

b) ¿En qué casos son inicializados automáticamente y por qué? ¿Con qué valor?
La regla general en C# es la siguiente:

- Se inicializan automáticamente (Con valor por defecto):
Campos de clases/estructuras: string? _bar; dentro de la clase.
Elementos de arreglos: int[] arr = new int; (todos los ints serán 0).

Por qué: 
Para garantizar que la memoria asignada a estos objetos no contenga "basura" 
o datos aleatorios del sistema. El Common Language Runtime (CLR) se asegura 
de limpiar esa memoria al crear la instancia.

Valor por defecto: 
Depende del tipo:
Tipos numéricos (int, double, etc.): 0 o 0.0.
Tipos referencia (string, clases): null.
bool: false.
string?: null.

- NO se inicializan automáticamente (Debe asignarseles valor):
Variables locales: string? _bar; dentro de un método.
Parámetros de método: (Aunque estos son valores pasados por el llamador).

Por qué: 
Por seguridad y rendimiento. El compilador no puede asumir qué valor necesitas
en una variable local antes de que tú decidas asignarlo. Si permitiera un valor 
por defecto oculto (como 0 o null) en todos los casos, podrían cometerse errores 
lógicos sutiles usando datos "por defecto" pensando que son datos reales.

No tienen valor por defecto: 
Si se intenta usarlas/leerlas antes de asignarles algo, el compilador lanzará un error.
*/

//Posibles soluciónes en cada caso:

/*Programa 1: Solución (Campo de Clase)
Para arreglar este programa, necesitamos asignar un valor a _bar antes de usarlo. 
Como es un campo, podemos hacerlo en el constructor de la clase.*/

/*
Foo f = new Foo();
f.Imprimir(); // Ahora imprimirá el valor de "Hola".

class Foo
{
    // Campo de instancia.
    string? _bar;

    // Constructor: Se ejecuta automáticamente al crear 'new Foo()'.
    // Aquí asignamos un valor explícito a _bar.
    public Foo()
    {
        _bar = "Hola"; 
        // Ahora _bar no es null, es "Hola".
    }

    public void Imprimir()
    {
        // Como _bar ya tiene un valor ("Hola"), .Length funciona correctamente.
        // El resultado será 4.
        Console.WriteLine(_bar!.Length); 
    }
}
*/

/*Programa 2: Solución (Variable Local)
Para arreglar este programa, debemos asignar un valor a la variable local _bar dentro del mismo método,
antes de cualquier instrucción que la use.*/

/*
Foo f = new Foo();
f.Imprimir(); // Ahora imprimirá el valor de "Mundo".

class Foo
{
    public void Imprimir()
    {
        // Variable local.
        string? _bar;

        // Asignación EXPLÍCITA y OBLIGATORIA antes de usarla.
        // Sin esta línea, el compilador daría error.
        _bar = "Mundo"; 

        // Ahora que _bar tiene un valor, podemos acceder a su longitud.
        // El resultado será 5.
        Console.WriteLine(_bar.Length); 
    }
}
*/
