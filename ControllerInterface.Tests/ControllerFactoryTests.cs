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
    private readonly ILogger<ControllerFactory> logger = Substitute.For<ILogger<ControllerFactory>>();
    private readonly ILogger<XboxController> controllerLogger = Substitute.For<ILogger<XboxController>>();
    private readonly IConfiguration configuration = Substitute.For<IConfiguration>();

    [OneTimeSetUp]
    public void Setup()
    {
        configuration["ControllerSettings:RefreshIntervalMilliseconds"].Returns("30");
    }

    [Test]
    public void XboxControllerObjectIsCreated()
    {
        Factory = new ControllerFactory(logger, controllerLogger, configuration);

        var controller = Factory.CreateXboxController();

        Assert.That(controller, Is.InstanceOf<IXboxController>());
    }

}