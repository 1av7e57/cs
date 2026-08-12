// Declaramos el espacio de nombres para el programa
namespace Ejercicio05;

// Declaramos un Delegado llamado FuncionEntera.
// Este delegado representa cualquier método que reciba un parámetro entero (int n)
// y devuelva un valor entero (int).
// Esto nos permite pasar métodos o expresiones lambda como parámetros a otras funciones.
delegate int FuncionEntera(int n);