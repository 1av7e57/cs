﻿/*Reemplazar el método estático GetCuentas() del ejercicio anterior por una propiedad estática de sólo lectura.*/

using System; // Importamos el namespace System
using System.Collections.Generic; // Necesario para List<T>

// Clase principal con la nueva lógica de prueba (Modificada)
class Program
{
    // Método principal de entrada
    static void Main()
    {
        // Creamos dos cuentas
        new Cuenta();
        new Cuenta();

        // Obtenemos la lista a través de la PROPIEDAD estática (sin paréntesis)
        List<Cuenta> cuentas = Cuenta.Cuentas;

        // Interactuamos con el objeto dentro de la lista (esto SÍ afecta al objeto real)
        cuentas[0].Depositar(50);
        // Salida esperada: Se depositó 50 en la cuenta 1 (Saldo=50)

        // Eliminamos un elemento de la lista DEVUELTA (la copia)
        cuentas.RemoveAt(0);
        
        // Mostramos el conteo de la lista devuelta (ahora es 1)
        Console.WriteLine(cuentas.Count); 
        // Salida esperada: 1

        // La clase Cuenta sigue manteniendo sus 2 cuentas internamente.
        // Recuperamos la lista de nuevo (otra copia fresca a través de la propiedad)
        cuentas = Cuenta.Cuentas;
        
        // Mostramos el conteo de la nueva lista (debería ser 2)
        Console.WriteLine(cuentas.Count);
        // Salida esperada: 2

        // Interactuamos con el objeto nuevamente
        cuentas[0].Extraer(30);
        // Salida esperada: Se extrajo 30 de la cuenta 1 (Saldo=20)
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

    // Lista interna estática que guarda TODAS las cuentas creadas
    // Es privada para que nadie pueda acceder a ella directamente
    static private List<Cuenta> _listaCuentas = new List<Cuenta>();
    
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
        
        // Guarda esta nueva instancia en la lista interna estática
        _listaCuentas.Add(this);
        
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

    // CAMBIO PRINCIPAL: Propiedad estática de solo lectura en lugar del método GetCuentas()
    // Se usa { get; } sin set, lo que la hace de solo lectura.
    // El cuerpo del get devuelve una COPIA de la lista para proteger la interna.
    public static List<Cuenta> Cuentas 
    { 
        get 
        { 
            // Retornamos una nueva lista instanciada con el contenido de _listaCuentas
            return new List<Cuenta>(_listaCuentas); 
        } 
    }
}

/*NOTAS:
Se ha transformado el método GetCuentas() en una propiedad estática de solo lectura (get; sin set;)
La propiedad de solo lectura se define como: public static List<Cuenta> Propiedad { get; }

La clave aquí es que el get debe devolver la misma lógica de protección (la copia de la lista) para mantener la seguridad de los datos internos.

Cambios Clave Explicados:
1. De Método a Propiedad:
Antes: public static List<Cuenta> GetCuentas() { ... } (Se llamaba con paréntesis: Cuenta.GetCuentas()).
Ahora: public static List<Cuenta> Cuentas { get { ... } } (Se accede como una variable: Cuenta.Cuentas).
Diferencia en la semántica del código: ahora Cuentas suena como un atributo del sistema, no como una acción.

2. Uso de solo Lectura:
Al definir solo el get y omitir el set, impedimos que alguien intente hacer algo como Cuenta.Cuentas = new List<Cuenta>(); desde fuera. 
Esto fuerza a que la lista interna se gestione únicamente a través del constructor y el acceso de lectura protegido.

3. Lógica de Seguridad (Dentro del get):
La línea return new List<Cuenta>(_listaCuentas); se mantiene dentro del accesador get.
Esto garantiza que cada vez que se accede a la propiedad Cuenta.Cuentas, se obtenga una nueva copia de la lista.
Si se eliminara esto y se usara return _listaCuentas;, la propiedad ya no sería segura y permitiría modificar la lista interna directamente,
rompiendo el encapsulamiento.

4. El comportamiento en Main() cambia ligeramente en la sintaxis de llamada (sin paréntesis), 
pero la lógica de ejecución y la salida en consola son idénticas a las anteriores.
Este cambio de sintaxis refleja una diferencia fundamental en cómo C# interpreta acciones (métodos) versus datos (propiedades).

a. La Diferencia Conceptual

Método (GetCuentas()): Representa una acción o un proceso.
En programación, cuando usamos paréntesis (), decimos al compilador: "Ejecuta el código dentro de esta función y dame el resultado".
Sintaxis: NombreClase.NombreMetodo()

Propiedad (Cuentas): Representa un valor o un estado.
No es una acción que realiza, es algo que es o que tiene.
En programación, cuando accedemos a una propiedad, estamos leyendo un valor directamente, como si fuera una variable. No hay "ejecución" visible, solo obtención de datos.
Sintaxis: NombreClase.NombrePropiedad (sin paréntesis)

b. El cambio de Sintaxis

En el caso del Método: Cuenta.GetCuentas()
Los paréntesis son OBLIGATORIOS.
Los paréntesis le dicen al compilador: "Invoca la función". Sin ellos, se estaría intentando referenciar el método en sí (el bloque de código), no el resultado que devuelve.

En el caso de la Propiedad: Cuenta.Cuentas
Los paréntesis NO son necesarios.

Una propiedad es un "atajo" inteligente. Cuando se escribe Cuenta.Cuentas, el compilador ve eso y automáticamente ejecuta internamente el código dentro del get { ... }.
La propiedad se comporta exactamente como una variable pública, pero con la ventaja de que detrás de escena ejecuta el código de protección (new List<Cuenta>(_listaCuentas)).
*/
