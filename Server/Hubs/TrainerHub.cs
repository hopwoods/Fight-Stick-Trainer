using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs;

internal class TrainerHub: Hub
{
    public async Task SendInputStringToClient(InputString inputString)
    {
        await Clients.All.SendAsync("inputStringReceived", inputString);
    }
}