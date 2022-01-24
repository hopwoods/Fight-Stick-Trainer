using ControllerInterface.Controllers;
using ControllerTestConsole.Utilities;
using Microsoft.Extensions.Logging;

namespace ControllerTestConsole.Events;

public class ConsoleControllerEvents : IControllerEvents
{
    private readonly ILogger<ConsoleControllerEvents> _logger;
    private readonly IUtilities _utilities;
    private int _disconnectedMessageCount = 0;
    private int _connectedMessageCount = 0;

    public ConsoleControllerEvents(ILogger<ConsoleControllerEvents> logger, IUtilities utilities)
    {
        _logger = logger;
        _utilities = utilities;
    }

    public Task OnControllerDisconnected(IXboxController controller)
    {
        if (_disconnectedMessageCount == 0)
        {
            _utilities.WriteLine();
            _utilities.PrintValue("Controller Disconnected", ConsoleColor.DarkRed);
            _utilities.WriteLine();
            _disconnectedMessageCount++;
        }

        _connectedMessageCount = 0;
        _logger.LogDebug("Controller Disconnected");

        return Task.CompletedTask;
    }

    public Task OnControllerConnected(IXboxController controller)
    {
        if (_connectedMessageCount == 0)
        {
            _utilities.WriteLine();
            _utilities.PrintValue("Controller Connected", ConsoleColor.DarkGreen);
            _utilities.WriteLine();
            _connectedMessageCount++;
        }

        _disconnectedMessageCount = 0;
        _logger.LogDebug("Controller Connected");

        return Task.CompletedTask;
    }
    
    public void OnAButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
    }

    public void OnBButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.BButton, ConsoleColor.DarkRed);
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.XButton, ConsoleColor.DarkCyan);
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.YButton, ConsoleColor.DarkYellow);
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.RbButton, ConsoleColor.White);
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.LbButton, ConsoleColor.White);
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.DpadUpButton, ConsoleColor.White);
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.DpadDownButton, ConsoleColor.White);
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.DpadLeftButton, ConsoleColor.White);
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.DpadRightButton, ConsoleColor.White);
    }
}