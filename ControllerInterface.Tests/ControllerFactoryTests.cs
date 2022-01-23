using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace ControllerInterface.Tests;

public class ControllerFactoryTests
{
    public IControllerFactory? Factory { get; private set; }
    private readonly ILogger<ControllerFactory> _logger = Substitute.For<ILogger<ControllerFactory>>();
    private readonly ILogger<XboxController> _controllerLogger = Substitute.For<ILogger<XboxController>>();

    [OneTimeSetUp]
    public void Setup()
    {
    }

    [Test]
    public void XboxControllerObjectIsCreated()
    {
        Factory = new ControllerFactory(_logger, _controllerLogger);

        var controller = Factory.CreateXboxController();

        Assert.That(controller, Is.InstanceOf<IXboxController>());
    }

}