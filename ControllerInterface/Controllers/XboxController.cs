using SharpDX.XInput;

namespace ControllerInterface.Controllers
{
    public class XboxController: IXboxController
    {
        #region Public Fields & Properties

        public bool IsConnected { get; set; }

        public bool AButton { get; set; }

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
            _state = Controller.GetState();
            _gamepad = _state.Gamepad;

            IsConnected = Controller.IsConnected;

            //Buttons
            AButton = (_gamepad.Buttons & GamepadButtonFlags.A) != 0;
        }

        #endregion
    }
}