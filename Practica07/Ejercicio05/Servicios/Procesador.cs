// Importamos el espacio de nombres de las subcarpetas a utilizar
using Ejercicio05.Modelos;
using Ejercicio05.Interfaces;

// Definimos el espacio de nombres propio
namespace Ejercicio05.Servicios;

// --- Clase Procesador Estática ---
// Se declara static porque contiene solo métodos de utilidad que no requieren estado interno
static class Procesador
{
    // Método estático para alquilar cualquier objeto que implemente IAlquilable a una Persona
    // Usa expresión de cuerpo (=>) para una implementación concisa
    public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);

    // Método estático para devolver cualquier objeto IAlquilable a una Persona
    public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelvePor(p);

    // Método estático para atender cualquier objeto que implemente IAtendible
    // Funciona tanto para Persona como para Perro gracias al polimorfismo
    public static void Atender(IAtendible x) => x.Atender();

    // Método estático para lavar cualquier objeto que implemente ILavable
    public static void Lavar(ILavable x) => x.SeLava();

    // Método estático para reciclar cualquier objeto que implemente IReciclable
    public static void Reciclar(IReciclable x) => x.SeRecicla();

    // Método estático para secar cualquier objeto que implemente ISecable
    public static void Secar(ISecable x) => x.SeSeca();

    // Método estático para vender cualquier objeto que implemente IVendible a una Persona
    public static void Vender(IVendible x, Persona p) => x.SeVendeA(p);
}
