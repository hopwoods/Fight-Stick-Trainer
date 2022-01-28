namespace ControllerInterface.Pocos;

public class InputString : IInputString
{
    private int nextInputInString;

    #region Constructors

    public InputString()
    {
        Inputs = new List<ControllerInput>();
        nextInputInString = 0;
    }
    public InputString(List<ControllerInput> inputs)
    {
        Inputs = inputs;
        nextInputInString = 0;
    }

    #endregion

    public List<ControllerInput> Inputs { get; set; }

    public void CheckInput(ControllerInputNames input)
    {
        var currentInput = Inputs[nextInputInString];
        if (currentInput.InputName == input)
        {
            currentInput.InputHit = true;
        }

        SetNextInputInString();

    }

    private void SetNextInputInString()
    {
        var stringLength = Inputs.Count;
        if (nextInputInString < stringLength)
        {
            nextInputInString++;
        }
        else
        {
            nextInputInString = 0;
        }
    }


}