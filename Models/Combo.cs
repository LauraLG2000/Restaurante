namespace Models;
using Models;


public class Combo : Producto
{
    public PlatoPrincipal? PlatoPrincipal{get; set;}
    public Bebida? Bebida{get; set;}
    public Postre? Postre{get; set;}
    public Producto? extra{get;set;}
    public decimal descuento {get;} = 0.2m;

    public decimal Precio
    {
        get
        {
            return CalcularPrecio();
        }
    }

    public Combo(string _nombre, PlatoPrincipal platoPrincipal, Bebida bebida, Postre postre) : base(_nombre, 0, [""])
    {
        PlatoPrincipal = platoPrincipal;
        Bebida = bebida;
        Postre = postre;
    }

    public override decimal CalcularPrecio()
    {
        decimal precioFinal = PlatoPrincipal?.Precio ?? 0 + Bebida?.Precio ?? 0 + Postre?.Precio ?? 0;
        return precioFinal;
        throw new NotImplementedException();
    }

    public decimal PrecioConDescuento()
    {
        return Precio - (Precio * (1-descuento));
    }

    public override void MostrarDescripcion()
    {
        Console.WriteLine($"{Nombre} - Plato Principal: {PlatoPrincipal.Nombre} - Bebida: {Bebida.Nombre} - Postre: {Postre.Nombre} - Precio: {Precio}");
    }
}