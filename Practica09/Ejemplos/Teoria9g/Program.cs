﻿// 1. Instancia de un delegado 'Funcion<int, string>'.
// Significa: Recibe un 'int' y devuelve un 'string'.
// Se asigna una expresión lambda: n => $"n = {n}".
// 'n' es el parámetro de tipo int, y la expresión retorna una cadena formateada.
Funcion<int, string> lambda1 = n => $"n = {n}";

// 2. Instancia de un delegado 'Funcion<string, int>'.
// Significa: Recibe un 'string' y devuelve un 'int'.
// Se asigna una expresión lambda: st => st.Length.
// Toma un string 'st' y retorna su longitud (int).
Funcion<string, int> lambda2 = st => st.Length;

// 3. Instancia de un delegado 'Funcion<int[], double>'.
// Significa: Recibe un array de enteros (int[]) y devuelve un double.
// Se asigna un método existente llamado 'Promedio' (inferencia de método).
// El compilador verifica que 'Promedio' coincida con la firma: (int[]) -> double.
Funcion<int[], double> f = Promedio;

// Llama a lambda1 pasando el entero 12.
// Ejecuta: 12 -> "n = 12"
// Resultado: imprime la cadena "n = 12"
Console.WriteLine(lambda1(12));

// Llama a lambda2 pasando el string "Hola Mundo!".
// Ejecuta: "Hola Mundo!" -> 11 (longitud del string)
// Resultado: devuelve el entero: 11
Console.WriteLine(lambda2("Hola Mundo!"));

// Llama al delegado 'f' (que apunta a Promedio) pasando un array de enteros.
// Ejecuta: {1,2,3,4,5} -> 3.0 (promedio de los números)
// Resultado: devuelve: 3 (entero truncado)
Console.WriteLine(f(new int[]{1, 2, 3, 4, 5}));

// Definición del método 'Promedio'.
// Recibe un array de enteros (int[] vector).
double Promedio(int[] vector)
{
    // Variable acumuladora para la suma.
    int suma = 0;
    
    // Recorre cada elemento del array y lo suma a 'suma'.
    foreach (int i in vector) 
        suma += i;
    
    // Calcula el promedio dividiendo la suma por la longitud.
    // Nota: En C# entero/entero = entero. Para precisión decimal, 
    // Se debería hacer (double)suma / vector.Length.
    // En este ejemplo, 15/5 = 3.0, pero con otros números podría truncar.
    return suma / vector.Length; 
}

/*NOTAS:
¿Qué hace este programa?
El programa demuestra la flexibilidad de los delegados genéricos para 
encapsular lógica de transformación de datos:
  -Conversión Int -> String: Convierte un número en una cadena descriptiva usando una lambda.
  -Conversión String -> Int: Extrae una propiedad (longitud) de un texto usando una lambda.
  -Conversión Array -> Double: Invoca un método tradicional (Promedio) a través de un delegado genérico.

Aclaración para Promedio(): 
El resultado de 3 es un entero truncado porque 'suma' y 'vector.Length' son enteros. 
Si el promedio fuera 3.5, imprimiría 3. Si se quisiera obtener decimales, 
el método Promedio debería castear a double.

Análisis:
Ventajas:
  -Tipado Seguro y Genérico: A diferencia de usar object y hacer casting manual, los genéricos (<T1, T2>) 
  garantizan en tiempo de compilación que el método asignado tenga la firma correcta. Si se intenta pasar 
  un string a lambda1, el compilador dará error.
  -Abstracción de la Implementación: La variable f no sabe ni le importa si está llamando a una lambda, 
  a un método estático o a un método de instancia. Solo sabe que recibe int[] y devuelve double. 
  Esto permite pasar lógica como parámetros (útil en callbacks, eventos, LINQ, etc.).
  -Reutilización de Código: No se necesita crear una clase nueva para cada transformación pequeña. 
  Las lambdas permiten definir la lógica "al vuelo" donde se necesita.
  -Sintaxis Concisa: Las expresiones lambda (n => ...) hacen que el código sea muy legible 
  para transformaciones simples.

Consideraciones:
  -Depuración (Debugging): Los errores en expresiones lambda anidadas o en la inferencia de tipos pueden ser 
  un poco más difíciles de rastrear que en métodos nombrados tradicionales.
  -Truncamiento de Tipos (Ejemplo específico): En el método Promedio, el uso de int para la división 
  genera un resultado entero. En un escenario real, se debería usar 'double suma' 
  o castear: 'return (double)suma / vector.Length;' para evitar pérdida de precisión.

  -Verbosidad vs. Func<> de .NET: En este ejemplo se define un delegado personalizado 'Funcion' para fines demostrativos. 
  En la práctica, C# ya trae delegados genéricos estándar como Func<T1, T2>, Action<T>, y Predicate<T>. Reescribirlos es innecesario .
  Si usáramos el estándar, el código sería:
    // En lugar de definir 'delegate T2 Funcion...'
    // Usamos 'Func<T1, T2>' que ya existe en System
    Func<int, string> lambda1 = n => $"n = {n}";
    Func<string, int> lambda2 = st => st.Length;
    Func<int[], double> f = Promedio;
  Esto reduce el código "boilerplate" (necesario para dar infraestructura funcional al programa pero que no aporta lógica de negocio ni valor específico al problema que se está resolviendo)
  y mejora la legibilidad al ser un estándar conocido por todos los desarrolladores C#.
*/
