using ControllerInterface.Controllers;
using ControllerInterface.Dtos;
using ControllerInterface.Events;
using ControllerTestConsole.Utilities;
using Microsoft.Extensions.Logging;

namespace ControllerTestConsole.Events;

public class ConsoleControllerEvents : IControllerEvents
{
    private readonly ILogger<ConsoleControllerEvents> logger;
    private readonly IUtilities utilities;
    private int disconnectedMessageCount = 0;
    private int connectedMessageCount = 0;

    public ConsoleControllerEvents(ILogger<ConsoleControllerEvents> logger, IUtilities utilities)
    {
        this.logger = logger;
        this.utilities = utilities;
    }

    public void OnControllerDisconnected(IXboxController controller)
    {
        if (disconnectedMessageCount == 0)
        {
            utilities.WriteLine();
            utilities.PrintValue("Controller Disconnected", ConsoleColor.DarkRed);
            utilities.WriteLine();
            disconnectedMessageCount++;
        }

        connectedMessageCount = 0;
        logger.LogDebug("Controller Disconnected");
    }

    public void OnControllerConnected(IXboxController controller)
    {
        if (connectedMessageCount == 0)
        {
            utilities.WriteLine();
            utilities.PrintValue("Controller Connected", ConsoleColor.DarkGreen);
            utilities.WriteLine();
            connectedMessageCount++;
        }

        disconnectedMessageCount = 0;
        logger.LogDebug("Controller Connected");
    }
    
    public void OnAButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
    }

    public void OnBButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.BButton, ConsoleColor.DarkRed);
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.XButton, ConsoleColor.DarkCyan);
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.YButton, ConsoleColor.DarkYellow);
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.RbButton, ConsoleColor.White);
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.LbButton, ConsoleColor.White);
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadUpButton, ConsoleColor.White);
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadDownButton, ConsoleColor.White);
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadLeftButton, ConsoleColor.White);
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadRightButton, ConsoleColor.White);
    }
}