/*Incorporar al ejercicio anterior la posibilidad también de lavar a los perros. 
También se debe incorporar una clase derivada de Película, las “películas clásicas” 
que además de alquilarse pueden venderse. Estos cambios deben poder realizarse 
sin necesidad de modificar la clase estática Procesador. 

El siguiente código debe producir la salida indicada:
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
Procesador.Vender(auto, persona); Procesador.Vender(perro, persona); Procesador.Lavar(perro);
Procesador.Secar(perro);
PeliculaClasica peliculaClasica = new PeliculaClasica(); 
Procesador.Alquilar(peliculaClasica, persona);
Procesador.Devolever(peliculaClasica, persona); 
Procesador.Vender(peliculaClasica, persona);

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
Lavando perro
Secando perro
Alquilando película clásica a persona
Película clásica devuelta por persona
Vendiendo película clásica a persona
*/

// Importamos el espacio de nombres System para tener acceso a Console.WriteLine y otras utilidades básicas
using System; 

// Importamos el espacio de nombres para las subcarpetas del proyecto
using Ejercicio02.Modelos;
using Ejercicio02.Servicios;
using Ejercicio02.Interfaces;

// Definimos el espacio de nombres propio del proyecto
namespace Ejercicio02;

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

        // Nueva instancia para objeto de clase películas clásicas
        PeliculaClasica peliculaClasica = new PeliculaClasica();


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

        // Nuevas operaciónes para Perro: 
        // Lavar y Secar (ahora posibles porque Perro implementa ILavable/ISecable)
        Procesador.Lavar(perro);
        Procesador.Secar(perro);

        // Nuevas llamadas para operaciónes de películas clásicas
        Procesador.Alquilar(peliculaClasica, persona);
        Procesador.Devolver(peliculaClasica, persona);
        Procesador.Vender(peliculaClasica, persona);
    }
}

/*NOTAS:
Este es un caso de estudio para demostrar la extensibilidad 
y el principio de Open/Closed (abierto a extensiones, cerrado a modificaciones).

El objetivo es lograr que, al agregar nuevas funcionalidades (lavar perros, vender películas clásicas), 
no tengamos que tocar una sola línea de la clase Procesador. 
Esto se logra gracias a las interfaces y al polimorfismo.

Cómo funciona:
-Procesador.Lavar(perro):
El método espera un ILavable.
Antes, Perro no era ILavable, así que el código no compilaba.
Ahora, Perro implementa ILavable. El compilador verifica el contrato, encuentra los métodos SeLava() y SeSeca() dentro de Perro, y permite la llamada. 
Sin tocar Procesador.

-Procesador.Vender(peliculaClasica, persona):
El método espera un IVendible.
PeliculaClasica hereda de Pelicula (que no es vendible) pero implementa explícitamente IVendible.
El compilador ve que PeliculaClasica tiene el método SeVendeA, y permite la llamada. Sin tocar Procesador.
*/
