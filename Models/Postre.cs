namespace Models;

public class Postre : Producto
{

    public decimal Calorias{get; set;}
    public bool isSugarFree{get;set;}
    public Postre(string _nombre, decimal _precio, List<string> _ingredientes, decimal _calorias, bool _isSugarFree) : base(_nombre, _precio, _ingredientes)
    {
        this.Calorias = _calorias;
        this.isSugarFree = _isSugarFree;
    }

    public override decimal CalcularPrecio()
    {
        throw new NotImplementedException();
    }

    public override void MostrarDescripcion()
    {
        string SugarFree = isSugarFree ? "Sí" : "No";
        Console.WriteLine($"Postre - Nombre: {Nombre} - Precio: {Precio} - Ingredientes:{Ingredientes} - Calorias:{Calorias} - Sin Azúcar:{SugarFree}");
    }
}