/*Implementar un programa calculadora que calcule una expresión ingresada por el usuario
correspondiente a una operación binaria de las cuatro elementales (ejemplo “44.5/456”,
“456*45”, “549-12”, “54+6” ). Utilizar try/catch para validar los números y controlar
cualquier tipo de excepción que pudiese ocurrir en la evaluación de la expresión.*/

// Importamos el namespace System para acceder a las clases básicas como Console, Convert, etc.
using System;

// Definimos la clase principal del programa
class Program
{
    // Método principal donde comienza la ejecución del programa
    static void Main()
    {
        // Declaramos una variable de tipo string para almacenar la expresión ingresada por el usuario
        string? expresion;

        // Declaramos variables de tipo double para almacenar los operandos y el resultado
        double numero1, numero2, resultado;

        // Declaramos una variable de tipo char para almacenar el operador ingresado
        char operador;

        // Mostramos un mensaje al usuario indicando qué debe ingresar
        Console.WriteLine("Ingresa una expresión con dos números y un operador (+, -, *, /):");

        // Leemos la entrada del usuario y la almacenamos en la variable expresion, eliminando espacios extra
        // Usamos el operador ! para indicar que asumimos que no es null confiando en la verificación de vacío
        expresion = Console.ReadLine()!.Trim();

        // Iniciamos un bloque try para capturar posibles excepciones durante la validación y cálculo
        try
        {
            // Verificamos si la expresión está vacía o nula antes de continuar
            if (string.IsNullOrEmpty(expresion))
            {
                // Si está vacía, lanzamos una excepción personalizada con un mensaje descriptivo
                throw new ArgumentException("La expresión no puede estar vacía.");
            }

            // Intentamos buscar la posición del operador (+, -, *, /) en la cadena
            int posicionOperador = -1;
            char operadorEncontrado = '\0';

            // Recorremos la cadena caractér por caaractér para encontrar el primer operador válido
            for (int i = 0; i < expresion.Length; i++)
            {
                // Verificamos si el caractér actual es uno de los operadores permitidos
                if (expresion[i] == '+' || expresion[i] == '-' || expresion[i] == '*' || expresion[i] == '/')
                {
                    // Si es el primer operador encontrado, guardamos su posición y valor
                    if (posicionOperador == -1)
                    {
                        posicionOperador = i;
                        operadorEncontrado = expresion[i];
                    }
                    else
                    {
                        // Si encontramos un segundo operador, lanzamos una excepción porque la expresión no es binaria válida
                        throw new FormatException("La expresión contiene más de un operador. Solo se permiten operaciones binarias.");
                    }
                }
            }

            // Verificamos si se encontró algún operador en la expresión
            if (posicionOperador == -1)
            {
                // Si no se encontró operador, lanzamos una excepción indicando el error
                throw new FormatException("No se encontró ningún operador válido (+, -, *, /) en la expresión.");
            }

            // Verificamos que haya caracteres antes y después del operador para los dos números
            if (posicionOperador == 0 || posicionOperador == expresion.Length - 1)
            {
                // Si el operador está al inicio o al final, lanzamos una excepción
                throw new FormatException("La expresión debe contener dos números válidos separados por un operador.");
            }

            // Extraemos la parte de la cadena correspondiente al primer número
            // Empezando desde el índice 0 hasta la posición del operador
            string parte1 = expresion.Substring(0, posicionOperador);

            // Extraemos la parte de la cadena correspondiente al segundo número
            // Empezando justo después de la posición del operador
            string parte2 = expresion.Substring(posicionOperador + 1);

            // Convertimos la primera parte a número double,
            // esto puede lanzar una excepción si no es un número válido
            // en cuyo caso, el programa deja de ejecutar el código normal inmediatamente 
            // y salta al bloque catch correspondiente.
            numero1 = double.Parse(parte1);

            // Convertimos la segunda parte a número double, 
            // esto también puede lanzar una excepción
            // que se maneja igualmente desde el bloque catch 
            numero2 = double.Parse(parte2);

            // Asignamos el operador encontrado a la variable operador
            operador = operadorEncontrado;

            // Seleccionamos la operación a realizar según el operador encontrado
            switch (operador)
            {
                // Caso para la suma
                case '+':
                    // Calculamos la suma de los dos números
                    resultado = numero1 + numero2;
                    break;

                // Caso para la resta
                case '-':
                    // Calculamos la resta de los dos números
                    resultado = numero1 - numero2;
                    break;

                // Caso para la multiplicación
                case '*':
                    // Calculamos la multiplicación de los dos números
                    resultado = numero1 * numero2;
                    break;

                // Caso para la división
                case '/':
                    // Verificamos si el segundo número es cero para evitar división por cero explícita
                    // Esto suele evita que el resultado sea Infinito, pero usaremos la lógica posterior
                    // para capturar Infinito si ocurre por otros medios
                    if (numero2 == 0)
                    {
                        // Si es cero, lanzamos una excepción específica para controlarlo como error de usuario
                        throw new DivideByZeroException("No se puede dividir por cero.");
                    }
                    // Calculamos la división de los dos números
                    resultado = numero1 / numero2;
                    break;

                // Caso por defecto si el operador no es reconocido (aunque ya fue validado antes)
                default:
                    // Lanzamos una excepción indicando que el operador no es válido
                    throw new InvalidOperationException("Operador no válido.");
            }

            // --- Verificación post-cálculo para Infinito y NaN ---

            // Verificamos si el resultado es infinito (positivo o negativo)
            if (double.IsInfinity(resultado))
            {
                // Lanzamos una excepción personalizada para manejar el caso infinito
                throw new ArithmeticException("El resultado es incorrecto. La operación matemática excede los límites numéricos.");
            }

            // Verificamos si el resultado es NaN (Not a Number)
            if (double.IsNaN(resultado))
            {
                // Lanzamos una excepción personalizada para manejar el caso NaN
                throw new ArithmeticException("El resultado No es un número (NaN). La operación matemática es indefinida.");
            }

            // Mostramos el resultado de la operación al usuario solo si es un número válido y finito
            Console.WriteLine($"El resultado de {numero1} {operador} {numero2} es: {resultado}");
        }
        // Manejamos la excepción de división por cero específicamente
        catch (DivideByZeroException ex)
        {
            // Mostramos un mensaje de error amigable al usuario
            Console.WriteLine($"Error de división: {ex.Message}");
        }
        // Manejamos la excepción aritmética para Infinity y NaN
        catch (ArithmeticException ex)
        {
            // Mostramos el mensaje específico de infinito o NaN
            Console.WriteLine($"Error matemático: {ex.Message}");
        }
        // Manejamos la excepción de formato (números no válidos, expresión mal formada)
        catch (FormatException ex)
        {
            // Mostramos un mensaje de error indicando que el formato es incorrecto
            Console.WriteLine($"Error de formato: {ex.Message}");
        }
        // Manejamos la excepción de argumento inválido (expresión vacía, etc.)
        catch (ArgumentException ex)
        {
            // Mostramos un mensaje de error indicando un argumento inválido
            Console.WriteLine($"Error de argumento: {ex.Message}");
        }
        // Manejamos cualquier otra excepción no prevista
        catch (Exception ex)
        {
            // Mostramos un mensaje de error genérico con los detalles de la excepción
            Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
        }
    }
}
