namespace ControllerInterface.Controllers
{
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
            Task.Run(WatcherLoop);
        }

        #endregion

        #region Methods

        private async Task WatcherLoop()
        {
            while (!_stopWatching)
            {
                try
                {
                    await DetectStates(_controller);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                await Task.Delay(_controller.RefreshIntervalMilliseconds);
            }
        }

        private async Task DetectStates(IXboxController controller)
        {
            DetectConnection(controller);

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

        #endregion


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue) return;
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                _stopWatching = true;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            disposedValue = true;
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
