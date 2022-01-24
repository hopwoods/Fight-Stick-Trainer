using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerHost;

public class ControllerStatusService : IHostedService, IDisposable
{
    private IXboxController Controller { get; }

    private readonly ILogger<ControllerStatusService> _logger;
    private readonly IControllerWatcherFactory _watcherFactory;
    private IXboxControllerWatcher? _controllerWatcher;
    private readonly IControllerEvents _consoleControllerEvents;
    private readonly IUtilities _utilities;

    public ControllerStatusService(ILogger<ControllerStatusService> logger, IXboxController controller, IControllerWatcherFactory watcherFactory, IControllerEvents consoleControllerEvents, IUtilities utilities)
    {
        Controller = controller;
        _logger = logger;
        _watcherFactory = watcherFactory;
        _consoleControllerEvents = consoleControllerEvents;
        _utilities = utilities;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogDebug("Controller Status Service Started");
        DoWork();
        return Task.CompletedTask;
    }

    private void DoWork()
    {
        Console.WriteLine($"Polling Rate: {Controller.RefreshIntervalMilliseconds}");

        _controllerWatcher = _watcherFactory.CreateXBoxControllerWatcher(Controller);

        Console.WriteLine("Press any key to exit.");

        if (_controllerWatcher == null) return;

        if (!Controller.IsConnected)
        {
            _utilities.PrintButtonValue("Controller Disconnected", ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        _utilities.PrintButtonValue("Controller Connected", ConsoleColor.DarkGreen);
        Console.WriteLine();

        _controllerWatcher.ControllerConnected += _consoleControllerEvents.OnControllerConnected;
        _controllerWatcher.ControllerDisconnected += _consoleControllerEvents.OnControllerDisconnected;

        _controllerWatcher.AButtonPressed += _consoleControllerEvents.OnAButtonPressed;
        _controllerWatcher.BButtonPressed += _consoleControllerEvents.OnBButtonPressed;
        _controllerWatcher.XButtonPressed += _consoleControllerEvents.OnXButtonPressed;
        _controllerWatcher.YButtonPressed += _consoleControllerEvents.OnYButtonPressed;

        _controllerWatcher.RbButtonPressed += _consoleControllerEvents.OnRbButtonPressed;
        _controllerWatcher.LbButtonPressed += _consoleControllerEvents.OnLbButtonPressed;

        _controllerWatcher.DpadUpButtonPressed += _consoleControllerEvents.OnDpadUpButtonPressed;
        _controllerWatcher.DpadDownButtonPressed += _consoleControllerEvents.OnDpadDownButtonPressed;
        _controllerWatcher.DpadLeftButtonPressed += _consoleControllerEvents.OnDpadLeftButtonPressed;
        _controllerWatcher.DpadRightButtonPressed += _consoleControllerEvents.OnDpadRightButtonPressed;
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogDebug("Controller Status Service is stopping.");

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _controllerWatcher?.Dispose();
    }
}