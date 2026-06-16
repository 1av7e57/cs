﻿/*¿Cuál es la salida por consola del siguiente código?*/

for (int i = 0; i <= 4; i++)
{
string st = i < 3 ? i == 2 ? "dos" : i == 1 ? "uno" : "< 1" : i < 4 ? "tres" : "> 3";
Console.WriteLine(st);
}

/*Respuesta:

La salida por consola será:

< 1
uno
dos
tres
> 3

¿Por qué es de esta manera?

Este código utiliza operadores ternarios anidados que evalúan cada valor de i (del 0 al 4),
según las condiciónes dadas (en orden de izquierda a derecha)
y asignan un texto a imprimir según qué resultado coincida en cada momento, así:

- Cuando i = 0:
    i < 3 es verdadero.
    Entra al primer bloque: i == 2 (falso) → i == 1 (falso) → Resultado: "< 1".

- Cuando i = 1:
    i < 3 es verdadero.
    i == 2 (falso) → i == 1 (verdadero) → Resultado: "uno".

- Cuando i = 2:
    i < 3 es verdadero.
    i == 2 (verdadero) → Resultado: "dos".

- Cuando i = 3:
    i < 3 es falso.
    Salta al segundo bloque (después del primer :): i < 4 (verdadero) → Resultado: "tres".
    
- Cuando i = 4:
    i < 3 es falso.
    Salta al segundo bloque: i < 4 (falso) → Resultado: "> 3".

NOTA: Aunque funciona, anidar tantos ternarios hace el código difícil de leer. En la práctica, sería mejor usar un switch o varios if/else.

*/
