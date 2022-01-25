using Server.Utilities;

namespace ControllerTestConsole.Utilities;

public class Utilities : IUtilities
{
    public void PrintValue(string buttonName, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{buttonName}");
    }
    
    public void WriteLine()
    {
        Console.WriteLine();
    }
}