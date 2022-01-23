using ControllerInterface.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerHost;

public class ControllerPollerService : IHostedService, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<ControllerPollerService> _logger;
    private Timer _timer = null!;
    private IXboxController Controller { get; set; }

    public ControllerPollerService(ILogger<ControllerPollerService> logger, IXboxController controller, IConfiguration configuration)
    {
        _logger = logger;
        Controller = controller;
        _configuration = configuration;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(int.Parse(_configuration["ControllerSettings:PollingRate"])));

        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        Controller.Update();

        if (Controller.IsConnected)
        {
            Console.WriteLine($"Xbox Controller is connected: {Controller.IsConnected}");
            Console.WriteLine($"Xbox Controller A Button Pressed: {Controller.A_Button}");
            Console.WriteLine($"Xbox Controller Y Button Pressed: {Controller.Y_Button}");
            Console.WriteLine($"Xbox Controller B Button Pressed: {Controller.B_Button}");
            Console.WriteLine($"Xbox Controller X Button Pressed: {Controller.X_Button}");
            Console.WriteLine($"Xbox Controller RB Button Pressed: {Controller.RB_Button}");
            Console.WriteLine($"Xbox Controller LB Button Pressed: {Controller.LB_Button}");
        }
        else
        {
            Console.WriteLine($"Please connect a Xbox controller");
        }
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