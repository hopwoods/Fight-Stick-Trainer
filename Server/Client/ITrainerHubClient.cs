using ControllerInterface.Dtos;

namespace Server.Client;

public interface ITrainerHubClient
{
    Task SendControllerConnectionStateAsync(bool isControllerConnected);
    
    Task SendButtonPressedAsync(string inputName);

    void Dispose();
}