using ControllerInterface.Controllers;
using NSubstitute;
using NUnit.Framework;

#pragma warning disable CS8602 // Dereference of a possibly null reference.

namespace ControllerInterface.Tests;

public class XboxControllerTests
{
    public IXboxController? Controller { get; private set; }

    [OneTimeSetUp]
    public void Setup()
    {
    }

    [Test]
    public void ControllerIsConnected()
    {
        Controller = CreateMockController();
        Controller.Update();

        var controllerIsConnected = Controller.IsConnected;

        Controller.Received().Update();
        Assert.That(controllerIsConnected, Is.True);
    }

    [Test]
    public void ControllerAButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.A_Button, Is.True);
    }

    [Test]
    public void ControllerBButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.B_Button, Is.True);
    }

    [Test]
    public void ControllerXButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.X_Button, Is.True);
    }

    [Test]
    public void ControllerYButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.Y_Button, Is.True);
    }

    [Test]
    public void ControllerRbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.RB_Button, Is.True);
    }

    [Test]
    public void ControllerLbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.LB_Button, Is.True);
    }


    private static IXboxController CreateMockController()
    {
        var controller = Substitute.For<IXboxController>();
        controller.When(xboxController => xboxController.Update())
            .Do(x =>
            {
                controller.IsConnected = true;
                controller.A_Button = true;
                controller.B_Button = true;
                controller.X_Button = true;
                controller.Y_Button = true;
                controller.RB_Button = true;
                controller.LB_Button = true;
            });

        return controller;
    }
}