using models;
using Models;

PlatoPrincipal platoPrincipal1 = new PlatoPrincipal("Pizza", 12, ["tomate", "queso", "albahaca"]);
Bebida bebida1 = new Bebida ("Fanta Naranja", 1.5m, ["Agua con Gas", "Zumo de Naranja"],false);
Postre postre1 = new Postre("Tarta de queso", 12.45m, ["Leche", "Queso", "Huevos"], 15, false);

List<Producto> combo = new();
combo.Add(platoPrincipal1);
combo.Add(bebida1);
combo.Add(postre1);

foreach (var producto in combo)
{
    producto?.MostrarDescripcion();
}

Combo combo1 = new Combo("Menú del Día", platoPrincipal1, bebida1, postre1);

combo1.MostrarDescripcion();
Console.WriteLine(combo1.CalcularPrecio());
Console.WriteLine(combo1.PrecioConDescuento());