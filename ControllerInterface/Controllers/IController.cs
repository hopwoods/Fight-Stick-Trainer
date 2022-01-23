namespace ControllerInterface.Controllers;
using SharpDX.XInput;

public interface IController
{
    Controller Controller { get; set; }

    /// <summary>
    /// Get the current controller state
    /// </summary>
    void Update();
}