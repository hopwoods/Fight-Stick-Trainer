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

        #endregion

        #region Private Fields & Properties

        private Controller Controller { get; set; }

        private State _state;
        private Gamepad _gamepad;

        #endregion


        #region Constructor

        public XboxController()
        {
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
            catch (Exception e)
            {
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
        }

        #endregion
    }
}