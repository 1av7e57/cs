namespace Teoria6;

class Auto : Automotor
{
    public TipoAuto Tipo;
    
    // CAMPO PROPIO para guardar la fecha (obligatorio porque la base es abstracta)
    private DateTime _fechaService; 

    public Auto(string marca, int modelo, TipoAuto tipo) : base(marca, modelo)
    {
        Tipo = tipo;
        _fechaService = DateTime.Now; // Inicialización por defecto
    }

    // Implementación del método base
    public override void HacerMantenimiento()
    {
        Console.WriteLine($"Haciendo mantenimiento al Auto {Tipo}...");
        _fechaService = DateTime.Now; // Actualizar fecha
    }

    // Implementación de Propiedad FechaService
    public override DateTime FechaService
    {
        get => _fechaService;
        set => _fechaService = value;
    }

    // Implementación de cómo se calcula la propiedad PrecioDeVenta (ejemplo: lógica simple)
    public override double PrecioDeVenta
    {
        get 
        {
            // Lógica específica para Auto
            double basePrice = 10000.0;
            if (Tipo == TipoAuto.Deportivo) basePrice *= 1.5;
            return basePrice;
        }
    }

    public override void Imprimir()
    {
        Console.Write($"Auto {Tipo} ");
        base.Imprimir();
    }
}