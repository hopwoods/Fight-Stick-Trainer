using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerHost;

public class ControllerStatusService : IHostedService, IDisposable
{
    private IXboxController Controller { get; }

    private readonly IConfiguration _configuration;
    private readonly ILogger<ControllerStatusService> _logger;
    private readonly IControllerWatcherFactory _watcherFactory;
    private IXboxControllerWatcher? _controllerWatcher;

    public ControllerStatusService(ILogger<ControllerStatusService> logger, IXboxController controller, IControllerWatcherFactory watcherFactory, IConfiguration configuration)
    {
        Controller = controller;
        _logger = logger;
        _watcherFactory = watcherFactory;
        _configuration = configuration;
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
            PrintButtonValue("Controller Disconnected", ConsoleColor.DarkRed);
            Console.WriteLine();
            return;
        }

        PrintButtonValue("Controller Connected", ConsoleColor.DarkGreen);
        Console.WriteLine();

        _controllerWatcher.ControllerConnected += OnControllerConnected;
        _controllerWatcher.ControllerDisconnected += OnControllerDisconnected;

        _controllerWatcher.AButtonPressed += OnAButtonPressed;
        _controllerWatcher.BButtonPressed += OnBButtonPressed;
        _controllerWatcher.XButtonPressed += OnXButtonPressed;
        _controllerWatcher.YButtonPressed += OnYButtonPressed;

        _controllerWatcher.RbButtonPressed += OnRbButtonPressed;
        _controllerWatcher.LbButtonPressed += OnLbButtonPressed;

        _controllerWatcher.DpadUpButtonPressed += OnDpadUpButtonPressed;
        _controllerWatcher.DpadDownButtonPressed += OnDpadDownButtonPressed;
        _controllerWatcher.DpadLeftButtonPressed += OnDpadLeftButtonPressed;
        _controllerWatcher.DpadRightButtonPressed += OnDpadRightButtonPressed;

    }

    private static void PrintButtonValue(string buttonName, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write($"{buttonName}");
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

    private void OnControllerDisconnected(IXboxController controller)
    {
        _logger.LogDebug("Controller Disconnected ");
    }

    private void OnControllerConnected(IXboxController controller)
    {
        _logger.LogDebug("Controller Connected ");
    }

    private static void OnAButtonPressed(IXboxController controller)
    {
        PrintButtonValue("A", ConsoleColor.DarkGreen);
    }
    private static void OnBButtonPressed(IXboxController controller)
    {
        PrintButtonValue("B", ConsoleColor.DarkRed);
    }
    private static void OnXButtonPressed(IXboxController controller)
    {
        PrintButtonValue("X", ConsoleColor.DarkCyan);
    }
    private static void OnYButtonPressed(IXboxController controller)
    {
        PrintButtonValue("Y", ConsoleColor.DarkYellow);
    }
    private static void OnRbButtonPressed(IXboxController controller)
    {
        PrintButtonValue("RB", ConsoleColor.White);
    }
    private static void OnLbButtonPressed(IXboxController controller)
    {
        PrintButtonValue("LB", ConsoleColor.White);
    }
    private static void OnDpadUpButtonPressed(IXboxController controller)
    {
        PrintButtonValue("Up", ConsoleColor.White);
    }
    private static void OnDpadDownButtonPressed(IXboxController controller)
    {
        PrintButtonValue("Down", ConsoleColor.White);
    }
    private static void OnDpadLeftButtonPressed(IXboxController controller)
    {
        PrintButtonValue("Left", ConsoleColor.White);
    }
    private static void OnDpadRightButtonPressed(IXboxController controller)
    {
        PrintButtonValue("Right", ConsoleColor.White);
    }
}