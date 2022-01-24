using ControllerInterface.Controllers;

namespace Server.Hubs;

public interface ITrainerHub
{
    Task ReceiveInputString(IInputString inputString);
    Task ReceiveControllerConnectionState(bool isControllerConnected);
}