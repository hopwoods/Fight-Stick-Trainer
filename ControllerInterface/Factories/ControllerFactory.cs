using ControllerInterface.Controllers;

namespace ControllerInterface.Factories;

public class ControllerFactory : IControllerFactory
{
    #region Implementation of IControllerFactory

    /// <inheritdoc />
    public IXboxController CreateXboxController()
    {
        return new XboxController();
    }

    #endregion
}