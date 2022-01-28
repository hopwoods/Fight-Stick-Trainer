namespace ControllerInterface.Services;

/// <summary>
/// Event types that can be triggered by a <see cref="ControllerWatcherService"/>
/// </summary>
public interface IControllerWatcherEvents
{
    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Controller is connected
    /// </summary>
    public event ControllerEvent ControllerConnected;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Controller is disconnected
    /// </summary>
    public event ControllerEvent ControllerDisconnected;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Controller is wireless
    /// </summary>
    public event ControllerEvent ControllerIsWireless;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the A button is pressed
    /// </summary>
    public event ControllerEvent AButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the B button is pressed
    /// </summary>
    public event ControllerEvent BButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the X button is pressed
    /// </summary>
    public event ControllerEvent XButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Y button is pressed
    /// </summary>
    public event ControllerEvent YButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Right Shoulder button is pressed
    /// </summary>
    public event ControllerEvent RbButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Left Shoulder button is pressed
    /// </summary>
    public event ControllerEvent LbButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Dpad Up button is pressed
    /// </summary>
    public event ControllerEvent DpadUpButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Dpad Down button is pressed
    /// </summary>
    public event ControllerEvent DpadDownButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Dpad Left button is pressed
    /// </summary>
    public event ControllerEvent DpadLeftButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Dpad Right button is pressed
    /// </summary>
    public event ControllerEvent DpadRightButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Start / View button is pressed
    /// </summary>
    public event ControllerEvent StartButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Left Stick button is pressed
    /// </summary>
    public event ControllerEvent LeftStickButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Right Stick button is pressed
    /// </summary>
    public event ControllerEvent RightStickButtonPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Right Trigger is pressed
    /// </summary>
    public event ControllerEvent RightTriggerPressed;

    /// <summary>
    /// Register a <see cref="ControllerEvent"/> for when the Left Trigger is pressed
    /// </summary>
    public event ControllerEvent LeftTriggerPressed;

    void Dispose();
}