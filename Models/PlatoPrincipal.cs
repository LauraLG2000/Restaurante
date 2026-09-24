using models;

namespace Models;

public class PlatoPrincipal : Producto
{
    public PlatoPrincipal(string _nombre, decimal _precio, List<string> _ingredientes) : base(_nombre, _precio, _ingredientes)
    {
    }

    public override decimal CalcularPrecio()
    {
        throw new NotImplementedException();
    }

    public override void MostrarDescripcion()
    {
        Console.WriteLine($"Plato Principal - Nombre: {Nombre} - Precio: {Precio} - Ingredientes:{Ingredientes}");
    }
}