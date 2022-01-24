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

        private Gamepad Gamepad => _lastState.Gamepad;

        private State _lastState;
        private readonly ILogger<XboxController> _logger;
        private long _lastMsRefreshed;
        private const long TicksPerMs = TimeSpan.TicksPerMillisecond;

        #endregion

        #region Constructor

        public XboxController(ILogger<XboxController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Controller = new Controller(UserIndex.One);
            RefreshIntervalMilliseconds = int.Parse(configuration["ControllerSettings:RefreshIntervalMilliseconds"]);
        }

        #endregion

        #region Methods

        public void EnsureRefresh()
        {
            var num = Environment.TickCount * TicksPerMs;

            if (!IsConnected)
            {
                if ((num - _lastMsRefreshed) < 1000)
                {
                    return;
                }
            }

            if ((num - _lastMsRefreshed) > RefreshIntervalMilliseconds)
            {
                RefreshControllerState();
            }
        }

        private void RefreshControllerState()
        {
            _lastMsRefreshed = Environment.TickCount * TicksPerMs;

            try
            {
                _lastState = Controller.GetState();
            }
            catch (SharpDXException e)
            {
                if (!e.Message.Contains("The device is not connected"))
                {
                    _logger.LogError(e, "An error occurred with the controller.");
                }
            }
        }

        #endregion

        #region Public Fields & Properties

        public int RefreshIntervalMilliseconds { get; set; }

        public bool IsConnected => Controller.IsConnected;

        public bool AButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            }
        }
        public bool BButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            }
        }

        public bool XButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            }
        }

        public bool YButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            }
        }

        public bool RbButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder);
            }
        }

        public bool LbButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder);
            }
        }

        public bool DpadUpButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            }
        }

        public bool DpadDownButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            }
        }

        public bool DpadLeftButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            }
        }

        public bool DpadRightButtonIsPressed
        {
            get
            {
                EnsureRefresh();
                return Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            }
        }

        #endregion
    }
}