/*Codificar las clases e interfaces necesarias para modelar un sistema que trabaja con las siguientes entidades: Autos, Libros, Películas, Personas y Perros. 
Algunas de estas entidades pueden ser: alquilables (se pueden alquilar a una persona y ser devueltas por una persona), vendibles (se pueden vender a una persona), lavables (se pueden lavar y secar) reciclables (se pueden reciclar) y atendibles (se pueden atender). A continuación se describen estas relaciones:
- Son Alquilables: Libros y Películas
- Son Vendibles: Autos y Perros
- Son Lavables: Autos
- Son Reciclables: Libros y Autos
- Son Atendibles: Personas y Perros 

Completar el código de la clase estática Procesador:
static class Procesador
{
public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p); public static . . .
. . .
}

La ejecución del siguiente código debe mostrar en la consola la salida indicada:
Auto auto = new Auto();
Libro libro = new Libro();
Persona persona = new Persona(); 
Perro perro = new Perro();
Pelicula pelicula = new Pelicula();
Procesador.Alquilar(pelicula, persona); 
Procesador.Alquilar(libro, persona);
Procesador.Atender(persona); 
Procesador.Atender(perro);
Procesador.Devolever(pelicula, persona); 
Procesador.Devolever(libro, persona);
Procesador.Lavar(auto);
Procesador.Reciclar(libro); 
Procesador.Reciclar(auto); 
Procesador.Secar(auto);
Procesador.Vender(auto, persona); 
Procesador.Vender(perro, persona);

Salida por consola:
Alquilando película a persona 
Alquilando libro a persona
Atendiendo persona
Atendiendo perro
Película devuelta por persona
Libro devuelto por persona
Lavando auto
Reciclando libro
Reciclando auto
Secando auto
Vendiendo auto a persona
Vendiendo perro a persona
*/

// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio01.Modelos;
using Ejercicio01.Servicios;
using Ejercicio01.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio01;

// --- Clase Principal (Entrada del programa) ---
class Program
{
    // Método Main: punto de entrada donde comienza la ejecución
    static void Main()
    {
        // Instanciación de objetos de cada clase entidad
        Auto auto = new Auto();
        Libro libro = new Libro();
        Persona persona = new Persona();
        Perro perro = new Perro();
        Pelicula pelicula = new Pelicula();

        // Llamadas a los métodos del procesador para ejecutar las operaciones solicitadas
        Procesador.Alquilar(pelicula, persona);
        Procesador.Alquilar(libro, persona);
        Procesador.Atender(persona);
        Procesador.Atender(perro);
        Procesador.Devolver(pelicula, persona);
        Procesador.Devolver(libro, persona);
        Procesador.Lavar(auto);
        Procesador.Reciclar(libro);
        Procesador.Reciclar(auto);
        Procesador.Secar(auto);
        Procesador.Vender(auto, persona);
        Procesador.Vender(perro, persona);
    }
}

/*NOTAS:

Puntos Clave del Diseño:
    - Interfaces Específicas: Cada comportamiento (IAlquilable, IVendible, etc.) es una interfaz independiente. 
    Esto permite que una clase como Auto implemente varias (IVendible, ILavable, IReciclable, ISecable) 
    mientras que Libro solo implementa las suyas (IAlquilable, IReciclable).
    - Polimorfismo en Procesador: Los métodos estáticos de Procesador reciben la interfaz como parámetro 
    (ej. ILavable x). Esto hace que el método funcione con cualquier objeto que implemente esa interfaz, 
    sin importar si es un Auto o una posible futura clase como Moto, etc.
    - Salida de Consola: Los mensajes se generan dentro de las clases (en los métodos de las interfaces implementadas) 
    para coincidir exactamente con el formato solicitado (ej. "Alquilando película a persona").

La Clase Estática Procesador:
El hecho de que la clase Procesador sea static influye principalmente en cómo se accede a sus métodos 
y en la gestión de recursos de la siguiente manera:

1.No es necesario instanciar la clase:
    -Al ser static, Procesador es una clase de utilidad que no necesita ser creada con new.
    -Permite llamar directamente a Procesador.Alquilar(...).

2.Los métodos son implícitamente estáticos:
    -Cualquier método dentro de una clase static debe ser static.
    Esto significa que los métodos Alquilar, Lavar, Vender, etc., pertenecen a la propia clase Procesador, no a una instancia de ella.
    -Esto obliga a que los métodos no puedan acceder a variables de instancia (no pueden usar this), lo cual sirve para este caso, 
    ya que todo lo que necesitan (el objeto x y la persona p) se les pasa como argumentos.

3.Rendimiento y Memoria
    -Sin instancia: El compilador y el runtime saben que solo existe una "copia" lógica de la clase. 
    No hay sobrecarga de memoria creando objetos vacíos solo para llamar a funciones.
    -Llamada directa: La llamada a un método estático es ligeramente más rápida porque el compilador 
    puede resolver la dirección de memoria en tiempo de compilación (llamada estática).

4.Seguridad y Estado
    -Al no poder tener estado interno (campos de instancia), la clase está garantizada como sin estado (stateless). 
    Esto evita errores donde una llamada a un método podría afectar a otra llamada futura debido a variables compartidas.
    -Cada llamada es independiente y predecible, lo cual es ideal para una clase de utilidades como esta.

En resumen:
    La clase static actúa como un contenedor de funciones utilitarias que operan sobre los objetos que se le pasa (libros, autos, etc.). 
    Si no fuera estática, se tendría que escribir código extra e innecesario para crear una instancia antes de poder usarla, complicando 
    el Main sin aportar ningún beneficio funcional.
*/
