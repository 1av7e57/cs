// Delegado: Es un tipo especial de clase que puede almacenar la referencia a un método que tenga la misma firma. 
// Se usa una sintaxis similar a la definición de una firma de método.
// Solo hace falta agregar la palabra clave 'delegate' a la definición 
// (Así podemos cargar a una variable toda una función):

// Definición del namespace que agrupa la lógica de la teoría 8
namespace Teoria8;

// Definimos el delegado 'Funcion'.
// Firma: Recibe un 'int' y retorna un 'int'.
// Cualquier método que coincida con esta firma puede ser asignado a una variable de este tipo.
delegate int Funcion(int n);

/*NOTAS:
Para este ejemplo, se optó por definir el delegado manualmente, sin embargo, en C# existe 
una familia de delegados genéricos predefinidos que cubren casi todas las necesidades, 
evitando tener que definir nuestro propio delegate cada vez.

Los más importantes son:
    -Func<T, TResult>: Un método que recibe parámetros (T) y retorna un valor (TResult).
    -Action<T>: Un método que recibe parámetros (T) pero no retorna nada (void).
    -Predicate<T>: Específicamente para métodos que retornan bool (muy usado en filtrado).
En este caso, como el método recibe un int y retorna un int, se usaría Func<int, int>.
*/