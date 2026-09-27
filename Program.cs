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
foreach (var producto in productosCarta)
{
    if (producto is Bebida)
    {
        producto.MostrarDescripcion();
    }
}

int opcionCarta = 0;
do
{
    Console.WriteLine("=====================");
    Console.WriteLine("     RESTAURANTE     ");
    Console.WriteLine("");
    Console.WriteLine("1. Ver carta");
    Console.WriteLine("2. Elegir Producto por número");
    Console.WriteLine("3. Buscar Producto por nombre");
    Console.WriteLine("4. Buscar Productos por precio");
    Console.WriteLine("5. Buscar Producto más caro");
    Console.WriteLine("0. Cerrar programa");
    Console.WriteLine("");
    Console.WriteLine("Elige una opción");

    if (int.TryParse(Console.ReadLine(), out opcionCarta))
    {
        switch (opcionCarta)
        {
            case 0:
                Console.WriteLine("Programa cerrado");
                break;
                
            case 1:
                MostrarCarta(productosCarta);
                break;

            case 2:
                BuscarProductoPorNumero(productosCarta);
                break;

            case 3:
                BuscarProductoPorNombre(productosCarta);
                break;

            case 4: 
                BuscarProductosPorRangoPrecio(productosCarta);
                break;

            case 5:
                BuscarProductoMasCaro(productosCarta);
                break;

            default:
                Console.WriteLine("Introduce una opción válida");
                break;        

        }
    }
} while (opcionCarta != 0);

//MÉTODOS
//Mostrar carta enumerada
void MostrarCarta(List<Producto> listaProductos)
{
    Console.WriteLine("=== CARTA RESTAURANTE ===");
    Console.WriteLine("    PLATO      PRECIO");
    Console.WriteLine("-------------------------");

    int contador = 1;
    foreach (var producto in productosCarta)
    {
        Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}€");
        contador++;
    }
}


//Seleccionar producto de la carta
void BuscarProductoPorNumero(List<Producto> listaProductos)
{
    int opcion;
    Console.WriteLine("=== Búsqueda por número ===");
    Console.Write("¿Qué producto quieres?");

    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        if (0 < opcion && opcion <= productosCarta.Count)
        {
            Console.WriteLine($"Has elegido:");
            productosCarta[opcion - 1].MostrarDescripcion();
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
}


//Busqueda de un producto por su nombre
void BuscarProductoPorNombre(List<Producto> listaProductos)
{
    Console.WriteLine("=== Búsqueda por nombre ===");
    Console.WriteLine("¿Qué producto desea buscar? Introduzca el nombre: ");
    string nombreProducto = Console.ReadLine().ToLower().Trim();
    bool productoEncontrado = false;

    foreach (var producto in productosCarta)
    {
        if (producto.Nombre.ToLower().Trim() == nombreProducto)
        {
            producto.MostrarDescripcion();
            productoEncontrado = true;
        }
    }

    if (!productoEncontrado)
    {
        Console.WriteLine("No se ha encontrado el producto");
    }
}

//Mostrar productos por un rango de precio
void BuscarProductosPorRangoPrecio(List<Producto> listaProductos)
{
    decimal rangoPrecio;
    bool hayProductos = false;

    Console.WriteLine("=== Búsqueda por precio máximo ===");
    Console.WriteLine("Introduce el precio máximo de la búsqueda: ");

    if (decimal.TryParse(Console.ReadLine(), out rangoPrecio))
    {
        Console.WriteLine($"=== Productos encontrados (hasta {rangoPrecio}€) ===");
        foreach (var producto in productosCarta)
        {
            if (producto.Precio <= rangoPrecio)
            {
                producto.MostrarDescripcion();
                hayProductos = true;
            }
        }
    }

    if (!hayProductos)
    {
        Console.WriteLine($"No existe ningún producto que cueste menos de {rangoPrecio}");
    }
}

//Localizar el producto más caro de la carta
void BuscarProductoMasCaro(List<Producto> listaProductos)
{
    decimal precioMaximo = 0;

    foreach (var producto in productosCarta)
    {
        if (producto.Precio > precioMaximo)
        {
            precioMaximo = producto.Precio;
        }
    }

    Console.WriteLine("El producto más caro es: ");
    foreach (var producto in productosCarta)
    {
        if (producto.Precio == precioMaximo)
        {
            producto.MostrarDescripcion();
        }
    }
}
