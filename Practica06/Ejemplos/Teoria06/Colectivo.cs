namespace Teoria6;

class Colectivo : Automotor
{
    public int CantPasajeros;

    // CAMPO PROPIO para guardar la fecha (obligatorio porque la base es abstracta)
    private DateTime _fechaService;

    public override int Modelo
    {
        protected set => base.Modelo = (value < 2015) ? 2015 : value;
    }
    public Colectivo(string marca, int modelo, int cantPasajeros) : base(marca, modelo)
    {
        CantPasajeros = cantPasajeros;
        _fechaService = DateTime.Now;  // Inicialización por defecto
    }

    // Implementación del método base
    public override void HacerMantenimiento()
    {
        Console.WriteLine($"Inspección de seguridad para Colectivo de {CantPasajeros} pasajeros...");
        _fechaService = DateTime.Now.AddDays(30); // Próximo service en 30 días
    }

    // Implementación de Propiedad FechaService
    public override DateTime FechaService
    {
        get => _fechaService;
        set => _fechaService = value;
    }

    // Implementación de cómo se calcula la Propiedad PrecioDeVenta (Ejemplo: lógica distinta)
    public override double PrecioDeVenta
    {
        get
        {
            // Lógica específica para Colectivo
            return 20000.0 + (CantPasajeros * 100);
        }
    }

    public override void Imprimir()
    => Console.WriteLine($"{Marca} {Modelo} ({CantPasajeros} pasajeros)");
}