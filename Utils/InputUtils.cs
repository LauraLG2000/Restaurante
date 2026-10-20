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
}