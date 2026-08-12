﻿/*Codificar una aplicación para manejar una lista de autos (dos atributos: Marca y Modelo) 
con el siguiente menú de opciones por consola:

Menú de Opciones
================

1. Ingresar autos desde la consola
2. Cargar lista de autos desde el disco
3. Guardar lista de autos en el disco
4. Listar por consola
5. Salir

Ingrese su opción:

-La opción 1 permite al usuario agregar autos a la lista actual en memoria ingresando la marca y el modelo por la consola. El final de la entrada se detecta al ingresar una marca vacía (sin caracteres). 
-La opción 2, carga en memoria una lista de autos previamente guardada en algún archivo de texto.
-La opción 3 guarda en un archivo de texto la lista actual en memoria. Se puede implementar de infinidad de maneras, por ejemplo se podría guardar cada auto en dos líneas consecutivas, la primera para la marca y la segunda para el modelo.
-La opción 4 produce un listado por consola de todos los autos en la lista actual en memoria. 
Tip: La interacción con el menú puede resolverse de la siguiente manera:
{
    . . .
    ConsoleKeyInfo tecla;
    do
    {
        tecla = Console.ReadKey(true);
        switch (tecla.KeyChar)
        {
            case '1': . . .
            case '2': . . .
            case '3': . . .
            case '4': . . .
        }
    } while (tecla.KeyChar != '5');
}
*/

using System;                      // Importamos operaciones básicas del sistema (Console, etc.)
using Ejercicio10.Contratos;       // Importamos los contratos (interfaces) definidos en el proyecto
using Ejercicio10.Infraestructura; // Importamos la implementación de infraestructura (la que lee/escribe archivos)
using Ejercicio10.Servicios;       // Importamos el servicio del menú que orquesta la lógica

// Define el espacio de nombres principal del proyecto
namespace Ejercicio10
{
    // Clase principal que contiene el método de entrada del programa
    class Program
    {
        // Método principal: es el primer código que se ejecuta al iniciar la aplicación
        static void Main()
        {
            // CONFIGURACIÓN DE DEPENDENCIAS (Composition Root)
            // Aquí decidimos qué implementación concreta usar.
            // Creamos una instancia de la clase que maneja archivos, pero la asignamos a la interfaz.
            // Esto cumple el principio de Inversión de Dependencia: el menú depende de la interfaz, no de la clase concreta.
            IAutoRepositorio repositorio = new ArchivoAutoRepositoio();
            
            // Creamos una instancia del servicio del menú.
            // Inyectamos el repositorio en el constructor para que el menú pueda guardar/cargar datos sin saber cómo lo hace.
            MenuServicio menu = new MenuServicio(repositorio);

            // Ejecutamos el ciclo principal del menú, que comenzará a leer la entrada del usuario.
            menu.Ejecutar();
        }
    }
}

/*NOTAS:
El objetivo de este ejercicio es aplicar conceptos de Interfaces, Inversión de Dependencias (DIP) y Arquitectura Limpia en C#.
Para cumplir con estos principios, se propone que el menú no sepa cómo guardar o cargar datos directamente. 
En su lugar, definiremos contratos (interfaces) para la gestión de datos y la estructura del auto, y luego crearemos implementaciones concretas.

Estructura del Programa:
1. Definición del Modelo y Contratos (Interfaces)
    - Archivo: Auto.cs La implementación concreta de la entidad.
        Definimos qué es un Auto y qué capacidades debe tener nuestro sistema de almacenamiento.
    - Archivo: IAutoRepositorio.cs 
        Esta interfaz define el contrato para guardar y cargar. 
        La clase Program y el Menu dependerán de esta interfaz, no de una clase concreta, cumpliendo con la Inversión de Dependencia.

2. Implementación de la Persistencia
    -Archivo: ArchivoAutoRepositorio.cs
        Aquí creamos la lógica concreta para leer/escribir en disco. 
        Al implementar IAutoRepositorio, podemos cambiar esta lógica en el futuro (ej. a una Base de Datos) sin tocar el menú.

3. La Lógica del Menú (Orquestador)
    - Archivo: MenuServicio.cs
        Aquí aplicamos la Arquitectura Limpia a nivel simple: el Menu no sabe nada de archivos. 
        Solo sabe que tiene un IAutoRepositorio y una lista de IAuto.

4. Punto de Entrada (Program.cs)
    - Archivo: Program.cs
        Finalmente, ensamblamos todo en Main. 
        Aquí es donde decidimos qué implementación concreta usar.

Puntos claves:
    - Interfaces (IAutoRepositorio): 
    Separa el qué (guardar/cargar) del cómo (archivo, base de datos, etc.).
    - Inversión de Dependencia (DIP): 
    La clase MenuServicio depende de la abstracción IAutoRepositorio, no de la clase concreta ArchivoAutoRepositoio.
    - División de Responsabilidades:
        Auto: Solo maneja datos.
        ArchivoAutoRepositoio: Solo maneja I/O (archivos).
        MenuServicio: Solo maneja la lógica de flujo y presentación.
        Program: Solo configura el inicio.
    - Arquitectura Limpia: 
    Si mañana se quisiera guardar en una base de datos SQL, solo se crea una clase SqlAutoRepositorio 
    que implemente IAutoRepositorio y se cambia una línea en Program.cs. El menú no se rompe ni cambia.
*/
