namespace Server.Events;

public class ServerControllerEvents : IControllerEvents
{
    #region Private Fields

    private readonly ILogger<ServerControllerEvents> logger;
    private readonly IUtilities utilities;
    private readonly IHubContext<TrainerHub, ITrainerHub> trainerHubContext;

    private const string GroupName = "FrontEnd";

    #endregion

    #region Constructor

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IUtilities utilities, IHubContext<TrainerHub, ITrainerHub> trainerHubContext)
    {
        this.logger = logger;
        this.utilities = utilities;
        this.trainerHubContext = trainerHubContext;
    }

    #endregion

    #region Private Methods

    private async Task SendControllerConnectionStateToClient(IXboxController controller, string eventName)
    {
        try
        {
            logger.LogInformation($"Controller Event: {eventName} triggered");
            logger.LogInformation("Sending Controller State to clients");
            await trainerHubContext.Clients.All.ReceiveControllerConnectionState(controller.IsConnected);
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
        await trainerHubContext.Clients.All.ReceiveButtonPress(inputName);
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

    public async void OnControllerIsWireless(IXboxController controller)
    {
        logger.LogInformation($"Controller Event: OnIsWireless triggered");
        logger.LogInformation($"Sending OnIsWireless notification to clients");
        await trainerHubContext.Clients.All.ReceiveControllerWirelessCapability(controller.IsWireless);
    }

    public async void OnUpdateBatteryInformation(IXboxController controller)
    {
        logger.LogInformation($"Controller Event: Battery Info Updated - Level: {controller.BatteryInformation.BatteryLevel}, Type - {controller.BatteryInformation.BatteryType}");
        logger.LogInformation($"Sending Battery Update notification to clients");
        var batteryInfoDto = new BatteryInformationDto
        {
            BatteryType = controller.BatteryInformation.BatteryType,
            BatteryLevel = controller.BatteryInformation.BatteryLevel
        };
        await trainerHubContext.Clients.All.ReceiveBatteryInformation(batteryInfoDto);
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

    public async void OnBackButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.ViewButton, ConsoleColor.White);
    }

    public async void OnLeftStickButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.LeftStickButton, ConsoleColor.White);
    }
    public async void OnRightStickButtonPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.RightStickButton, ConsoleColor.White);
    }

    public async void OnRightTriggerPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.RightTrigger, ConsoleColor.White);
    }

    public async void OnLeftTriggerPressed(IXboxController controller)
    {
        await SendButtonPressToClients(ControllerInputNames.LeftTrigger, ConsoleColor.White);
    }

    #endregion
}