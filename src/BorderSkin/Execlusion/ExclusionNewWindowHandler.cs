using BorderSkin.BorderSkinning;
using WinApiWrappers;

namespace BorderSkin.Execlusion
{
    class ExclusionNewWindowHandler : INewWindowHandler
    {
        private static ExcludeList ExcludeList
        {
            get { return Settings.Settings.ExcludeList; }
        }

        public bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager)
        {
            ExcludedWindow exludeInfo = ExcludeList[window];

            if (exludeInfo != null)
            {
                if (exludeInfo.HasSkin)
                {
                    manager.AddSkinWindow(new SkinableWindowBorder(window, exludeInfo.Skin, true));
                }

                return true;
            }

            return false;
        }
    }
}