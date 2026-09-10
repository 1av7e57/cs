﻿// --- CASO 1: Intercambio de enteros (int) ---

// Declaramos dos variables de tipo 'object' para actuar como contenedores genéricos
object o1, o2;

// Inicializamos las variables originales de tipo 'int'
int a = 17; 
int b = 23;

// Asignamos los valores de 'a' y 'b' a 'o1' y 'o2' respectivamente.
// Aquí ocurre un proceso de 'Boxing': el valor int se envuelve en un objeto.
o1 = a; 
o2 = b;

// Llamamos al método Swap genérico usando las variables 'object'.
// El método no sabe que son enteros, solo ve objetos.
Swap(ref o1, ref o2);

// Recuperamos los valores originales realizando 'Unboxing' explícito.
// Es obligatorio especificar el tipo de destino al convertir de object a int.
a = (int)o1; 
b = (int)o2;

// Imprimimos el resultado del intercambio de enteros
Console.WriteLine($"a={a} y b={b}");

// --- CASO 2: Intercambio de cadenas (string) ---

// Declaramos los dos strings originales
string s1 = "hola"; 
string s2 = "mundo";

// Asignamos los valores a las variables 'object' compartidas antes (se sobreescriben las anteriores).
// Para string, esto es un 'boxing' de referencia (no copia los datos, pero sí referencia al objeto).
o1 = s1; 
o2 = s2;

// Llamamos al mismo método Swap.
Swap(ref o1, ref o2);

// Recuperamos los valores realizando 'unboxing' explícito a string.
s1 = (string)o1; 
s2 = (string)o2;

// Imprimimos el resultado del intercambio de strings
Console.WriteLine($"s1 = {s1} y s2 = {s2}");

// Definición del método Swap genérico basado en 'object'
// Acepta dos referencias a objetos de cualquier tipo
void Swap(ref object i, ref object j)
{
    // Variable temporal de tipo object para guardar el valor de 'i'
    object auxiliar = i;

    // Intercambio de referencias/valores
    i = j;
    j = auxiliar;
}

/*NOTAS:
Análisis de Ventajas y Limitaciones
Este enfoque utiliza la clase base object para lograr flexibilidad, 
pero introduce problemas de rendimiento y seguridad importantes.

Ventajas (sobre el primer ejemplo):
    1.Reutilización de Código: Ya no se necesita escribir 
    una función Swap diferente para cada tipo (int, string, double, etc.). 
    Una sola función (Swap(ref object, ref object)) sirve para todos.

    2.Reducción de Código: Evita la duplicación de la lógica de intercambio.

Limitaciones:
    1.Costo de Rendimiento (Boxing/Unboxing):
        -Cuando se convierte un tipo de valor (int) a object, el runtime crea una copia en el montón de memoria (Heap) 
        y la envuelve en un objeto. (Esto es propiamente lo que llamamos 'Boxing').

        -Al recuperar el valor ((int)o1), se hace 'Unboxing', lo que implica una verificación de tipo 
        y otra operación de memoria.

        -Impacto: En bucles grandes o en código de alto rendimiento, esto es significativamente 
        más lento que trabajar con el tipo original.

    2.Falta de Seguridad de Tipos (Type Safety):
        -El compilador no sabe qué tipo específico se está manejando dentro del método. Solo ve object.

        -Riesgo: Si se intenta hacer un unboxing incorrecto (ej. convertir un int a string), el programa 
        compilará, pero explotará en tiempo de ejecución con un error InvalidCastException. El compilador 
        no puede proteger contra casos de esta naturaleza.

    3.Código Verboso y Propenso a Errores:
        -El código de "cliente" (donde se llama al método) es más sucio. Se tiene que declarar variables object, 
        hacer asignaciones y luego hacer casts explícitos en cada paso para recuperar los valores originales.

    4.Pérdida de Información de Tipo:
        -Dentro del método Swap, no dr puede ejecutar métodos específicos del tipo original. Por ejemplo, 
        si se pasan dos int, no se podría usar .ToString() o .CompareTo() dentro del método sin hacer casts primero,
        lo cual rompe la elegancia.

Conclusión:
    Este enfoque es un "parche" que resuelve el problema de la duplicación de código a costa del rendimiento 
    y la seguridad. Es una solución funcional para prototipos rápidos, pero no es la solución ideal 
    en C# moderno para tipos de valor.
*/
