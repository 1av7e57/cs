// Este archivo es el punto de entrada de la aplicación.

// Importamos el espacio de nombres donde se define la clase 'Calculador'
using CalculoSimple;

// Creamos una instancia directa de la clase 'Calculador'.
// PROBLEMA: Aquí estamos creando la dependencia internamente (hardcoded).
// La clase 'Calculador' es responsable de crear su propio 'Logger'.
Calculador calc = new Calculador();

// Invocamos el método 'Calcular' pasando el número 3.
// La lógica de negocio (cálculo) y el registro (logging) están fuertemente acoplados.
calc.Calcular(3);

/*NOTAS:
Análisis Inicial del Problema: puntos clave que violan el DIP:
    -Dependencia Concreta: Calculador instancia directamente new Logger().
    -Responsabilidad Única: Calculador se ocupa tanto de la 
    lógica de negocio (cálculo) como de la infraestructura (logging).
    -Falta de Abstracción: No hay una interfaz que Calculador pueda depender. 
    Si mañana se necesitára guardar el log en un archivo o en una base de datos, 
    se tendría que modificar Calculador.cs.
    -Dificultad de Pruebas (Testing): Es difícil hacer pruebas unitarias a Calculador 
    porque está fuertemente acoplado a logger (Si aplicamos Inyección de Dependencias, 
    Calculador dejaría de crear el Logger y lo recibiría desde afuera).
*/
