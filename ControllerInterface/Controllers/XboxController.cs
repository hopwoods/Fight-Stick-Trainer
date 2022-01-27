using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharpDX;
using SharpDX.XInput;

namespace ControllerInterface.Controllers
{
    public class XboxController: IXboxController
    {
        #region Private Fields & Properties

        private Controller Controller { get; }

        private Gamepad Gamepad => lastState.Gamepad;

        private State lastState;
        private readonly ILogger<XboxController> logger;
        private long lastMsRefreshed;
        private const long TicksPerMs = TimeSpan.TicksPerMillisecond;
        private readonly int deBounceInterval;
        private readonly int heldButtonInterval;

        #endregion

        #region Constructor

        public XboxController(ILogger<XboxController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            Controller = new Controller(UserIndex.One);
            RefreshIntervalMilliseconds = int.Parse(configuration["ControllerSettings:RefreshIntervalMilliseconds"]);
            deBounceInterval = RefreshIntervalMilliseconds;
            heldButtonInterval = 65;
        }

        #endregion

        #region Methods

        public void EnsureRefresh()
        {
            var num = Environment.TickCount * TicksPerMs;

            if (!IsConnected)
            {
                if ((num - lastMsRefreshed) < 1000)
                {
                    return;
                }
            }

            if ((num - lastMsRefreshed) > RefreshIntervalMilliseconds)
            {
                RefreshControllerState();
            }
        }

        private void RefreshControllerState()
        {
            lastMsRefreshed = Environment.TickCount * TicksPerMs;

            try
            {
                lastState = Controller.GetState();
            }
            catch (SharpDXException e)
            {
                if (!e.Message.Contains("The device is not connected"))
                {
                    logger.LogError(e, "An error occurred with the controller.");
                }
            }
        }

        /// <summary>
        /// Checks if a button has been pressed then checks again after a DeBounce interval in milliseconds
        /// </summary>
        /// <param name="button"></param>
        /// <returns>True if the button has been pressed</returns>
        private async Task<bool> ButtonHasBeenPressedAsync(GamepadButtonFlags button)
        {
            EnsureRefresh();

            //Has button press been initiated?
            var buttonPressed = Gamepad.Buttons.HasFlag(button);

            if (buttonPressed == false)
                return false;

            //Has button been pressed and released?
            await Task.Delay(deBounceInterval);
            var buttonPressedAfterInterval = Gamepad.Buttons.HasFlag(button);

            if (buttonPressed && !buttonPressedAfterInterval) return true;

            //Hold Detection
            await Task.Delay(heldButtonInterval);
            var buttonPressedAfterHoldInterval = Gamepad.Buttons.HasFlag(button);

            return buttonPressed && buttonPressedAfterHoldInterval;
        }

        #endregion

        #region Public Fields & Properties

        public int RefreshIntervalMilliseconds { get; set; }
        public bool IsConnected => Controller.IsConnected;
        public Task<bool> AButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.A);
        public Task<bool> BButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.B);
        public Task<bool> XButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.X);
        public Task<bool> YButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.Y);
        public Task<bool> RbButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.RightShoulder);
        public Task<bool> LbButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.LeftShoulder);
        public Task<bool> DpadUpButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.DPadUp);
        public Task<bool> DpadDownButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.DPadDown);
        public Task<bool> DpadLeftButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.DPadLeft);
        public Task<bool> DpadRightButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.DPadRight);
        public Task<bool> ViewButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.None);
        public Task<bool> StartButtonIsPressed => ButtonHasBeenPressedAsync(GamepadButtonFlags.Start);

        #endregion
    }
}