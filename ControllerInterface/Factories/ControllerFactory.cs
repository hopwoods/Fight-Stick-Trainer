namespace ControllerInterface.Factories;

public class ControllerFactory : IControllerFactory
{
    #region Implementation of IControllerFactory

    private readonly ILogger<ControllerFactory> logger;
    private readonly ILogger<XboxController> controllerLogger;
    private readonly IConfiguration configuration;

    public ControllerFactory(ILogger<ControllerFactory> logger, ILogger<XboxController> controllerLogger, IConfiguration configuration)
    {
        this.logger = logger;
        this.controllerLogger = controllerLogger;
        this.configuration = configuration;
    }

    /// <inheritdoc />
    public IXboxController CreateXboxController()
    {
        logger.LogInformation("Created New Xbox Controller");
        return new XboxController(controllerLogger, configuration);
    }

    #endregion
}