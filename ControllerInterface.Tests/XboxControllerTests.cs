using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using NUnit.Framework;
using NUnit.Framework.Constraints;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                               
namespace ControllerInterface.Tests;

public class Tests
{
    public IXboxController? Controller { get; private set; }
    public IControllerFactory? ControllerFactory { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
        ControllerFactory = new ControllerFactory();
    }

    [Test]
    public void ControllerIsConnected()
    {

        Controller = ControllerFactory.CreateXboxController();
        var controllerIsConnected = Controller.IsConnected;


        Assert.That(controllerIsConnected, Is.True);
    }
}