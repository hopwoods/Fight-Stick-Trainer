using ControllerInterface.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Factories;

public class ControllerFactory : IControllerFactory
{
    #region Implementation of IControllerFactory

    private readonly ILogger<ControllerFactory> _logger;
    private readonly ILogger<XboxController> _controllerLogger;
    private readonly IConfiguration _configuration;

    public ControllerFactory(ILogger<ControllerFactory> logger, ILogger<XboxController> controllerLogger, IConfiguration configuration)
    {
        _logger = logger;
        _controllerLogger = controllerLogger;
        _configuration = configuration;
    }

    /// <inheritdoc />
    public IXboxController CreateXboxController()
    {
        _logger.LogInformation("Created New Xbox Controller");
        return new XboxController(_controllerLogger, _configuration);
    }

    #endregion
}