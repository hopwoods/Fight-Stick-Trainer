namespace ControllerInterface.Controllers
{
    public delegate void ControllerEvent(IXboxController controller);

    public class XboxControllerWatcher : IDisposable, IXboxControllerWatcher
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

        #endregion

        #region Private Properties & Fields

        private bool _stopWatching;
        private readonly IXboxController _controller;

        #endregion

        #region Constructor
        public XboxControllerWatcher(IXboxController controller)
        {
            _controller = controller;
            ThreadPool.QueueUserWorkItem(o => WatcherLoop());
        }

        #endregion

        #region Methods

        private void WatcherLoop()
        {
            Thread.Sleep(1000);
            while (!_stopWatching)
            {
                try
                {
                    DetectStates(_controller);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                Thread.Sleep(_controller.RefreshIntervalMilliseconds);
            }
        }

        private void DetectStates(IXboxController controller)
        {
            DetectConnection(controller);

            if (controller.AButtonIsPressed) FireAButtonPressed(controller);
            if (controller.BButtonIsPressed) FireBButtonPressed(controller);
            if (controller.XButtonIsPressed) FireXButtonPressed(controller);
            if (controller.YButtonIsPressed) FireYButtonPressed(controller);

            if (controller.RbButtonIsPressed) FireRbButtonPressed(controller);
            if (controller.LbButtonIsPressed) FireLbButtonPressed(controller);

            if (controller.DpadUpButtonIsPressed) FireDpadUpButtonPressed(controller);
            if (controller.DpadDownButtonIsPressed) FireDpadDownButtonPressed(controller);
            if (controller.DpadLeftButtonIsPressed) FireDpadLeftButtonPressed(controller);
            if (controller.DpadRightButtonIsPressed) FireDpadRightButtonPressed(controller);

        }

        private void DetectConnection(IXboxController controller)
        {
            if (controller.IsConnected)
            {
                FireConnected(controller);
            }
            else
            {
                FireDisconnected(controller);
            }
        }

        #endregion

        #region Connection Events

        private void FireConnected(IXboxController controller)
        {
            ControllerConnected?.Invoke(controller);
        }
        private void FireDisconnected(IXboxController controller)
        {
            ControllerDisconnected?.Invoke(controller);
        }

        #endregion

        #region ButtonEvents

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


        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _stopWatching = true;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~XboxControllerWatcher() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
