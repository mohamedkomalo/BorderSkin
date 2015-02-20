using WinApiWrappers;

namespace BorderSkin.BorderSkinning
{
    class PreventShutdownSkinningNewWindowHandler : INewWindowHandler
    {
        public bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager)
        {
            // TODO: find another way to exclude Shut Down Windows or get the title name from the registry to support loclized names
            return window.Title == "Shut Down Windows";
        }
    }
}