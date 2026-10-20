using Models;
using Utils;
public class MenuPedido
{
    private const int OpcionSalir = 9;
    private const int PrimeraOpcion = 1;
    private List<Producto> carta;
    private List<Producto> pedido;
    string mensajeInput;

    public MenuPedido()
    {
        pedido = new List<Producto>();

        carta = new List<Producto>();

        carta.Add(new Entrante("Patatas Bravas", 10.50m, ["Patatas", "Salsa Brava"], 4, true));
        carta.Add(new Entrante("Nachos", 9.90m, ["Nachos", "Guacamole"], 3, false));
        carta.Add(new Entrante("Ensaladilla Rusa", 12.90m, ["Patata", "Mayonesa", "Atún", "Huevo Duro"], 2, false));

        carta.Add(new Bebida("Agua", 1.20m, [""], false));
        carta.Add(new Bebida("CocaCola", 2.00m, ["Agua Carbonatada", "Edulcorantes"], false));

        carta.Add(new PlatoPrincipal("Pizza", 12, ["Tomate", "Queso", "Albahaca"]));
        carta.Add(new PlatoPrincipal("Hamburguesa", 17.50m, ["Hamburguesa", "Queso", "Lechuga", "Bacon"]));

        carta.Add(new Postre("Tarta de queso", 12.45m, ["Leche", "Queso", "Huevos"], 15, false));
        carta.Add(new Postre("Tarta 3 chocolates", 15.45m, ["Leche", "Galleta", "Chocolate Blanco", "Chocolate Negro", "Chocolate con Leche"], 20, true));
    }

    public void MostrarMenu()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n====== RESTAURANTE ======\n");
            Console.WriteLine($"{PrimeraOpcion}. Ver carta");
            Console.WriteLine("2. Añadir producto al pedido");
            Console.WriteLine("3. Ver pedido");
            Console.WriteLine("4. Eliminar producto del pedido");
            Console.WriteLine("5. Finalizar pedido");
            Console.WriteLine("6. Buscar producto por su nombre");
            Console.WriteLine("7. Productos por precio");
            Console.WriteLine("8. Producto más caro");
            Console.WriteLine($"{OpcionSalir}. Cerrar programa");
            Console.WriteLine($"\n Elige una opción ({PrimeraOpcion}-{OpcionSalir})");

            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < PrimeraOpcion || opcion > OpcionSalir)
            {
                Console.WriteLine($"Error: Introduce una opción válida ({PrimeraOpcion}-{OpcionSalir})");
                continue;
            }

            switch (opcion)
            {
                case PrimeraOpcion:
                    MostrarCarta();
                    break;

                case 2:
                    AgregarProductoAlPedido();
                    break;

                case 3:
                    MostrarPedido();
                    break;

                case 4:
                    EliminarProductoDelPedido();
                    break;

                case 5:
                    FinalizarPedido();
                    break;

                case 6:
                    BuscarProductoPorNombre();
                    break;

                case 7:
                    BuscarProductosPorRangoPrecio();
                    break;

                case 8:
                    BuscarProductoMasCaro();
                    break;
                
                case OpcionSalir:
                    Console.WriteLine("Programa cerrado.");
                    break;
            }

        } while (opcion != OpcionSalir);
    }

    public void MostrarCarta()
    {
        Console.WriteLine($"\n====== CARTA RESTAURANTE ======");
        Console.WriteLine("    PLATO      PRECIO");
        Console.WriteLine("--------------------------");

        int contador = 1;
        foreach (var producto in carta)
        {
            Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}€");
            contador++;
        }
    }

    public void AgregarProductoAlPedido()
    {
        try
        {
            MostrarCarta();

            mensajeInput = "Introduce el número del producto: ";
            int numeroProducto = InputUtils.InputIntDentroRangoArray(mensajeInput, carta);

            pedido.Add(carta[numeroProducto - 1]);
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    public void MostrarPedido()
    {
        decimal totalPrecio = 0;
        int contador = 1;

        if (pedido.Count != 0)
        {
            Console.WriteLine("\n====== PEDIDO ======");
            Console.WriteLine("----------------------\n");

            foreach (var producto in pedido)
            {
                Console.WriteLine($"{contador}. {producto.Nombre} - {producto.Precio}");
                totalPrecio += producto.Precio;
                contador++;
            }

            Console.WriteLine("\n----------------------");
            Console.WriteLine($"TOTAL:  {totalPrecio}€");
            Console.WriteLine($"Productos:  {pedido.Count}");
        }
        else
        {
            Console.WriteLine("No hay productos registrados.");
        }
    }

    public void EliminarProductoDelPedido()
    {
        try
        {
            if (pedido.Count != 0)
            {
                MostrarPedido();

                mensajeInput = "Introduce el número del producto a eliminar del pedido: ";
                int opcionProducto = InputUtils.InputIntDentroRangoArray(mensajeInput, pedido);

                pedido.RemoveAt(opcionProducto - 1);
            }
            else
            {
                Console.WriteLine("El pedido está vacío.");
            }
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }


    }

    public void FinalizarPedido()
    {
        if (pedido.Count != 0)
        {
            MostrarPedido();
            Console.WriteLine("Gracias por su visita");
            pedido.Clear();
        }
        else
        {
            Console.WriteLine("El pedido está vacío");
        }
    }

    public void BuscarProductoPorNombre()
    {
        try
        {
            mensajeInput = "Introduce el nombre del producto a buscar: ";
            string nombreProducto = InputUtils.InputStringNoVacio(mensajeInput).ToLower().Trim();
            bool encontrado = false;

            foreach (var producto in carta)
            {
                if (producto.Nombre.ToLower().Equals(nombreProducto))
                {
                    Producto productoEncontrado = producto;
                    productoEncontrado.MostrarDescripcion();
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine($"No se ha encontrado el producto {nombreProducto}");
            }
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.ToString());
        }
    }

    public void BuscarProductosPorRangoPrecio()
    {
        try
        {
            mensajeInput = "Introduce el precio máximo de la búsqueda: ";
            decimal precioMaximo = InputUtils.InputDecimalMayorDeCero(mensajeInput);

            List<Producto> cartaFiltrada = new List<Producto>();

            foreach (var producto in carta)
            {
                if (producto.Precio <= precioMaximo)
                {
                    cartaFiltrada.Add(producto);
                }
            }

            if (cartaFiltrada.Count != 0)
            {
                foreach (var producto in cartaFiltrada)
                {
                    producto.MostrarDescripcion();
                }
            }
            else
            {
                Console.WriteLine($"No hay productos por {precioMaximo} o menos");
            }
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    public void BuscarProductoMasCaro()
    {
        decimal precioMaximo = 0.0m;

        foreach (var producto in carta)
        {
            if (producto.Precio > precioMaximo)
            {
                precioMaximo = producto.Precio;
            }
        }

        foreach (var producto in carta)
        {
            if (producto.Precio == precioMaximo)
            {
                producto.MostrarDescripcion();
            }
        }
    }
}