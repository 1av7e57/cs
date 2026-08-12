/*Este archivo contiene la lógica específica de negocio. 
Al separarla, cumplimos con el principio de Responsabilidad Única.

El método LongitudPar es la lógica específica. 
Al usar delegados, el método de destino puede estar en cualquier clase, 
cumpliendo con la Inversión de Dependencias.
(el Main depende de la abstracción del delegado, no de la implementación concreta).*/

// Definimos una clase para encapsular la lógica de negocio
// Usamos 'public' para que sea accesible desde el archivo Program.cs
public class Calcular
{
    // Método estático que verifica si la longitud de un string es un número par.
    // 'static' permite llamarlo directamente desde la clase sin crear una instancia.
    // Esto facilita su uso como objetivo de un delegado.
    public static bool LongitudPar(string st)
    {
        // .Length obtiene el número de caracteres en la cadena 'st'
        // % 2 calcula el residuo de la división entre 2
        // == 0 verifica si el residuo es 0 (es decir, si es par)
        // El resultado de la expresión booleana se devuelve automáticamente
        return st.Length % 2 == 0;
    }
    
    // Podrían agregarse más métodos aquí si el ejercicio creciera
}