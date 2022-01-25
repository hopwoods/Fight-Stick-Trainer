using ControllerInterface.Dtos;
using Microsoft.AspNetCore.SignalR.Client;

namespace Server.Client
{
    public class TrainerHubClient : IDisposable, ITrainerHubClient
    {
        private readonly HubConnection connection;
        private readonly ILogger<TrainerHubClient> logger;
        private bool disposedValue;

        public TrainerHubClient(ILogger<TrainerHubClient> logger)
        {
            this.logger = logger;
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7064/hub")
                .Build();

            connection.Closed += async (Exception? error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.StartAsync();
        }

        public async Task SendControllerConnectionStateAsync(bool isControllerConnected)
        {
            try
            {
                await connection.InvokeAsync("SendControllerConnectionStateToClient", isControllerConnected);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred sending controller connection state");
            }
        }

        public async Task SendButtonPressedAsync(string inputName)
        {
            try
            {
                await connection.InvokeAsync("SendButtonPressToClient", inputName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred sending button {inputName} has been pressed");
            }
        }

        protected virtual async Task Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    await connection.StopAsync();
                    await connection.DisposeAsync();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TrainerHubClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            _ = Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
