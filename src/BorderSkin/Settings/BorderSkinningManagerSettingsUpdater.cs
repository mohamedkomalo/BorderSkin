using System;
using BorderSkin.BorderSkinning;

namespace BorderSkin.Settings
{
    class SkinningSettingsUpdater : IDisposable
    {
        private readonly BorderSkinningManager _borderSkinningManager;

        public SkinningSettingsUpdater(BorderSkinningManager borderSkinningManager)
        {
            _borderSkinningManager = borderSkinningManager;

            Settings.BorderSkinningChanged += OnSkinningChangedHandler;

            OnSkinningChangedHandler();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                BorderSkin.Settings.Settings.BorderSkinningChanged -= OnSkinningChangedHandler;
            }
        }

        private void OnSkinningChangedHandler()
        {
            if (ThemingEnabled)
                _borderSkinningManager.Start();
            else
                _borderSkinningManager.Stop();
        }

        private static bool ThemingEnabled
        {
            get { return BorderSkin.Settings.Settings.BorderSkinning; }
        }
    }
}
