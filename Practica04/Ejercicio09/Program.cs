/*Completar la clase Cuenta para que el siguiente código produzca la salida indicada:

Nota: Utilizar en la medida de lo posible la sintaxis :this en el encabezado de los constructores para invocar a otro constructor ya definido

Cuenta cuenta = new Cuenta();
cuenta.Imprimir();
cuenta = new Cuenta(30222111);
cuenta.Imprimir();
cuenta = new Cuenta("José Perez");
cuenta.Imprimir();
cuenta = new Cuenta("Maria Diaz", 20287544);
cuenta.Imprimir();
cuenta.Depositar(200);
cuenta.Imprimir();
cuenta.Extraer(150);
cuenta.Imprimir();
cuenta.Extraer(1500);

class Cuenta
{
    private double _monto;
    private int _titularDNI;
    private string? _titularNobre;
. . .
}

Salida en consola:
Nombre: No especificado, DNI: No especificado, Monto: 0
Nombre: No especificado, DNI: 30222111, Monto: 0
Nombre: Jose Perez, DNI: No especificado, Monto: 0
Nombre: Maria Diaz, DNI: 20287544, Monto: 0
Nombre: Maria Diaz, DNI: 20287544, Monto: 200
Nombre: Maria Diaz, DNI: 20287544, Monto: 50

Operación cancelada, monto insuficiente
*/

using System; // Importamos el namespace System, necesario para usar Console.WriteLine y otras funciones básicas del sistema.

class Cuenta // Definimos la clase Cuenta, que representa una cuenta bancaria con propiedades y métodos.
{
    private double _monto; // Campo privado que almacena el saldo actual de la cuenta (puede tener decimales).
    private int _titularDNI; // Campo privado que almacena el DNI del titular (0 si no se especifica).
    private string? _titularNombre; // Campo privado nullable que almacena el nombre del titular (null si no se especifica).

    // Constructor por defecto: se llama cuando se crea una cuenta sin argumentos.
    // Usa 'this' para invocar al constructor principal con nombre "No especificado" y DNI 0.
    public Cuenta() : this("No especificado", 0) { }

    // Constructor con solo DNI: se llama cuando se proporciona un número de DNI.
    // Usa 'this' para invocar al constructor principal con nombre "No especificado" y el DNI proporcionado.
    public Cuenta(int dni) : this("No especificado", dni) { }

    // Constructor con solo nombre: se llama cuando se proporciona un nombre de titular.
    // Usa 'this' para invocar al constructor principal con el nombre proporcionado y DNI 0.
    public Cuenta(string nombre) : this(nombre, 0) { }

    // Constructor principal: recibe nombre y DNI, inicializa todos los campos.
    // Este es el único constructor que asigna valores directamente a los campos privados.
    public Cuenta(string nombre, int dni)
    {
        _titularNombre = nombre; // Asigna el nombre del titular al campo privado.
        _titularDNI = dni; // Asigna el DNI del titular al campo privado.
        _monto = 0; // Inicializa el saldo de la cuenta en 0.
    }

    // Método para depositar dinero en la cuenta.
    public void Depositar(double cantidad)
    {
        if (cantidad > 0) // Verifica que la cantidad a depositar sea positiva.
        {
            _monto += cantidad; // Suma la cantidad al saldo actual.
        }
        // Si la cantidad es 0 o negativa, no se realiza ninguna acción.
    }

    // Método para extraer dinero de la cuenta.
    public void Extraer(double cantidad)
    {
        if (cantidad > 0 && cantidad <= _monto) // Verifica que la cantidad sea positiva y no exceda el saldo disponible.
        {
            _monto -= cantidad; // Resta la cantidad del saldo actual.
        }
        else // Si no se cumplen las condiciones (monto insuficiente o cantidad inválida).
        {
            Console.WriteLine("Operación cancelada, monto insuficiente"); // Muestra mensaje de error en consola.
        }
    }

    // Método para mostrar la información de la cuenta en consola.
    public void Imprimir()
    {
        // Determina el nombre a mostrar: si es nulo o vacío, muestra "No especificado", sino el nombre real.
        string nombreDisplay = string.IsNullOrEmpty(_titularNombre) ? "No especificado" : _titularNombre;
        
        // Determina el DNI a mostrar: si es 0, muestra "No especificado", sino el DNI convertido a texto.
        string dniDisplay = _titularDNI == 0 ? "No especificado" : _titularDNI.ToString();

        // Imprime en consola el formato solicitado con los valores actuales.
        Console.WriteLine($"Nombre: {nombreDisplay}, DNI: {dniDisplay}, Monto: {_monto}");
    }
}

