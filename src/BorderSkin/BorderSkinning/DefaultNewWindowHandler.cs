using WinApiWrappers;

namespace BorderSkin.BorderSkinning
{
    class DefaultNewWindowHandler : INewWindowHandler
    {
        public bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager)
        {
            manager.AddSkinWindow(new SkinableWindowBorder(window, Settings.Settings.Skin, false));

            return true;
        }
    }
}