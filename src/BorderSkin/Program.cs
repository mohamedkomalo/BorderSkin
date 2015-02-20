using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WindowsHook;
using BorderSkin.BorderSkinning;
using BorderSkin.BorderSkinning.Explorer;
using BorderSkin.ErrorHandling;
using BorderSkin.Execlusion;
using BorderSkin.Settings;

namespace BorderSkin
{
    class Program
    {
        public static readonly string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public const string SourceCodeWebsite = "github.com/mohamedkomalo/BorderSkin";
        public const string KomaloGithubWebsite = "mohamedkomalo.github.io";

        public const string KomaloWebsite = "komalo.deviantart.com";
        public const string BorderSkinWebsite = "borderskin.deviantart.com";
        public const string MoreLangWebsite = "https://komalo.deviantart.com/favourites/#Border-Skin-Language-Files";
        public const string MoreSkinsWebsite = "https://komalo.deviantart.com/favourites/#Border-Skin-Themes";

        public const string MoreExpSkinsWebsite = "https://komalo.deviantart.com/favourites/#Border-Skin-Explorer-Themes";

        public static BorderSkinningManager BorderSkinningManager;
        public static IWindowsHookController WindowsHook = WindowsHookControllerFactory.CreateGlobalWindowsHook();

        private static SkinningSettingsUpdater _skinningSettingsUpdater;

        [STAThread()]
        public static void Main()
        {
            try {
                ErrorManager.Start();
                Settings.Settings.Load();
                SettingsDialogue.StartTray();

                BorderSkinningManager = new BorderSkinningManager(WindowsHook);
                BorderSkinningManager.NewWindowHandlers.Insert(0, new ExplorerNewWindowHandler());
                BorderSkinningManager.NewWindowHandlers.Insert(0, new ExclusionNewWindowHandler());
                BorderSkinningManager.NewWindowHandlers.Insert(0, new InclusionNewWindowHandler());
                BorderSkinningManager.NewWindowHandlers.Insert(0, new PreventShutdownSkinningNewWindowHandler());

                _skinningSettingsUpdater = new SkinningSettingsUpdater(BorderSkinningManager);

                WindowsHook.Start();

                Application.Run();
            } catch (Exception ex) {
                ErrorManager.ProccessError(ex);
            }
        }

        public static void UnLoad()
        {
            BorderSkinningManager.Stop();
            WindowsHook.Dispose();

            _skinningSettingsUpdater.Dispose();

            Settings.Settings.Unload();
            SettingsDialogue.UnLoad();
        }

        public static void Exit()
        {
            UnLoad();
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}
