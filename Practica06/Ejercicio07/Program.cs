﻿/*Crear un programa para gestionar empleados en una empresa:

-Los empleados deben tener las propiedades públicas de sólo lectura Nombre, DNI, FechaDeIngreso, SalarioBase y Salario. 
-Los valores de estas propiedades (a excepción de Salario que es una propiedad calculada) deben establecerse por medio de un constructor adecuado.
-Existen dos tipos de empleados: Administrativo y Vendedor. 
-No se podrán crear objetos de la clase padre Empleado, pero sí de sus clases hijas (Administrativo y Vendedor). 
-Aparte de las propiedades de solo lectura mencionadas: 
    el administrativo tiene otra propiedad pública de lectura/escritura llamada Premio
    y el vendedor tiene otra propiedad pública de lectura/escritura llamada Comision.
-La propiedad de solo lectura Salario, se calcula como el salario base más la comisión o el premio según corresponda.
-Las clases tendrán además un método público llamado AumentarSalario() que tendrá una implementación distinta en cada clase.
    En el caso del administrativo se incrementará el salario base en un 1% por cada año de antigüedad que posea en la empresa, 
    en el caso del vendedor se incrementará el salario base en un 5% si su antigüedad es inferior a 10 años o en un 10% en caso contrario.

El siguiente código (ejecutado el día 9/4/2022) debería mostrar en la consola el resultado indicado:

Empleado[] empleados = new Empleado[] {
new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
};
foreach (Empleado e in empleados)
{
    Console.WriteLine(e);
    e.AumentarSalario();
    Console.WriteLine(e);
}

Salida por consola esperada:

Administrativo Nombre: Ana, DNI: 20000000 Antigüedad: 3
Salario base: 10000, Salario: 11000
-------------
Administrativo Nombre: Ana, DNI: 20000000 Antigüedad: 3
Salario base: 10300, Salario: 11300
-------------
Vendedor Nombre: Diego, DNI: 30000000 Antigüedad: 12
Salario base: 10000, Salario: 12000
-------------
Vendedor Nombre: Diego, DNI: 30000000 Antigüedad: 12
Salario base: 11000, Salario: 13000
-------------
Vendedor Nombre: Luis, DNI: 33333333 Antigüedad: 10
Salario base: 10000, Salario: 12000
-------------
Vendedor Nombre: Luis, DNI: 33333333 Antigüedad: 10
Salario base: 11000, Salario: 13000
-------------

Recomendaciones: 
-Observar que el método AumentarSalario() y la propiedad de solo lectura Salario en la clase Empleado pueden declararse como abstractos. 
-Intentar no utilizar campos sino propiedades auto-implementadas todas las veces que sea posible.
-Además sería deseable que la propiedad SalarioBase definida en Empleado sea pública para la lectura y protegida para la escritura, 
para que pueda establecerse desde las subclases Administrativo y Vendedor.
*/

using System; // Importamos el namespace System para clases base.
using System.Globalization; // Importamos System.Globalization para usar ParseExact con formatos de fecha específicos.

// Definimos la clase base abstracta Empleado.
// Al ser abstracta, no podemos instanciar objetos de esta clase directamente, solo sus hijas.
public abstract class Empleado
{
    // --- PROPIEDADES AUTO-IMPLEMENTADAS ---

    // Propiedad de solo lectura Nombre. Se inicializa en el constructor.
    public string Nombre { get; }

    // Propiedad de solo lectura DNI. Se inicializa en el constructor.
    public long DNI { get; }

    // Propiedad de solo lectura FechaDeIngreso. Se inicializa en el constructor.
    public DateTime FechaDeIngreso { get; }

    // Propiedad SalarioBase: pública para lectura, protegida para escritura.
    // Esto permite que las clases hijas (Administrativo y Vendedor) la modifiquen, pero no el código externo.
    public double SalarioBase { get; protected set; }

    // Propiedad abstracta Salario.
    // Al ser abstracta, obliga a las clases hijas a implementar su propia lógica de cálculo.
    // Es de solo lectura (get) porque el valor se deriva de otras propiedades.
    public abstract double Salario { get; }

