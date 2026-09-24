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

//Entrantes
Entrante patatasBravas = new Entrante("Patatas Bravas", 10.50m, ["Patatas", "Salsa Brava"], 4, true);
Entrante nachos = new Entrante("Nachos", 9.90m, ["Nachos", "Guacamole"], 3, false);
Entrante ensaladillaRusa = new Entrante("Ensaladilla Rusa", 12.90m, ["Patata", "Mayonesa", "Atún", "Huevo Duro"], 2, false);

patatasBravas.MostrarDescripcion();
nachos.MostrarDescripcion();
ensaladillaRusa.MostrarDescripcion();