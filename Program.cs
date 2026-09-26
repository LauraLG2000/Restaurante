using Models;

//BLOQUE 1 - Herencia y polimorfismo
//1. Clase Entrante
Entrante patatasBravas = new Entrante("Patatas Bravas", 10.50m, ["Patatas", "Salsa Brava"], 4, true);
Entrante nachos = new Entrante("Nachos", 9.90m, ["Nachos", "Guacamole"], 3, false);
Entrante ensaladillaRusa = new Entrante("Ensaladilla Rusa", 12.90m, ["Patata", "Mayonesa", "Atún", "Huevo Duro"], 2, false);

patatasBravas.MostrarDescripcion();
nachos.MostrarDescripcion();
ensaladillaRusa.MostrarDescripcion();

//2.Carta Restaurante
Bebida agua = new Bebida("Agua", 1.20m, [""], false);
Bebida cocaCola = new Bebida("CocaCola", 2.00m, ["Agua Carbonatada", "Edulcorantes"], false);

PlatoPrincipal pizza = new PlatoPrincipal("Pizza", 12, ["Tomate", "Queso", "Albahaca"]);
PlatoPrincipal hamburguesa = new PlatoPrincipal("Hamburguesa", 17.50m, ["Hamburguesa", "Queso", "Lechuga", "Bacon"]);

Postre tartaQueso = new Postre("Tarta de queso", 12.45m, ["Leche", "Queso", "Huevos"], 15, false);
Postre tarta3Chocolates = new Postre("Tarta 3 chocolates", 15.45m, ["Leche", "Galleta", "Chocolate Blanco", "Chocolate Negro", "Chocolate con Leche"], 20, true);

List<Producto> productosCarta = [patatasBravas, nachos, pizza, hamburguesa, agua, cocaCola, tartaQueso, tarta3Chocolates];

//Filtrado de productos
Console.WriteLine("=== CARTA BEBIDAS ===");
foreach(var producto in productosCarta)
{
    if(producto is Bebida)
    {
        producto.MostrarDescripcion();
    }
}

//Mostrar carta enumerada
Console.WriteLine("=== CARTA RESTAURANTE ===");
Console.WriteLine("    PLATO      PRECIO");
Console.WriteLine("-------------------------");

int contador = 1;
foreach (var producto in productosCarta)
{
    Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}€");
    contador++;
}

//Seleccionar producto de la carta
int opcion;
Console.Write("¿Qué producto quieres?");

if(int.TryParse(Console.ReadLine(),out opcion))
{
    if(0 < opcion && opcion <= productosCarta.Count)
    {
        Console.WriteLine($"Has elegido:");
        productosCarta[opcion-1].MostrarDescripcion();
    }
    else
    {
        Console.WriteLine("Ese producto no existe");
    }
}
else
{
    Console.WriteLine("Debes introducir un número de la carta");
}

//Busqueda de un producto por su nombre
Console.WriteLine("¿Qué producto desea buscar? Introduzca el nombre: " );
string nombreProducto = Console.ReadLine().ToLower().Trim();
bool productoEncontrado = false;

foreach(var producto in productosCarta)
{
    if(producto.Nombre.ToLower().Trim() == nombreProducto)
    {
        producto.MostrarDescripcion();
        productoEncontrado = true;
    }
}

if (!productoEncontrado)
{
    Console.WriteLine("No se ha encontrado el producto");
}