    // Constructor de la clase base Empleado.
    // Recibe y asigna los valores comunes a todos los empleados.
    // (Se asigna directamente a la propiedad, no a un campo).
    public Empleado(string nombre, long dni, DateTime fechaDeIngreso, double salarioBase)
    {
        Nombre = nombre;                 // Asigna el nombre recibido al campo de la propiedad.
        DNI = dni;                       // Asigna el DNI recibido.
        FechaDeIngreso = fechaDeIngreso; // Asigna la fecha de ingreso.
        SalarioBase = salarioBase;       // Asigna el salario base inicial.
    }

    // Método abstracto AumentarSalario.
    // Obliga a las clases hijas a definir cómo se realiza el aumento específico.
    public abstract void AumentarSalario();

    // Método protegido para calcular la antigüedad (Flexible con parámetro opcional).
    protected int CalcularAntiguedad(DateTime? fechaReferencia = null)
    {
        // Si no se pasa una fecha, usamos "new DateTime(2022, 4, 9)" (fecha fija del ejercicio).
        DateTime fecha = fechaReferencia ?? new DateTime(2022, 4, 9); // o "DateTime.Now" en producción.

        int anos = fecha.Year - FechaDeIngreso.Year;

        // Ajuste si aún no ha pasado el mes/día de ingreso en el año actual
        if (fecha.Month < FechaDeIngreso.Month ||
           (fecha.Month == FechaDeIngreso.Month && fecha.Day < FechaDeIngreso.Day))
        {
            anos--;
        }
        return anos;
    }

    // Sobrecarga del método ToString para mostrar la información del empleado.
    // No usa la versión genérica heredada de object, sino una personalizada.
    // Esto permite que Console.WriteLine(e) imprima el formato deseado automáticamente.
    public override string ToString()
    {
        // Usamos el método para calcular la antigüedad.
        int antiguedad = CalcularAntiguedad();

        // Retorna el string formateado con Nombre, DNI y Antigüedad.
        return $"{GetType().Name} Nombre: {Nombre}, DNI: {DNI} Antigüedad: {antiguedad}\nSalario base: {SalarioBase}, Salario: {Salario}";
    }
}

// Clase derivada Administrativo que hereda de Empleado.
public class Administrativo : Empleado
{
    // --- Propiedad pública de lectura/escritura Premio (Autoimplementada) ---
    public double Premio { get; set; }

    // Constructor que llama al constructor de la clase base.
    // Inicializa Nombre, DNI, FechaDeIngreso y SalarioBase.
    public Administrativo(string nombre, long dni, DateTime fechaDeIngreso, double salarioBase)
        : base(nombre, dni, fechaDeIngreso, salarioBase)
    {
        // El Premio se inicializa en 0 por defecto,
        // pero puede cambiarse después con el inicializador de objeto {Premio=...}
    }

    // Implementación de la propiedad abstracta Salario.
    // Para Administrativo, el salario es el SalarioBase + el Premio.
    public override double Salario
    {
        get
        {
            return SalarioBase + Premio; // Retorna la suma.
        }
    }

    // Implementación del método AumentarSalario.
    // Incrementa el SalarioBase en un 1% por cada año de antigüedad.
    public override void AumentarSalario()
    {
        // Reutilizamos el método de la clase base
        int anos = CalcularAntiguedad();

        // Calculamos el porcentaje de aumento (1% por año).
        double porcentaje = 0.01 * anos;

        // Actualizamos la propiedad protegida SalarioBase.
        // El 1 es vital aquí porque preserva el valor original. Sin él, se estaría calculando solo la diferencia, no el nuevo estado.
        SalarioBase = SalarioBase * (1 + porcentaje);
    }
}

// Clase derivada Vendedor que hereda de Empleado.
public class Vendedor : Empleado
{
    // --- Propiedad pública de lectura/escritura Comision (Autoimplementada) ---
    public double Comision { get; set; }

    // Constructor que llama al constructor de la clase base.
    public Vendedor(string nombre, long dni, DateTime fechaDeIngreso, double salarioBase)
        : base(nombre, dni, fechaDeIngreso, salarioBase)
    {
        // La Comision se inicializa en 0 por defecto,
        // pero puede cambiarse después con el inicializador de objeto {Comision=...}
    }

    // Implementación de la propiedad abstracta Salario.
    // Para Vendedor, el salario es el SalarioBase + la Comision.
    public override double Salario
    {
        get
        {
            return SalarioBase + Comision; // Retorna la suma.
        }
    }