// Clase principal del programa, punto de entrada para la ejecución.
public class Program
{
    // Método Main: donde comienza la ejecución del programa.
    public static void Main()
    {
        // Crea una cuenta con valores por defecto (nombre y DNI no especificados, saldo 0).
        Cuenta cuenta = new Cuenta();
        cuenta.Imprimir(); // Muestra: Nombre: No especificado, DNI: No especificado, Monto: 0

        // Crea una cuenta solo con DNI (nombre no especificado, saldo 0).
        cuenta = new Cuenta(30222111);
        cuenta.Imprimir(); // Muestra: Nombre: No especificado, DNI: 30222111, Monto: 0

        // Crea una cuenta solo con nombre (DNI no especificado, saldo 0).
        cuenta = new Cuenta("José Perez");
        cuenta.Imprimir(); // Muestra: Nombre: Jose Perez, DNI: No especificado, Monto: 0

        // Crea una cuenta con nombre y DNI (saldo 0).
        cuenta = new Cuenta("Maria Diaz", 20287544);
        cuenta.Imprimir(); // Muestra: Nombre: Maria Diaz, DNI: 20287544, Monto: 0

        // Deposita 200 en la cuenta actual.
        // La variable 'cuenta' siempre apunta a la instancia (el objeto) que se creó más recientemente.
        cuenta.Depositar(200);
        cuenta.Imprimir(); // Muestra: Nombre: Maria Diaz, DNI: 20287544, Monto: 200

        //Extrae 150 de la cuenta actual (saldo suficiente).
        cuenta.Extraer(150);
        cuenta.Imprimir(); // Muestra: Nombre: Maria Diaz, DNI: 20287544, Monto: 50

        // Intenta extraer 1500, pero el saldo es insuficiente (50).
        cuenta.Extraer(1500); // Muestra: Operación cancelada, monto insuficiente
    }
}

/*NOTAS: 
Aclaraciónes:
C# sabe a qué cuenta depositar porque la variable cuenta siempre apunta a la instancia (el objeto) 
que se creó más recientemente. Aunque el nombre de la variable sea cuenta en todas las líneas, 
el objeto en memoria cambia.

Cuando Creamos la cuenta de María Díaz, la variable 'cuenta' apunta a este objeto ya que es el más reciente
y las demás cuentas quedan "sueltas" en la memoria sin ninguna variable apuntando a ellas. 
Luego, el recolector de basura de C# (Garbage Collector) las eliminará porque ya no se usan.

El compilador de C# no se confunde porque la variable es una referencia dinámica. 

Si se quisiera mantener las cuentas antiguas para usarlas después, 
tendrían que guardarse en variables con nombres diferentes desde un principio
Ejemplo:

Cuenta cuenta1 = new Cuenta();       // Etiqueta 1 apunta al Objeto 1
Cuenta cuenta2 = new Cuenta(30222111); // Etiqueta 2 apunta al Objeto 2

cuenta1.Depositar(200); // Modifica el Objeto 1
cuenta2.Depositar(500); // Modifica el Objeto 2

Alternativamente, si no se quiere cambiar el nombre de la variable principal 'cuenta',
la única otra forma es crear variables temporales o auxiliares para guardar una cuenta antes de perderla.
Ejemplo:

// 1. Creamos la cuenta de José y la guardamos en una variable temporal
Cuenta cuentaJose = new Cuenta("José Perez"); 
cuentaJose.Depositar(50); // Depositamos en ella

// 2. Ahora reutilizamos la variable 'cuenta' para María
cuenta = new Cuenta("Maria Diaz", 20287544);
cuenta.Depositar(200);

// 3. Si queremos depositar de nuevo en José, usamos la variable auxiliar
cuentaJose.Depositar(100); // Funciona porque guardamos la referencia en cuentaJose

De otra forma, una vez que una variable se reasigna a un nuevo objeto, la referencia anterior se rompe para siempre.
*/
