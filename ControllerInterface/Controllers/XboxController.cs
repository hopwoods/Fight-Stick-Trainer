using Microsoft.Extensions.Logging;
using SharpDX;
using SharpDX.XInput;

namespace ControllerInterface.Controllers
{
    public class XboxController: IXboxController
    {
        #region Public Fields & Properties

        public bool IsConnected { get; set; }
        public bool AButton { get; set; }
        public bool BButton { get; set; }
        public bool XButton { get; set; }
        public bool YButton { get; set; }
        public bool RbButton { get; set; }
        public bool LbButton { get; set; }
        public bool DpadUpButton { get; set; }
        public bool DpadDownButton { get; set; }
        public bool DpadLeftButton { get; set; }
        public bool DpadRightButton { get; set; }

        #endregion

        #region Private Fields & Properties

        private readonly ILogger<XboxController> _logger;

        private Controller Controller { get; set; }

        private State _state;
        private Gamepad _gamepad;

        #endregion


        #region Constructor

        public XboxController(ILogger<XboxController> logger)
        {
            _logger = logger;
            Controller = new Controller(UserIndex.One);
        }

        #endregion

        #region Methods

        public void Update()
        {
            try
            {
                _state = Controller.GetState();
            }
            catch (SharpDXException e)
            {
                _logger.LogInformation(e, "No Controller is connected.");
                IsConnected = false;
                return;
            }
            
            _gamepad = _state.Gamepad;

            IsConnected = Controller.IsConnected;

            //Buttons
            AButton = (_gamepad.Buttons & GamepadButtonFlags.A) != 0;
            BButton = (_gamepad.Buttons & GamepadButtonFlags.B) != 0;
            XButton = (_gamepad.Buttons & GamepadButtonFlags.X) != 0;
            YButton = (_gamepad.Buttons & GamepadButtonFlags.Y) != 0;
            RbButton = (_gamepad.Buttons & GamepadButtonFlags.RightShoulder) != 0;
            LbButton = (_gamepad.Buttons & GamepadButtonFlags.LeftShoulder) != 0;
            DpadUpButton = (_gamepad.Buttons & GamepadButtonFlags.DPadUp) != 0;
            DpadDownButton = (_gamepad.Buttons & GamepadButtonFlags.DPadDown) != 0;
            DpadLeftButton = (_gamepad.Buttons & GamepadButtonFlags.DPadLeft) != 0;
            DpadRightButton = (_gamepad.Buttons & GamepadButtonFlags.DPadRight) != 0;
        }

        #endregion
    }
}