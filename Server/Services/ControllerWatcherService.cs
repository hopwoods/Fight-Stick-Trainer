using ControllerInterface.Controllers;
using ControllerInterface.Factories;

namespace Server.Services
{
    public class ControllerWatcherService : IHostedService, IDisposable
    {
        private IXboxController Controller { get; }

        private IXboxControllerWatcher? _controllerWatcher;
        private readonly ILogger<ControllerWatcherService> _logger;
        private readonly IControllerWatcherFactory _watcherFactory;
        private readonly IControllerEvents _controllerEvents;

        public ControllerWatcherService(ILogger<ControllerWatcherService> logger, IXboxController controller, IControllerWatcherFactory watcherFactory, IControllerEvents controllerEvents)
        {
            Controller = controller;
            _logger = logger;
            _watcherFactory = watcherFactory;
            _controllerEvents = controllerEvents;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Controller Watcher Service Started");
            _controllerWatcher = _watcherFactory.CreateXBoxControllerWatcher(Controller);

            RegisterEvents();

            return Task.CompletedTask;
        }

        private void RegisterEvents()
        {
            if (_controllerWatcher != null)
            {
                _controllerWatcher.ControllerConnected += controller => _controllerEvents.OnControllerConnected(controller);
                _controllerWatcher.ControllerDisconnected += controller => _controllerEvents.OnControllerDisconnected(controller);

                _controllerWatcher.AButtonPressed += _controllerEvents.OnAButtonPressed;
                _controllerWatcher.BButtonPressed += _controllerEvents.OnBButtonPressed;
                _controllerWatcher.XButtonPressed += _controllerEvents.OnXButtonPressed;
                _controllerWatcher.YButtonPressed += _controllerEvents.OnYButtonPressed;

                _controllerWatcher.RbButtonPressed += _controllerEvents.OnRbButtonPressed;
                _controllerWatcher.LbButtonPressed += _controllerEvents.OnLbButtonPressed;

                _controllerWatcher.DpadUpButtonPressed += _controllerEvents.OnDpadUpButtonPressed;
                _controllerWatcher.DpadDownButtonPressed += _controllerEvents.OnDpadDownButtonPressed;
                _controllerWatcher.DpadLeftButtonPressed += _controllerEvents.OnDpadLeftButtonPressed;
                _controllerWatcher.DpadRightButtonPressed += _controllerEvents.OnDpadRightButtonPressed;
            }
            else
            {
                throw new NullReferenceException(
                    "Unable to register events. There is no controller watcher service running.");
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("Controller Watcher Service is stopping.");

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _controllerWatcher?.Dispose();
        }
    }
}
