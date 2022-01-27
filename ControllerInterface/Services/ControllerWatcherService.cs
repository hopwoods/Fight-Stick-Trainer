using ControllerInterface.Controllers;
using ControllerInterface.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ControllerInterface.Services;

/// <summary>
/// Background service that watches for controller inputs and fires related events.
/// </summary>
public class ControllerWatcherService : BackgroundService, IControllerWatcherEvents
{
    #region Public Properties & Fields

    public event ControllerEvent? ControllerConnected;
    public event ControllerEvent? ControllerDisconnected;
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
        await DetectButtonPresses(controller);
    }

    /// <summary>
    /// Watch for button presses on the controller
    /// </summary>
    /// <param name="controller">The controller being watched</param>
    private async Task DetectButtonPresses(IXboxController controller)
    {
        if (await controller.AButtonIsPressed) FireAButtonPressed(controller);
        if (await controller.BButtonIsPressed) FireBButtonPressed(controller);
        if (await controller.XButtonIsPressed) FireXButtonPressed(controller);
        if (await controller.YButtonIsPressed) FireYButtonPressed(controller);

        if (await controller.RbButtonIsPressed) FireRbButtonPressed(controller);
        if (await controller.LbButtonIsPressed) FireLbButtonPressed(controller);

        if (await controller.DpadUpButtonIsPressed) FireDpadUpButtonPressed(controller);
        if (await controller.DpadDownButtonIsPressed) FireDpadDownButtonPressed(controller);
        if (await controller.DpadLeftButtonIsPressed) FireDpadLeftButtonPressed(controller);
        if (await controller.DpadRightButtonIsPressed) FireDpadRightButtonPressed(controller);

        if (await controller.StartButtonIsPressed) FireStartButtonPressed(controller);

        if (await controller.LeftStickButtonIsPressed) FireLeftStickButtonPressed(controller);
        if (await controller.RightStickButtonIsPressed) FireRightStickButtonPressed(controller);

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
    /// Register the methods which get called when a event is fired
    /// </summary>
    private void RegisterEvents()
    {
        ControllerConnected += controllerEvents.OnControllerConnected;
        ControllerDisconnected += controllerEvents.OnControllerDisconnected;

        AButtonPressed += controllerEvents.OnAButtonPressed;
        BButtonPressed += controllerEvents.OnBButtonPressed;
        XButtonPressed += controllerEvents.OnXButtonPressed;
        YButtonPressed += controllerEvents.OnYButtonPressed;

        RbButtonPressed += controllerEvents.OnRbButtonPressed;
        LbButtonPressed += controllerEvents.OnLbButtonPressed;

        DpadUpButtonPressed += controllerEvents.OnDpadUpButtonPressed;
        DpadDownButtonPressed += controller => controllerEvents.OnDpadDownButtonPressed(controller);
        DpadLeftButtonPressed += controllerEvents.OnDpadLeftButtonPressed;
        DpadRightButtonPressed += controllerEvents.OnDpadRightButtonPressed;

        StartButtonPressed += controllerEvents.OnStartButtonPressed;

        LeftStickButtonPressed += controllerEvents.OnLeftStickButtonPressed;
        RightStickButtonPressed += controllerEvents.OnRightStickButtonPressed;
    }

    #endregion

    #region Event Triggers

    internal void FireConnected(IXboxController controller)
    {
        ControllerConnected?.Invoke(controller);
    }

    internal void FireDisconnected(IXboxController controller)
    {
        ControllerDisconnected?.Invoke(controller);
    }

    internal void FireAButtonPressed(IXboxController controller)
    {
        AButtonPressed?.Invoke(controller);
    }

    internal void FireBButtonPressed(IXboxController controller)
    {
        BButtonPressed?.Invoke(controller);
    }

    internal void FireXButtonPressed(IXboxController controller)
    {
        XButtonPressed?.Invoke(controller);
    }

    internal void FireYButtonPressed(IXboxController controller)
    {
        YButtonPressed?.Invoke(controller);
    }

    internal void FireRbButtonPressed(IXboxController controller)
    {
        RbButtonPressed?.Invoke(controller);
    }

    internal void FireLbButtonPressed(IXboxController controller)
    {
        LbButtonPressed?.Invoke(controller);
    }

    internal void FireDpadUpButtonPressed(IXboxController controller)
    {
        DpadUpButtonPressed?.Invoke(controller);
    }

    internal void FireDpadDownButtonPressed(IXboxController controller)
    {
        DpadDownButtonPressed?.Invoke(controller);
    }

    internal void FireDpadLeftButtonPressed(IXboxController controller)
    {
        DpadLeftButtonPressed?.Invoke(controller);
    }

    internal void FireDpadRightButtonPressed(IXboxController controller)
    {
        DpadRightButtonPressed?.Invoke(controller);
    }

    internal void FireStartButtonPressed(IXboxController controller)
    {
        StartButtonPressed?.Invoke(controller);
    }

    internal void FireLeftStickButtonPressed(IXboxController controller)
    {
        LeftStickButtonPressed?.Invoke(controller);
    }

    internal void FireRightStickButtonPressed(IXboxController controller)
    {
        RightStickButtonPressed?.Invoke(controller);
    }

    #endregion


}
