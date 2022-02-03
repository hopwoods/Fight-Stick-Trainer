using SharpDX.XInput;

namespace Server.Hubs;

public class TrainerHub : Hub<ITrainerHub>
{
    private const string GroupName = "FrontEnd";

    public async Task SendInputStringToClient(IInputString inputString)
    {
        await Clients.All.ReceiveInputString(inputString);
    }

    public async Task SendControllerConnectionStateToClient(bool isControllerConnected)
    {
        await Clients.All.ReceiveControllerConnectionState(isControllerConnected);
    }

    public async Task SendControllerWirelessCapabilityToClient(bool isControllerWireless)
    {
        await Clients.All.ReceiveControllerWirelessCapability(isControllerWireless);
    }

    public async Task SendButtonPressToClient(string inputName)
    {
        await Clients.All.ReceiveButtonPress(inputName);
    }

    public async Task SendBatteryInformationToClient(BatteryInformationDto batteryInformation)
    {
        await Clients.All.ReceiveBatteryInformation(batteryInformation);
    }

    public Task JoinGroup()
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
    }
}