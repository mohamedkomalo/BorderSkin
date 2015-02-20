using System;
using System.Diagnostics;

namespace BorderSkin.BorderSkinning.Handlers
{
    class ProcessExitHandler : IDisposable
    {
        private SkinableWindowBorder _skinWindow;
        private Process _parentProcess;

        public ProcessExitHandler(SkinableWindowBorder skinWindow, Process parentProcess)
        {
            _skinWindow = skinWindow;

            _parentProcess = parentProcess;
            _parentProcess.EnableRaisingEvents = true;
            _parentProcess.Exited += OnProcessCloseHandler;

        }

        private void OnProcessCloseHandler(object sender, EventArgs e)
        {
            _skinWindow.Dispose();
        }

        public void Dispose()
        {
            _parentProcess.EnableRaisingEvents = false;
            _parentProcess.Exited -= OnProcessCloseHandler;

            _parentProcess.Dispose();
            _parentProcess = null;

            _skinWindow = null;
        }
    }
}