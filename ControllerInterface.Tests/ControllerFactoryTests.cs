using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using NUnit.Framework;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace ControllerInterface.Tests;

public class ControllerFactoryTests
{
    public IControllerFactory? Factory { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
    }

    [Test]
    public void XboxControllerObjectIsCreated()
    {
        Factory = new ControllerFactory();

        var controller = Factory.CreateXboxController();

        Assert.That(controller, Is.InstanceOf<IXboxController>());
    }

}