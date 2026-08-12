﻿/*Identificar todos los miembros en la siguiente declaración de clase. Indicar si se trata de un
constructor, método, campo, propiedad o indizador, si es estático o de instancia, y en caso que
corresponda si es de sólo lectura, sólo escritura o lectura y escritura. En el caso de las propiedades
indicar también si se trata de una propiedad auto-implementada.
Nota: La clase compila perfectamente. Sólo prestar atención a la sintaxis, la semántica es irrelevante.*/
class A
{
    // Campo: estático privado, lectura y escritura
    private static int a;

    // Campo: estático privado, solo lectura (readonly)
    private static readonly int b;

    // Constructor: de instancia  
    // Visibilidad por defecto: interno (internal). El miembro es visible y accesible solo dentro del mismo proyecto (ensamblado)
    // NOTA: En C#, si la clase no tiene modificador, es 'internal'. El constructor sin modificador también será 'internal'.
    A() { }

    // Constructor: instancia pública (por el modificador 'public'), recibe un parámetro.
    // Usa 'this()' para llamar al constructor por defecto.
    public A(int i) : this() { }

    // Constructor estático: se ejecuta una sola vez antes de crear instancias o acceder a miembros estáticos.
    // Los constructores estáticos no pueden tener modificadores de acceso (como public o internal)
    // Solo puede acceder a miembros estáticos (como 'b'). 
    static A() => b = 2;

    // Campo: instancia internal, lectura y escritura.
    // Al no tener private, es internal por defecto)
    int c;

    // Método: estático público. No devuelve valor (void). Modifica el campo estático 'a'.
    public static void A1() => a = 1;

    // Método: instancia pública. Recibe un parámetro 'a'. Devuelve int.
    // Accede al campo estático 'a' mediante el nombre de la clase 'A'.
    public int A1(int a) => A.a + a;

    // Campo: estático público, lectura y escritura.
    public static int A2;

    // Propiedad: como la clase es internal por defecto, esta propiedad también es internal.
    // Solo lectura (implícita por no tener setter y usar Expresión de Cuerpo de Miembro (Expression-bodied Member).
    // El operador => en una propiedad es una forma ABREVIADA de escribir un accesor get.
    // static int A3 => 3; es exactamente equivalente a escribir: static int A3 { get => 3; }
    // Es una propiedad con implementación explícita (no auto-implementada).
    static int A3 => 3;

    // Método: instancia privada, devuelve int.
    private int A4() => 4;

    // Propiedad: instancia pública, solo lectura (solo get).
    // Es una propiedad con implementación explícita (no auto-implementada).
    public int A5 { get => 5; }

    // Propiedad: instancia internal (por defecto), solo escritura (solo set).
    // Es una propiedad con implementación explícita.
    int A6 { set => c = value; }

    // Propiedad: instancia pública, lectura y escritura.
    // Es una propiedad auto-implementada (auto-implemented property).
    public int A7 { get; set; }

    // Propiedad: instancia pública, solo lectura (solo get).
    // Tiene inicializador. Es una propiedad auto-implementada de solo lectura.
    public int A8 { get; } = 8;

    // Indizador: instancia pública, solo lectura (al usar => en un indexador sin un set explícito, se convierte en un indexador de solo lectura.).
    // Recibe un parámetro 'int i' y devuelve 'i'.
    public int this[int i] => i;
}

/*Nota: aclaraciones importantes:

- Visibilidad por defecto: En C#, si una clase o miembro no tiene un modificador de acceso explícito 
(public, private, protected, internal), su visibilidad predeterminada es internal 
(accesible dentro del mismo ensamblado). 
En el código original:
A(), static A(), int c, A6, A3 (y su modificador static) son internal por defecto.

- Constructores:
A() y A(int i) son constructores de instancia.
static A() es un constructor estático. Solo puede inicializar miembros estáticos.

- Propiedades Auto-implementadas:
A7: { get; set; } es la forma clásica auto-implementada.
A8: { get; } = 8; es una propiedad auto-implementada de solo lectura con inicializador.
A5, A6, A3 no son auto-implementadas porque tienen cuerpos (get => ... o set => ...) definidos manualmente.

- Indizador: this[int i] es un indizador. 
Permite acceder a instancias de la clase como si fueran un array (ej: obj).

- La sintaxis de '=>'
En C#, la sintaxis de expresión bodied Member para propiedades (Propiedad => valor) 
es un atajo exclusivamente para el accesor get.
public int A { get => 5; } → Funciona (equivale a get { return 5; }).
public int A => 5; → Funciona (equivale a get { return 5; }).
El compilador siempre interpreta la expresión a la derecha de => como el valor de retorno del get.

- ¿Cómo se escribe entonces un set?
Si se necesita un set, siempre debe usarse la sintaxis con llaves {}. 
Incluso si la lógica es tan simple como asignar a un campo, debe escribirse explícitamente:

    // Incorrecto (Esto no compila):
    // public int X => campo; // El compilador cree que esto es un get que devuelve campo

    // Correcto (Sintaxis obligatoria para set):
    public int X { set => campo = valor; }

- Ejemplos comparativos:

a) Solo lectura (SÍ usa bodied Member directa, SIN llaves):
    // Equivalente a: get { return 5; }
    public int SoloGet => 5; 

b) Solo escritura (NO usa bodied Member directa, REQUIERE llaves):
    // Equivalente a: set { campo = valor; }
    public int SoloSet { set => campo = valor; } 
    // Nota: Aunque se usa '=>' dentro de las llaves del set, 
    // la propiedad en sí requiere las llaves {} para definir el accesor 'set'.

c) Lectura y escritura (Mezcla, usando llaves):
    public int GetSet {
    get => campo;         // Sí permite usar bodied Member en el get
    set => campo = valor; // Sí permite usar bodied Member en el set (dentro de las llaves)
    }
*/
