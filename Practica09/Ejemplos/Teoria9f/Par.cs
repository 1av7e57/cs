// Definición de una clase genérica 'Par' que acepta DOS parámetros de tipo: T1 y T2.
// Estos parámetros actúan como marcadores de posición para tipos de datos reales que se definirán al crear el objeto.
class Par<T1, T2>
{
    // Propiedad pública A de tipo T1. El tipo exacto se decidirá al instanciar la clase.
    // El setter es privado, manteniendo la inmutabilidad externa.
    public T1 A { get; private set; }
    
    // Propiedad pública B de tipo T2. Puede ser un tipo diferente al de A.
    public T2 B { get; private set; }

    // Constructor que recibe dos parámetros: 'a' del tipo T1 y 'b' del tipo T2.
    public Par(T1 a, T2 b)
    {
        // Asigna el valor del parámetro 'a' a la propiedad 'A'.
        this.A = a;
        
        // Asigna el valor del parámetro 'b' a la propiedad 'B'.
        this.B = b;
    }
}