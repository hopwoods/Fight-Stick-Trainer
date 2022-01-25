using ControllerInterface.Dtos;

namespace ControllerInterface.Pocos;

public class InputString : IInputString
{
    private int _nextInputInString;

    #region Constructors

    public InputString()
    {
        Inputs = new List<ControllerInput>();
        _nextInputInString = 0;
    }
    public InputString(List<ControllerInput> inputs)
    {
        Inputs = inputs;
        _nextInputInString = 0;
    }

    #endregion

    public List<ControllerInput> Inputs { get; set; }

    public void CheckInput(ControllerInputNames input)
    {
        var currentInput = Inputs[_nextInputInString];
        if (currentInput.InputName == input)
        {
            currentInput.InputHit = true;
        }

        SetNextInputInString();

    }

    private void SetNextInputInString()
    {
        var stringLength = Inputs.Count;
        if (_nextInputInString < stringLength)
        {
            _nextInputInString++;
        }
        else
        {
            _nextInputInString = 0;
        }
    }

    
}