namespace ControllerInterface.Controllers;

public interface IInputString
{
    List<ControllerInput> Inputs { get; set; }
    void CheckInput(ControllerInputNames input);
}