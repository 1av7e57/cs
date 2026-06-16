/*Codificar una clase llamada Ecuacion2 para representar una ecuación de 2o grado. Esta clase debe tener 3
campos privados, los coeficientes a, b y c de tipo double. La única forma de establecer los valores de estos
campos será en el momento de la instanciación de un objeto Ecuacion2.

Codificar los siguientes métodos:
- GetDiscriminante(): devuelve el valor del discriminante (double), el discriminante tiene la siguiente
formula, (b^2)-4*a*c.
- GetCantidadDeRaices(): devuelve 0, 1 ó 2 dependiendo de la cantidad de raíces reales que posee la
ecuación. Si el discriminante es negativo no tiene raíces reales, si el discriminante es cero tiene una
única raíz, si el discriminante es mayor que cero posee 2 raíces reales.
- ImprimirRaices(): imprime la única o las 2 posibles raíces reales de la ecuación. En caso de no poseer
soluciones reales debe imprimir una leyenda que así lo especifique.
*/

using System; // Importamos el namespace System para usar la clase Console y Math

class Ecuacion2 // Definimos la clase Ecuacion2
{
    // Definimos los tres campos privados a, b y c de tipo double
    private double a; // Campo privado para el coeficiente a
    private double b; // Campo privado para el coeficiente b
    private double c; // Campo privado para el coeficiente c

    // Constructor para instanciar el objeto y establecer los valores de a, b y c
    public Ecuacion2(double coefA, double coefB, double coefC)
    {
        // Validación: El coeficiente 'a' no puede ser 0 en una ecuación de segundo grado
        if (coefA == 0) // Si el coeficiente 'a' es igual a 0
        {
            // Lanzamos una excepción para detener la ejecución y avisar del error
            throw new ArgumentException("El coeficiente 'a' no puede ser 0 en una ecuación de segundo grado.");
        }
        // Si la validación pasa, asignamos los valores a los campos privados
        a = coefA; // Asignamos el valor de coefA al campo privado a
        b = coefB; // Asignamos el valor de coefB al campo privado b
        c = coefC; // Asignamos el valor de coefC al campo privado c
    }

    // Método para obtener el valor del discriminante
    public double GetDiscriminante()
    {   
        // Calculamos el discriminante usando la formula (b^2 - 4*a*c)
        double discriminante = (b * b) - (4 * a * c);
        return discriminante; // Devolvemos el valor calculado del discriminante
    }

    // Método para determinar la cantidad de raíces reales
    public int GetCantidadDeRaices()
    {
        double delta = GetDiscriminante(); // Obtenemos el valor del discriminante llamando al método anterior
        if (delta < 0) // Si el discriminante es negativo
        {
            return 0; // La ecuación no tiene raíces reales, devolvemos 0
        }
        else if (delta == 0) // Si el discriminante es igual a cero
        {
            return 1; // La ecuación tiene una única raíz real, devolvemos 1
        }
        else // Si el discriminante es mayor que cero
        {
            return 2; // La ecuación tiene dos raíces reales, devolvemos 2
        }
    }

    // Método para imprimir las raíces reales de la ecuación
    public void ImprimirRaices()
    {
        double delta = GetDiscriminante(); // Obtenemos el valor del discriminante
        int cantidad = GetCantidadDeRaices(); // Obtenemos la cantidad de raíces

        if (cantidad == 0) // Si no hay raíces reales
        {
            Console.WriteLine("La ecuación no tiene soluciones reales."); // Imprimimos el mensaje correspondiente
        }
        else if (cantidad == 1) // Si hay una sola raíz real
        {
            double raiz = -b / (2 * a); // Calculamos la única raíz usando la formula -b / 2a 
            // Convertimos la raíz a string con 2 decimales para una salida más limpia
            Console.WriteLine("La única raíz real es: " + raiz.ToString("F2")); 
        }
        else // Si hay dos raíces reales
        {   
            // Usamos la fórmula completa: (-b ± raiz(b^2 - 4*a*c)) / (2*a)
            double raiz1 = (-b + Math.Sqrt(delta)) / (2 * a); // Calculamos la primera raíz usando la formula completa
            double raiz2 = (-b - Math.Sqrt(delta)) / (2 * a); // Calculamos la segunda raíz usando la formula completa
            // Convertimos ambas raíces a string con 2 decimales
            Console.WriteLine("Las raíces reales son: " + raiz1.ToString("F2") + " y " + raiz2.ToString("F2"));
        }
    }
}

