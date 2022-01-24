using ControllerInterface.Controllers;
using NSubstitute;
using NUnit.Framework;

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
        Controller.EnsureRefresh();

        var controllerIsConnected = Controller.IsConnected;

        Controller.Received().EnsureRefresh();
        Assert.That(controllerIsConnected, Is.True);
    }

    [Test]
    public void ControllerAButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.AButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerBButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.BButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerXButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.XButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerYButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.YButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerRbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.RbButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerLbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.LbButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerDpadUpButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.DpadUpButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerDpadDownButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.DpadDownButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerDpadLeftButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.DpadLeftButtonIsPressed, Is.True);
    }

    [Test]
    public void ControllerDpadRightButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(Controller.DpadRightButtonIsPressed, Is.True);
    }


    private static IXboxController CreateMockController()
    {
        var controller = Substitute.For<IXboxController>();
        controller.IsConnected.Returns(true);

        //Buttons
        controller.AButtonIsPressed.Returns(true);
        controller.BButtonIsPressed.Returns(true);
        controller.XButtonIsPressed.Returns(true);
        controller.YButtonIsPressed.Returns(true);
        controller.RbButtonIsPressed.Returns(true);
        controller.LbButtonIsPressed.Returns(true);
        controller.DpadUpButtonIsPressed.Returns(true);
        controller.DpadDownButtonIsPressed.Returns(true);
        controller.DpadLeftButtonIsPressed.Returns(true);
        controller.DpadRightButtonIsPressed.Returns(true);

        return controller;
    }
}