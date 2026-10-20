namespace Utils;

public class InputUtils
{
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