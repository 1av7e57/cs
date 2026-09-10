﻿// Crea una lista de cadenas con los días de la semana
List<string> dias = new List<string>() {
    "lunes","martes","miércoles","jueves","viernes"
};

// Uso de: public T Find (Predicate<T> match);
// Busca el PRIMER elemento que cumpla la condición en la lambda.
// El compilador infiere que 'st' es string, creando un Predicate<string>.
// La condición 'st[0] == 'm'' verifica si el primer carácter es 'm'.
// Devuelve "martes" (el primero que coincide).
string? st = dias.Find(st => st[0] == 'm');

// Imprime el resultado encontrado ("martes")
Console.WriteLine($"Empieza con m: {st}");

// Imprime un mensaje antes de la siguiente búsqueda
Console.WriteLine("Tienen 6 letras:");

// Uso de: List<T> FindAll (Predicate<T> match);
// Busca TODOS los elementos que cumplan la condición.
// La condición 'st.Length == 6' verifica si la longitud de la cadena es 6.
// Retorna una NUEVA lista con los elementos que coinciden: "lunes", "martes", "viernes".
List<string> lista = dias.FindAll(st => st.Length == 6);

// Itera sobre la nueva lista 'lista' y ejecuta la acción para cada elemento.
// Imprime cada día con un espacio al inicio.
lista.ForEach(st => Console.WriteLine(" " + st));

/*NOTAS:
Puntos Clave de este Ejemplo:
- Predicate<T> vs Func<T, bool>: Aunque Predicate<string> y Func<string, bool> son técnicamente intercambiables 
en C# (ambos reciben un string y devuelven un bool), Predicate<T> es un delegado específico diseñado para 
búsquedas en colecciones. El compilador lo reconoce inmediatamente para métodos como Find y FindAll.
- Find: Devuelve el primer elemento que coincide. Si no encuentra ninguno, devuelve null (de ahí 
el tipo string? en la variable).
- FindAll: Devuelve una nueva lista (List<T>) con todos los elementos que coinciden con el predicado.
- Lambdas: La sintaxis st => ... es la forma más limpia de definir la lógica del predicado "al vuelo" 
sin crear métodos separados.
*/
