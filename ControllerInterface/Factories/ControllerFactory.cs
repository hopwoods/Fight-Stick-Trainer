using ControllerInterface.Controllers;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Factories;

public class ControllerFactory : IControllerFactory
{
    #region Implementation of IControllerFactory

    private readonly ILogger<ControllerFactory> _logger;
    private readonly ILogger<XboxController> _controllerLogger;

    public ControllerFactory(ILogger<ControllerFactory> logger, ILogger<XboxController> controllerLogger)
    {
        _logger = logger;
        _controllerLogger = controllerLogger;
    }

    /// <inheritdoc />
    public IXboxController CreateXboxController()
    {
        return new XboxController(_controllerLogger);
    }

    #endregion
}