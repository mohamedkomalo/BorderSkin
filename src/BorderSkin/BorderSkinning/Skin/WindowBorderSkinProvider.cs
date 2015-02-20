using System.Collections.Generic;
using System.IO;
using BorderSkin.BorderSkinning.Explorer.Skin;
using BorderSkin.BorderSkinning.Skin.Ini;

namespace BorderSkin.BorderSkinning.Skin
{
    class WindowBorderSkinProvider
    {
        public static List<string> AllSkins
        {
            get
            {
                List<string> functionReturnValue = default(List<string>);
                functionReturnValue = new List<string>();
                DirectoryInfo Root = new DirectoryInfo(SkinPaths.SkinsFolder);
                foreach (DirectoryInfo DirectoryName in Root.GetDirectories())
                {
                    if (!ExplorerSkin.IsExplorerSkin(DirectoryName.Name))
                    {
                        functionReturnValue.Add(DirectoryName.Name);
                    }
                }
                return functionReturnValue;
            }
        }

        public static WindowBorderSkin LoadTheme(string SkinName, string ColorSchemeName)
        {
            string SkinPath = SkinIniLoader.GetSkinFolder(SkinName);
            return new WindowBorderSkin(SkinPath, ColorSchemeName);
        }
    }
}
