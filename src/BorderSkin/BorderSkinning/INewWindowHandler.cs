using WinApiWrappers;

namespace BorderSkin.BorderSkinning
{
    interface INewWindowHandler
    {
        /// <summary>
        /// handle creating new skin window for a new window in the system
        /// </summary>
        /// <param name="window"></param>
        /// <param name="manager"></param>
        /// <returns>
        ///     true or false wether the handler has processed this window
        /// </returns>
        bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager);
    }
}