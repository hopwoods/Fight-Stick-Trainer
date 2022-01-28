namespace ControllerInterface.Services;

/// <summary>
/// Background service that watches for controller inputs and fires related events.
/// </summary>
public class ControllerWatcherService : BackgroundService, IControllerWatcherEvents
{
    #region Public Properties & Fields

    public event ControllerEvent? ControllerConnected;
    public event ControllerEvent? ControllerDisconnected;
    public event ControllerEvent? ControllerIsWireless;
    public event ControllerEvent? AButtonPressed;
    public event ControllerEvent? BButtonPressed;
    public event ControllerEvent? XButtonPressed;
    public event ControllerEvent? YButtonPressed;
    public event ControllerEvent? RbButtonPressed;
    public event ControllerEvent? LbButtonPressed;
    public event ControllerEvent? DpadUpButtonPressed;
    public event ControllerEvent? DpadDownButtonPressed;
    public event ControllerEvent? DpadLeftButtonPressed;
    public event ControllerEvent? DpadRightButtonPressed;
    public event ControllerEvent? StartButtonPressed;
    public event ControllerEvent? LeftStickButtonPressed;
    public event ControllerEvent? RightStickButtonPressed;
    public event ControllerEvent? RightTriggerPressed;
    public event ControllerEvent? LeftTriggerPressed;

    #endregion

    #region Private Properties & Fields
    private readonly IXboxController controllerBeingWatched;
    private readonly IControllerEvents controllerEvents;
    private readonly ILogger<ControllerWatcherService> logger;

    #endregion

    #region Constructor
    public ControllerWatcherService(IXboxController controllerBeingWatched, IControllerEvents controllerEvents, ILogger<ControllerWatcherService> logger)
    {
        this.controllerBeingWatched = controllerBeingWatched;
        this.controllerEvents = controllerEvents;
        this.logger = logger;
        RegisterEvents();
    }

    #endregion

    #region Background Service Overrides

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Task.Factory.StartNew(async () =>
          {
              logger.LogInformation($"Controller Watcher Server starting");

              // loop until a cancellation is requested
              while (!cancellationToken.IsCancellationRequested)
              {
                  try
                  {
                      await WatchController(controllerBeingWatched);
                  }
                  catch (OperationCanceledException) { }
              }
          }, cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Controller Watcher Server service stopping");
        await Task.CompletedTask;
    }

    #endregion

    #region Private Methods
    
    /// <summary>
    /// When the controller state changes, fire the associated events.
    /// </summary>
    /// <param name="controller"></param>
    /// <returns></returns>
    private async Task WatchController(IXboxController controller)
    {
        DetectConnection(controller);
        DetectCapabilities(controller);
        await DetectButtonPresses(controller);
    }

    /// <summary>
    /// Watch for button presses on the controller
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private async Task DetectButtonPresses(IXboxController controller)
    {
        // Face Buttons
        if (await controller.AButtonIsPressed) FireAButtonPressed(controller);
        if (await controller.BButtonIsPressed) FireBButtonPressed(controller);
        if (await controller.XButtonIsPressed) FireXButtonPressed(controller);
        if (await controller.YButtonIsPressed) FireYButtonPressed(controller);

        //Shoulder Buttons
        if (await controller.RbButtonIsPressed) FireRbButtonPressed(controller);
        if (await controller.LbButtonIsPressed) FireLbButtonPressed(controller);

        // DPad Buttons
        if (await controller.DpadUpButtonIsPressed) FireDpadUpButtonPressed(controller);
        if (await controller.DpadDownButtonIsPressed) FireDpadDownButtonPressed(controller);
        if (await controller.DpadLeftButtonIsPressed) FireDpadLeftButtonPressed(controller);
        if (await controller.DpadRightButtonIsPressed) FireDpadRightButtonPressed(controller);

        // Start / Menu Button
        if (await controller.StartButtonIsPressed) FireStartButtonPressed(controller);

        // Analogue Stick Buttons
        if (await controller.LeftStickButtonIsPressed) FireLeftStickButtonPressed(controller);
        if (await controller.RightStickButtonIsPressed) FireRightStickButtonPressed(controller);

        // Triggers
        if (await controller.RightTriggerIsPressed) FireRightTriggerPressed(controller);
        if (await controller.LeftTriggerIsPressed) FireLeftTriggerPressed(controller);

    }

