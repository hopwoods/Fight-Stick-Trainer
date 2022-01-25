using ControllerInterface.Controllers;
using ControllerInterface.Events;
using ControllerInterface.Factories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Services
{
    public class ControllerWatcherService : IHostedService, IDisposable
    {
        private IXboxController Controller { get; }

        private IXboxControllerWatcher? controllerWatcher;
        private bool disposedValue;
        private readonly ILogger<ControllerWatcherService> logger;
        private readonly IControllerWatcherFactory watcherFactory;
        private readonly IControllerEvents controllerEvents;

        public ControllerWatcherService(ILogger<ControllerWatcherService> logger, IXboxController controller, IControllerWatcherFactory watcherFactory, IControllerEvents controllerEvents)
        {
            Controller = controller;
            this.logger = logger;
            this.watcherFactory = watcherFactory;
            this.controllerEvents = controllerEvents;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            logger.LogDebug("Controller Watcher Service Started");
            controllerWatcher = watcherFactory.CreateXBoxControllerWatcher(Controller);

            RegisterEvents();

            return Task.CompletedTask;
        }

        private void RegisterEvents()
        {
            if (controllerWatcher != null)
            {
                controllerWatcher.ControllerConnected += controllerEvents.OnControllerConnected;
                controllerWatcher.ControllerDisconnected += controllerEvents.OnControllerDisconnected;

                controllerWatcher.AButtonPressed += controllerEvents.OnAButtonPressed;
                controllerWatcher.BButtonPressed += controllerEvents.OnBButtonPressed;
                controllerWatcher.XButtonPressed += controllerEvents.OnXButtonPressed;
                controllerWatcher.YButtonPressed += controllerEvents.OnYButtonPressed;

                controllerWatcher.RbButtonPressed += controllerEvents.OnRbButtonPressed;
                controllerWatcher.LbButtonPressed += controllerEvents.OnLbButtonPressed;

                controllerWatcher.DpadUpButtonPressed += controllerEvents.OnDpadUpButtonPressed;
                controllerWatcher.DpadDownButtonPressed += controller => controllerEvents.OnDpadDownButtonPressed(controller);
                controllerWatcher.DpadLeftButtonPressed += controllerEvents.OnDpadLeftButtonPressed;
                controllerWatcher.DpadRightButtonPressed += controllerEvents.OnDpadRightButtonPressed;
            }
            else
            {
                throw new NullReferenceException(
                    "Unable to register events. There is no controller watcher service running.");
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogDebug("Controller Watcher Service is stopping.");

            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ControllerWatcherService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
