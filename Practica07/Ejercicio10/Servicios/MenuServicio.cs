using System;                     // Importa operaciones básicas del sistema
using System.Collections.Generic; // Importa colecciones
using Ejercicio10.Contratos;      // Importa los contratos (IAuto, IAutoRepositorio)
using Ejercicio10.Modelos;        // Importa la clase Auto

// Define el espacio de nombres para los servicios
namespace Ejercicio10.Servicios
{
    // Clase que maneja la interacción con el usuario y coordina las operaciones
    public class MenuServicio
    {
        // Campo privado que guarda la referencia al repositorio (inyectada)
        // Al ser readonly, no se puede cambiar después del constructor
        private readonly IAutoRepositorio _repository;
        // Campo privado que guarda la lista de autos en memoria
        private readonly List<IAuto> _autos;

        // Constructor: Recibe la implementación del repositorio desde afuera
        // Esto permite cambiar la fuente de datos sin modificar esta clase
        public MenuServicio(IAutoRepositorio repository)
        {
            // Asigna el repositorio recibido al campo privado
            _repository = repository;
            // Inicializa la lista de autos como una lista vacía
            _autos = new List<IAuto>();
        }

        // Método principal que ejecuta el bucle del menú
        public void Ejecutar()
        {
            // Variable de control para salir del bucle
            bool salir = false;
            // Variable para almacenar la tecla presionada por el usuario
            ConsoleKeyInfo tecla;

            // Bucle infinito que se rompe solo si 'salir' es true
            do
            {
                // Muestra el menú de opciones en consola
                MostrarMenu();
                
                // Lee una tecla presionada por el usuario sin esperar a Enter
                tecla = Console.ReadKey(true);

                // Evalúa qué tecla se presionó
                switch (tecla.KeyChar)
                {
                    case '1':
                        // Llama al método para ingresar autos manualmente
                        IngresarAutos();
                        break;
                    case '2':
                        // Llama al método para cargar autos desde el archivo
                        CargarAutos();
                        break;
                    case '3':
                        // Llama al método para guardar autos en el archivo
                        GuardarAutos();
                        break;
                    case '4':
                        // Llama al método para mostrar la lista actual
                        ListarAutos();
                        break;
                    case '5':
                        // Marca la variable de salida como verdadera
                        salir = true;
                        // Muestra mensaje de despedida
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        // Si la tecla no es ninguna de las anteriores, muestra error
                        Console.WriteLine("\nOpción no válida.");
                        Console.Write("\nPresiona una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (!salir); // Repite mientras 'salir' sea falso
        }

        // Método privado para mostrar el menú en pantalla
        private void MostrarMenu()
        {
            // Limpia la consola para mostrar un menú fresco
            Console.Clear();
            // Imprime el título
            Console.WriteLine("Menú de Opciones");
            // Imprime la línea separadora
            Console.WriteLine("================");
            // Imprime las opciones numeradas
            Console.WriteLine("1. Ingresar autos desde la consola");
            Console.WriteLine("2. Cargar lista de autos desde el disco");
            Console.WriteLine("3. Guardar lista de autos en el disco");
            Console.WriteLine("4. Listar por consola");
            Console.WriteLine("5. Salir");
            // Pide al usuario que ingrese su opción
            Console.Write("\nIngrese su opción: ");
        }

        // Método privado para agregar autos manualmente
        private void IngresarAutos()
        {
            // Mensaje informativo
            Console.WriteLine("\n--- Ingresar Autos ---");
            Console.WriteLine("Ingrese Datos (vacío para terminar):");
            
            // Bucle infinito para ingresar múltiples autos
            while (true)
            {
                // Pide la marca
                Console.Write("Marca: ");
                // Lee la línea ingresada por el usuario (string? indica que puede ser null)
                string? marca = Console.ReadLine();
                
                // Si la marca está vacía o es solo espacios, termina el bucle
                if (string.IsNullOrWhiteSpace(marca)) break;

                // Pide el modelo
                Console.Write("Modelo: ");
                // Lee el modelo
                string? modelo = Console.ReadLine();

                // Si el modelo está vacío, avisa y pide de nuevo (continue salta al inicio del while)
                if (string.IsNullOrWhiteSpace(modelo))
                {
                    Console.WriteLine("El modelo no puede estar vacío, auto descartado.");
                    continue;
                }

                // Crea un nuevo Auto con los datos ingresados
                _autos.Add(new Auto(marca, modelo));
                // Confirma al usuario que se agregó
                Console.WriteLine("Auto agregado.");
            }
        }

        // Método privado para cargar datos desde el repositorio
        private void CargarAutos()
        {
            // Limpia la lista actual en memoria para evitar duplicados
            _autos.Clear(); 
            // Llama al repositorio para obtener la lista guardada
            var autosCargados = _repository.Cargar();
            // Agrega todos los autos cargados a la lista local
            _autos.AddRange(autosCargados);
        }

        // Método privado para guardar datos en el repositorio
        private void GuardarAutos()
        {
            // Delega la tarea de guardar al repositorio, pasando la lista actual
            _repository.Guardar(_autos);
        }

        // Método privado para mostrar la lista en consola
        private void ListarAutos()
        {
            // Título de la sección
            Console.WriteLine("\n--- Lista de Autos ---");
            
            // Verifica si la lista está vacía
            if (_autos.Count == 0)
            {
                // Mensaje si no hay datos
                Console.WriteLine("No hay autos en la lista.");
                // Pausa para el usuario
                Console.Write("\nPresiona una tecla para continuar...");
                Console.ReadKey();
                // Sale del método
                return;
            }

            // Inicializa un contador para numerar los autos
            int indice = 1;
            
            // Recorre cada auto en la lista
            foreach (var auto in _autos)
            {
                // Imprime el número de orden, marca y modelo
                Console.WriteLine($"{indice}. {auto.Marca} - {auto.Modelo}");
                // Incrementa el contador
                indice++;
            }
            
            // Pausa final para que el usuario pueda leer la lista
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
