using ControllerInterface.Controllers;
using Microsoft.Extensions.Logging;

namespace ControllerHost;

public class ConsoleControllerEvents : IControllerEvents
{
    private readonly ILogger<ConsoleControllerEvents> _logger;
    private readonly IUtilities _utilities;

    public ConsoleControllerEvents(ILogger<ConsoleControllerEvents> logger, IUtilities utilities)
    {
        _logger = logger;
        _utilities = utilities;
    }

    public void OnControllerDisconnected(IXboxController controller)
    {
        _logger.LogDebug("Controller Disconnected ");
    }

    public void OnControllerConnected(IXboxController controller)
    {
        _logger.LogDebug("Controller Connected ");
    }
    
    public void OnAButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("A", ConsoleColor.DarkGreen);
    }

    public void OnBButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("B", ConsoleColor.DarkRed);
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("X", ConsoleColor.DarkCyan);
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("Y", ConsoleColor.DarkYellow);
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("RB", ConsoleColor.White);
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("LB", ConsoleColor.White);
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("Up", ConsoleColor.White);
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("Down", ConsoleColor.White);
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("Left", ConsoleColor.White);
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue("Right", ConsoleColor.White);
    }
}