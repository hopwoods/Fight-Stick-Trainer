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
    #region Private Fields

    private readonly ILogger<ServerControllerEvents> logger;
    private readonly IInputString inputString;
    private readonly IUtilities utilities;
    private readonly IHubContext<TrainerHub, ITrainerHub> trainerHub;

    #endregion

    #region Constructor

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IInputString inputString, IUtilities utilities, IHubContext<TrainerHub, ITrainerHub> trainerHub)
    {
        this.logger = logger;
        this.inputString = inputString;
        this.utilities = utilities;
        this.trainerHub = trainerHub;
    }

    #endregion

    #region Private Methods

    private async Task SendControllerConnectionStateToClient(IXboxController controller, string eventName)
    {
        try
        {
            logger.LogInformation($"Controller Event: {eventName} triggered");
            logger.LogInformation("Sending Controller State to clients");
            await trainerHub.Clients.All.ReceiveControllerConnectionState(controller.IsConnected);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }
    }

    private async Task SendButtonPressToClients(string inputName, ConsoleColor color)
    {
        logger.LogInformation($"Controller Event: On{inputName}ButtonPressed triggered");
        logger.LogInformation($"Sending Button Press {inputName} notification to clients");
        utilities.PrintValue(inputName, color);
        await trainerHub.Clients.All.ReceiveButtonPress(inputName);
    }

    #endregion

    #region Implementation of IControllerEvents

    public async void OnControllerDisconnected(IXboxController controller)
    {
        await SendControllerConnectionStateToClient(controller, "OnControllerDisconnected");
    }
    public async void OnControllerConnected(IXboxController controller)
    {
        await SendControllerConnectionStateToClient(controller, "OnControllerDisconnected");
    }
    public async void OnAButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
    }
    public async void OnBButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.BButton, ConsoleColor.DarkRed);
    }
    public async void OnXButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.XButton, ConsoleColor.DarkCyan);
    }
    public async void OnYButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.YButton, ConsoleColor.DarkYellow);
    }
    public async void OnRbButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.RbButton, ConsoleColor.White);
    }
    public async void OnLbButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.LbButton, ConsoleColor.White);
    }
    public async void OnDpadUpButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.DpadUpButton, ConsoleColor.White);
    }
    public async void OnDpadDownButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.DpadDownButton, ConsoleColor.White);
    }
    public async void OnDpadLeftButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.DpadLeftButton, ConsoleColor.White);
    }
    public async void OnDpadRightButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.DpadRightButton, ConsoleColor.White);
    }
    public async void OnStartButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.StartButton, ConsoleColor.White);
    }

    #endregion
}