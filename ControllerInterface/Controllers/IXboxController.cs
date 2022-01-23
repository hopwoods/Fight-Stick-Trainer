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

    /// <summary>
    /// The B Button
    /// </summary>
    bool BButton { get; set; }

    /// <summary>
    /// The X Button
    /// </summary>
    bool XButton { get; set; }

    /// <summary>
    /// The Y Button
    /// </summary>
    bool YButton { get; set; }

    /// <summary>
    /// The Right Shoulder Button
    /// </summary>
    bool RbButton { get; set; }

    /// <summary>
    /// The Left Shoulder Button
    /// </summary>
    bool LbButton { get; set; }

    /// <summary>
    /// Up on the DPad
    /// </summary>
    bool DpadUpButton { get; set; }

    /// <summary>
    /// Down on the DPad
    /// </summary>
    bool DpadDownButton { get; set; }

    /// <summary>
    /// Left on the DPad
    /// </summary>
    bool DpadLeftButton { get; set; }

    /// <summary>
    /// Right on the DPad
    /// </summary>
    bool DpadRightButton { get; set; }
}