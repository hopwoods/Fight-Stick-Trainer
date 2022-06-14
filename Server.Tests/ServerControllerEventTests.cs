using ControllerInterface.Controllers;
using ControllerInterface.Dtos;
using ControllerInterface.Events;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Server.Events;
using Server.Hubs;
using Server.Utilities;
using SharpDX.XInput;
using System.Threading.Tasks;

namespace Server.Tests;
[TestFixture]
public class ServerControllerEventTests
{
    private Mock<IHubContext<TrainerHub, ITrainerHub>>? hubContext;
    private IControllerEvents? events;
    private Mock<ILogger<ServerControllerEvents>>? logger;
    private Mock<IUtilities>? utilities;
    private Mock<IXboxController> controller = null!;

    [SetUp]
    public void Setup()
    {
        logger = new Mock<ILogger<ServerControllerEvents>>();
        utilities = new Mock<IUtilities>();
        hubContext = new Mock<IHubContext<TrainerHub, ITrainerHub>>();
        events = new ServerControllerEvents(logger.Object, utilities.Object, hubContext.Object);
        controller = new Mock<IXboxController>();
    }

    [Test]
    public void OnControllerDisconnected_TellsHubToSendControllerConnectionState()
    {
        controller.Setup(xboxController => xboxController.IsConnected).Returns(false);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveControllerConnectionState(false))
            .Returns(Task.CompletedTask);

        events!.OnControllerDisconnected(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveControllerConnectionState(false), Times.Once);
    }

    [Test]
    public void OnControllerConnected_TellsHubToSendControllerConnectionState()
    {
        controller.Setup(xboxController => xboxController.IsConnected).Returns(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveControllerConnectionState(true))
            .Returns(Task.CompletedTask);

        events!.OnControllerDisconnected(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveControllerConnectionState(true), Times.Once);
    }

    [TestCase(false)]
    [TestCase(true)]
    public void OnIsWireless_TellsHubToSendWirelessCapability(bool isWireless)
    {
        controller.Setup(xboxController => xboxController.IsWireless).Returns(isWireless);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveControllerWirelessCapability(isWireless))
            .Returns(Task.CompletedTask);

        events!.OnControllerIsWireless(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveControllerWirelessCapability(isWireless), Times.Once);
    }

    [Test]
    public void OnUpdateBatteryInformation_TellsHubToSendBatteryInfo()
    {
        controller.Setup(xboxController => xboxController.BatteryInformation)
            .Returns(new BatteryInformation
            {
                BatteryType = BatteryType.Wired,
                BatteryLevel = BatteryLevel.Full
            });

        var batteryInformationDto = new BatteryInformationDto
        {
            BatteryType = BatteryType.Wired,
            BatteryLevel = BatteryLevel.Full
        };

        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveBatteryInformation(It.IsAny<BatteryInformationDto>()))
            .Returns(Task.CompletedTask);

        events!.OnUpdateBatteryInformation(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveBatteryInformation(batteryInformationDto), Times.Once);
    }


    [Test]
    public void OnButtonPress_A_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.AButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.AButton))
            .Returns(Task.CompletedTask);

        events!.OnAButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.AButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_B_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.AButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.BButton))
            .Returns(Task.CompletedTask);

        events!.OnBButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.BButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_X_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.XButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.XButton))
            .Returns(Task.CompletedTask);

        events!.OnXButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.XButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_Y_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.YButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.YButton))
            .Returns(Task.CompletedTask);

        events!.OnYButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.YButton), Times.Once);
    }
    
    [Test]
    public void OnButtonPress_RB_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.RbButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.RbButton))
            .Returns(Task.CompletedTask);

        events!.OnRbButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.RbButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_LB_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.LbButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.LbButton))
            .Returns(Task.CompletedTask);

        events!.OnLbButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.LbButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_LStick_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.LeftStickButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.LeftStickButton))
            .Returns(Task.CompletedTask);

        events!.OnLeftStickButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.LeftStickButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_RStick_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.RightStickButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.RightStickButton))
            .Returns(Task.CompletedTask);

        events!.OnRightStickButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.RightStickButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_LTrigger_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.LeftTriggerIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.LeftTrigger))
            .Returns(Task.CompletedTask);

        events!.OnLeftStickButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.LeftStickButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_RTrigger_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.RightTriggerIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.RightTrigger))
            .Returns(Task.CompletedTask);

        events!.OnRightTriggerPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.RightTrigger), Times.Once);
    }

    [Test]
    public void OnButtonPress_Start_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.StartButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.StartButton))
            .Returns(Task.CompletedTask);

        events!.OnStartButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.StartButton), Times.Once);
    }

    [Test]
    public void OnButtonPress_View_TellsHubToSendButtonPress()
    {
        controller.Setup(xboxController => xboxController.ViewButtonIsPressed).ReturnsAsync(true);
        hubContext!
            .Setup(hub => hub.Clients.All.ReceiveButtonPress(ControllerInputNames.ViewButton))
            .Returns(Task.CompletedTask);

        events!.OnBackButtonPressed(controller.Object);

        hubContext!.Verify(x => x.Clients.All.ReceiveButtonPress(ControllerInputNames.ViewButton), Times.Once);
    }

}