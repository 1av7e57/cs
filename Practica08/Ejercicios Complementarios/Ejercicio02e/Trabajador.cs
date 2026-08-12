using System; // Importamos para funciónes básicas
class Trabajador
{
    // CAMBIO CLAVE:
    // Ahora es un 'event' en lugar de un campo público.
    // El compilador genera una clase interna para manejar la lista de suscriptores.
    // La lógica pública es:
    // 1. Solo se permite += (agregar) y -= (quitar).
    // 2. El evento es seguro contra asignaciones directas (=).
    public event EventHandler? Trabajando; 

    public void Trabajar()
    {
        // La invocación sigue siendo igual.
        // El operador '?.' es seguro incluso con la notación de eventos.
        Trabajando?.Invoke(this, EventArgs.Empty);

        // Lógica del trabajo
        Console.WriteLine("Trabajo concluido");
    }
}