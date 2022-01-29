using System.Threading.Tasks;
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
    public void ControllerIsConnectedAsync()
    {
        Controller = CreateMockController();
        Controller.EnsureRefresh();

        var controllerIsConnected = Controller.IsConnected;

        Controller.Received().EnsureRefresh();
        Assert.That(controllerIsConnected, Is.True);
    }

    [Test]
    public async Task ControllerAButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.AButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerBButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.BButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerXButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.XButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerYButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.YButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerRbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.RbButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerLbButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.LbButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerDpadUpButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.DpadUpButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerDpadDownButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.DpadDownButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerDpadLeftButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.DpadLeftButtonIsPressed, Is.True);
    }

    [Test]
    public async Task ControllerDpadRightButtonPressed()
    {
        Controller = CreateMockController(); ;
        Controller.EnsureRefresh();


        Controller.Received().EnsureRefresh();
        Assert.That(await Controller.DpadRightButtonIsPressed, Is.True);
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