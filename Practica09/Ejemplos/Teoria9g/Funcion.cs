// Definición de un delegado genérico personalizado llamado 'Funcion'.
// Toma dos parámetros de tipo: T1 (entrada) y T2 (salida).
// El método que se asigne a este delegado debe recibir un parámetro de tipo T1
// y retornar un valor de tipo T2.
delegate T2 Funcion<T1, T2>(T1 valor);