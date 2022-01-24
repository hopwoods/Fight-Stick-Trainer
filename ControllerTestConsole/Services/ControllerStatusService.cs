using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerTestConsole.Services;

public class ControllerStatusService : IHostedService, IDisposable
{
    private IXboxController Controller { get; }

    private IXboxControllerWatcher? _controllerWatcher;
    private readonly ILogger<ControllerStatusService> _logger;
    private readonly IControllerWatcherFactory _watcherFactory;
    private readonly IControllerEvents _consoleControllerEvents;

    public ControllerStatusService(ILogger<ControllerStatusService> logger, IXboxController controller, IControllerWatcherFactory watcherFactory, IControllerEvents consoleControllerEvents)
    {
        Controller = controller;
        _logger = logger;
        _watcherFactory = watcherFactory;
        _consoleControllerEvents = consoleControllerEvents;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogDebug("Controller Status Service Started");
        _controllerWatcher = _watcherFactory.CreateXBoxControllerWatcher(Controller);

        RegisterEvents();

        return Task.CompletedTask;
    }

    private void RegisterEvents()
    {
        if (_controllerWatcher != null)
        {
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
        else
        {
            throw new NullReferenceException(
                "Unable to register events. There is no controller watcher service running.");
        }
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