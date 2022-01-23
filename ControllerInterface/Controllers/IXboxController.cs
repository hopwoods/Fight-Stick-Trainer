namespace ControllerInterface.Controllers;

public interface IXboxController: IController
{
    /// <summary>
    /// Is the controller plugged in and powered on
    /// </summary>
    bool IsConnected { get; set; }
}