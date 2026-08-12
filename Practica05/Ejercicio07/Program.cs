﻿/*Dada la siguiente definición incompleta de clase:
class ListaDePersonas
{
    public void Agregar(Persona p1)
    {
        . . .
    }
 . . .
}
Completarla y agregar dos indizadores de sólo lectura:
- Un índice entero que permite acceder a las personas de la lista por número de documento. 
Por ejemplo: p1=lista[30456345] devuelve el objeto Persona que tiene DNI=30456345 o null en caso que no exista en la lista.
- Un índice de tipo char que devuelve un List<string> con todos los nombres de las personas de la lista que comienzan 
con el carácter pasado como índice.
*/

using System; // Importamos el namespace System para usar clases como DateTime y Console
using System.Collections.Generic; // Necesario para usar List

// Definición de la clase ListaDePersonas
public class ListaDePersonas
{
    // Campo privado: Lista interna para almacenar los objetos Persona
    private List<Persona> _personas;

    // Constructor: Inicializa la lista interna
    public ListaDePersonas()
    {
        _personas = new List<Persona>();
    }

    // Método para agregar una Persona a la lista
    public void Agregar(Persona p1)
    {
        // Añadimos el objeto Persona p1 a la lista interna
        _personas.Add(p1);
    }

    // Indizador de tipo Persona con índice entero (DNI)
    // Permite buscar a una persona por su número de documento
    public Persona this[int dni]
    {
        get
        {
            // Recorremos la lista interna buscando una persona cuyo DNI coincida
            foreach (Persona p1 in _personas)
            {
                // Si el DNI del objeto actual coincide con el índice pasado
                if (p1.DNI == dni)
                {
                    return p1; // Devolvemos el objeto Persona encontrado
                }
            }
            
            // Si no encontramos ninguna persona con ese DNI, devolvemos null
            return null!;
        }
    }

