using ControllerInterface.Controllers;
using ControllerInterface.Services;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Factories
{
    public class ControllerWatcherFactory : IControllerWatcherFactory
    {
        private readonly ILogger<ControllerWatcherFactory> _logger;

        public ControllerWatcherFactory(ILogger<ControllerWatcherFactory> logger)
        {
            _logger = logger;
        }

        public IXboxControllerWatcher CreateXBoxControllerWatcher(IXboxController controller)
        {
            _logger.LogInformation("Created Controller Watcher");
            return new XboxControllerWatcher(controller);
        }
    }
}
