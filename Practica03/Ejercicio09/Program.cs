/*Verificar con un par de ejemplos si la sección opcional [:formatString] de formatos compuestos
redondea o trunca cuando se formatean números reales restringiendo la cantidad de decimales.
Plantear los ejemplos con cadenas de formato compuesto y con cadenas interpoladas.*/

// Importa el espacio de nombres System, necesario para clases básicas como Console
using System;

// Define la clase principal del programa
class Program
{
    // El método Main es el punto de entrada donde comienza la ejecución del programa
    static void Main()
    {
        // Declaramos un array de tipo decimal (números con decimales de alta precisión)
        // INICIALIZACIÓN: Es OBLIGATORIO usar el sufijo 'm' o 'M' al final de los números literales.
        // Sin la 'm', C# los trataría como 'double' y daría error de conversión implícita.
        // Elegimos valores específicos para probar bordes con precisión exacta:
        decimal[] valores = {
            1.234m,  // El dígito siguiente es 4 (< 5)    Redondeo hacia ABAJO -> 1.23
            1.235m,  // Caso límite exacto (termina en 5) Redondeo hacia arriba-> 1.24
            1.245m,  // Caso límite exacto (termina en 5) Redondeo hacia arriba-> 1.25 
            1.225m,  // Caso límite exacto (termina en 5) Redondeo hacia arriba-> 1.23
            1.239m,  // El dígito siguiente es 9 (> 5)    Redondeo hacia arriba-> 1.24
            1.2345m, // El dígito siguiente es 4 (< 5)    Redondeo hacia ABAJO -> 1.23
            1.2355m  // Caso crítico múltiple             Redondeo hacia arriba-> 1.24
        };

        // Imprimimos un título explicativo en la consola
        // \n inserta un salto de línea
        Console.WriteLine("Prueba de formato: Redondeo vs Truncamiento en C# (TIPO DECIMAL)\n");
        
        // Imprimimos una cabecera para nuestra tabla de resultados
        Console.WriteLine("Valor original:            | Compuesto:            | Interpolada:            | Estado:      ");

        // Imprimimos una línea separadora visual
        // new string('-', 93) crea una cadena de 93 caracteres del tipo guion '-'
        Console.WriteLine(new string('-', 93));

        // Iniciamos un bucle 'foreach' para iterar sobre cada número en nuestro array 'valores'
        // 'valor' es una variable decimal temporal que tomará el valor de cada elemento en cada vuelta
        foreach (decimal valor in valores)
        {
            // --- MÉTODO 1: Formato Compuesto Clásico ---
            // string.Format es el método estándar.
            // "{0:F2}" es la cadena de formato:
            //   {0}: refiere al primer argumento (que es 'valor')
            //   :F2 significa "Formato Fijo con 2 decimales".
            //   Con 'decimal', esto aplica la regla 'Round Half to Even' de forma EXACTA.
            string formatoCompuesto = string.Format("{0:F2}", valor);

            // --- MÉTODO 2: Cadena Interpolada ---
            // La interpolación de cadenas usa el símbolo $ al inicio.
            // Dentro de las llaves {}, colocamos la variable 'valor' seguido del formato :F2.
            // El compilador traduce esto internamente a una llamada a string.Format, por lo que el resultado es idéntico.
            string interpolada = $"{valor:F2}";

            // --- COMPARACIÓN ---
            // Comparamos si la cadena generada por el método clásico es idéntica a la generada por interpolación.
            bool sonIguales = formatoCompuesto == interpolada;

            // Imprimimos la fila de resultados en la consola.
            // Concatenamos varias cadenas con el operador + para formar la línea completa.
            // {0,10} significa: primer argumento, ancho de columna 10, alineado a la derecha (el numero es positivo)
            // Usamos {formatoCompuesto,10} para alinear el resultado del método 1.
            // Usamos {interpolada,10} para alinear el resultado del método 2.
            // SonIguales se imprime tal cual (true/false).
            Console.WriteLine($"Valor original: {valor,10} | " +
                              $"Compuesto: {formatoCompuesto,10} | " +
                              $"Interpolada: {interpolada,10} | " +
                              $"Iguales: {sonIguales}");
        }

        // --- SECCIÓN DE EXPLICACIÓN FINAL ---
        // Imprimimos una nota para explicar el comportamiento observado
        Console.WriteLine("\nNota importante:");
        Console.WriteLine("Cuando se usa ToString(\"F2\") o string.Format(\"{0:F2}\", valor)");
        Console.WriteLine("C# utiliza una lógica de REDONDEO matemático tradicional donde el 5 siempre sube.");
        Console.WriteLine("Por lo que el valor NO SE TRUNCA.");
        Console.WriteLine("En C#: El truncamiento se logra con: ");
        Console.WriteLine("Math.Truncate(valor * 100) / 100.0.");
        Console.WriteLine("\nEjemplo: 1.239 SE REDONDEA en 1.24 (9 ≥ 5, sube).");
        Console.WriteLine("En lugar de TRUNCARSE a 1.23 (cortando el 9).");
    }
}

/*Nota:
Conclusiones:
- Equivalencia: el formato clásico string.Format("{0:F2}", valor) y
la interpolación $"{valor:F2}" producen exactamente el mismo resultado.
- Cuando se usa ToString("F2") o string.Format("{0:F2}", valor), 
C# utiliza una lógica de redondeo matemático tradicional donde el 5 siempre sube).

Redondeo vs Truncamiento:

- Truncamiento (Truncation)
Es el proceso de cortar los dígitos decimales a partir de una posición específica 
sin hacer ningún cálculo matemático. Simplemente se ignoran los dígitos restantes.
Lógica: "Toma los dígitos hasta el punto deseado y desecha el resto".
En C#: Se logra con Math.Truncate(valor * 100) / 100.0.

- Redondeo (Rounding)
Es el proceso de encontrar el valor más cercano a un número específico. 
Si el número está exactamente a mitad de camino entre dos valores, se aplica una regla
para decidir hacia dónde ir (hacia arriba o hacia abajo).
Lógica(:F2): "Mira el primer dígito que vas a eliminar. Si es 5 o mayor, sube el último dígito retenido. 
Si es menor que 5, déjalo igual".

¿Por qué es importante esta distinción?
La diferencia entre "Truncamiento" y "Redondeo hacia abajo" se nota claramente en un caso como 1.239:
- Truncamiento:   1.239 se convierte en 1.23 (corta el 9).
- Redondeo (:F2): 1.239 se convierte en 1.24 (porque el 9 es mayor a 5, sube).
*/
