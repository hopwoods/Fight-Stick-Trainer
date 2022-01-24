using ControllerInterface.Controllers;

namespace ControllerInterface.Factories;

public interface IControllerWatcherFactory
{
    IXboxControllerWatcher CreateXBoxControllerWatcher(IXboxController controller);
}