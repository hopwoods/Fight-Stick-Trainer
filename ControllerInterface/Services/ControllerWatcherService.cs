namespace ControllerInterface.Services;

/// <summary>
/// Background service that watches for controller inputs and fires related events.
/// </summary>
public class ControllerWatcherService : BackgroundService
{
    #region Private Properties & Fields

    private readonly IXboxController controllerBeingWatched;
    private readonly ILogger<ControllerWatcherService> logger;
    private readonly IEventStore eventStore;

    #endregion

    #region Constructor
    public ControllerWatcherService(IXboxController controllerBeingWatched, ILogger<ControllerWatcherService> logger, IEventStore eventStore)
    {
        this.controllerBeingWatched = controllerBeingWatched;
        this.logger = logger;
        this.eventStore = eventStore;
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
        if (await controller.AButtonIsPressed) eventStore.FireEvent(EventType.AButtonPressed, controller);
        if (await controller.BButtonIsPressed) eventStore.FireEvent(EventType.BButtonPressed, controller);
        if (await controller.XButtonIsPressed) eventStore.FireEvent(EventType.XButtonPressed, controller);
        if (await controller.YButtonIsPressed) eventStore.FireEvent(EventType.YButtonPressed, controller);

        //Shoulder Buttons
        if (await controller.RbButtonIsPressed) eventStore.FireEvent(EventType.RbButtonPressed, controller);
        if (await controller.LbButtonIsPressed) eventStore.FireEvent(EventType.LbButtonPressed, controller);

        // DPad Buttons
        if (await controller.DpadUpButtonIsPressed) eventStore.FireEvent(EventType.DpadUpButtonPressed, controller);
        if (await controller.DpadDownButtonIsPressed) eventStore.FireEvent(EventType.DpadDownButtonPressed, controller);
        if (await controller.DpadLeftButtonIsPressed) eventStore.FireEvent(EventType.DpadLeftButtonPressed, controller);
        if (await controller.DpadRightButtonIsPressed) eventStore.FireEvent(EventType.DpadRightButtonPressed, controller);

        // Start / Menu & Back / View Buttons
        if (await controller.StartButtonIsPressed) eventStore.FireEvent(EventType.StartButtonPressed, controller);
        if (await controller.BackButtonIsPressed) eventStore.FireEvent(EventType.BackButtonPressed, controller);

        // Analogue Stick Buttons
        if (await controller.LeftStickButtonIsPressed) eventStore.FireEvent(EventType.LeftStickButtonPressed, controller);
        if (await controller.RightStickButtonIsPressed) eventStore.FireEvent(EventType.RightStickButtonPressed, controller);

        // Triggers
        if (await controller.RightTriggerIsPressed) eventStore.FireEvent(EventType.RightTriggerPressed, controller);
        if (await controller.LeftTriggerIsPressed) eventStore.FireEvent(EventType.LeftTriggerPressed, controller);
    }

    /// <summary>
    /// Watch for the controller being connected or disconnected
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private void DetectConnection(IXboxController controller)
    {
        eventStore.FireEvent(controller.IsConnected ? EventType.ControllerConnected : EventType.ControllerDisconnected, controller);
    }

    /// <summary>
    /// Watch for the controller capabilities being set
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private void DetectCapabilities(IXboxController controller)
    {
        if (controller.IsWireless)
            eventStore.FireEvent(EventType.ControllerIsWireless, controller);

        eventStore.FireEvent(EventType.UpdateBatteryInformation, controller);
    }

    #endregion
}
