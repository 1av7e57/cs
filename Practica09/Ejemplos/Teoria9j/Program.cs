﻿// Crea una lista de enteros (números)
List<int> lista = new List<int>() { 3, 6, 8 };

// Convierte CADA elemento de 'lista' (int) a un nuevo tipo (string).
// El delegado 'Converter<int, string>' se instancia automáticamente con el método 'NroToNombre'.
// El resultado es una NUEVA lista de cadenas con los nombres de los meses correspondientes.
List<string> listaMeses = lista.ConvertAll<string>(NroToNombre);

// Itera sobre la nueva lista de meses y los imprime en consola.
// Salida esperada: "Marzo", "Junio", "Agosto" (dependiendo de la cultura del sistema).
listaMeses.ForEach(st => Console.WriteLine(st));

// Método que cumple la firma de 'Converter<int, string>':
// Recibe un 'int' (input) y devuelve un 'string' (output).
string NroToNombre(int i) {
    // Crea un objeto DateTime usando el número como mes (año arbitrario 2000, día 1).
    // Nota: Si 'i' no es entre 1 y 12, esto lanzará una excepción.
    DateTime fecha = new DateTime(2000, i, 1);
    
    // Convierte la fecha a un string con el formato "MMMM" (nombre completo del mes).
    return fecha.ToString("MMMM");
}

/*NOTAS:
Puntos Clave del delegado genérico 'Converter<TInput, TOutput>':
- Transformación de Tipos: A diferencia de Action (que solo ejecuta) o Predicate (que solo evalúa), 
Converter transforma un tipo A en un tipo B.
- ConvertAll: Es un método es exclusivo de la clase List<T> que hace uso de este Delegado. Crea una nueva lista
en memoria para la conversión. La lista original (lista de enteros) permanece intacta.
- Referencia a Método: En este ejemplo, pasamos NroToNombre como referencia al método. 
También se podría usar una lambda de esta forma:
    // Equivalente usando lambda
    List<string> listaMeses = lista.ConvertAll(i => new DateTime(2000, i, 1).ToString("MMMM"));

Aclaración:
- Cultura del Sistema: El resultado ToString("MMMM") depende de la configuración regional (Culture) del sistema.
En un sistema en español, se vería "Marzo", "Junio", "Agosto". En uno en inglés, "March", "June", "August".
*/
