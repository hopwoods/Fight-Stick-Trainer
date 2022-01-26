using ControllerInterface.Controllers;
using ControllerInterface.Dtos;
using ControllerInterface.Events;
using ControllerInterface.Pocos;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using Server.Utilities;

namespace Server;

internal class ServerControllerEvents : IControllerEvents
{
    private readonly ILogger<ServerControllerEvents> logger;
    private readonly IInputString inputString;
    private readonly IUtilities utilities;
    private readonly IHubContext<TrainerHub, ITrainerHub> trainerHub;

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IInputString inputString, IUtilities utilities, IHubContext<TrainerHub, ITrainerHub> trainerHub)
    {
        this.logger = logger;
        this.inputString = inputString;
        this.utilities = utilities;
        this.trainerHub = trainerHub;
    }

    #region Implementation of IControllerEvents

    public async void OnControllerDisconnected(IXboxController controller)
    {
        try
        {
            logger.LogInformation("Controller Event: OnControllerDisconnected triggered");
            logger.LogInformation("Sending Controller State to clients");
            await trainerHub.Clients.All.ReceiveControllerConnectionState(controller.IsConnected);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }

    }

    public async void OnControllerConnected(IXboxController controller)
    {
        try
        {
            logger.LogInformation("Controller Event: OnControllerConnected triggered");
            logger.LogInformation("Sending Controller State to clients");
            await trainerHub.Clients.All.ReceiveControllerConnectionState(controller.IsConnected);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }
    }

    public async void OnAButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.AButton);
    }

    public async void OnBButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.BButton, ConsoleColor.DarkRed);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.BButton);
    }

    public async void OnXButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.XButton, ConsoleColor.DarkCyan);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.XButton);
    }

    public async void OnYButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.YButton, ConsoleColor.DarkYellow);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.YButton);
    }

    public async void OnRbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.RbButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.RbButton);
    }

    public async void OnLbButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.LbButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.LbButton);
    }

    public async void OnDpadUpButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadUpButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.DpadUpButton);
    }

    public async void OnDpadDownButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadDownButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.DpadDownButton);
    }

    public async void OnDpadLeftButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadLeftButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.DpadLeftButton);
    }

    public async void OnDpadRightButtonPressed(IXboxController controller)
    {
        utilities.PrintValue(ControllerInputNames.DpadRightButton, ConsoleColor.White);
        await trainerHub.Clients.All.ReceiveButtonPress(ControllerInputNames.DpadRightButton);
    }

    #endregion
}