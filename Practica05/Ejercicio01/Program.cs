﻿/*Codificar la clase Cuenta de tal forma que el siguiente código produzca la salida por consola que
se indica.
código:
...
Cuenta c1 = new Cuenta();
c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
Cuenta c2 = new Cuenta();
c2.Depositar(200).Depositar(800);
new Cuenta().Depositar(20).Extraer(20);
c2.Extraer(1000).Extraer(1);
Console.WriteLine("\nDETALLE");
Cuenta.ImprimirDetalle();
...
Salida por consola:
Se creó la cuenta Id=1
Se depositó 100 en la cuenta 1 (Saldo=100)
Se depositó 50 en la cuenta 1 (Saldo=150)
Se extrajo 120 de la cuenta 1 (Saldo=30)
Operación denegada - Saldo insuficiente
Se creó la cuenta Id=2
Se depositó 200 en la cuenta 2 (Saldo=200)
Se depositó 800 en la cuenta 2 (Saldo=1000)
Se creó la cuenta Id=3
Se depositó 20 en la cuenta 3 (Saldo=20)
Se extrajo 20 de la cuenta 3 (Saldo=0)
Se extrajo 1000 de la cuenta 2 (Saldo=0)
Operación denegada - Saldo insuficiente

DETALLE
CUENTAS CREADAS: 3
DEPÓSITOS:       5  - Total depositado: 1170
EXTRACCIONES:    3  - Total extraído:   1140
                    - Saldo:              30

 * Se denegaron 2 extracciones por falta de fondos
*/

using System; // Importamos el namespace System, necesario para usar Console.WriteLine y otras funciones básicas del sistema.

// Clase principal que contiene la lógica de la aplicación
class Program
{
    // Método principal de entrada
    static void Main()
    {
        // Instancia c1 y realiza la cadena de operaciones solicitada
        Cuenta c1 = new Cuenta();
        c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
        
        // Instancia c2 y realiza sus operaciones
        Cuenta c2 = new Cuenta();
        c2.Depositar(200).Depositar(800);
        
        // Creación y operación de una cuenta anónima (sin asignar a variable)
        // Se crea una instancia temporal que recibe un ID único y se descarta al final.
        new Cuenta().Depositar(20).Extraer(20);
        
        // Operaciones finales sobre c2
        c2.Extraer(1000).Extraer(1);
        
        // Imprime un salto de línea y el título del detalle
        Console.WriteLine("\nDETALLE");
        
        // Llama al método estático para imprimir el resumen global
        Cuenta.ImprimirDetalle();
    }
}

// Definición de la clase Cuenta
class Cuenta
{
    // Variable estática para llevar el contador global de cuentas creadas
    static private int _cuentaContador = 0;
    
    // Variable estática para contar el total de depósitos exitosos
    static private int _totalDepositos = 0;
    
    // Variable estática para acumular el monto total depositado
    static private decimal _montoTotalDepositado = 0;
    
    // Variable estática para contar total de extracciones exitosas
    static private int _totalExtracciones = 0;
    
    // Variable estática para acumular el monto total extraído
    static private decimal _montoTotalExtraido = 0;
    
    // Variable estática para contar extracciones denegadas
    static private int _extraccionesDenegadas = 0;
    
    // Propiedad única para el identificador de la cuenta
    public int Id { get; private set; }
    
    // Propiedad para el saldo actual de la cuenta
    public decimal Saldo { get; private set; }

    // Constructor de la clase
    public Cuenta()
    {
        // Incrementa el contador global y asigna el nuevo ID
        _cuentaContador++;
        this.Id = _cuentaContador;
        this.Saldo = 0;
        
        // Imprime el mensaje de creación de la cuenta
        Console.WriteLine($"Se creó la cuenta Id={this.Id}");
    }

    // Método para depositar dinero
    // Retorna la instancia actual (this) para permitir encadenamiento
    public Cuenta Depositar(decimal cantidad)
    {
        // Asegura que la cantidad sea positiva
        if (cantidad <= 0) return this;

        // Actualiza el saldo de la instancia
        this.Saldo += cantidad;
        
        // Actualiza las estadísticas globales
        _totalDepositos++;
        _montoTotalDepositado += cantidad;
        
        // Imprime el mensaje de éxito
        Console.WriteLine($"Se depositó {cantidad} en la cuenta {this.Id} (Saldo={this.Saldo})");
        
        // Retorna la instancia actual para seguir encadenando métodos
        return this;
    }

    // Método para extraer dinero
    // Retorna la instancia actual (this) para permitir encadenamiento
    public Cuenta Extraer(decimal cantidad)
    {
        // Verifica si hay fondos suficientes
        if (this.Saldo >= cantidad)
        {
            // Resta la cantidad del saldo
            this.Saldo -= cantidad;
            
            // Actualiza las estadísticas globales de extracciones exitosas
            _totalExtracciones++;
            _montoTotalExtraido += cantidad;
            
            // Imprime el mensaje de éxito
            Console.WriteLine($"Se extrajo {cantidad} de la cuenta {this.Id} (Saldo={this.Saldo})");
        }
        else
        {
            // Si no hay fondos, incrementa el contador de denegaciones
            _extraccionesDenegadas++;
            
            // Imprime el mensaje de error
            Console.WriteLine("Operación denegada - Saldo insuficiente");
        }
        
        // Retorna la instancia actual para seguir encadenando métodos
        return this;
    }

