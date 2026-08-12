using System; // Importamos para funciónes básicas
class Trabajador // Código corregido 
{
    // Definición del evento (puede ser null si nadie se suscribe)
    public EventHandler? Trabajando; 

    public void Trabajar()
    {
        // Solución: Usar el operador '?.' para invocar el evento de forma segura.
        // Si 'Trabajando' es null, esta línea no hace nada y no lanza excepción.
        // Si 'Trabajando' tiene suscriptores, se ejecutan en orden.
        Trabajando?.Invoke(this, EventArgs.Empty);
        // Realiza algún trabajo...
        Console.WriteLine("Trabajo concluido");
    }
}