// Definición de la clase 'Par' que agrupa dos valores enteros.
class Par
{
    // Propiedad pública A de tipo entero (int).
    // El modificador 'private set' indica que solo se puede modificar desde dentro de la clase (inmutabilidad externa).
    public int A { get; private set; }
    
    // Propiedad pública B de tipo entero (int), también con setter privado.
    public int B { get; private set; }

    // Constructor de la clase que recibe dos parámetros: 'a' y 'b'.
    public Par(int a, int b)
    {
        // Asigna el valor del parámetro 'a' a la propiedad de instancia 'A'.
        this.A = a;
        
        // Asigna el valor del parámetro 'b' a la propiedad de instancia 'B'.
        this.B = b;
    }
}