using SharpDX.XInput;

namespace ControllerInterface.Controllers;

public interface IXboxController: IController
{

    /// <summary>
    /// Is the controller plugged in and powered on
    /// </summary>
    bool IsConnected { get; set; }

    /// <summary>
    /// The A Button
    /// </summary>
    bool AButton { get; set; }
}