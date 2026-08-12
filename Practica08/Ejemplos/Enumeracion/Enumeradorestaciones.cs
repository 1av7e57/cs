using System; // Importamos la biblioteca 'System' para usar excepciones y tipos básicos
using System.Collections; // Importamos 'System.Collections' para acceder a la interfaz 'IEnumerator'

// Definimos la clase EnumeradorEstaciones que hereda/implementa la interfaz IEnumerator
class EnumeradorEstaciones : IEnumerator
{
    // Variable privada que guarda el estado actual. Inicia en "Inicio" para indicar que no hemos empezado a recorrer
    private string actual = "Inicio";

    // Propiedad Current: Devuelve el elemento actual.
    // Según la especificación de IEnumerator, debe lanzar una excepción si no hay un elemento válido.
    public object Current
    {
        get
        {
            // Si estamos en el estado inicial ("Inicio") o ya terminamos ("Fin"), no hay elemento válido
            if (actual == "Inicio" || actual == "Fin")
            {
                // Lanzamos una excepción indicando que no se puede acceder a un elemento en este momento
                throw new InvalidOperationException("No hay elemento actual válido.");
            }
            // Si estamos en una estación válida, devolvemos su nombre como objeto
            return actual;
        }
    }

    // Método Reset(): Restablece el iterador a su estado inicial.
    // Al llamar a esto, el siguiente MoveNext() empezará de nuevo desde el principio.
    public void Reset()
    {
        // Devolvemos la variable 'actual' a "Inicio" para reiniciar el ciclo
        actual = "Inicio";
    }

    // Método MoveNext(): Avanza al siguiente elemento de la colección.
    // Devuelve true si el movimiento fue exitoso, false si llegamos al final.
    public bool MoveNext()
    {
        // Usamos un switch para decidir a qué estación avanzar según el estado actual
        switch (actual)
        {
            // CASO 1: Si estamos en el inicio, avanzamos a la primera estación: "verano"
            case "Inicio":
                actual = "verano";
                break; // Salimos del switch

            // CASO 2: Si estamos en verano, avanzamos a otoño
            case "verano":
                actual = "otoño";
                break;

            // CASO 3: Si estamos en otoño, avanzamos a invierno
            case "otoño":
                actual = "invierno";
                break;

            // CASO 4: Si estamos en invierno, avanzamos a primavera
            case "invierno":
                actual = "primavera";
                break;

            // CASO 5: Si estamos en primavera, avanzamos al estado final "Fin"
            case "primavera":
                actual = "Fin";
                break;

            // CASO DEFAULT: Si por alguna razón llegamos a un estado no esperado o ya estamos en "Fin"
            default:
                // Nos aseguramos de que el estado permanezca como "Fin" para evitar bucles infinitos
                actual = "Fin";
                break;
        }

        // Retornamos true si el estado actual NO es "Fin" (es decir, tenemos más elementos)
        // Retornamos false si el estado es "Fin" (se acabaron las estaciones)
        return actual != "Fin";
    }
}