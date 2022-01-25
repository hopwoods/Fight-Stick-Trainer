using ControllerInterface.Controllers;
using ControllerInterface.Dtos;
using ControllerInterface.Events;
using ControllerInterface.Pocos;
using Server.Client;
using Server.Utilities;

namespace Server;

internal class ServerControllerEvents : IControllerEvents
{
    private readonly ILogger<ServerControllerEvents> _logger;
    private readonly ITrainerHubClient _client;
    private readonly IInputString _inputString;
    private readonly IUtilities _utilities;

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IInputString inputString, ITrainerHubClient client, IUtilities utilities)
    {
        _logger = logger;
        _inputString = inputString;
        _client = client;
        _utilities = utilities;
    }

    #region Implementation of IControllerEvents

    public async Task OnControllerDisconnected(IXboxController controller)
    {
        try
        {
            _logger.LogInformation("Controller Event: OnControllerDisconnected triggered");
            _logger.LogInformation("Sending Controller State to clients");
            await _client.SendControllerConnectionStateAsync(controller.IsConnected);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }

    }

    public async Task OnControllerConnected(IXboxController controller)
    {
        await _client.SendControllerConnectionStateAsync(controller.IsConnected);
    }

    public async Task OnAButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.AButton, ConsoleColor.DarkGreen);
        await _client.SendButtonPressedAsync(ControllerInputNames.AButton);
    }

    public void OnBButtonPressed(IXboxController controller)
    {
        _utilities.PrintValue(ControllerInputNames.BButton, ConsoleColor.DarkRed);
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        return;
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        return;
    }

    #endregion
}