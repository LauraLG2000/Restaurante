using Models;

namespace Utils;

public class InputUtils
{
    public static int InputIntDentroRangoArray(string mensaje, List<Producto> lista)
    {
        int indice;

        Console.Write(mensaje);

        if (!int.TryParse(Console.ReadLine(), out indice) || indice < 0 || indice > lista.Count)
            {
                throw new ArgumentOutOfRangeException("Error: no hay ningún producto asociado a ese número");
            }

        return indice;
        
    }
    public static string InputStringNoVacio(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine();

        if(entrada is null || entrada == "")
        {
            throw new NullReferenceException("Error: El campo no puede estar vacío.");
        }

        return entrada;
    }

    public static decimal InputDecimalMayorDeCero(string mensaje)
    {
        Console.Write(mensaje);
        decimal entrada;

        if(!decimal.TryParse(Console.ReadLine(), out entrada) || entrada < 0.0m)
        {
            throw new ArgumentOutOfRangeException("Error: El valor no puede ser 0 o negativo.");
        }

        return entrada;
    }
}