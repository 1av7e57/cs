// Definición del namespace que agrupa la lógica de la teoría 8
using Teoria8;

// Instancia un nuevo objeto de la clase Auxiliar
Auxiliar aux = new Auxiliar();

// Invoca el método Procesar sobre la instancia creada
// Esto ejecutará internamente SumaUno(10) y SumaDos(10)
aux.Procesar();

/*NOTAS:
¿Qué observamos aquí?
    -Acoplamiento fuerte: La clase Auxiliar está "acoplada" a sus propios métodos SumaUno y SumaDos. 
    Si se quisiéra que Procesar hiciera una resta o una multiplicación, tendría que modificarse 
    el código interno de la clase Auxiliar.
    -Sin flexibilidad: No hay forma de decirle a Procesar "usa esta otra lógica" sin tocar esta clase.
El siguiente paso natural con Delegados sería transformar Procesar para que acepte una "instrucción" (un delegado) 
y así pueda ejecutar cualquier función que le pasemos desde Program.cs, en lugar de estar atado a SumaUno y SumaDos.
*/
