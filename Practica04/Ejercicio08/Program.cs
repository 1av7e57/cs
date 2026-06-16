/*¿Qué se puede decir en relación a la sobrecarga de métodos en este ejemplo?*/

class A
{
    public void Metodo(short n)
    {
        Console.Write("short {0} - ", n);
    }
    public void Metodo(int n) // Firma repetida (nombre y parámetros idénticos)
    {
        Console.Write("int {0} - ", n);
    }
    public int Metodo(int n) // Firma repetida (nombre y parámetros idénticos)
    {
        return n + 10;
    }
}

/*
Respuesta:
En este código hay un error de compilación relacionado con la sobrecarga de métodos.
No puede haber dos métodos con el mismo nombre y la misma lista de parámetros, 
incluso si tienen distintos tipos de retorno.

En la clase A, existen:

public void Metodo(int n) { ... }
public int Metodo(int n) { ... }

Ambos se llaman 'Metodo' y reciben exactamente lo mismo: un int. 
Para el compilador de C#, la firma de un método se compone solo del nombre y los parámetros
(tipo, orden y cantidad). El tipo de retorno NO forma parte de la firma, por lo que el compilador
no puede distinguir cuál de los dos métodos debe llamarse cuando, por ejemplo, se use Metodo(5).

Esto generará un error similar a:
Type 'A' already defines a member called 'Metodo' with the same parameter types.
(Metodo ya está definido en la clase A con los mismos parámetros)

Soluciónes posibles:

1.Cambiar uno de los tipos de parámetros para que las firmas sean distintas:

public void Metodo(short n) { ... }
public void Metodo(int n) { ... }
public int Metodo(long n) { ... } // Firma única

2.Cambiar el nombre de uno de los métodos si la lógica es diferente:

public void Metodo(int n) { ... }
public int ObtenerValor(int n) { ... }

Conclusión: la sobrecarga en C# solo funciona si los parámetros son diferentes, 
el tipo de retorno No ayuda a diferenciarlos.
*/


