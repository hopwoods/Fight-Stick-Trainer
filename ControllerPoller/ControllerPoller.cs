using ControllerInterface.Controllers;

namespace ControllerPoller
{
    public class ControllerPollerService : IHostedService, IDisposable
    {
        private int _executionCount = 0;
        private readonly ILogger<ControllerPollerService> _logger;
        private Timer _timer = null!;
        private IXboxController Controller { get; set; }

        public ControllerPollerService(ILogger<ControllerPollerService> logger, IXboxController controller)
        {
            _logger = logger;
            Controller = controller;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref _executionCount);

            Controller.Update();

            _logger.LogInformation(
                "Updated Controller. Count: {Count}", count);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}