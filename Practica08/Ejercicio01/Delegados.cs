// Aquí solo se declaran los "contratos" o plantillas de tipos de métodos que se pueden pasar como argumentos.
// No contiene lógica de negocio. Esto permite mantener la separación de responsabilidades

// 1. Definición de Del1
// Este delegado representa un método que recibe un parámetro entero (int)
// y NO devuelve ningún valor (void).
// Se usa para acciones como imprimir o registrar datos.
public delegate void Del1(int x);

// 2. Definición de Del2
// Este delegado representa un método que recibe un array de enteros (int[])
// y NO devuelve ningún valor (void).
// Se usa para procesar colecciones de números.
public delegate void Del2(int[] x);

// 3. Definición de Del3
// Este delegado representa un método que recibe un entero (int)
// y DEVUELVE un entero (int) como resultado.
// Se usa para cálculos que retornan un valor (como una suma).
public delegate int Del3(int x);

// 4. Definición de Del4
// Este delegado representa un método que recibe una cadena de texto (string)
// y DEVUELVE un valor booleano (bool) (verdadero o falso).
// Se usa para validaciones o condiciones (como verificar si la longitud es par).
public delegate bool Del4(string x);