// Declaramos el espacio de nombres para el programa
namespace Ejercicio05;

// Define un delegado llamado Predicado.
// Representa cualquier método que reciba un entero (int n)
// y devuelva un valor booleano (bool: true o false).
// Se usa para definir condiciones de filtrado.
delegate bool Predicado(int n);