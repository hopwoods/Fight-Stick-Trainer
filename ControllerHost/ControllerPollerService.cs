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
            Console.WriteLine($"Xbox Controller A Button Pressed: {Controller.AButton}");
            Console.WriteLine($"Xbox Controller Y Button Pressed: {Controller.YButton}");
            Console.WriteLine($"Xbox Controller B Button Pressed: {Controller.BButton}");
            Console.WriteLine($"Xbox Controller X Button Pressed: {Controller.XButton}");
            Console.WriteLine($"Xbox Controller RB Button Pressed: {Controller.RbButton}");
            Console.WriteLine($"Xbox Controller LB Button Pressed: {Controller.LbButton}");
            Console.WriteLine($"Xbox Controller DPad Up Button Pressed: {Controller.DpadUpButton}");
            Console.WriteLine($"Xbox Controller DPad Down Button Pressed: {Controller.DpadDownButton}");
            Console.WriteLine($"Xbox Controller DPad Left Button Pressed: {Controller.DpadLeftButton}");
            Console.WriteLine($"Xbox Controller DPad Right Button Pressed: {Controller.DpadRightButton}");
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