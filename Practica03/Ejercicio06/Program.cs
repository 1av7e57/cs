/*¿De qué tipo quedan definidas las variables x, y, z en el siguiente código?
int i = 10;
var x = i * 1.0;
var y = 1f;
var z = i * y;*/

int i = 10; // 'i' es de tipo entero (int)

// 'i' (int) multiplicado por '1.0' (double). 
// En C#, al operar un int con un double, el resultado se promueve a double.
var x = i * 1.0; // x es de tipo double

// El sufijo 'f' indica explícitamente que el literal es un float.
var y = 1f;      // y es de tipo float

// 'i' (int) multiplicado por 'y' (float).
// La operación entre int y float resulta en un float.
var z = i * y;   // z es de tipo float

/*Nota:
Es importante recordar que en C# 
los literales decimales sin sufijo (como 1.0) 
se consideran double por defecto, mientras que float requiere el sufijo f o F.

Promoción de tipos:
En C#, cuando se realizan operaciones aritméticas entre tipos numéricos diferentes, 
el compilador aplica una serie de reglas de promoción de tipos 
(también llamadas conversiones implícitas o widening conversions) 
para evitar la pérdida de datos.

El principio fundamental es que:
Cuando el compilador encuentra una operación como A op B (donde op es +, -, *, /)
el operando de "menor precisión" 
se convierte al tipo de "mayor precisión" 
antes de realizar la operación. 
El resultado final siempre será del tipo con mayor rango o precisión de los dos operandos.

Jerarquía de precedencia de los tipos numéricos en C#, de menor a mayor capacidad de conversión:
1-sbyte, byte, short, ushort, int, uint
2-long, ulong
3-float
4-double
5-decimal
(char se comporta como un entero sin signo, 
pero rara vez se usa en estas operaciones 
aritméticas directas con decimales).

Tabla de Resumen de Resultados 
Operando A	 Operando B	  Tipo del Resultado	 Razón
int	         int	      int	                 Regla de enteros pequeños
int	         long	      long	                 long es mayor que int
int	         float	      float	                 float es mayor que int
int	         double	      double	             double es mayor que float
float	     double	      Error	                 Requiere conversión explícita
int	         decimal	  decimal	             decimal es el mayor
float	     decimal	  Error	                 Requiere conversión explícita

*/
