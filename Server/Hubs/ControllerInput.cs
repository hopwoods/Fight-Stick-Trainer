using ControllerInterface.Controllers;

namespace Server.Hubs;

internal class ControllerInput
{
    public ControllerInputNames Input { get; set; }
    public bool InputHit { get; set; }
}