using SharpDX.XInput;

namespace ControllerInterface.Controllers
{
    public class XboxController: IXboxController
    {
        public Controller Controller { get; set; }
        public bool IsConnected { get; set; }

        #region Constructor

        public XboxController()
        {
            Controller = new Controller(UserIndex.One);
            IsConnected = Controller.IsConnected;
        }

        #endregion


        #region Methods

        public void Update()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}