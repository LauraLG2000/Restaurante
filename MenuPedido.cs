using Models;
public class MenuPedido
{
    private const int OpcionSalir = 9;
    private const int PrimeraOpcion = 1;
    private List<Producto> carta;
    private List<Producto> pedido;

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
                case 1:
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

                default:
                    Console.WriteLine("Introduce una opción válida");
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
            int numeroProducto;
            Console.WriteLine("Introduce el número del producto: ");

            if (!int.TryParse(Console.ReadLine(), out numeroProducto) || numeroProducto < 0 || numeroProducto > pedido.Count)
            {
                throw new ArgumentOutOfRangeException("Error: no hay ningún producto asociado a ese número");
            }

            pedido.Add(carta[numeroProducto]);
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            Console.WriteLine(aoore.ToString());
        }
    }

    public void MostrarPedido()
    {

    }

    public void EliminarProductoDelPedido()
    {

    }

    public void FinalizarPedido()
    {

    }

    public void BuscarProductoPorNombre()
    {

    }

    public void BuscarProductosPorRangoPrecio()
    {

    }

    public void BuscarProductoMasCaro()
    {

    }

}