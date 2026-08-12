// Aquí implementamos la lógica de lectura y los dos eventos.
class Ingresador
{
    // 1. Evento para línea vacía.
    // Usa EventHandler estándar porque no necesitamos pasar datos extra (solo que ocurrió).
    public event EventHandler? LineaVaciaIngresada;

    // 2. Evento para número ingresado.
    // Usa EventHandler<T> donde T es nuestra clase personalizada NumeroEventArgs.
    // Esto permite pasar el valor del número a los suscriptores.
    public event EventHandler<NumeroEventArgs>? NroIngresado;

    public void Ingresar()
    {
        Console.WriteLine("Ingrese líneas de texto. Escriba 'fin' para terminar.");

        while (true)
        {
            // Leemos la línea ingresada por el usuario.
            string? linea = Console.ReadLine();

            // Verificamos si el usuario escribió "fin" para salir del bucle.
            if (linea != null && linea.ToLower() == "fin")
            {
                break;
            }

            // Caso A: La línea está vacía.
            if (string.IsNullOrWhiteSpace(linea))
            {
                // Disparamos el evento LineaVaciaIngresada.
                // Usamos '?.' para evitar errores si nadie se ha suscrito.
                LineaVaciaIngresada?.Invoke(this, EventArgs.Empty);
            }
            // Caso B: Intentamos convertir la línea a número.
            else if (int.TryParse(linea, out int numero))
            {
                // Creamos el objeto de argumentos con el número extraído.
                NumeroEventArgs args = new NumeroEventArgs(numero);

                // Disparamos el evento NroIngresado pasando el objeto 'args'.
                NroIngresado?.Invoke(this, args);
            }
            // Caso C: Es texto que no es un número y no está vacío.
            // En este ejercicio no se pide hacer nada, así que simplemente ignoramos.
        }
        // Mensaje que se muestra cuando se rompe el bucle tras escribir 'fin'.
        Console.WriteLine("Fin del ingreso.");
    }
}