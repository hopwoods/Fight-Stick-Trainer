using ControllerInterface.Controllers;
using ControllerInterface.Dtos;
using ControllerInterface.Events;
using ControllerInterface.Pocos;
using Server.Client;
using Server.Utilities;

namespace Server;

internal class ServerControllerEvents : IControllerEvents
{
    private readonly ILogger<ServerControllerEvents> logger;
    private readonly ITrainerHubClient client;
    private readonly IInputString inputString;
    private readonly IUtilities utilities;

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IInputString inputString, ITrainerHubClient client, IUtilities utilities)
    {
        this.logger = logger;
        this.inputString = inputString;
        this.client = client;
        this.utilities = utilities;
    }

    #region Implementation of IControllerEvents

    public async void OnControllerDisconnected(IXboxController controller)
    {
        try
        {
            logger.LogInformation("Controller Event: OnControllerDisconnected triggered");
            logger.LogInformation("Sending Controller State to clients");
            await client.SendControllerConnectionStateAsync(controller.IsConnected);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }

    }

    public async void OnControllerConnected(IXboxController controller)
    {
        await client.SendControllerConnectionStateAsync(controller.IsConnected);
    }

    public async void OnAButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
        await client.SendButtonPressedAsync(ControllerInputNames.AButton);
    }

    public async void OnBButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.BButton, ConsoleColor.DarkRed);
        await client.SendButtonPressedAsync(ControllerInputNames.BButton);
    }

    public async void OnXButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.XButton, ConsoleColor.DarkCyan);
        await client.SendButtonPressedAsync(ControllerInputNames.XButton);
    }

    public async void OnYButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.YButton, ConsoleColor.DarkYellow);
        await client.SendButtonPressedAsync(ControllerInputNames.YButton);
    }

    public async void OnRbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.RbButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.RbButton);
    }

    public async void OnLbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.LbButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.LbButton);
    }

    public async void OnDpadUpButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadUpButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.DpadUpButton);
    }

    public async void OnDpadDownButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadDownButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.DpadDownButton);
    }

    public async void OnDpadLeftButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadLeftButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.DpadLeftButton);
    }

    public async void OnDpadRightButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadRightButton, ConsoleColor.White);
        await client.SendButtonPressedAsync(ControllerInputNames.DpadRightButton);
    }

    #endregion
}