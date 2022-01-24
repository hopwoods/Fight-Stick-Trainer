using ControllerInterface.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Client;
using Server.Hubs;

namespace Server;

internal class ServerControllerEvents: IControllerEvents
{
    private readonly ILogger<ServerControllerEvents> _logger;
    private readonly ITrainerHubClient _client;
    private readonly IInputString _inputString;

    public ServerControllerEvents(ILogger<ServerControllerEvents> logger, IInputString inputString, ITrainerHubClient client)
    {
        _logger = logger;
        _inputString = inputString;
        _client = client;
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
        try
        {
            _logger.LogInformation("Controller Event: OnControllerConnected triggered");
            _logger.LogInformation("Sending Controller State to clients");
            await _client.SendControllerConnectionStateAsync(controller.IsConnected);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while sending Controller State.");
            throw;
        }
    }

    public void OnAButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }
    
    public void OnBButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnXButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnYButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnRbButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnLbButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnDpadUpButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnDpadDownButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnDpadLeftButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    public void OnDpadRightButtonPressed(IXboxController controller)
    {
        throw new NotImplementedException();
    }

    #endregion
}