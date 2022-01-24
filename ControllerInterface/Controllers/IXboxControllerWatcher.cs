namespace ControllerInterface.Controllers;

public interface IXboxControllerWatcher
{
    event ControllerEvent? ControllerConnected;
    event ControllerEvent? ControllerDisconnected;

    event ControllerEvent? AButtonPressed;
    event ControllerEvent? BButtonPressed;
    event ControllerEvent? XButtonPressed;
    event ControllerEvent? YButtonPressed;

    event ControllerEvent? RbButtonPressed;
    event ControllerEvent? LbButtonPressed;

    event ControllerEvent? DpadUpButtonPressed;
    event ControllerEvent? DpadDownButtonPressed;
    event ControllerEvent? DpadLeftButtonPressed;
    event ControllerEvent? DpadRightButtonPressed;

    void Dispose();
}