using SharpDX.XInput;

namespace ControllerInterface.Controllers;

public interface IXboxController: IController
{
    /// <summary>
    /// Interval in milliseconds to poll the controller
    /// </summary>
    int RefreshIntervalMilliseconds { get; set; }

    /// <summary>
    /// Is the controller plugged in and powered on
    /// </summary>
    bool IsConnected { get; }

    /// <summary>
    /// The A Button
    /// </summary>
    Task<bool> AButtonIsPressed { get; }

    /// <summary>
    /// The B Button
    /// </summary>
    Task<bool> BButtonIsPressed { get; }

    /// <summary>
    /// The X Button
    /// </summary>
    Task<bool> XButtonIsPressed { get; }

    /// <summary>
    /// The Y Button
    /// </summary>
    Task<bool> YButtonIsPressed { get; }

    /// <summary>
    /// The Right Shoulder Button
    /// </summary>
    Task<bool> RbButtonIsPressed { get; }

    /// <summary>
    /// The Left Shoulder Button
    /// </summary>
    Task<bool> LbButtonIsPressed { get; }

    /// <summary>
    /// Up on the DPad
    /// </summary>
    Task<bool> DpadUpButtonIsPressed { get; }

    /// <summary>
    /// Down on the DPad
    /// </summary>
    Task<bool> DpadDownButtonIsPressed { get; }

    /// <summary>
    /// Left on the DPad
    /// </summary>
    Task<bool> DpadLeftButtonIsPressed { get; }

    /// <summary>
    /// Right on the DPad
    /// </summary>
    Task<bool> DpadRightButtonIsPressed { get; }
}