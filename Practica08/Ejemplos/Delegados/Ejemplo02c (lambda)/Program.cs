// Definición del namespace que agrupa la lógica de la teoría 8
using Teoria8;

// Instancia un nuevo objeto de la clase Auxiliar
Auxiliar aux = new Auxiliar();

// Invoca el método Procesar sobre la instancia creada
// Esto ejecutará internamente SumaUno(10) y SumaDos(10)
aux.Procesar();

/*NOTAS: 

Inferencia de tipos en expresiónes Lambda:
Cuando se omite el tipo de dato en los parámetros de una expresión lambda 
(por ejemplo, escribir n => n * 2 en lugar de (int n) => n * 2), el compilador de C# siempre infiere 
el tipo basándose en el contexto del delegado al que se está asignando o pasando como argumento.
Este proceso se llama inferencia de tipos de destino (target-typing).

¿Cómo funciona el proceso?
-El Contexto es Rey: El compilador mira a qué variable, parámetro o propiedad se le está asignando la lambda.
-Verificación de Firma: Consulta la definición de ese delegado (o Func<>/Action<>) para ver qué tipo de parámetros 
espera y qué tipo devuelve.
-Asignación: Asigna ese tipo a los parámetros de la lambda automáticamente.

Ejemplo en el código:
En la línea:
    Aplicar(v, n => n * 2);

-El método Aplicar espera un segundo parámetro de tipo Funcion.
-El delegado Funcion está definido como delegate int Funcion(int n);.
-Por lo tanto, el compilador sabe que n debe ser un int.
-Si se intentara pasar una lambda que espere un string (ej. n => n.Length) a Aplicar, el código fallaría al compilar,
porque hay una incompatibilidad entre el tipo inferido (int) y la operación que se intenta hacer.

¿Cuándo se puede omitir el tipo?
Solo se puede omitir los tipos cuando el compilador puede determinar inequívocamente el tipo del contexto.

Un detalle importante: Los Paréntesis
Aunque se omita el tipo, la sintaxis de los parámetros depende de cuántos sean:
-Un solo parámetro: Pueden omitirse los paréntesis.
    n => n * 2 (Válido y común)
-Cero o múltiples parámetros: SIEMPRE debe usarse paréntesis, incluso si se omiten los tipos.
    () => 5 (Sin parámetros)
    (x, y) => x + y (Dos parámetros, tipos inferidos)

*/
