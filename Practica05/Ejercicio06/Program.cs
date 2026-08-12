﻿/*Definir la clase Persona con las siguientes propiedades de lectura y escritura:
-Nombre de tipo string, Sexo de tipo char, DNI de tipo int, y FechaNacimiento de tipo DateTime. 
Además:
-Definir una propiedad de sólo lectura (calculada) Edad de tipo int. 
-Definir un indizador de lectura/escritura que permita acceder a las propiedades a través de un índice entero. 
Así, si p es un objeto Persona, con p[0] se accede al nombre, p[1] al sexo p[2] al DNI, p[3] a la fecha de
nacimiento y p[4] a la edad. 
En caso de asignar p[4] simplemente el valor es descartado. 
Observar que el tipo del indizador debe ser capaz almacenar valores de tipo int, char, DateTime y string.*/

using System; // Importamos el namespace System para usar clases como DateTime y Console

// Definimos la clase Persona
public class Persona
{
    // Campo privado para almacenar el nombre
    private string? _nombre;

    // Campo privado para almacenar el sexo
    private char _sexo;

    // Campo privado para almacenar el DNI
    private int _dni;

    // Campo privado para almacenar la fecha de nacimiento
    private DateTime _fechaNacimiento;

    // Propiedad de lectura y escritura para Nombre
    public string? Nombre
    {
        get { return _nombre; } // Devuelve el valor del nombre
        set { _nombre = value; } // Asigna el valor recibido al nombre
    }

    // Propiedad de lectura y escritura para Sexo
    public char Sexo
    {
        get { return _sexo; } // Devuelve el valor del sexo
        set { _sexo = value; } // Asigna el valor recibido al sexo
    }

    // Propiedad de lectura y escritura para DNI
    public int DNI
    {
        get { return _dni; } // Devuelve el valor del DNI
        set { _dni = value; } // Asigna el valor recibido al DNI
    }

    // Propiedad de lectura y escritura para FechaNacimiento
    public DateTime FechaNacimiento
    {
        get { return _fechaNacimiento; } // Devuelve la fecha de nacimiento
        set { _fechaNacimiento = value; } // Asigna la fecha recibida
    }

    // Propiedad de solo lectura (calculada) para la Edad
    public int Edad
    {
        get
        {
            // Calculamos la edad restando el año actual al año de nacimiento
            int edad = DateTime.Now.Year - _fechaNacimiento.Year;
            
            // Verificamos si el cumpleaños ya ocurrió este año
            // Si la fecha actual es anterior al cumpleaños en el año actual, restamos 1
            if (DateTime.Now < _fechaNacimiento.AddYears(edad))
            {
                edad--; // Ajustamos la edad si el cumpleaños aún no llegó
            }
            
            return edad; // Devolvemos la edad calculada
        }
    }

    // Definición del indizador para acceder a las propiedades mediante un índice entero
    // Usamos 'object' como tipo porque debe almacenar string, char, int, DateTime y int (Edad)
    public object this[int indice]
    {
        get
        {
            // Si el índice es 0, devolvemos el Nombre
            if (indice == 0) return _nombre!;
            // Si el índice es 1, devolvemos el Sexo
            if (indice == 1) return _sexo;
            // Si el índice es 2, devolvemos el DNI
            if (indice == 2) return _dni;
            // Si el índice es 3, devolvemos la FechaNacimiento
            if (indice == 3) return _fechaNacimiento;
            // Si el índice es 4, devolvemos la Edad (calculada)
            if (indice == 4) return Edad;
            
            // Si el índice no es válido, lanzamos una excepción
            throw new IndexOutOfRangeException("Índice fuera del rango válido (0-4).");
        }
        set
        {
            // Si el índice es 0, asignamos el valor al Nombre (convertimos a string)
            if (indice == 0) _nombre = (string)value;
            // Si el índice es 1, asignamos el valor al Sexo (convertimos a char)
            else if (indice == 1) _sexo = (char)value;
            // Si el índice es 2, asignamos el valor al DNI (convertimos a int)
            else if (indice == 2) _dni = (int)value;
            // Si el índice es 3, asignamos el valor a la FechaNacimiento (convertimos a DateTime)
            else if (indice == 3) _fechaNacimiento = (DateTime)value;
            // Si el índice es 4, descartamos el valor (no hacemos nada) como se solicitó
            else if (indice == 4) { /* El valor es descartado */ }
            // Si el índice no es válido, lanzamos una excepción
            else throw new IndexOutOfRangeException("Índice fuera del rango válido (0-4).");
        }
    }
}

