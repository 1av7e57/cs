// Importamos el espacio de nombres que contiene las interfaces IEnumerable y IEnumerator
using System.Collections.Generic;

// Definimos el espacio de nombres para el proyecto
namespace Ejercicio08;

// Declaramos una clase estática que engloba la lógica de los Iteradores. 
// Al ser estática, no necesitamos instanciarla para usar sus métodos. 
// Esto es común para utilidades o generadores.
public static class Iteradores
{
    // Rango:
    // Método iterador que devuelve una secuencia de enteros.
    // Retorna la interfaz IEnumerable<int>, lo que permite que el método sea recorrido con foreach.
    // Parámetros: inicio (valor inicial), fin (valor límite), paso (incremento o decremento).
    public static IEnumerable<int> Rango(int inicio, int fin, int paso)
    {
        // Validación crítica: si el paso es 0, el bucle sería infinito.
        // yield break finaliza la ejecución del iterador inmediatamente.
        if (paso == 0) yield break; 

        // Variable que rastrea el valor actual de la secuencia.
        int actual = inicio;
        
        // Verificamos la dirección del paso para ajustar la condición del bucle.
        if (paso > 0)
        {
            // Si el paso es positivo, seguimos mientras el valor actual sea menor o igual al fin.
            while (actual <= fin)
            {
                // yield return pausa el método y devuelve el valor actual al llamador.
                // El estado de la variable 'actual' se mantiene para la siguiente iteración.
                yield return actual;
                
                // Avanzamos al siguiente número en la secuencia.
                actual += paso;
            }
        }
        else
        {
            // Si el paso es negativo, seguimos mientras el valor actual sea mayor o igual al fin.
            while (actual >= fin)
            {
                // Devolvemos el valor actual y pausamos la ejecución.
                yield return actual;
                
                // Avanzamos hacia atrás en la secuencia.
                actual += paso;
            }
        }
    }

    // Potencias:
    // Método iterador para generar potencias: b^1, b^2, ..., b^k.
    // Parámetros: baseNum (la base), exponente (cuántas potencias generar).
    public static IEnumerable<int> Potencias(int baseNum, int exponente)
    {
        // Usamos 'long' para evitar desbordamiento de enteros durante el cálculo intermedio.
        long resultado = 1;
        
        // Bucle desde 1 hasta el exponente deseado.
        for (int i = 1; i <= exponente; i++)
        {
            // Calculamos la siguiente potencia multiplicando por la base.
            resultado *= baseNum;
            
            // Verificación de seguridad: si el resultado excede el límite de un int, detenemos.
            if (resultado > int.MaxValue) yield break;
            
            // Convertimos a int y devolvemos el valor.
            // El casting es seguro gracias a la verificación anterior.
            yield return (int)resultado;
        }
    }

    // DivisiblesPor
    // Método iterador que filtra una secuencia existente.
    // Parámetros: secuencia (cualquier IEnumerable<int>), divisor (número por el que dividir).
    public static IEnumerable<int> DivisiblesPor(IEnumerable<int> secuencia, int divisor)
    {
        // Evitar división por cero, lo cual lanzaría una excepción.
        if (divisor == 0) yield break; 

        // Recorremos la secuencia pasada como parámetro.
        // Nota: Esto se ejecuta solo cuando se itera sobre el resultado de este método.
        foreach (int numero in secuencia)
        {
            // Comprobamos si el número es divisible por el divisor (resto 0).
            if (numero % divisor == 0)
            {
                // Si cumple la condición, lo devolvemos.
                yield return numero;
            }
            // Si no cumple, el bucle continúa automáticamente con el siguiente número.
        }
    }
}