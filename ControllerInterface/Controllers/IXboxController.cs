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
    bool A_Button { get; set; }
    bool B_Button { get; set; }
    bool X_Button { get; set; }
    bool Y_Button { get; set; }
    bool RB_Button { get; set; }
    bool LB_Button { get; set; }
}