// Clase principal del programa
public class Program
{
    // Método Main, punto de entrada de la aplicación
    public static void Main()
    {
        // Creamos una nueva instancia de la clase Persona
        Persona p = new Persona();

        // Asignamos valores iniciales a las propiedades
        p.Nombre = "Juan"; // Asignamos el nombre "Juan"
        p.Sexo = 'M'; // Asignamos el sexo 'M'
        p.DNI = 12345678; // Asignamos el DNI 12345678
        p.FechaNacimiento = new DateTime(1990, 7, 15); // Asignamos una fecha de nacimiento

        // Mostramos los valores usando el indizador (lectura)
        Console.WriteLine("Nombre: " + p[0]); // Muestra el nombre a través del índice 0
        Console.WriteLine("Sexo: " + p[1]); // Muestra el sexo a través del índice 1
        Console.WriteLine("DNI: " + p[2]); // Muestra el DNI a través del índice 2
        Console.WriteLine("Fecha Nacimiento: " + p[3]); // Muestra la fecha a través del índice 3
        Console.WriteLine("Edad: " + p[4]); // Muestra la edad calculada a través del índice 4

        // Prueba de asignación a través del indizador
        p[0] = "Maria"; // Cambiamos el nombre a través del índice 0
        Console.WriteLine("Nuevo Nombre: " + p[0]); // Verificamos el cambio

        // Intentamos asignar un valor a la propiedad Edad (índice 4)
        // Según los requisitos, este valor debe ser descartado
        p[4] = 999; 
        Console.WriteLine("Edad después de intentar asignar 999 (debe ser la calculada): " + p[4]);
        
        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.WriteLine("\nPresione una tecla para finalizar");
        Console.ReadKey();
    }
}

/*NOTAS:
- Propiedad Edad: Es de solo lectura (get únicamente) y calcula la edad basándose en la fecha actual 
y la fecha de nacimiento, ajustando si el cumpleaños aún no ha ocurrido en el año actual.
- Indizador (this[int indice]):
    Usa el tipo object como retorno y parámetro de asignación. 
    Esto es necesario porque C# requiere que todos los tipos en una estructura sean compatibles, 
    y object es la base de todos los tipos, permitiendo guardar string, char, int y DateTime.

    En el get, devuelve el valor correspondiente según el índice.
    En el set, realiza el cast (conversión) explícito al tipo esperado para índices 0 a 3. 
    Para el índice 4 (Edad), simplemente no hace nada, cumpliendo con el requisito de descartar el valor.

Aclaración: 
Verificación del Cumpleaños en el calculo de Edad:
    if (DateTime.Now < _fechaNacimiento.AddYears(edad))
Aquí el código compara la fecha actual con la fecha en la que la persona cumpliría "esa edad calculada" (36 años).
1. _fechaNacimiento.AddYears(edad):
    Toma la fecha de nacimiento: 15/07/1990.
    Le suma los 36 años calculados.
    Resultado: 15/07/2026. (Esta es la fecha exacta en la que la persona cumple 36 años).
2. Comparación:
    Lado izquierdo (DateTime.Now): 21/06/2026. (Fecha de creación del programa)
    Lado derecho (Cumpleaños 2026): 15/07/2026.
    Pregunta: ¿Es 21/06/2026 menor (antes) que 15/07/2026?
    Respuesta: SÍ (true). Hoy es antes del cumpleaños. (Para la fecha actual 21/06/2026 )
3. Ajuste de la Edad
    Dado que la condición del if es verdadera (todavía no ha cumplido años este año):
        edad--; // Ajustamos la edad si el cumpleaños aún no llegó
    La variable edad (que valía 36) se decrementa en 1.
    Nuevo valor: 36 - 1 = 35.
Lógica: Aunque la diferencia de años es 36, como el cumpleaños (15 de julio) aún no ha llegado 
en la fecha actual (21 de junio), la persona todavía tiene 35 años.

¿Qué pasaría si el cumpleaños ya hubiera pasado?
Paso 3. El bloque if se ignora. edad sigue siendo 36.
Resultado: La persona tiene 36 años.
*/
