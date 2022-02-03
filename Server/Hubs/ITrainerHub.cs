using SharpDX.XInput;

namespace Server.Hubs;

public interface ITrainerHub
{
    /// <summary>
    /// Client receives a <see cref="IInputString"/> object
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    Task ReceiveInputString(IInputString inputString);

    /// <summary>
    /// Client receives a <see cref="bool"/> indicating the controller connection state
    /// </summary>
    /// <param name="isControllerConnected">Connection state of the controller</param>
    /// <returns></returns>
    Task ReceiveControllerConnectionState(bool isControllerConnected);

    /// <summary>
    /// Client receives a <see cref="bool"/> indicating if the controller is wireless
    /// </summary>
    /// <param name="isTheControllerWireless">Wireless capability of the controller</param>
    /// <returns></returns>
    Task ReceiveControllerWirelessCapability(bool isTheControllerWireless);

    /// <summary>
    /// Clint receives a notification of button press and the name of that button.
    /// </summary>
    /// <param name="inputName">Name of the button</param>
    /// <returns></returns>
    Task ReceiveButtonPress(string inputName);

    /// <summary>
    /// Clint receives a <see cref="BatteryInformation"/> object with the current battery status
    /// </summary>
    /// <param name="batteryInformation">Information on the battery level and type</param>
    /// <returns></returns>
    Task ReceiveBatteryInformation(BatteryInformationDto batteryInformation);

    Task JoinGroup();

}