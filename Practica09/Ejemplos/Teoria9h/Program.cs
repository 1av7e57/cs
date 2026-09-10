﻿// Crea una nueva lista genérica de cadenas de texto (string)
List<string> lista = new List<string>() { "hola", "mundo" };

// Ejecuta la acción definida en la lambda para CADA elemento de la lista
// 'st' representa el elemento actual de tipo string en cada iteración
// La lambda 'st => Console.WriteLine(st)' se convierte en una instancia de Action<string>
lista.ForEach(st => Console.WriteLine(st));

/*NOTAS:
Análisis del Código
1. List<string>: La lista genérica contiene cadenas de texto (string). Esto define el tipo del elemento T.
2. Action<string>: Este es el delegado genérico.
    - T se infiere automáticamente como string porque la lista es de tipo List<string>.
    - Action indica que el delegado no devuelve nada (void), solo ejecuta una acción.
3. st => Console.WriteLine(st): expresión lambda. Es la forma más concisa de crear una instancia de Action<string> 
sin necesidad de definir una clase o método separado.
    - st: Es el parámetro de entrada (el elemento actual de la lista).
    - Console.WriteLine(st): Es el cuerpo de la acción (lo que se hace con ese elemento).

Ventajas del uso genérico:
La definición original public void ForEach(Action<T> action); no necesita especificar qué tipo de dato va a manejar.
- Si la lista es List<int>, el compilador convierte automáticamente Action<T> en Action<int>.
- Si es List<Persona>, se convierte en Action<Persona>.
El método ForEach es reutilizable porque funciona con cualquier tipo de dato, y el compilador se encarga de verificar 
que el delegado que se pasas sea compatible con ese tipo.
*/
