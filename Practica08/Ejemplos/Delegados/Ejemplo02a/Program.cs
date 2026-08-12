// Definición del namespace que agrupa la lógica de la teoría 8
using Teoria8;

// Instancia un nuevo objeto de la clase Auxiliar
Auxiliar aux = new Auxiliar();

// Invoca el método Procesar sobre la instancia creada
// Esto ejecutará internamente SumaUno(10) y SumaDos(10)
aux.Procesar();

/*NOTAS:
Al agregar delegate int Funcion(int n); y usar la variable f de ese tipo en Auxiliar, 
se logra desacoplar la llamada de la función.

Puntos Clave:
    -Abstracción: La clase Auxiliar ya no necesita saber exactamente qué método va a ejecutar (SumaUno o SumaDos). 
    Solo sabe que va a ejecutar lo que esté guardado en f.
    -Flexibilidad (limitada): Ahora se puede cambiar el comportamiento de Procesar simplemente cambiando 
    qué método se le asigna a f antes de llamarlo. 

    En el ejemplo actual, la lógica de "decidir qué método usar" sigue dentro de Auxiliar. 
    Sin embargo, los delegados permiten incluso pasar ese control desde Program.cs.
*/
