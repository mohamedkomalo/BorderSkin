using BorderSkin.BorderSkinning.Explorer.Forms;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning.Explorer
{
    class ExplorerNewWindowHandler : INewWindowHandler
    {
        public bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager)
        {
            if (Settings.Settings.ExplorerSkinning && ExplorerSkinWindow.IsExplorerWindow(window))
            {
                manager.AddSkinWindow(new ExplorerSkinWindow(window, Settings.Settings.ExplorerSkin));

                return true;
            }

            return false;
        }
    }
}