using System;

namespace BorderSkin.BorderSkinning.Explorer.Forms
{
    class ExplorerSettingsUpdateHandler : IDisposable
    {
        
        private ExplorerSkinWindow _explorerSkinWindow;

        public ExplorerSettingsUpdateHandler(ExplorerSkinWindow explorerSkinWindow)
        {
            _explorerSkinWindow = explorerSkinWindow;

            Settings.Settings.ExplorerSkinningChanged += SettingsOnExplorerSkinningChanged;
        }

        private void SettingsOnExplorerSkinningChanged()
        {
            BorderSkinningManager.RestoreBorder(_explorerSkinWindow.Parent);
            _explorerSkinWindow.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Settings.Settings.ExplorerSkinningChanged -= SettingsOnExplorerSkinningChanged;
                _explorerSkinWindow = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}