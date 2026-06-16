/*¿Qué salida por la consola produce el siguiente código?
¿Qué se puede inferir respecto de la excepción división por cero en relación al tipo de los operandos? */

int x = 0; // Se declara un int 'x' y se inicializa en 0

try
{
    // 1. División de punto flotante (double / int):
    // El operando 1.0 es de tipo double. Al dividir por cero, C# no lanza excepción.
    // Sigue el estándar IEEE 754 y devuelve "Infinity".
    Console.WriteLine(1.0 / x);  // Salida: Infinity

    // 2. División de enteros (int / int):
    // Ambos operandos son enteros. La división por cero en enteros NO es permitida.
    // Esto lanza una excepción System.DivideByZeroException.
    Console.WriteLine(1 / x);    // ¡Lanza excepción aquí!

    // Esta línea nunca se ejecuta porque el programa salta al bloque catch
    // en cuanto ocurre la excepción en la línea anterior.
    Console.WriteLine("todo OK");
}
catch (Exception e) 
{
    // Captura la excepción lanzada en la división entera.
    // Imprime el mensaje de error: "Attempted to divide by zero."
    Console.WriteLine(e.Message);
}

/* Respuestas:
Salida por consola:

∞
Attempted to divide by zero.

Inferencia sobre la excepción de división por cero:
El comportamiento de la división por cero en C# depende del tipo de dato de los operandos:
- Operaciones enteras (int, long, etc.): Cuando se divide un número entero por cero 
(ej. 1 / x), el runtime de C# lanza una excepción System.DivideByZeroException.
- Operaciones de punto flotante (double, float): Cuando se divide un número de punto flotante por cero 
(ej. 1.0 / x donde x es int pero se promueve a double), el resultado no lanza una excepción. 
En su lugar, el resultado es Infinity (o -Infinity / NaN), siguiendo el estándar IEEE 754.

¿Por qué ocurre esto?
A diferencia de los números enteros, que tienen un rango finito y lanzan una excepción 
si intentas dividir por cero, los números de punto flotante están diseñados para manejar
casos especiales matemáticos sin interrumpir la ejecución del programa. 

Según este estándar:
- División de un número positivo por cero: El resultado es Infinity (Infinito positivo).
- División de un número negativo por cero: El resultado es -Infinity (Infinito negativo).
- División de cero por cero (0.0 / 0.0): El resultado es NaN (Not a Number), ya que matemáticamente es indefinido.
*/
