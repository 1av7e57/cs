using System; // para System.Random y funciónes básicas
using System.Collections.Generic; // Necesario para IComparer<T>

namespace Ejercicio07 // Definimos el espacio de nombres
{
    // Clase principal que contiene la lógica de ordenamiento aleatorio
    public class OrdenamientoAleatorio
    {
        // Ordena aleatoriamente un array de objetos usando Array.Sort() y una implementación de IComparer.
        // Modifica el array original.
        public static void OrdenarAleatoriamente(object[] array)
        {
            // Validación de entrada
            // Si el array es nulo o tiene 0 o 1 elemento, ya está "ordenado", así que salimos.
            if (array == null || array.Length <= 1)
                return;

            // Obtenemos la cantidad total de elementos en el array para usarla en los bucles.
            // La asignamos a la variable n
            int n = array.Length;

            // Instanciamos Random SOLO UNA VEZ.
            // Es crucial crear una sola instancia aquí. Si la creáramos dentro de un bucle,
            // usaría la misma semilla (reloj del sistema) varias veces en milisegundos,
            // generando los mismos números aleatorios repetidamente.
            Random random = new Random();

            // 1. Generar claves aleatorias para cada posición
            // Cada índice tendrá un valor único que determinará su posición final.
            double[] claves = new double[n];
            for (int i = 0; i < n; i++)
            {
                claves[i] = random.NextDouble();
            }

            // 2. Crear array de índices (0, 1, 2, ..., n-1)
            // Ordenaremos estos índices, no los objetos directamente.
            int[] indices = new int[n];
            for (int i = 0; i < n; i++)
            {
                indices[i] = i;
            }

            // 3. Instanciar nuestra clase que implementa IComparer<int>
            // Pasar las claves generadas al constructor.
            IComparer<int> comparador = new ComparadorAleatorioConClaves(claves);

            // 4. Llamar a Array.Sort pasando el array de índices y el comparador.
            // Array.Sort usará internamente el método Compare() de definimos en ComparadorAleatorioConClaves.
            Array.Sort(indices, comparador);

            // 5. Reconstruir el array original usando el nuevo orden de índices
            object[] resultado = new object[n];
            for (int i = 0; i < n; i++)
            {
                // El índice que debe ir en la posición 'i' del nuevo orden es indices[i]
                resultado[i] = array[indices[i]];
            }

            // 6. Copiar el resultado de vuelta al array original (pasado por referencia)
            Array.Copy(resultado, array, n);
        }
    }
}