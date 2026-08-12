namespace Teoria5;

class Cuadrado
{
	private double _lado;
	public double Lado
	{
		get => _lado;
		set => _lado = value;
	}
	public double Area
	{
		get => _lado * _lado;
	}
}
