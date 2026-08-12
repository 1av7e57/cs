
// Definimos la clase que se encarga de contar las líneas.
// Esta clase actúa como el Suscriptor. Se encarga de la lógica de negocio (contar), 
// pero ahora no necesita saber cómo se obtienen los datos, solo reacciona cuando recibe el aviso.
class ContadorDeLineas
{
    // Variable privada para almacenar la cantidad de líneas contadas.
    // Es privada para mantener el encapsulamiento (nadie más puede modificarla directamente).
    private int _cantLineas = 0;

    // Método principal que inicia el proceso de conteo.
    public void Contar()
    {
        // Instanciamos el objeto Ingresador.
        // Nota: Aquí ya no hay dependencia fuerte porque Ingresador no necesita saber de nosotros.
        Ingresador ingresador = new Ingresador();

        // SUSCRIPCIÓN AL EVENTO:
        // Vinculamos el evento 'LineaIngresada' del objeto 'ingresador' con el método 'ManejarLineaIngresada'.
        // El símbolo '+=' significa "agregar un oyente" a la lista de suscriptores del evento.
        // El compilador toma el método ManejarLineaIngresada y crea una instancia del Delegado EventHandler que apunta a ese método.
        // Ahora, cada vez que Ingresador dispare el evento, se ejecutará el método.
        ingresador.LineaIngresada += ManejarLineaIngresada;

        // Ejecutamos la lógica de entrada de datos.
        // Este método mantendrá la ejecución hasta que el usuario ingrese una línea vacía.
        ingresador.Ingresar();

        // LIMPIEZA (Buena Práctica):
        // Una vez terminado el conteo, quitamos la suscripción.
        // Esto evita fugas de memoria si el objeto 'ingresador' viviera más tiempo que este contador.
        ingresador.LineaIngresada -= ManejarLineaIngresada;

        // Mostramos el resultado final al usuario por consola.
        Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
    }

    // Método que será llamado automáticamente cuando el evento 'LineaIngresada' se dispare.
    // La firma (object? sender, EventArgs e) es la estándar para eventos en C#.
    private void ManejarLineaIngresada(object? sender, EventArgs e)
    {
        // Incrementamos el contador interno cada vez que recibimos la notificación.
        // No necesita saber quién llamó, solo que ocurrió el evento.
        _cantLineas++;
    }
}