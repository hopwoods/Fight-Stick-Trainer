namespace Server.Client;

public interface ITrainerHubClient
{
    Task SendControllerConnectionStateAsync(bool isControllerConnected);
    void Dispose();
}