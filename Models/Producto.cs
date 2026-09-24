namespace Models;
public abstract class Producto
{
    public string Nombre {get; set;}
    public decimal Precio {get; set;}
    public List<string> Ingredientes {get; set;}

    public Producto (string _nombre, decimal _precio, List<string> _ingredientes){
        this.Nombre = _nombre;
        this.Precio = _precio;
        this.Ingredientes = _ingredientes;
    }

    public abstract void MostrarDescripcion();

    public abstract decimal CalcularPrecio();
}