    // Indizador de tipo List<string> con índice char (Inicial del nombre)
    // Devuelve una lista con los nombres que comienzan con el carácter dado
    public List<string> this[char inicial]
    {
        get
        {
            // Creamos una nueva lista de strings para almacenar los resultados
            List<string> nombresEncontrados = new List<string>();

            // Recorremos la lista interna de personas
            foreach (Persona p1 in _personas)
            {
                // Verificamos que el Nombre no sea nulo antes de intentar acceder a él
                if (p1.Nombre != null)
                {
                    // Obtenemos el primer carácter del nombre y lo convertimos a minúscula
                    // para hacer una comparación que no distinga mayúsculas/minúsculas
                    char primerLetra = p1.Nombre[0];
                    
                    // Comparamos la inicial del nombre con el índice pasado (char inicial)
                    // Usamos .ToLower() para asegurar que 'A' y 'a' se traten igual
                    if (char.ToLower(primerLetra) == char.ToLower(inicial))
                    {
                        // Si coincide, agregamos el nombre completo a la lista de resultados
                        nombresEncontrados.Add(p1.Nombre);
                    }
                }
            }

            // Devolvemos la lista de nombres encontrados
            return nombresEncontrados;
        }
    }
}


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
        // Creamos una nueva instancia de la clase Persona (p1)
        Persona p1 = new Persona();

        // Asignamos valores iniciales a las propiedades
        p1.Nombre = "Juan"; // Asignamos el nombre "Juan"
        p1.Sexo = 'M'; // Asignamos el sexo 'M'
        p1.DNI = 12345678; // Asignamos el DNI 12345678
        p1.FechaNacimiento = new DateTime(1990, 7, 15); // Asignamos una fecha de nacimiento

        // Creamos la lista
        ListaDePersonas lista = new ListaDePersonas();
        // Agregamos a la persona a la lista
        lista.Agregar(p1); // p1 es Juan

        // Mostramos los valores usando el indizador (lectura)
        Console.WriteLine("Nombre: " + p1[0]); // Muestra el nombre a través del índice 0
        Console.WriteLine("Sexo: " + p1[1]); // Muestra el sexo a través del índice 1
        Console.WriteLine("DNI: " + p1[2]); // Muestra el DNI a través del índice 2
        Console.WriteLine("Fecha Nacimiento: " + p1[3]); // Muestra la fecha a través del índice 3
        Console.WriteLine("Edad: " + p1[4]); // Muestra la edad calculada a través del índice 4
        
        // Prueba de asignación a través del indizador
        p1[0] = "Maria"; // Cambiamos el nombre a través del índice 0
        Console.WriteLine("Nuevo Nombre: " + p1[0]); // Verificamos el cambio (Ahora p1 es María)

        // Intentamos asignar un valor a la propiedad Edad (índice 4)
        // Este valor debe ser descartado (Edad sigue siendo 35)
        p1[4] = 999; 
        Console.WriteLine("Edad después de intentar asignar 999 (debe ser la calculada): " + p1[4]);

        // Agregamos una nueva persona (p2)
        Persona p2 = new Persona();
        p2.Nombre = "Carlos";
        p2.Sexo = 'M';
        p2.DNI = 87654321;
        p2.FechaNacimiento = new DateTime(2000, 1, 1);
        lista.Agregar(p2); // Agregamos a "Carlos" (p2) a la lista

        // Mostramos los valores usando el indizador (lectura)
        Console.WriteLine("\nNombre: " + p2[0]); // Muestra el nombre a través del índice 0
        Console.WriteLine("Sexo: " + p2[1]); // Muestra el sexo a través del índice 1
        Console.WriteLine("DNI: " + p2[2]); // Muestra el DNI a través del índice 2
        Console.WriteLine("Fecha Nacimiento: " + p2[3]); // Muestra la fecha a través del índice 3
        Console.WriteLine("Edad: " + p2[4]); // Muestra la edad calculada a través del índice 4

        // Prueba del indizador por DNI (enteros)
        Persona encontrada = lista[12345678]; // Debería encontrar a Maria (o Juan si no cambiamos el orden)
        Console.WriteLine("\nPersona por DNI 12345678: " + (encontrada != null ? encontrada.Nombre : "No encontrada"));

        // Prueba del indizador por inicial (char)
        List<string> nombresConM = lista['M']; // Busca nombres que empiecen por M
        Console.WriteLine("Nombres con 'M': " + string.Join(", ", nombresConM));

        List<string> nombresConC = lista['C']; // Busca nombres que empiecen por C
        Console.WriteLine("Nombres con 'C': " + string.Join(", ", nombresConC));

        List<string> nombresConZ = lista['Z']; // Busca nombres que empiecen por Z (No debería haber ninguno)
        // .Count es una propiedad en List<T> que Devuelve un (int) según la cantidad total de elementos que hay en la lista.
        // Ya que el retorno es 0, escribe "Ninguno". Si lo hubiera, lo imprimiría como los anteriores.
        Console.WriteLine("Nombres con 'Z': " + (nombresConZ.Count == 0 ? "Ninguno" : string.Join(", ", nombresConZ))); // Decide usando de operador ternario '? :'

        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.WriteLine("\nPresione una tecla para finalizar");
        Console.ReadKey();
    }
}

/*NOTAS;
Explicación de cambios y funcionamiento:
- Campo _personas: Es una List<Persona> privada que actúa como el almacenamiento real de los objetos.
- Constructor: Es vital inicializar la lista en el constructor, de lo contrario daría un error de "NullReferenceException" al intentar agregar personas.
- Agregar(Persona p): Añade el objeto a la lista interna usando Add.

- Indizador Entero (this[int dni]): Busqueda por DNI
    Recorre la lista con un foreach.
    Compara p.DNI con el dni del índice.
    Si encuentra coincidencia, retorna el objeto Persona inmediatamente.
    Si termina el bucle sin encontrar nada, retorna null.

- Indizador Char (this[char inicial]): Busqueda por inicial
    Crea una nueva List<string> vacía para almacenar los resultados.
    Recorre la lista de personas.
    Verifica que p.Nombre no sea null.
    Compara la primera letra del nombre con el carácter del índice. 
    Se usa char.ToLower() para que la búsqueda sea insensible a mayúsculas/minúsculas.
    Agrega los nombres coincidentes a la lista de resultados y la retorna.
*/
