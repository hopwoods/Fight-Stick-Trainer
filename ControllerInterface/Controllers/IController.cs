namespace ControllerInterface.Controllers;
using SharpDX.XInput;

public interface IController
{
    /// <summary>
    /// Get the current controller state
    /// </summary>
    void Update();
}