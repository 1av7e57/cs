// Importa los contratos para implementar la interfaz IAuto
using Ejercicio10.Contratos;

// Define el espacio de nombres para los modelos
namespace Ejercicio10.Modelos
{
    // Clase que representa un Auto y cumple con el contrato IAuto
    public class Auto : IAuto
    {
        // Propiedad pública para la marca (implementa IAuto.Marca)
        public string Marca { get; set; }
        // Propiedad pública para el modelo (implementa IAuto.Modelo)
        public string Modelo { get; set; }

        // Constructor que recibe marca y modelo para inicializar el objeto
        public Auto(string marca, string modelo)
        {
            // Asigna el valor del parámetro 'marca' a la propiedad 'Marca'
            Marca = marca;
            // Asigna el valor del parámetro 'modelo' a la propiedad 'Modelo'
            Modelo = modelo;
        }
    }
}
