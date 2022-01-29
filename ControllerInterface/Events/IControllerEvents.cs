namespace ControllerInterface.Events;

/// <summary>
/// Methods to execute when inputs on a controller have been performed.
/// </summary>
public interface IControllerEvents
{
    /// <summary>
    /// Method to execute when the controller disconnects
    /// </summary>
    /// <param name="controller"></param>
    void OnControllerDisconnected(IXboxController controller);

    /// <summary>
    /// Method to execute when the controller connects
    /// </summary>
    /// <param name="controller"></param>
    void OnControllerConnected(IXboxController controller);

    /// <summary>
    /// Method to execute when the controller has wireless capability
    /// </summary>
    /// <param name="controller"></param>
    void OnControllerIsWireless(IXboxController controller);

    /// <summary>
    /// Method to execute when the A button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnAButtonPressed(IXboxController controller);

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

    /// <summary>
    /// Method to execute when the Start / Menu button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnStartButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Back / View button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnBackButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Left Stick button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnLeftStickButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Right Stick button is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnRightStickButtonPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Right trigger is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnRightTriggerPressed(IXboxController controller);

    /// <summary>
    /// Method to execute when the Left trigger is pressed
    /// </summary>
    /// <param name="controller"></param>
    void OnLeftTriggerPressed(IXboxController controller);
}