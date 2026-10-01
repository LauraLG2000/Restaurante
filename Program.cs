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

int opcionCarta;
List<Producto> pedido = new List<Producto>();
do
{
    Console.WriteLine("");
    Console.WriteLine("     RESTAURANTE     ");
    Console.WriteLine("---------------------");
    Console.WriteLine("");
    Console.WriteLine("1. Ver carta");
    Console.WriteLine("2. Añadir producto al pedido");
    Console.WriteLine("3. Ver pedido");
    Console.WriteLine("4. Eliminar producto del pedido");
    Console.WriteLine("5. Finalizar pedido");
    Console.WriteLine("6. Buscar producto por su nombre");
    Console.WriteLine("7. Productos por precio");
    Console.WriteLine("8. Producto más caro");
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
                Console.WriteLine("     CARTA     ");
                Console.WriteLine("---------------");
                Console.WriteLine("");
                MostrarCarta(productosCarta);
                break;

            case 2:
                AgregarProductoAlPedido(productosCarta, pedido);
                break;

            case 3:
                MostrarPedido(pedido);
                break;

            case 4:
                EliminarProductoDelPedido(pedido);
                break;

            case 5:
                FinalizarPedido(pedido);
                break;

            case 6:
                BuscarProductoPorNombre(productosCarta);
                break;

            case 7:
                BuscarProductosPorRangoPrecio(productosCarta);
                break;    

            case 8:
                BuscarProductoMasCaro(productosCarta);
                break;

            default:
                Console.WriteLine("Introduce una opción válida");
                break;

        }
    }
} while (opcionCarta != 0);

Console.WriteLine("¡Gracias por su visita, vuelva pronto!");

//MÉTODOS
//Mostrar carta enumerada
void MostrarCarta(List<Producto> listaProductos)
{
    Console.WriteLine("=== CARTA RESTAURANTE ===");
    Console.WriteLine("    PLATO      PRECIO");
    Console.WriteLine("-------------------------");

    int contador = 1;
    foreach (var producto in listaProductos)
    {
        Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}€");
        contador++;
    }
}

//Método para agregar un producto al pedido
void AgregarProductoAlPedido(List<Producto> carta, List<Producto> pedido)
{
    Console.WriteLine("     CARTA     ");
    Console.WriteLine("---------------");
    MostrarCarta(carta);

    pedido.Add(BuscarProductoPorNumero(carta));
}

//Seleccionar producto de la carta
Producto BuscarProductoPorNumero(List<Producto> listaProductos)
{
    int opcion;
    Producto productoEncontrado = null;
    do
    {
        Console.Write("¿Qué producto quieres? Introduce el número: ");

        if (int.TryParse(Console.ReadLine(), out opcion))
        {
            if (0 < opcion && opcion <= listaProductos.Count)
            {
                Console.WriteLine($"Producto {listaProductos[opcion - 1].Nombre} añadido al pedido.");
                productoEncontrado = listaProductos[opcion - 1];
            }
            else
            {
                Console.WriteLine("Ese producto no existe en la carta.");
            }
        }
        else
        {
            Console.WriteLine("Debes introducir un número de la carta");
        }
    } while (0 >= opcion || opcion > listaProductos.Count);

    return productoEncontrado;
}

//Mostrar el pedido
void MostrarPedido(List<Producto> pedido)
{
    decimal totalPrecio = 0;
    int contador = 1;

    if (pedido.Count != 0)
    {
        Console.WriteLine("     PEDIDO     ");
        Console.WriteLine("----------------");
        Console.WriteLine("");

        foreach (var producto in pedido)
        {
            Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}€");
            totalPrecio += producto.Precio;
            contador++;
        }

        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine($"TOTAL:  {totalPrecio}€");
    }
    else
    {
        Console.WriteLine("El pedido está vacío");
        Console.WriteLine("");
    }
}

//Método Eliminar producto del pedido
void EliminarProductoDelPedido(List<Producto> pedido)
{
    int opcion;

    if (pedido.Count == 0)
    {
        Console.WriteLine("No hay productos en el pedido");
    }
    else
    {
        MostrarPedido(pedido);
        Console.WriteLine("¿Qué producto quieres eliminar?");

        if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= pedido.Count)
        {
            Console.WriteLine($"Producto {pedido[opcion - 1].Nombre} eliminado con éxito");
            pedido.RemoveAt(opcion - 1);
        }
        else
        {
            Console.WriteLine("Número incorrecto");
        }
    }
}

//Finalizar pedido
void FinalizarPedido(List<Producto> pedido)
{
    decimal totalPedido = 0;

    if (pedido.Count != 0)
    {
        foreach (var producto in pedido)
        {
            totalPedido += producto.Precio;
        }

        MostrarPedido(pedido);
        Console.WriteLine($"Productos:      {pedido.Count}");

        Console.WriteLine("Gracias por su visita");
        pedido.Clear();
    }
    else
    {
        Console.WriteLine("El pedido está vacío, no se puede generar el ticket.");
    }

}

//Busqueda de un producto por su nombre
void BuscarProductoPorNombre(List<Producto> listaProductos)
{
    Console.WriteLine("=== Búsqueda producto por nombre ===");
    Console.WriteLine("¿Qué producto desea buscar? Introduzca el nombre: ");
    string nombreProducto = Console.ReadLine().ToLower().Trim();
    bool productoEncontrado = false;

    foreach (var producto in listaProductos)
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
        foreach (var producto in listaProductos)
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

    foreach (var producto in listaProductos)
    {
        if (producto.Precio > precioMaximo)
        {
            precioMaximo = producto.Precio;
        }
    }

    Console.WriteLine("El producto más caro es: ");
    foreach (var producto in listaProductos)
    {
        if (producto.Precio == precioMaximo)
        {
            producto.MostrarDescripcion();
        }
    }
}
