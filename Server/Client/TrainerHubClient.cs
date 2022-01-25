using ControllerInterface.Dtos;
using Microsoft.AspNetCore.SignalR.Client;

namespace Server.Client
{
    public class TrainerHubClient : IDisposable, ITrainerHubClient
    {
        private readonly HubConnection _connection;
        private readonly ILogger<TrainerHubClient> _logger;
        private bool _disposedValue;

        public TrainerHubClient(ILogger<TrainerHubClient> logger)
        {
            _logger = logger;
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7064/hub")
                .Build();

            _connection.Closed += async (Exception? error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };

            _connection.StartAsync();
        }

        public async Task SendControllerConnectionStateAsync(bool isControllerConnected)
        {
            try
            {
                await _connection.InvokeAsync("SendControllerConnectionStateToClient", isControllerConnected);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred sending controller connection state");
            }
        }

        public async Task SendButtonPressedAsync(string inputName)
        {
            try
            {
                await _connection.InvokeAsync("SendButtonPressToClient", inputName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred sending button {inputName} has been pressed");
            }
        }

        protected virtual async Task Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    await _connection.StopAsync();
                    await _connection.DisposeAsync();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
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
