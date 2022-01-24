namespace ControllerHost;

public class Utilities : IUtilities
{
    public void PrintValue(string buttonName, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{buttonName}");
    }
}