    // Implementación del método AumentarSalario.
    // Incrementa el SalarioBase en 5% si antigüedad < 10 años, o 10% si es >= 10 años.
    public override void AumentarSalario()
    {
        // Reutilizamos el método de la clase base
        int anos = CalcularAntiguedad();

        double porcentaje;
        // Lógica condicional según la antigüedad.
        if (anos < 10)
        {
            porcentaje = 0.05; // 5%
        }
        else
        {
            porcentaje = 0.10; // 10%
        }

        // Actualizamos la propiedad protegida SalarioBase.
        SalarioBase = SalarioBase * (1 + porcentaje);
    }
}

// Clase principal del programa.
public class Program
{
    // Método Main, punto de entrada del programa
    public static void Main()
    {
        // Definimos el formato de fecha esperado: día/mes/año.
        // Usamos InvariantCulture para asegurar que el formato se interprete igual en cualquier sistema.
        string formatoFecha = "d/M/yyyy";
        IFormatProvider proveedor = CultureInfo.InvariantCulture;

        // Creamos un array de objetos de tipo Empleado (polimorfismo).
        Empleado[] empleados = new Empleado[] {
            // Instancia de Administrativo con inicializador de objeto para el Premio.
            // Usamos ParseExact para forzar el formato día/mes/año.
            new Administrativo("Ana", 20000000, DateTime.ParseExact("26/4/2018", formatoFecha, proveedor), 10000) {Premio=1000},
            // Instancia de Vendedor con inicializador de objeto para la Comision.
            new Vendedor("Diego", 30000000, DateTime.ParseExact("2/4/2010", formatoFecha, proveedor), 10000) {Comision=2000},
            // Otra instancia de Vendedor, con inicializador de objeto para la Comision.
            new Vendedor("Luis", 33333333, DateTime.ParseExact("30/12/2011", formatoFecha, proveedor), 10000) {Comision=2000}
        };

        // Iteramos sobre cada empleado en el array.
        foreach (Empleado e in empleados)
        {
            Console.WriteLine(e);               // Imprime el estado inicial.
            Console.WriteLine("-------------"); // Imprime el separador antes del aumento.

            e.AumentarSalario();                // Aplica el aumento.

            Console.WriteLine(e);               // Imprime el estado después del aumento.
            Console.WriteLine("-------------"); // Imprime el separador final del bloque.
        }
    }
}

