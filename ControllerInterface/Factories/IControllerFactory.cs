using ControllerInterface.Controllers;

namespace ControllerInterface.Factories
{
    public interface IControllerFactory
    {
        IXboxController CreateXboxController();
    }
}