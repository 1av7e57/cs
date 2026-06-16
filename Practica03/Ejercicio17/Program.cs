/*¿Cuál es la salida por consola del siguiente programa?*/

// Bloque principal de prueba que llama a los métodos y captura excepciones globales

try
{
    Metodo1();
}
catch
{
    // Captura la excepción propagada desde Metodo1 (que no la atrapó localmente)
    Console.WriteLine("Método 1 propagó una excepción no tratada");
}

try
{
    Metodo2();
}
catch
{
    // Captura la excepción propagada desde Metodo2 (su catch local no coincidió)
    Console.WriteLine("Método 2 propagó una excepción no tratada");
}

try
{
    Metodo3();
}
catch
{
    // Captura la excepción re-lanzada desde Metodo3
    Console.WriteLine("Método 3 propagó una excepción");
}

void Metodo1()
{
    object obj = "hola";
    try
    {
        // Intento de conversión inválida: string a int
        // Esto lanza InvalidCastException
        int i = (int)obj;
    }
    finally
    {
        // El bloque finally SE EJECUTA SIEMPRE, incluso si hubo una excepción no atrapada.
        // Esto asegura limpieza de recursos o registro de logs antes de que la excepción suba.
        Console.WriteLine("Bloque finally en Metodo1");
    }
    // La excepción continúa propagándose hacia arriba ya que no hay catch aquí
}

void Metodo2()
{
    object obj = "hola";
    try
    {
        // Intento de conversión inválida: string a int
        // Lanza InvalidCastException
        int i = (int)obj;
    }
    catch (OverflowException)
    {
        // Este bloque SOLO captura OverflowException.
        // Como la excepción real es InvalidCastException, este bloque se SALTA.
        Console.WriteLine("Overflow"); // Nunca se ejecuta
    }
    // La excepción InvalidCastException no fue atrapada, así que sube al llamador
}

void Metodo3()
{
    object obj = "hola";
    try
    {
        // Intento de conversión inválida: string a int
        // Lanza InvalidCastException
        int i = (int)obj;
    }
    catch (InvalidCastException)
    {
        // Este bloque COINCIDE con la excepción lanzada.
        Console.WriteLine("Excepción InvalidCast en Metodo3");
        
        // 'throw;' re-lanza la excepción ORIGINAL preservando la pila de llamadas (stack trace).
        // Si usáramos 'throw new...', se perdería el origen del error.
        throw; 
    }
    // Después de 'throw', la ejecución no continúa aquí; la excepción sube inmediatamente
}

/*
Salida por consola:

Bloque finally en Metodo1
Método 1 propagó una excepción no tratada
Método 2 propagó una excepción no tratada
Excepción InvalidCast en Metodo3
Método 3 propagó una excepción


Análisis paso a paso:

-Metodo1():
Se intenta castear "hola" (string) a int. Esto lanza InvalidCastException.
No hay un bloque catch en Metodo1, pero hay un bloque finally.
El bloque finally siempre se ejecuta, incluso si hay una excepción no atrapada. Por eso se imprime: Bloque finally en Metodo1.
La excepción se propaga hacia arriba.
El try-catch en Main (o donde esté el código principal) captura la excepción y ejecuta su catch.
Se imprime: Método 1 propagó una excepción no tratada.

-Metodo2():
Se intenta castear "hola" a int. Lanza InvalidCastException.
El catch en Metodo2 solo captura OverflowException.
Como el tipo de excepción no coincide, el catch se salta.
La excepción InvalidCastException se propaga hacia arriba.
El try-catch en Main captura la excepción y ejecuta su catch.
Se imprime: Método 2 propagó una excepción no tratada.
Nota: el catch de Metodo2 no imprime nada porque la excepción no es Overflow, 
así que la cadena "Overflow" nunca se ve).

-Metodo3():
Se intenta castear "hola" a int. Lanza InvalidCastException.
El catch (InvalidCastException) en Metodo3 sí coincide.
Se imprime: Excepción InvalidCast en Metodo3.
La instrucción throw; vuelve a lanzar la misma excepción original (preservando la pila de llamadas).
La excepción se propaga hacia arriba.
El try-catch en Main captura la excepción.
Se imprime: Método 3 propagó una excepción.

Conclusiones:
-finally se ejecuta siempre (Metodo1).
-Si el catch no coincide con el tipo de excepción, la excepción sigue subiendo (Metodo2).
-throw; re-lanza la excepción para que sea manejada en un nivel superior (Metodo3).

Aclaraciónes:
La expresión "re-lanzar la excepción" significa que el método (metodo3() en nuestro ejemplo)
maneja el error pero solo parcialmente (ej. imprimiendo un log), pero el problema sigue existiendo
y debe ser resuelto por el nivel superior del programa (generalmente Main() ).

Preservar el Origen del Error (Stack Trace)
Cuando se usa throw; dentro de un bloque catch, se re-lanza la misma excepción que fue capturada. 
Esto hace que el sistema mantenga intacta la ruta completa de cómo se llegó al error.
- Con throw;: El stack trace muestra: Main -> Metodo3 -> (Error ocurre aquí) 
Esto le dice al desarrollador exactamente dónde se originó el problema en el código.
- Con throw new Exception(...): Si creas una nueva excepción, el stack trace se reinicia.
Mostraría: Main -> Metodo3 -> (Nuevo objeto creado aquí) El origen real del error se pierde,
y se vería el error como si hubiera ocurrido en la línea del throw, no en la línea donde falló el cast.
*/