    /// <summary>
    /// Watch for the controller being connected or disconnected
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private void DetectConnection(IXboxController controller)
    {
        if (controller.IsConnected) 
            FireConnected(controller);
        else
            FireDisconnected(controller);
    }    
    
    /// <summary>
    /// Watch for the controller capabilities being set
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private void DetectCapabilities(IXboxController controller)
    {
        if (controller.IsWireless) 
            FireIsWireless(controller);
    }

    /// <summary>
    /// Register the methods which get called when a event is fired
    /// </summary>
    private void RegisterEvents()
    {
        // Controller connection
        ControllerConnected += controllerEvents.OnControllerConnected;
        ControllerDisconnected += controllerEvents.OnControllerDisconnected;

        // Controller Capabilities
        ControllerIsWireless += controllerEvents.OnControllerIsWireless;

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

        // Start / Menu Button
        StartButtonPressed += controllerEvents.OnStartButtonPressed;

        // Analogue Stick Buttons
        LeftStickButtonPressed += controllerEvents.OnLeftStickButtonPressed;
        RightStickButtonPressed += controllerEvents.OnRightStickButtonPressed;

        // Triggers
        LeftTriggerPressed += controllerEvents.OnLeftTriggerPressed;
        RightTriggerPressed += controllerEvents.OnRightTriggerPressed;
    }

    #endregion

    #region Event Triggers

    private void FireConnected(IXboxController controller)
    {
        ControllerConnected?.Invoke(controller);
    }

    private void FireDisconnected(IXboxController controller)
    {
        ControllerDisconnected?.Invoke(controller);
    }

    private void FireIsWireless(IXboxController controller)
    {
        ControllerIsWireless?.Invoke(controller);
    }

    private void FireAButtonPressed(IXboxController controller)
    {
        AButtonPressed?.Invoke(controller);
    }

    private void FireBButtonPressed(IXboxController controller)
    {
        BButtonPressed?.Invoke(controller);
    }

    private void FireXButtonPressed(IXboxController controller)
    {
        XButtonPressed?.Invoke(controller);
    }

    private void FireYButtonPressed(IXboxController controller)
    {
        YButtonPressed?.Invoke(controller);
    }

    private void FireRbButtonPressed(IXboxController controller)
    {
        RbButtonPressed?.Invoke(controller);
    }

    private void FireLbButtonPressed(IXboxController controller)
    {
        LbButtonPressed?.Invoke(controller);
    }

    private void FireDpadUpButtonPressed(IXboxController controller)
    {
        DpadUpButtonPressed?.Invoke(controller);
    }

    private void FireDpadDownButtonPressed(IXboxController controller)
    {
        DpadDownButtonPressed?.Invoke(controller);
    }

    private void FireDpadLeftButtonPressed(IXboxController controller)
    {
        DpadLeftButtonPressed?.Invoke(controller);
    }

    private void FireDpadRightButtonPressed(IXboxController controller)
    {
        DpadRightButtonPressed?.Invoke(controller);
    }

    private void FireStartButtonPressed(IXboxController controller)
    {
        StartButtonPressed?.Invoke(controller);
    }

    private void FireLeftStickButtonPressed(IXboxController controller)
    {
        LeftStickButtonPressed?.Invoke(controller);
    }

    private void FireRightStickButtonPressed(IXboxController controller)
    {
        RightStickButtonPressed?.Invoke(controller);
    }

    private void FireRightTriggerPressed(IXboxController controller)
    {
        RightTriggerPressed?.Invoke(controller);
    }

    private void FireLeftTriggerPressed(IXboxController controller)
    {
        LeftTriggerPressed?.Invoke(controller);
    }

    #endregion


}
