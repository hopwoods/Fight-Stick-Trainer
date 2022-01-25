using ControllerInterface.Pocos;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs;

internal class TrainerHub : Hub
{
    public async Task SendInputStringToClient(IInputString inputString)
    {
        await Clients.All.SendAsync("ReceiveInputString", inputString);
    }

    public async Task SendControllerConnectionStateToClient(bool isControllerConnected)
    {
        await Clients.All.SendAsync("ReceiveControllerConnectionState", isControllerConnected);
    }

    public async Task SendButtonPressToClient(string inputName)
    {
        await Clients.All.SendAsync("ReceiveButtonPress", inputName);
    }
}