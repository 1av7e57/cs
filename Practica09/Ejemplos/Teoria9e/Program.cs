﻿// Crea una nueva instancia de la clase 'Par' llamada 'p', inicializándola con los valores 1 y 15.
Par p = new Par(1, 15);

// Imprime en consola el valor de la propiedad A y la propiedad B usando interpolación de cadenas.
Console.WriteLine($"A = {p.A} y B = {p.B}");

// Imprime en consola la suma de las propiedades A y B.
Console.WriteLine($"A + B = {p.A + p.B} ");

/*NOTAS:
¿Qué hace este programa?
El programa define una estructura de datos personalizada llamada Par diseñada específicamente 
para almacenar dos números enteros.
    -Instancia un objeto p con los valores 1 y 15.
    -Muestra los valores individuales.
    -Calcula y muestra la suma de ambos.
El resultado en consola será:
A = 1 y B = 15
A + B = 16

Análisis: Ventajas y Desventajas
    Este enfoque utiliza una clase concreta (no genérica).

Ventajas:
    -Simplicidad y Claridad: Es muy fácil de leer y entender para alguien que solo necesita manejar pares de enteros.
    No hay conceptos complejos de genéricos involucrados.
    -Seguridad de Tipos Estricta: El compilador sabe exactamente que A y B son int. No hay riesgo de error 
    de tipo en este contexto específico.
    -Rendimiento (en casos muy específicos): Al no usar genéricos, no hay una ligera sobrecarga de boxing 
    (aunque con int y genéricos en .NET moderno la diferencia es casi nula, pero conceptualmente es directo).

Desventajas:
    -Falta de Reutilización (Acoplamiento): Esta clase solo sirve para int. 
    Si luego se necesitara un par de float, string o un objeto personalizado Cliente, 
    se tendría que crear otra clase llamada ParDoble, ParTexto, etc. 
    Esto viola el principio DRY (Don't Repeat Yourself).
    -Duplicación de Código: La lógica de la clase (constructor, propiedades, acceso) 
    se repetiría idéntica para cada nuevo tipo de dato que se quiera emparejar.
    -Mantenimiento Difícil: Si se quiere cambiar la lógica interna (por ejemplo, 
    añadir un método Sumar o cambiar el nombre de las propiedades), se tendría que 
    editar múltiples clases en lugar de una sola genérica.

Conclusión: 
    Este código es funcional pero poco escalable. 
    Es el escenario perfecto para introducir Clases Genéricas, donde se podría definir 
    Par<T> y reutilizar la misma lógica para cualquier tipo de dato 
    (Par<int>, Par<string>, etc.) sin reescribir código.
*/
