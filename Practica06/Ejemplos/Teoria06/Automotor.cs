namespace Teoria6;

abstract class Automotor
{
    // Propiedad pública de solo lectura (campo implícito)
    public string Marca { get; }
    // Campo privado _modelo
    private int _modelo;
    // Porpiedad pública de lectura/escritura para el campo _modelo
    public virtual int Modelo
    {
        get => _modelo;
        protected set => _modelo = (value < 2005) ? 2005 : value;
    }
    // Constructor de Automotor
    // Aunque una clase abstracta NO puede instanciarse, las clases hijas necesitan que ese constructor exista
    // para inicializar los datos que les pertenecen a la parte "padre" del objeto.
    public Automotor(string marca, int modelo)
    {
        Marca = marca;
        Modelo = modelo;
    }
    // Con esta modificiación Auto y Colectivo deben implementar (hacer override):

    // 1. Método abstracto: Sin cuerpo (Deben definirlo)
    public abstract void HacerMantenimiento();

    // 2. Propiedad FechaService: Solo firma. 
    // Los hijos DEBEN tener un campo propio para guardar la fecha.
    public abstract DateTime FechaService { get; set; } // Mucha atención aquí, NO debemos confundir con propiedades auto-implementadas,
                                                        // la clave para saberlo es el modificador abstract, debemos leer cuidadosamente las líneas de código

    // 3. Propiedad PrecioDeVenta: Solo get.
    // Los hijos deben definir cómo se calcula.
    public abstract double PrecioDeVenta { get; } // Propiedad abstracta (NO es auto-implementada !)
    
    // Método virtual que imprime los datos: Marca y Modelo (puede sobreescribirse por clases hijas)
    public virtual void Imprimir() => Console.WriteLine($"{Marca} {Modelo}");
}