namespace Automotores;

using System;

// CLASE PÚBLICA (Requisito para que la vea ConsolaUI)
public class Auto
{
    private string? _marca;
    private int _modelo;

    // 1. Constructor Vacío
    public Auto()
    {
        _marca = "FIAT";
        _modelo = DateTime.Now.Year;
    }

    // 2. Constructor con SOLO marca
    // Llama al constructor vacío
    public Auto(string marca) : this() 
    {
        _marca = marca; 
    }

    // 3. Constructor COMPLETO
    public Auto(string marca, int modelo)
    {
        _marca = marca;
        _modelo = modelo;
    }

    public string ObtenerDescripcion()
    {
        return $"Auto {_marca} {_modelo}";
    }
}
