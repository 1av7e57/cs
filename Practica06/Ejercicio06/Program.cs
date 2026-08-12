/*Ofrecer una implementación polimórfica para mejorar el siguiente programa:

ElementoBase.Imprimir(new A(), new B(), new C(), new D());

class A
{
    public void ImprimirA() => Console.WriteLine("Soy una instancia A");
}
class B
{
    public void ImprimirB() => Console.WriteLine("Soy una instancia B");
}
class C
{
    public void ImprimirC() => Console.WriteLine("Soy una instancia C");
}
class D
{
    public void ImprimirD() => Console.WriteLine("Soy una instancia D");
}
static class ElementoBase
{
    public static void Imprimir(params object[] vector)
    {
        foreach (object o in vector)
        {
            if (o is A) { (o as A)?.ImprimirA(); }
            else if (o is B) { (o as B)?.ImprimirB(); }
            else if (o is C) { (o as C)?.ImprimirC(); }
            else if (o is D) { (o as D)?.ImprimirD(); }
        }
    }
}
*/

using System; // Importamos el namespace System necesario para funciones básicas

// CLASE BASE: ElementoBase
// Representa la entidad genérica que todos los elementos heredarán.
public class ElementoBase
{
    // PROPIEDAD con setter privado. 
    // Solo esta clase y sus derivadas pueden asignar un valor.
    public string Nombre { get; private set; } = "Instancia Base";

    // CONSTRUCTOR VACÍO
    // Permite que las clases hijas no pasen parámetros si no quieren.
    // O crear un constructor específico en una clase hija (pasando datos distintos)
    public ElementoBase() {}

    // CONSTRUCTOR CON PARÁMETRO
    // Para cuando sí queremos inicializar el nombre desde el principio.
    public ElementoBase(string nombre) => Nombre = nombre;

    // MÉTODO: Imprimir
    // Define el comportamiento predeterminado de impresión.
    // 'virtual' permite que las clases hijas (A, B, C, D) lo sobrescriban con 'override' si lo desean.
    public virtual void Imprimir()
    {
        // Imprime en consola usando interpolación de cadenas ($"...") para insertar el valor de 'Nombre'.
        Console.WriteLine($"Soy una {Nombre}");
    }
}

// CLASE: A
// Hereda de ElementoBase.
class A : ElementoBase
{
    // CONSTRUCTOR DE A:
    // Inicializa la propiedad 'Nombre' con el string "Instancia A" vía el constructor base.
    // (Opción1) usar el método base Imprimir pasando el parámetro própio (Nombre).
    public A() : base("Instancia A") { }
}

// CLASE: B
// Hereda de ElementoBase.
class B : ElementoBase
{
    // CONSTRUCTOR DE B:
    // Utiliza el constructor vacío de la clase base.
    public B() { }

    // (Opcion2) Sobrescribe el método base para imprimir un mensaje específico de B.
    // (No usa la propiedad 'Nombre', por eso el valor por defecto de la base es irrelevante).
    public override void Imprimir()
    {
        Console.WriteLine($"Soy una Instancia B");

    }
}

// CLASE: C
// Hereda de ElementoBase.
class C : ElementoBase
{
    // CONSTRUCTOR DE C:
    // Inicializa la propiedad 'Nombre' con el string "Instancia C" vía el constructor base.
    // (Opción1) usar el método base Imprimir pasando el parámetro própio (Nombre).
    public C() : base("Instancia C") { }
}

// CLASE: D
// Hereda de ElementoBase.
class D : ElementoBase
{
    // CONSTRUCTOR DE D:
    // Utiliza el constructor vacío de la clase base.
    public D() { }

    // (Opcion2) Sobrescribe el método base para imprimir un mensaje específico de D.
    // (No usa la propiedad 'Nombre', por eso el valor por defecto de la base es irrelevante).
    public override void Imprimir()
    {
        Console.WriteLine($"Soy una Instancia D");

    }
}

// CLASE DE SERVICIO: Imprimidor
// Encapsula la lógica de procesamiento de colecciones de ElementoBase.
// Es 'static' porque no necesita instanciarse; se usa directamente como utilidad.
public static class Imprimidor
{
    // MÉTODO ESTÁTICO: Iterar
    // 'params' permite pasar un array o una lista separada por comas de ElementoBase.
    public static void Iterar(params ElementoBase[] objetos)
    {
        // Bucle foreach: recorre cada objeto en el array pasado.
        foreach (var obj in objetos)
        {
            // LLAMADA POLIMÓRFICA:
            // Llama al método 'Imprimir()'.
            // El compilador decide en tiempo de ejecución (Runtime) qué implementación ejecutar:
            // - Si 'obj' es una instancia de A, B, C o D y no sobrescribieron el método,
            //   ejecuta el de ElementoBase.
            // - Si una clase lo sobrescribe con 'override', ejecutará la nueva versión.
            obj.Imprimir();
        }
    }
}

