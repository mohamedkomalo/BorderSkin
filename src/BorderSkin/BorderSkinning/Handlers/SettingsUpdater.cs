using System;
using BorderSkin.BorderSkinning.Explorer.Forms;
using BorderSkin.Execlusion;

namespace BorderSkin.BorderSkinning.Handlers
{
    class SettingsUpdater : IDisposable
    {
        private SkinableWindowBorder _skinWindow;
        private bool IsExecluded;

        public SettingsUpdater(bool isExecluded, SkinableWindowBorder skinWindow)
        {
            IsExecluded = isExecluded;
            _skinWindow = skinWindow;
            AddSettingsHandlers();
        }

        protected virtual void Dispose(bool disposing)
        {
            RemoveSettingsHandlers();
            _skinWindow = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddSettingsHandlers()
        {
            Settings.Settings.BorderUISettings += _skinWindow.Update;
            Settings.Settings.SkinChanged += OnSkinChangedHandler;

            Settings.Settings.ExcludeList.ExcludedWindowAdded += SettingsOnExclusionListAdded;
            Settings.Settings.IncludeList.ExcludedWindowAdded += SettingsOnInclusionListAdded;

            Settings.Settings.ExcludeList.ExcludedWindowRemoving += ExcludeListOnExcludedWindowRemoving;
            Settings.Settings.IncludeList.ExcludedWindowRemoving += IncludeListOnExcludedWindowRemoving;

            Settings.Settings.BorderSkinningChanged += SettingsOnBorderSkinningChanged;
            Settings.Settings.ExplorerSkinningChanged += SettingsOnExplorerSkinningChanged;

            Settings.Settings.HideAddressbarChanged += _skinWindow.WindowEventHandler.AdjustSkinWindowToParentBounds;
            Settings.Settings.HideMenuBarChanged += _skinWindow.WindowEventHandler.AdjustSkinWindowToParentBounds;
        }

        private void RemoveSettingsHandlers()
        {
            Settings.Settings.BorderUISettings -= _skinWindow.Update;
            Settings.Settings.SkinChanged -= OnSkinChangedHandler;

            Settings.Settings.ExcludeList.ExcludedWindowAdded -= SettingsOnExclusionListAdded;
            Settings.Settings.IncludeList.ExcludedWindowAdded -= SettingsOnInclusionListAdded;

            Settings.Settings.ExcludeList.ExcludedWindowRemoving -= ExcludeListOnExcludedWindowRemoving;
            Settings.Settings.IncludeList.ExcludedWindowRemoving -= IncludeListOnExcludedWindowRemoving;

            Settings.Settings.BorderSkinningChanged -= SettingsOnBorderSkinningChanged;
            Settings.Settings.ExplorerSkinningChanged -= SettingsOnExplorerSkinningChanged;

            Settings.Settings.HideAddressbarChanged -= _skinWindow.WindowEventHandler.AdjustSkinWindowToParentBounds;
            Settings.Settings.HideMenuBarChanged -= _skinWindow.WindowEventHandler.AdjustSkinWindowToParentBounds;
        }

        private void SettingsOnInclusionListAdded(ExcludedWindow newIncludedWindow)
        {
            if (!newIncludedWindow.CheckWindow(_skinWindow.Parent))
            {
                // This means that this is the first addition of included window, all non included windows should be diposed
                if (Settings.Settings.IncludeList.Count == 1){
                    _skinWindow.Dispose();
                }
            }
            else
            {
                if (newIncludedWindow.HasSkin)
                {
                    _skinWindow.Skin = newIncludedWindow.Skin;
                }
            }
        }

        private void SettingsOnExclusionListAdded(ExcludedWindow excludedWindow)
        {
            if (excludedWindow.CheckWindow(_skinWindow.Parent))
            {
                if (excludedWindow.HasSkin)
                {
                    _skinWindow.Skin = excludedWindow.Skin;
                }
                else
                {
                    _skinWindow.Dispose();
                }
            }
        }

        private void IncludeListOnExcludedWindowRemoving(ExcludedWindow includedWindow)
        {
            if (includedWindow.CheckWindow(_skinWindow.Parent))
            {
                _skinWindow.Dispose();
            }
        }

        private void ExcludeListOnExcludedWindowRemoving(ExcludedWindow excludedWindow)
        {
            if (excludedWindow.CheckWindow(_skinWindow.Parent) && excludedWindow.HasSkin)
            {
                _skinWindow.Skin = Settings.Settings.Skin;
            }
        }

        private void SettingsOnBorderSkinningChanged()
        {
            BorderSkinningManager.RestoreBorder(_skinWindow.Parent);
            _skinWindow.Dispose();
        }

        private void SettingsOnExplorerSkinningChanged()
        {
            if (!(_skinWindow is ExplorerSkinWindow) && ExplorerSkinWindow.IsExplorerWindow(_skinWindow.Parent))
            {
                BorderSkinningManager.RestoreBorder(_skinWindow.Parent);
                _skinWindow.Dispose();
            }
        }

        private void OnSkinChangedHandler()
        {
            if (!IsExecluded)
            {
                _skinWindow.Skin = Settings.Settings.Skin;
            }
        }
    }
}