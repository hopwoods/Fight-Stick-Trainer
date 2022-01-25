using ControllerInterface.Controllers;

namespace ControllerInterface.Events;

public interface IControllerEvents
{
    /// <summary>
    /// Method to execute when the controller disconnects
    /// </summary>
    /// <param name="controller"></param>
    Task OnControllerDisconnected(IXboxController controller);

    /// <summary>
    /// Method to execute when the controller connects
    /// </summary>
    /// <param name="controller"></param>
    Task OnControllerConnected(IXboxController controller);

    /// <summary>
    /// Method to execute when the A button is pressed
    /// </summary>
    /// <param name="controller"></param>
    Task OnAButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the B button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnBButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the X button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnXButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Y button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnYButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Right Shoulder button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnRbButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Left Shoulder button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnLbButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Dpad Up button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnDpadUpButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Dpad Down button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnDpadDownButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Dpad Left button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnDpadLeftButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Dpad Right button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnDpadRightButtonPressed(IXboxController controller);
}