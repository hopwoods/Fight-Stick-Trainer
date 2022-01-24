namespace ControllerHost;

public class Utilities : IUtilities
{
    public void PrintButtonValue(string buttonName, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{buttonName}");
    }
}