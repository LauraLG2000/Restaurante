using Models;
namespace Models;

public class Entrante : Producto
{

    public int CantidadPersonas{get; set;}
    public bool isCaliente{get; set;}

    public Entrante(string _nombre, decimal _precio, List<string> _ingredientes, int _cantidadPersonas, bool _isCaliente) : base(_nombre, _precio, _ingredientes)
    {
        this.CantidadPersonas = _cantidadPersonas;
        this.isCaliente = _isCaliente;
    }

    public override decimal CalcularPrecio()
    {
        throw new NotImplementedException();
    }

    public override void MostrarDescripcion()
    {
        string entranteCaliente = isCaliente ? "Sí": "No";
        string listaIngredientes = string.Join(", ", Ingredientes);
        Console.WriteLine($"Entrante - Nombre: {Nombre} - Precio: {Precio} - Ingredientes: {listaIngredientes} - Cantidad de Personas:{CantidadPersonas} - Se sirve caliente:{entranteCaliente}");
    }
}