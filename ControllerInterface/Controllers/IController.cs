namespace ControllerInterface.Controllers;

public interface IController
{
    /// <summary>
    /// Get the current controller state
    /// </summary>
    void EnsureRefresh();
}