// Clase principal del programa
class Program
{
    // Método Main, punto de entrada del programa
    static void Main()
    {
        // LLAMADA AL SERVICIO:
        // Invoca al método estático 'Iterar' de la clase 'Imprimidor'.
        // Se pasan 4 instancias nuevas (A, B, C, D) como argumentos.
        // Gracias al parámetro 'params', no es necesario crear un array explícitamente.
        Imprimidor.Iterar(new A(), new B(), new C(), new D());

    }
}

/*Notas:
El objetivo del ejercicio es transformar un diseño rígido basado en verificaciones de tipo (is/as) 
en una arquitectura escalable basada en herencia y polimorfismo.

La versión original utilizaba un método estático Imprimir que aceptaba object[] 
y dependía de una serie de condiciones if/else para determinar el tipo de cada elemento y llamar a su método específico.

Problemas del enfoque inicial:
Problema	                Descripción	                                                            Consecuencia
Violación de SRP	        El método Imprimir conocía todos los tipos existentes (A, B, C, D).	    La clase centralizaba lógica que debería estar en cada objeto.
Violación de Open/Closed	Para agregar una clase E, era obligatorio modificar el método Imprimir.	Alto riesgo de introducir errores al editar código existente.
Casting Explícito	        Uso de is y as en cada iteración.	                                      Código verboso, lento (verificación de tipo en tiempo de ejecución) y propenso a errores si se olvida un tipo.
Pérdida de Tipado	        El array era de object.	                                                El compilador no podía validar métodos; los errores se detectaban solo en tiempo de ejecución.
Rigidez                     Cada clase tenía su propio método (ImprimirA, ImprimirB).	            No existía una interfaz común; difícil de gestionar en colecciones.

Enfoque Orientado a Objetos (Polimórfico):
La versión actual define una clase base concreta ElementoBase con un método virtual, un constructor flexible (vacío y con parámetro) 
y propiedades compartidas con control de acceso granular. Las clases A, B, C, D heredan de ella. 
El servicio Imprimidor solo conoce la base, no las implementaciones específicas.

Mejoras que ofrece este enfoque:

A. Arquitectura y Diseño
    ElementoBase: Gestiona el ciclo de vida del objeto (inicialización segura) y su comportamiento base.
    Imprimidor: Solo gestiona la iteración de colecciones.
    Resultado: Cambios en la lógica de "cómo imprimir" o "cómo instanciar" no afectan la lógica de "cómo iterar".

    Principio Open/Closed (OCP):
    Abierto para extensión: Puede crearse class E : ElementoBase sin tocar una sola línea de código existente, incluso si E decide no pasar parámetros al constructor base.
    Cerrado para modificación: El método Imprimidor.Iterar nunca necesita cambiar, independientemente de cuántos tipos nuevos existan.

    Flexibilidad de Inicialización Segura:
    Se introdujo un constructor vacío y un constructor con parámetro en la base.
    Beneficio: Permite que las clases hijas elijan la estrategia de inicialización:
    Si necesitan un nombre específico (como A y C), usan : base("Nombre").
    Si el nombre es irrelevante (como B y D), usan el constructor vacío, evitando código "basura" o valores innecesarios.

    Control de Acceso Granular: La propiedad Nombre es { get; private set; }.
    Esto permite que la clase base (y sus heredados) asignen el valor en cualquier momento (no solo en el constructor).

    Tipado Estático Seguro:
    Se eliminó object[]. Ahora se usa ElementoBase[].
    Beneficio: El compilador garantiza que solo objetos válidos (heredados de la base) pueden pasar. 
    Si se intentara pasar algo no relacionado, el código no compila, previniendo errores en producción.

B. Rendimiento y Mantenibilidad
    Eliminación de Verificaciones de Tipo:
    Se eliminó el bloque if (o is X) ... else if ....
    Beneficio: El bucle es más limpio y la ejecución es más rápida (la máquina virtual C# resuelve el método directamente
    mediante la tabla de métodos virtuales, sin verificar tipos en cada paso).

    Inmutabilidad de Datos:
    Propiedad Nombre definida como { get; private set; } con valor por defecto.
    Seguridad: Previene que el estado de un objeto sea corrompido accidentalmente desde fuera de la clase.
    Robustez: El valor por defecto asegura que, incluso si se usa el constructor vacío, el objeto tenga un estado válido inmediatamente, evitando NullReferenceException.
    Flexibilidad Interna: Permite a la clase base o heredadas ajustar el valor si es necesario (ej. en lógica de inicialización compleja), sin perder la protección externa.

    Polimorfismo Real:
    Uso de virtual en la base y override (opcional) en las hijas.
    Beneficio: Permite que objetos de distintos tipos se comporten de manera diferente ante el mismo mensaje (obj.Imprimir()), 
    sin necesidad de saber su tipo exacto, y permitiendo que algunas implementaciones ignoren completamente el estado de la propiedad base si así lo desean.
*/
