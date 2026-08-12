using System; // Importamos para funciónes básicas
class Trabajador
{
    // 1. Declaración del evento.
    // Se usa el delegado estándar 'EventHandler' que ya tiene la firma correcta.
    // El '?' indica que es un tipo nullable (puede ser null si nadie se suscribe).
    public EventHandler? Trabajando; 

    // 2. Método que realiza la acción y dispara el evento.
    public void Trabajar()
    {
        // 3. Invocación segura del evento.
        // El operador '?.' verifica si hay suscriptores.
        // Si 'Trabajando' no es null, ejecuta la lista de métodos (en este caso, nuestra lambda).
        // Pasamos 'this' (el trabajador) y 'EventArgs.Empty'.
        Trabajando?.Invoke(this, EventArgs.Empty);

        // 4. Continuación de la lógica del trabajo.
        // Esto se ejecuta inmediatamente después de que la lambda termine.
        Console.WriteLine("Trabajo concluido");
    }
}