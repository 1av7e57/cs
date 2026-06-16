/*Codificar la clase Hora de tal forma que el siguiente código produzca la salida por consola que se observa.
Hora h = new Hora(23,30,15);
h.Imprimir();

Salida en consola: 
23 horas, 30 minutos y 15 segundos
*/

// Importamos el namespace System para poder usar Console.WriteLine y otras utilidades básicas
using System;

// Definimos la clase pública llamada Hora
public class Hora
{
    // Declaramos las campos como privados para que solo esta clase pueda modificarlos directamente

    // Declaración de la variable privada 'horas' de tipo entero (int)
    private int horas;

    // Declaración de la variable privada 'minutos' de tipo entero (int)
    private int minutos;

    // Declaración de la variable privada 'segundos' de tipo entero (int)
    private int segundos;

    // Definición del constructor de la clase
    // Este método se ejecuta automáticamente cuando creamos una nueva instancia con 'new'
    // Recibe tres parámetros: horas, minutos y segundos
    public Hora(int horas, int minutos, int segundos)
    {
        // Asignamos el valor del parámetro 'horas' a la propiedad de la clase 'this.horas'
        // 'this' se usa para diferenciar la propiedad de la clase del parámetro
        this.horas = horas;

        // Asignamos el valor del parámetro 'minutos' a la propiedad de la clase 'this.minutos'
        this.minutos = minutos;

        // Asignamos el valor del parámetro 'segundos' a la propiedad de la clase 'this.segundos'
        this.segundos = segundos;
    }

    // Definición del método público 'Imprimir'
    // No recibe parámetros y no devuelve ningún valor (void)
    public void Imprimir()
    {
        // Utilizamos Console.WriteLine para mostrar texto en la consola
        // Usamos interpolación de cadenas con '$' para insertar las variables directamente dentro del texto
        // {horas} se reemplaza por el valor de la variable 'horas'
        // {minutos} se reemplaza por el valor de la variable 'minutos'
        // {segundos} se reemplaza por el valor de la variable 'segundos'
        Console.WriteLine($"{horas} horas, {minutos} minutos y {segundos} segundos");
    }
}

// Clase principal del programa (punto de entrada)
public class Program
{
    // Método principal Main (donde comienza la ejecución del programa)
    public static void Main()
    {
        // Creamos una nueva instancia (objeto) de la clase Hora
        // Le pasamos los valores 23, 30 y 15 al constructor
        // El objeto se guarda en la variable 'h'
        Hora h = new Hora(23, 30, 15);

        // Llamamos al método 'Imprimir' del objeto 'h'
        // Esto ejecutará el código dentro de Imprimir() y mostrará el resultado en consola
        h.Imprimir();
    }
}

