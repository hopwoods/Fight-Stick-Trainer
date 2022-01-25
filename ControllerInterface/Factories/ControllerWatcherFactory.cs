using ControllerInterface.Controllers;
using ControllerInterface.Services;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Factories
{
    public class ControllerWatcherFactory : IControllerWatcherFactory
    {
        private readonly ILogger<ControllerWatcherFactory> logger;

        public ControllerWatcherFactory(ILogger<ControllerWatcherFactory> logger)
        {
            this.logger = logger;
        }

        public IXboxControllerWatcher CreateXBoxControllerWatcher(IXboxController controller)
        {
            logger.LogInformation("Created Controller Watcher");
            return new XboxControllerWatcher(controller);
        }
    }
}