/*NOTAS:

1. Resumen del Programa:

Sistema orientado a objetos diseñado para gestionar empleados de una empresa, calculando salarios y aplicando aumentos basados en la antigüedad y el tipo de empleado. 
El programa demuestra principios clave de POO: Abstracción, Herencia, Encapsulamiento y Polimorfismo.

2. Arquitectura de Clases

El sistema se divide en una clase base abstracta y dos clases derivadas concretas.

Clase Base:  Empleado  (Abstracta)
Representa la entidad genérica. No se puede instanciar directamente. Define el contrato común para todos los empleados.

| Miembro                | Tipo      | Modificador                  | Descripción                                                                          |
| ---------------------- | --------- | ---------------------------- | ------------------------------------------------------------------------------------ |
|  Nombre                | Propiedad |  public get;                 | Solo lectura. Se fija en el constructor.                                             |
|  DNI                   | Propiedad |  public get;                 | Solo lectura. Identificador único.                                                   |
|  FechaDeIngreso        | Propiedad |  public get;                 | Solo lectura. Fecha de contratación.                                                 |
|  SalarioBase           | Propiedad |  public get; protected set;  | Lectura pública, escritura solo para clases hijas.                                   |
|  Salario               | Propiedad |  abstract get;               |   Debe ser implementada   por las hijas (Base + Premio/Comisión).                    |
|  AumentarSalario()     | Método    |  abstract                    |   Debe ser implementado   por las hijas (Lógica específica de aumento).              |
|  CalcularAntiguedad()  | Método    |  protected                   | Utilidad interna. Calcula años de servicio. Soporta inyección de fecha para pruebas. |
|  ToString()            | Método    |  override                    | Formatea la salida para consola (Nombre, DNI, Antigüedad, Salarios).                 |

Clase Derivada:  Administrativo 
Hereda de  Empleado . Representa empleados de área administrativa.

| Miembro              | Tipo      | Descripción                                                 |
| -------------------- | --------- | ----------------------------------------------------------- |
|  Premio              | Propiedad |  public get; set;      | Bonus fijo asignado al empleado.   |
|  Salario             | Override  |  SalarioBase + Premio  | Cálculo del salario total.         |
|  AumentarSalario()   | Override  |  Aumenta SalarioBase un 1% por cada año de antigüedad.      |

Clase Derivada:  Vendedor 
Hereda de  Empleado . Representa empleados del área de ventas.

| Miembro             | Tipo      | Descripción                                                                      |
| ------------------- | --------- | -------------------------------------------------------------------------------- |
|  Comision           | Propiedad |  public get; set;        | Bonus variable por ventas.                            |
|  Salario            | Override  |  SalarioBase + Comision  | Cálculo del salario total.                            |
|  AumentarSalario()  | Override  |  Aumenta SalarioBase un 5% si antigüedad < 10 años, o 10% si ≥ 10 años.          |

Clase Principal:  Program 
Punto de entrada ( Main ). Orquesta la creación de objetos y la ejecución del flujo.

3. Flujo de Ejecución

a.Inicialización de Datos  :
    Se crea un array de tipo  Empleado[]  (Polimorfismo: array de la clase base que contiene objetos de las clases hijas).
    Se utilizan  DateTime.ParseExact  para garantizar el formato de fecha  dd/MM/yyyy  independientemente de la configuración regional del sistema.
b.Iteración  :
    Se recorre el array con un  foreach .
        Paso A  : Se imprime el estado actual del empleado ( ToString() ).
        Paso B  : Se imprime un separador visual.
        Paso C  : Se invoca  e.AumentarSalario() .
    Polimorfismo en acción: El compilador decide en tiempo de ejecución si llama al método de  Administrativo  o  Vendedor  según el tipo real del objeto.
        Paso D  : Se imprime el nuevo estado (con los salarios actualizados).
        Paso E  : Se imprime el separador final.

4. Conceptos Técnicos Clave

Propiedades Auto-Implementadas
Uso de  { get; }  y  { get; set; }  para evitar código repetitivo (boilerplate). El compilador genera el campo privado automáticamente.
     Ventaja    : Código más limpio y fácil de mantener.
     Seguridad  :  { get; }  asegura que el valor no cambie fuera del constructor.

Propiedades con Acceso Modificado
 public double SalarioBase { get; protected set; } 
      get  público    : Cualquier código puede leer el salario base.
      set  protegido  : Solo la clase  Empleado  y sus hijas ( Administrativo ,  Vendedor ) pueden modificarlo. El código externo no puede alterar el salario directamente, forzando el uso del método AumentarSalario() .

Propiedades Abstractas
 public abstract double Salario { get; } 
   Obliga a las clases hijas a proveer su propia lógica. Si una clase hija no implementa esto, no se compilará.
   Garantiza que todos los empleados tengan un cálculo de salario, aunque sea distinto.

Métodos Abstractos
 public abstract void AumentarSalario();
    Obliga a las clases hijas a proveer su propia lógica de actualización (ej. aplicar el porcentaje de aumento).

Inyección de Dependencias (Patrón simple)
El método  CalcularAntiguedad(DateTime? fechaReferencia = null)  acepta un parámetro opcional.
     Uso normal      :  CalcularAntiguedad()  usa la fecha fija del ejercicio (o  DateTime.Now  en producción).
     Uso de pruebas  : Permite pasar una fecha específica ( new DateTime(2025, 1, 1) ) para validar cálculos sin depender del tiempo real.

Polimorfismo
   
Empleado[] empleados = new Empleado[] {
    new Administrativo(...),
    new Vendedor(...)
};
foreach (Empleado e in empleados) {
    e.AumentarSalario(); // Llama a la implementación correcta según el objeto real
}
   
El código trata a todos como Empleado, pero el comportamiento cambia dinámicamente.

5. Reglas de Negocio (Lógica de Cálculo)

| Tipo               | Fórmula de Salario       | Regla de Aumento                                             |
| ------------------ | ------------------------ | ------------------------------------------------------------ |
|   Administrativo   |  SalarioBase + Premio    |  SalarioBase += SalarioBase * (0.01 * Antigüedad)            |
|   Vendedor         |  SalarioBase + Comisión  |  Si  Antigüedad < 10 :  +5% | Si  Antigüedad >= 10 :  +10%   |

La antigüedad se calcula en años completos, considerando si ya pasó el mes/día de ingreso.

*/
