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
        Assert.That(Controller.AButton, Is.True);
    }

    [Test]
    public void ControllerBButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.BButton, Is.True);
    }

    [Test]
    public void ControllerXButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.XButton, Is.True);
    }

    [Test]
    public void ControllerYButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.YButton, Is.True);
    }

    [Test]
    public void ControllerRbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.RbButton, Is.True);
    }

    [Test]
    public void ControllerLbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.LbButton, Is.True);
    }

    [Test]
    public void ControllerDpadUpButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.DpadUpButton, Is.True);
    }

    [Test]
    public void ControllerDpadDownButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.DpadDownButton, Is.True);
    }

    [Test]
    public void ControllerDpadLeftButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.DpadLeftButton, Is.True);
    }

    [Test]
    public void ControllerDpadRightButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.Update();


        Controller.Received().Update();
        Assert.That(Controller.DpadRightButton, Is.True);
    }


    private static IXboxController CreateMockController()
    {
        var controller = Substitute.For<IXboxController>();
        controller.When(xboxController => xboxController.Update())
            .Do(x =>
            {
                controller.IsConnected = true;
                controller.AButton = true;
                controller.BButton = true;
                controller.XButton = true;
                controller.YButton = true;
                controller.RbButton = true;
                controller.LbButton = true;
                controller.DpadUpButton = true;
                controller.DpadDownButton = true;
                controller.DpadLeftButton = true;
                controller.DpadRightButton = true;
            });

        return controller;
    }
}