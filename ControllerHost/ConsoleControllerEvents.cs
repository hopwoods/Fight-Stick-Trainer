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
        _utilities.PrintButtonValue("A", ConsoleColor.DarkGreen);
    }

    public void OnBButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("B", ConsoleColor.DarkRed);
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("X", ConsoleColor.DarkCyan);
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("Y", ConsoleColor.DarkYellow);
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("RB", ConsoleColor.White);
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("LB", ConsoleColor.White);
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("Up", ConsoleColor.White);
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("Down", ConsoleColor.White);
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("Left", ConsoleColor.White);
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        _utilities.PrintButtonValue("Right", ConsoleColor.White);
    }
}