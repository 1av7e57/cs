﻿/*Agregar a la clase Cuenta del ejercicio anterior un método estático GetCuentas() que devuelva un List<Cuenta> con todas las cuentas creadas. 
Controlar que la modificación de la lista devuelta, por ejemplo borrando algún elemento, no afecte el listado que internamente mantiene la clase Cuenta. 
Sin embargo. debe ser posible interactuar efectivamente con los objetos Cuenta de la lista devuelta. 
Verificar que el siguiente código produzca la salida por consola que se indica:

new Cuenta();
new Cuenta();
List<Cuenta> cuentas = Cuenta.GetCuentas();
// se recuperó la lista de cuentas creadas
cuentas[0].Depositar(50);
// se depositó 50 en la primera cuenta de la lista devuelta
cuentas.RemoveAt(0);
Console.WriteLine(cuentas.Count);
// se borró un elemento de la lista devuelta
// pero la clase Cuenta sigue manteniendo todos
// los datos "La cuenta id: 1 tiene 50 de saldo"
cuentas = Cuenta.GetCuentas();
Console.WriteLine(cuentas.Count);
// se recupera nuevamente la lista de cuentas
cuentas[0].Extraer(30);
//se extrajo 30 de la cuenta id: 1 que tenía 50 de saldo

Salida por consola:

Se creó la cuenta Id=1
Se creó la cuenta Id=2
Se depositó 50 en la cuenta 1 (Saldo=50)
1
2
Se extrajo 30 de la cuenta 1 (Saldo=20)*/

using System; // Importamos el namespace System, necesario para usar Console.WriteLine y otras funciones básicas del sistema.
using System.Collections.Generic; // Se incluye explícitamente para usar List<T>

// Clase principal con la nueva lógica de prueba
class Program
{
    // Método principal de entrada
    static void Main()
    {
        // Creamos dos cuentas
        new Cuenta();
        new Cuenta();

        // Obtenemos una COPIA de la lista de cuentas
        List<Cuenta> cuentas = Cuenta.GetCuentas();

        // Interactuamos con el objeto dentro de la lista (esto SÍ afecta al objeto real)
        cuentas[0].Depositar(50);
        // Salida esperada: Se depositó 50 en la cuenta 1 (Saldo=50)

        // Eliminamos un elemento de la lista DEVUELTA (la copia)
        cuentas.RemoveAt(0);
        
        // Mostramos el conteo de la lista devuelta (ahora es 1)
        Console.WriteLine(cuentas.Count); 
        // Salida esperada: 1

        // La clase Cuenta sigue manteniendo sus 2 cuentas internamente.
        // Recuperamos la lista de nuevo (otra copia fresca)
        cuentas = Cuenta.GetCuentas();
        
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
    
    // Variable estática para contar el total de extracciones exitosas
    static private int _totalExtracciones = 0;
    
    // Variable estática para acumular el monto total extraído
    static private decimal _montoTotalExtraido = 0;
    
    // Variable estática para contar extracciones denegadas
    static private int _extraccionesDenegadas = 0;

    // NUEVO: Lista interna estática que guarda TODAS las cuentas creadas
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
        
        // NUEVO: Guarda esta nueva instancia en la lista interna estática
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

    // NUEVO: Método estático para obtener la lista de cuentas
    public static List<Cuenta> GetCuentas()
    {
        // Devolvemos una NUEVA lista que contiene las mismas referencias a los objetos Cuenta.
        // Esto crea una "copia superficial" de la lista:
        // 1. La lista nueva es independiente (si la borran, _listaCuentas no se toca).
        // 2. Los objetos dentro (Cuenta) son los mismos (si modifican Saldo en la copia, afecta al original).
        return new List<Cuenta>(_listaCuentas);
    }
}

/*NOTAS: Aclaraciónes:
Para cumplir con el requisito de que modificar la lista devuelta no afecte la lista interna, 
pero que modificar los objetos SÍ afecte, la solución es devolver una copia nueva de la lista (snapshot), no la lista original.

Explicación de los Cambios Clave:

1. Añadimos una variable estática privada:
static private List<Cuenta> _listaCuentas = new List<Cuenta>();
En el constructor, cada vez que se crea new Cuenta(), la cuenta se añade a sí misma a esta lista:
public Cuenta()
{
    // ...
    _listaCuentas.Add(this); // Se guarda
    // ...
}
Esto asegura que la clase Cuenta siempre tenga un registro completo de todas las instancias creadas.

2. El Método GetCuentas() y la Protección de Datos
public static List<Cuenta> GetCuentas()
{
    return new List<Cuenta>(_listaCuentas);
}

¿Por qué esto es crucial?

- Escenario A (Sin copia, error de seguridad): Si hubiéramos hecho 
return _listaCuentas;, el usuario recibiría la misma lista. 
Si el usuario hiciera cuentas.Clear() o cuentas.RemoveAt(0), esto borraría las cuentas de la memoria interna de la clase.
La clase perdería el rastro de las cuentas creadas.

- Escenario B (Con copia, correcto): Al hacer new List<Cuenta>(_listaCuentas), creamos una nueva lista en memoria 
que contiene las mismas referencias a los objetos Cuenta.
    Si el usuario borra la lista devuelta (cuentas.RemoveAt(0)), solo borra la referencia en la copia. La lista interna _listaCuentas sigue intacta con todos los objetos.
    Si el usuario modifica un objeto (cuentas.Depositar(50)), está modificando el objeto real en memoria. Como la lista interna también apunta a ese mismo objeto, el cambio es visible para todos. Esto es lo que nos permite interactuar efectivamente con los objetos.

*/
