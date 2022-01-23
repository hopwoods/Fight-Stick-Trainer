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
    bool BButton { get; set; }
    bool XButton { get; set; }
    bool YButton { get; set; }
}