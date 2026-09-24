using Models;

namespace Models;

public class Bebida : Producto
{

    public bool isAlcoholica{get; set;}
    public Bebida(string _nombre, decimal _precio, List<string> _ingredientes, bool _isAlcoholica) : base(_nombre, _precio, _ingredientes)
    {
        this.isAlcoholica = _isAlcoholica;
    }

    public override decimal CalcularPrecio()
    {
        throw new NotImplementedException();
    }

    public override void MostrarDescripcion()
    {
        string Alcoholica = isAlcoholica ? "Sí" : "No";
        Console.WriteLine($"Bebida - Nombre: {Nombre} - Precio: {Precio} - Ingredientes:{Ingredientes} - Alcoholica:{Alcoholica}");
    }
}