class Program // Clase principal, punto de entrada del programa
{
    static void Main() // Método principal, donde comienza la ejecución del programa
    {
        try // Bloque try para capturar posibles excepciones del constructor
        {
            // Creamos un objeto de la clase Ecuacion2 con coeficientes de ejemplo
            // Por ejemplo: x^2 - 5x + 6 = 0 (a=1, b=-5, c=6)
            Ecuacion2 ecuacionA = new Ecuacion2(1, -5, 6);
            // Imprimimos un encabezado:
            Console.WriteLine("\n--- Prueba Discriminante > 0 (Dos raíces posibles) ---");
            Console.WriteLine("Ejemplo: x^2 - 5x + 6 = 0 (a=1, b=-5, c=6)");
            // Imprimimos el discriminante para verificar
            Console.WriteLine("El discriminante es: " + ecuacionA.GetDiscriminante());
            // Imprimimos la cantidad de raíces
            Console.WriteLine("Cantidad de raíces reales: " + ecuacionA.GetCantidadDeRaices());
            // Imprimimos las raíces
            ecuacionA.ImprimirRaices();

            // Probamos con otra ecuación que no tenga raíces reales: x^2 + 1 = 0 (a=1, b=0, c=1)
            Console.WriteLine("\n--- Prueba Discriminante < 0 (Sin raíces reales) ---");
            Console.WriteLine("Ejemplo: x^2 + 1 = 0 (a=1, b=0, c=1)");
            Ecuacion2 ecuacionB = new Ecuacion2(1, 0, 1);
            Console.WriteLine("El discriminante es: " + ecuacionB.GetDiscriminante());
            Console.WriteLine("Cantidad de raíces reales: " + ecuacionB.GetCantidadDeRaices());
            ecuacionB.ImprimirRaices();

            // Creamos una nueva instancia de Ecuacion2 con coeficientes que den discriminante 0
            // Ejemplo: 1x^2 - 4x + 4 = 0  (que es (x-2)^2 = 0, solución x=2)
            Ecuacion2 ecuacionC = new Ecuacion2(1, -4, 4);
            // Imprimimos un encabezado para identificar esta prueba
            Console.WriteLine("\n--- Prueba Discriminante = 0 (Una sola raíz posible) ---");
            Console.WriteLine("Ejemplo: 1x^2 - 4x + 4 = 0 (a=1, b=-4, c=4)");
            // Mostramos el valor del discriminante calculado
            Console.WriteLine("El discriminante es: " + ecuacionC.GetDiscriminante());
            // Mostramos cuántas raíces hay según el método
            Console.WriteLine("Cantidad de raíces reales: " + ecuacionC.GetCantidadDeRaices());
            // Llamamos al método que imprime la solución
            ecuacionC.ImprimirRaices();

            Console.WriteLine("\n--- Prueba de Validación (a = 0) ---");
            Ecuacion2 ecuacionInvalida = new Ecuacion2(0, 2, 3); // Esto lanzará una excepción
            ecuacionInvalida.ImprimirRaices();
        }
        catch (ArgumentException ex) // Bloque catch para manejar la excepción si 'a' es 0
        {
            // Imprimimos el mensaje de error con el detalle de la excepción
            Console.WriteLine("Error: " + ex.Message);
        }

        // El programa puede continuar aquí sin problemas
        Console.WriteLine("\nEl programa continúa ejecutándose correctamente...");
    }
}

/*Notas:

Formula cuadrática (sirve para hallar el valor de x )
x = (-b ± raiz(b^2 - 4*a*c)) / (2*a)

ecuación de ejemplo:
x^2 - 5x + 6 = 0

valores:
a = 1
b = -5
c = 6

calculamos discriminante (Δ) (sirve saber si hay valores posibles para x y cuántos)
(b^2 - 4*a*c)
b^2 = (-5)^2 = 25
4*a*c = 4 * 1 * 6 = 24
Resultado: 25 - 24 = 1

El hecho de que el discriminante (el resultado 1) sea positivo nos dice cuántas soluciones hay (dos) y de qué tipo son (reales)

Regla:
-si Δ > 0 (Es positivo):La raíz cuadrada de un número positivo existe y da dos resultados distintos.
-si Δ = 0 (Es cero):La raíz cuadrada de cero es cero. El "más menos" desaparece porque +0 y -0 son lo mismo.
Conclusión: La ecuación tiene una sola solución real.
-si Δ < 0 (Es negativo):La ecuación no tiene solución en los números reales. (Para resolverla necesitarías usar números imaginarios, un tema más avanzado).

Sustituimos a, b y el valor de Δ en la fórmula:
x = (-  b  ± raiz( b^2 - 4*a*c)) / (2*a)
x = (-  b  ± raiz(-5^2 - 4*1*6)) / (2*1)
x = (-(-5) ± √   (      1     )) / (2*1)
x = (-(-5) ± √1) / (2 * 1)

Simplificamos lo que está dentro:
-(-5) se convierte en +5.
√1 es 1.
2 * 1 es 2.
La ecuación queda: x = (5 ± 1) / 2

Resolver el "más o menos" (±)
-Primera solución (con el más): x₁ = (5 + 1) / 2 x₁ = 6 / 2 x₁ = 3
-Segunda solución (con el menos): x₂ = (5 - 1) / 2 x₂ = 4 / 2 x₂ = 2

Conclusión:
De ahí es de donde sabemos que las soluciones son 
x = 3 
y
x = 2

Resumen:
- El Discriminante (b^2 - 4*a*c) es el "detector" que nos dice si hay soluciones y cuántas.
- La Fórmula General es la "calculadora" que nos da los valores exactos de las soluciones.
*/
