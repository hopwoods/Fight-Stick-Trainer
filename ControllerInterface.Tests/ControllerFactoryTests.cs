using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace ControllerInterface.Tests;

public class ControllerFactoryTests
{
    public IControllerFactory? Factory { get; private set; }
    private readonly ILogger<ControllerFactory> _logger = Substitute.For<ILogger<ControllerFactory>>();
    private readonly ILogger<XboxController> _controllerLogger = Substitute.For<ILogger<XboxController>>();
    private readonly IConfiguration _configuration = Substitute.For<IConfiguration>();

    [OneTimeSetUp]
    public void Setup()
    {
        _configuration["ControllerSettings:RefreshIntervalMilliseconds"].Returns("30");
    }

    [Test]
    public void XboxControllerObjectIsCreated()
    {
        Factory = new ControllerFactory(_logger, _controllerLogger, _configuration);

        var controller = Factory.CreateXboxController();

        Assert.That(controller, Is.InstanceOf<IXboxController>());
    }

}