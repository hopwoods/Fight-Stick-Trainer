using ControllerInterface.Controllers;
using ControllerInterface.Services;

namespace ControllerInterface.Factories;

public interface IControllerWatcherFactory
{
    IXboxControllerWatcher CreateXBoxControllerWatcher(IXboxController controller);
}