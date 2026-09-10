﻿// Opción 2: Uso de var con variables intermedias

// Es muy comun usar LINQ con inferencia de tipos (con la palabra clave var) 
// para simplificar escritura y lectura del código.

// 1. Creamos la lista de strings inicial.
var lista = new List<string>() { "uno", "dos", "tres" };

// 2. Guardamos el primer paso de la transformación en una variable llamada 'secuencia1'.
//    El tipo inferido es IEnumerable<string>.
//    Esto nos permite reutilizar este paso si lo necesitamos después.
var secuencia1 = lista.Select(st => "(" + st.ToUpper() + ")");

// 3. Mostramos el resultado del primer paso: "(UNO) (DOS) (TRES)".
Mostrar(secuencia1);

// 4. Tomamos 'secuencia1' y calculamos las longitudes, guardándolo en 'secuencia2'.
//    El tipo inferido es IEnumerable<int>.
var secuencia2 = secuencia1.Select(st => st.Length);

// 5. Mostramos las longitudes: 5 5 5.
Mostrar(secuencia2);

// 6. Tomamos 'secuencia2' y dividimos entre 2.0, guardándolo en 'secuencia3'.
//    El tipo inferido es IEnumerable<double>.
var secuencia3 = secuencia2.Select(n => n / 2.0);

// 7. Mostramos el resultado final: 2.5 2.5 2.5.
Mostrar(secuencia3);

// 8. Definición del método genérico Mostrar (igual que en la Opción 1).
void Mostrar<T>(IEnumerable<T> secuencia)
{
    // 9. La ejecución real ocurre aquí dentro del bucle foreach.
    foreach (T elemento in secuencia)
    {
        Console.Write(elemento + " ");
    }
    Console.WriteLine();
}

/*NOTAS:
Esta es la forma más equilibrada. Usamos var para que el compilador infiera el tipo exacto, 
manteniendo la legibilidad de tener nombres para cada paso del proceso.

Ventajas:
  -Equilibrio perfecto: Es la práctica más común en la industria moderna de C#.
  -Inferencia de tipos: El compilador sabe el tipo exacto (ej. IEnumerable<string>), 
  pero no se necesita escribirlo. Si cambia la lógica, el tipo se actualiza solo.
  -Puntos de control: Permite guardar los pasos intermedios en variables con nombres descriptivos 
  (secuencia1, secuencia2), lo que facilita la depuración y la lectura sin la verbosidad de la Opción 1.
  -Flexibilidad: Se puede llamar a Mostrar(secuencia1) y luego usar secuencia2 después sin problemas.

Desventajas:
  -Pérdida de documentación explícita: Al usar var, el tipo no es visible a simple vista en la declaración. (
  Aunque en un IDE moderno, al pasar el mouse, se verás inmediatamente).
  -Ambigüedad (en casos raros): Si la lógica es muy compleja y el tipo no es obvio, var puede hacer 
  que sea más difícil entender qué está pasando sin usar el IntelliSense.
*/
