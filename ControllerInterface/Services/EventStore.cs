namespace ControllerInterface.Services;

public class EventStore : IEventStore {

    private readonly IControllerEvents controllerEvents;

    private Dictionary<EventType, ControllerEvent?> Events { get; }

    public EventStore(IControllerEvents controllerEvents)
    {
        this.controllerEvents = controllerEvents;
        RegisterEvents();
        Events = new Dictionary<EventType, ControllerEvent?>
        {
            { EventType.ControllerConnected, ControllerConnected },
            { EventType.ControllerDisconnected, ControllerDisconnected },
            { EventType.ControllerIsWireless, ControllerIsWireless },
            { EventType.UpdateBatteryInformation, UpdatedBatteryInformation },

            { EventType.AButtonPressed, AButtonPressed },
            { EventType.BButtonPressed, BButtonPressed },
            { EventType.XButtonPressed, XButtonPressed },
            { EventType.YButtonPressed, YButtonPressed },

            { EventType.RbButtonPressed, RbButtonPressed },
            { EventType.LbButtonPressed, LbButtonPressed },

            { EventType.DpadDownButtonPressed, DpadDownButtonPressed },
            { EventType.DpadUpButtonPressed, DpadUpButtonPressed },
            { EventType.DpadLeftButtonPressed, DpadLeftButtonPressed },
            { EventType.DpadRightButtonPressed, DpadRightButtonPressed },

            { EventType.StartButtonPressed, StartButtonPressed },
            { EventType.BackButtonPressed, BackButtonPressed },

            { EventType.LeftStickButtonPressed, LeftStickButtonPressed },
            { EventType.RightStickButtonPressed, RightStickButtonPressed },

            { EventType.LeftTriggerPressed, LeftTriggerPressed },
            { EventType.RightTriggerPressed, RightTriggerPressed },
        };
    }

    public void FireEvent(EventType eventType, IXboxController controller)
    {
        var eventToFire = Events[eventType];
        eventToFire?.Invoke(controller);
    }

    public void RegisterEvents()
    {
        // Controller connection
        ControllerConnected += controllerEvents.OnControllerConnected;
        ControllerDisconnected += controllerEvents.OnControllerDisconnected;

        // Controller Capabilities
        ControllerIsWireless += controllerEvents.OnControllerIsWireless;
        UpdatedBatteryInformation += controllerEvents.OnUpdateBatteryInformation;

        // Face Buttons
        AButtonPressed += controllerEvents.OnAButtonPressed;
        BButtonPressed += controllerEvents.OnBButtonPressed;
        XButtonPressed += controllerEvents.OnXButtonPressed;
        YButtonPressed += controllerEvents.OnYButtonPressed;

        // Shoulder Buttons
        RbButtonPressed += controllerEvents.OnRbButtonPressed;
        LbButtonPressed += controllerEvents.OnLbButtonPressed;

        // Dpad Buttons
        DpadUpButtonPressed += controllerEvents.OnDpadUpButtonPressed;
        DpadDownButtonPressed += controller => controllerEvents.OnDpadDownButtonPressed(controller);
        DpadLeftButtonPressed += controllerEvents.OnDpadLeftButtonPressed;
        DpadRightButtonPressed += controllerEvents.OnDpadRightButtonPressed;

        // Start / Menu & Back / View Buttons
        StartButtonPressed += controllerEvents.OnStartButtonPressed;
        BackButtonPressed += controllerEvents.OnBackButtonPressed;

        // Analogue Stick Buttons
        LeftStickButtonPressed += controllerEvents.OnLeftStickButtonPressed;
        RightStickButtonPressed += controllerEvents.OnRightStickButtonPressed;

        // Triggers
        LeftTriggerPressed += controllerEvents.OnLeftTriggerPressed;
        RightTriggerPressed += controllerEvents.OnRightTriggerPressed;
    }

    private event ControllerEvent? ControllerConnected;
    private event ControllerEvent? ControllerDisconnected;
    private event ControllerEvent? ControllerIsWireless;
    private event ControllerEvent? UpdatedBatteryInformation;
    private event ControllerEvent? AButtonPressed;
    private event ControllerEvent? BButtonPressed;
    private event ControllerEvent? XButtonPressed;
    private event ControllerEvent? YButtonPressed;
    private event ControllerEvent? RbButtonPressed;
    private event ControllerEvent? LbButtonPressed;
    private event ControllerEvent? DpadUpButtonPressed;
    private event ControllerEvent? DpadDownButtonPressed;
    private event ControllerEvent? DpadLeftButtonPressed;
    private event ControllerEvent? DpadRightButtonPressed;
    private event ControllerEvent? StartButtonPressed;
    private event ControllerEvent? BackButtonPressed;
    private event ControllerEvent? LeftStickButtonPressed;
    private event ControllerEvent? RightStickButtonPressed;
    private event ControllerEvent? RightTriggerPressed;
    private event ControllerEvent? LeftTriggerPressed;
}