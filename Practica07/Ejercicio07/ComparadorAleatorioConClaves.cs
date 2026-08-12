using System;
using System.Collections.Generic;

namespace Ejercicio07// Definimos el espacio de nombres
{
    // Clase que implementa la interfaz IComparer<int> para comparar índices 
    // basándose en un array de claves aleatorias pregeneradas.
    public class ComparadorAleatorioConClaves : IComparer<int>
    {
        // Campo privado de solo lectura para almacenar las claves
        private readonly double[] _claves;

        /// Constructor que recibe el array de claves aleatorias.
        public ComparadorAleatorioConClaves(double[] claves)
        {
            // Se maneja el caso de posible valor nulo en claves
            if (claves == null)
                throw new ArgumentNullException(nameof(claves));
            
            _claves = claves;
        }

        // Método requerido por la interfaz IComparer<T>.
        // Compara dos índices (x e y) devolviendo el resultado de comparar sus claves asociadas.
        public int Compare(int x, int y)
        {
            // Comparamos la clave del índice 'x' con la clave del índice 'y'.
            // Si claves[x] < claves[y] devuelve negativo (-1).
            // Si claves[x] > claves[y] devuelve positivo (1).
            // Si son iguales devuelve 0.
            return _claves[x].CompareTo(_claves[y]);
        }
    }
}