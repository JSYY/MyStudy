using System;
using System.Threading;
using UIH.MicroConsole.Common.Unity.ApplicationContext;

namespace UIH.MicroConsole.Common.Unity
{
    public interface IUnityApplication
    {
        void WaitForExit();
        void Exit();
    }

    public sealed class UnityApplication : IUnityApplication, IDisposable
    {
        private bool _disposed;
        private readonly UnityApplicationContext _appContext;
        private readonly ManualResetEvent _exitEvent = new ManualResetEvent(false);

        public UnityApplication(Type startupModuleType)
        {
            _appContext = new UnityApplicationContext();
            _appContext.RegisterInstance<IUnityApplication>(this);
            _appContext.Initialize(startupModuleType);
        }

        public void WaitForExit()
        {
            _exitEvent.WaitOne();
        }

        public void Exit()
        {
            _exitEvent.Set();
        }

        public IUnityApplicationContext GetApplicationContext()
        {
            return _appContext;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _exitEvent.Set();
                _appContext.Dispose();
                _exitEvent.Dispose();
                _disposed = true;
            }
        }
    }
}