    // Método estático para imprimir el resumen global de todas las cuentas
    public static void ImprimirDetalle()
    {
        // Imprime el total de cuentas creadas
        Console.WriteLine($"CUENTAS CREADAS: {_cuentaContador}");
        
        // Imprime la línea de depósitos con formato
        Console.WriteLine($"DEPÓSITOS:       {_totalDepositos}  - Total depositado: {_montoTotalDepositado}");
                    
        // Imprime la línea de extracciones con formato alineado
        Console.WriteLine($"EXTRACCIONES:    {_totalExtracciones}  - Total extraído:   {_montoTotalExtraido}");

        // Calcula el balance global (Total depositado - Total extraído)
        decimal saldoGlobal = _montoTotalDepositado - _montoTotalExtraido;
        
        // Imprime el saldo global final con la misma indentación visual
        Console.WriteLine($"                    - Saldo:              {saldoGlobal}");
        
        // Imprime el total de operaciones denegadas si hay alguna
        if (_extraccionesDenegadas > 0)
        {
            Console.WriteLine($" * Se denegaron {_extraccionesDenegadas} extracciones por falta de fondos");
        }
    }
}

/*NOTAS: 
Aclaraciónes sobre el uso de this:
El uso de this en este código es el mecanismo fundamental que permite el encadenamiento de métodos (method chaining), 
una técnica de programación que hace que el código sea más legible y conciso.

¿Qué es this?
En C# (y en la mayoría de los lenguajes orientados a objetos), this es una referencia especial que apunta a la instancia actual del objeto 
que está ejecutando el código.
Si se tiene una clase Cuenta, cuando se crea Cuenta c1 = new Cuenta();, el sistema crea un objeto en memoria.
Dentro de los métodos de ese objeto (como Depositar), la palabra this se refiere específicamente a esa cuenta c1.
Si se ejecuta el mismo código en c2, this se referirá a c2.

¿Por qué es vital en este ejercicio?
El requisito del ejercicio es permitir esta sintaxis:
c1.Depositar(100).Depositar(50).Extraer(120);

-El problema de los métodos que no retornan nada:
Usando métodos con un tipo de retorno vacío (void) esto no funcionaría. ¿Por qué?
Cuando se ejecuta c1.Depositar(100), el método se ejecuta, modifica el saldo y termina. 
El resultado de esa operación sería void (nada). Si se intenta encadenar:
El compilador sería incapaz de llamar a .Depositar(50) sobre 'nada'.

-La solución: Retornar la instancia actual
Para solucionar esto, cambiamos el tipo de retorno del método a la misma clase (Cuenta) y retornamos this:

Importante a tener en cuenta:
La firma del método es fundamental y es la razón técnica por la que el encadenamiento es posible.
Cuando se declara:
public Cuenta Depositar(decimal cantidad)
Se está referenciando explícitamente el tipo de retorno esperado.
- La palabra Cuenta al inicio de la firma (antes del nombre del método) le dice al compilador:
"Este método promete devolver un objeto de tipo Cuenta".
- Validación del return this;
Dentro del cuerpo del método, la línea return this; es compatible con la firma declarada.
 Firma: Dice que se devuelve un Cuenta.
 Código: this es una referencia al objeto actual, que es de tipo Cuenta.
 Resultado: El compilador verifica que this coincide con el tipo Cuenta prometido en la firma. 
Si la firma dijera public void Depositar... y se intentara hacer return this;, el compilador daría un error inmediato 
porque void no puede retornar valores.

¿Qué sucede paso a paso al ejecutar c1.Depositar(100).Depositar(50);?
-Primera llamada: c1.Depositar(100) se ejecuta.
this apunta a c1.
Se suma 100 al saldo de c1.
El método retorna c1 (gracias a return this;).
-El encadenamiento: El compilador recibe c1 como resultado de la primera llamada.
-Segunda llamada: Inmediatamente llama a .Depositar(50) sobre el objeto recibido (que es c1).
this sigue apuntando a c1.
Se suma 50.
Retorna c1 de nuevo.

¿Qué sucede al crear una cuenta nueva?
Cada vez que se crea una nueva cuenta (new Cuenta()), se crea un objeto completamente nuevo e independiente en la memoria. 
En ese nuevo objeto, this apunta a esa nueva cuenta, no a la anterior.

¿Por qué this cambia?
this es una referencia dinámica e instantánea. No es una variable global que apunta a "la cuenta que se esté usando actualmente". 
Es una referencia relativa al objeto específico que ejecutó el método.
Si c1 llama al método -> this = c1.
Si c2 llama al método -> this = c2.
Si una cuenta anónima new Cuenta().Depositar(10) llama al método -> this = esa cuenta anónima.

¿Son independientes?
Sí, absolutamente. Son objetos separados en la memoria.
Nunca se mezclan. La Cuenta #1 no sabe nada de lo que hace la Cuenta #2, y viceversa, 
excepto por las variables estáticas (_cuentaContador, _totalDepositos, etc.) que son globales y compartidas por todas las instancias.

Conclusión: el uso de this en este código permite:
-Legibilidad (Fluidez): Permite leer el código como una narrativa: "Crea cuenta, deposita 100, luego deposita 50, luego extrae 120". Sin esto, tendrías que escribir cada línea en una línea separada, lo cual es más repetitivo y menos elegante.
-Estado Interno: Al retornar this, garantizamos que todas las operaciones en la cadena se apliquen al mismo objeto en memoria. Si el método retornara null o una copia, la cadena se rompería o modificaría un objeto incorrecto.
-Reutilización: Permite crear flujos de trabajo complejos en una sola línea, como se ve en c2.Extraer(1000).Extraer(1).
*/
