﻿// Opción 3: Encadenamiento fluido (Fluent API)

// si nos interesara mostrar sólamente la secuencia 3, podemos hacerlo de la siguiente manera, 
// utilizando la interfaz fluida (fluent API)

var lista = new List<string>() { "uno", "dos", "tres" };

// 2. Encadenamos tres operaciones de transformación en una sola expresión.
//    - Primero convertimos a mayúsculas y añadimos paréntesis.
//    - Luego calculamos la longitud de cada string resultante.
//    - Finalmente dividimos la longitud entre 2.0.
//    El compilador infiere que el tipo de 'secuencia3' es IEnumerable<double>.
//    Importante: Nada se ejecuta hasta que llamamos a Mostrar().
var secuencia3 = lista
    .Select(st => "(" + st.ToUpper() + ")")
    .Select(st => st.Length)
    .Select(n => n / 2.0);

// 3. Ejecutamos la consulta completa y mostramos el resultado final: 2.5 2.5 2.5.
Mostrar(secuencia3);

// 4. Definición del método genérico Mostrar (igual que en la Opción 1).
void Mostrar<T>(IEnumerable<T> secuencia)
{
    // 5. La iteración aquí fuerza la ejecución de toda la cadena de Select anteriores.
    foreach (T elemento in secuencia)
    {
        Console.Write(elemento + " ");
    }
    Console.WriteLine();
}

/*NOTAS:

Aquí eliminamos las variables intermedias y encadenamos las operaciones directamente. 
Esto es ideal si solo necesitamos el resultado final y no nos interesa inspeccionar los pasos intermedios.

Ventajas:
  -Concisión: Si solo nos interesa el resultado final (la secuencia3), este es el camino más corto. 
  Elimina el "ruido" de las variables intermedias.
  -Flujo lógico (pipeline): "Toma la lista, conviértela, luego mide la longitud, luego divide por 2". 
  Es muy expresivo para transformaciones puras.
  -Menos variables: Reduce el desorden en el ámbito local si no se necesitan los pasos intermedios.

Desventajas:
  -Difícil depuración paso a paso: Si algo falla en el segundo .Select(), no se tiene 
  una variable intermedia para inspeccionar qué salió mal antes de llegar al final. 
  Se tiene que dividir la línea para depurar.
  -Lectura compleja: Si la cadena de operaciones es muy larga (demasiados .Select), 
  la línea se puede volver inmanejable y difícil de leer.

Puntos clave a recordar:
  - Definición vs. Ejecución: En todas las líneas donde se usa .Select(...), solo se está definiendo QUÉ hacer. 
  El código NO hace nada hasta que Mostrar entra en el foreach.
  - Inferencia de tipos: En la Opción 3, aunque escribimos var secuencia2, el compilador sabe internamente 
  que es IEnumerable<int> porque st.Length devuelve un entero.
  - Cadena de dependencia: En la Opción 2 y 3, secuencia3 depende de secuencia2, que depende de secuencia1, 
  que depende de lista. Si se cambia lista antes de llamar a Mostrar(secuencia3), el resultado cambiará 
  en todos los casos (debido a la ejecución diferida).

Comparación:
  Característica	Opción 1 (Tipos explícitos)	     Opción 2 (var intermedio)	 Opción 3 (Fluido)
  Legibilidad	    Media (mucha palabra clave)	     Muy Alta                    Alta (si es corto)
  Depuración	    Fácil	                           Fácil                       Difícil (sin dividir) 
  Flexibilidad	  Alta	                           Alta                        Baja (solo resultado final)
  Uso típico	    APIs públicas, contratos claros	 Lógica de negocio estándar  Transformaciones rápidas/funcionales

Conclusión:
  -La Opción 2 suele ser la preferible en el desarrollo diario de C#. Aporta la claridad de tener pasos nombrados 
  (secuencia1, secuencia2) para entender el flujo, pero elimina la redundancia de escribir IEnumerable<T>.

  -La Opción 1 puede servir cuando se esté definiendo el tipo de retorno de una función pública 
  o cuando el tipo no sea obvio para otros desarrolladores.

  -La Opción 3 puede ser útil cuando se esté haciendo una transformación rápida en una sola línea 
  y no se necesite guardar el estado intermedio (por ejemplo, dentro de un return o una asignación final).
*/
