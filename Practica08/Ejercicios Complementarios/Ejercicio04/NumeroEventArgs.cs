// Clase personalizada para transportar datos.
// Necesitamos esta clase para empaquetar el número y pasarlo en el evento.
// Hereda de EventArgs, que es el estándar en .NET para eventos con datos.
public class NumeroEventArgs : EventArgs
{
    // Propiedad pública para almacenar el valor numérico.
    public int Valor { get; }

    // Constructor que recibe el valor y lo asigna a la propiedad.
    public NumeroEventArgs(int valor)
    {
        Valor = valor;
    }
}