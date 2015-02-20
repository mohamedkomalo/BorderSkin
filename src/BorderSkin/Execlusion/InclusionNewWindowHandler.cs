using BorderSkin.BorderSkinning;
using WinApiWrappers;

namespace BorderSkin.Execlusion
{
    class InclusionNewWindowHandler : INewWindowHandler
    {
        private static ExcludeList IncludeList
        {
            get { return Settings.Settings.IncludeList; }
        }

        public bool HandleNewWindow(TopLevelWindow window, BorderSkinningManager manager)
        {
            if (IncludeList.HasWindows)
            {
                ExcludedWindow included = IncludeList[window];

                if (included == null) return true;

                if (included.Skin != null)
                {
                    manager.AddSkinWindow(new SkinableWindowBorder(window, included.Skin, false));
                    return true;
                }
            }

            return false;
        }
    }
}