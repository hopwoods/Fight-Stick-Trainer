using Microsoft.Extensions.Logging;
using SharpDX;
using SharpDX.XInput;

namespace ControllerInterface.Controllers
{
    public class XboxController: IXboxController
    {
        #region Public Fields & Properties

        public bool IsConnected { get; set; }
        public bool A_Button { get; set; }
        public bool B_Button { get; set; }
        public bool X_Button { get; set; }
        public bool Y_Button { get; set; }
        public bool RB_Button { get; set; }
        public bool LB_Button { get; set; }

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
                _logger.LogInformation(e.Message);
                IsConnected = false;
                return;
            }
            
            _gamepad = _state.Gamepad;

            IsConnected = Controller.IsConnected;

            //Buttons
            A_Button = (_gamepad.Buttons & GamepadButtonFlags.A) != 0;
            B_Button = (_gamepad.Buttons & GamepadButtonFlags.B) != 0;
            X_Button = (_gamepad.Buttons & GamepadButtonFlags.X) != 0;
            Y_Button = (_gamepad.Buttons & GamepadButtonFlags.Y) != 0;
            RB_Button = (_gamepad.Buttons & GamepadButtonFlags.RightShoulder) != 0;
            LB_Button = (_gamepad.Buttons & GamepadButtonFlags.LeftShoulder) != 0;
        }

        #endregion
    }
}