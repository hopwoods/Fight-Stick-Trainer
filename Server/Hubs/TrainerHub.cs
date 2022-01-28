namespace Server.Hubs;

public class TrainerHub : Hub<ITrainerHub>
{
    private const string GroupName = "FrontEnd";

    public async Task SendInputStringToClient(IInputString inputString)
    {
        await Clients.Group(GroupName).ReceiveInputString(inputString);
    }

    public async Task SendControllerConnectionStateToClient(bool isControllerConnected)
    {
        await Clients.Group(GroupName).ReceiveControllerConnectionState(isControllerConnected);
    }

    public async Task SendControllerWirelessCapabilityToClient(bool isControllerWireless)
    {
        await Clients.Group(GroupName).ReceiveControllerWirelessCapability(isControllerWireless);
    }

    public async Task SendButtonPressToClient(string inputName)
    {
        await Clients.Group(GroupName).ReceiveButtonPress(inputName);
    }

    public Task JoinGroup()
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
    }
}