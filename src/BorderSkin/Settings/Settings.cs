using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Explorer.Skin;
using BorderSkin.BorderSkinning.Skin;
using BorderSkin.Execlusion;
using BorderSkin.Language;
using BorderSkin.Utilities;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace BorderSkin.Settings
{
    class Settings
    {
        private const string SettingsFilePath = "Settings.ini";
        private const string SettingsSection = "Settings";

        private const string ExcludeFileName = "ExcludeList.ini";
        private const string IncludeFileName = "IncludeList.ini";

        private static readonly IniFile SettingsFile = new IniFile(Path.Combine(Program.AppPath, SettingsFilePath));

        private static readonly string StartUpShortcutPath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName + ".lnk");

        public readonly static ExcludeList ExcludeList = new ExcludeList(Path.Combine(Program.AppPath, ExcludeFileName));
        public readonly static ExcludeList IncludeList = new ExcludeList(Path.Combine(Program.AppPath, IncludeFileName));

        private static event Action<String> PropertyChanged;

        public static event Action BorderUISettings;

        public static void Load()
        {
            foreach (var p in typeof (Settings).GetProperties())
            {
                var value = SettingsFile.GetValue(SettingsSection, p.Name, "");
                object convertedValue;

                if (p.PropertyType == typeof (LanguageFile))
                    convertedValue = LanguageFile.LoadFromDefault(value);

                else if (p.PropertyType == typeof (WindowBorderSkin))
                    convertedValue = WindowBorderSkinProvider.LoadTheme(value.Split(',')[0], value.Split(',')[1]);

                else if (p.PropertyType == typeof (ExplorerSkin))
                    convertedValue = ExplorerSkin.LoadTheme(value.Split(',')[0], value.Split(',')[1]);

                else
                    convertedValue = Convert.ChangeType(value, p.PropertyType);

                p.SetValue(null, convertedValue, null);
            }

            PropertyChanged += AutoSave;
        }

        public static void Unload()
        {
            Skin.Dispose();
            ExplorerSkin.Dispose();
        }

        private static void AutoSave(string settingsName)
        {
            PropertyInfo property = typeof (Settings).GetProperty(settingsName);
            SettingsFile.SetValue(SettingsSection, settingsName, property.GetValue(null, null).ToString());
        }

        public static bool FirstRun
        {
            get { return _firstRun; }
            set
            {
                _firstRun = value;
                OnPropertyChanged("Transparency");
            }
        }

        private static bool _transparency;

        public static bool Transparency
        {
            get { return _transparency; }
            set
            {
                _transparency = value;

                OnBorderUISettingsChanged();
                OnPropertyChanged("Transparency");
            }
        }


        private static bool _reflection;

        public static bool Reflection
        {
            get { return _reflection; }
            set
            {
                _reflection = value;

                OnBorderUISettingsChanged();
                OnPropertyChanged("Reflection");
            }
        }


        private static bool _fullBlur;

        public static bool FullBlur
        {
            get { return _fullBlur; }
            set
            {
                _fullBlur = value;

                OnBorderUISettingsChanged();
                OnPropertyChanged("FullBlur");
            }
        }


        private static bool _blurEnabled;

        public static bool BlurEnabled
        {
            get { return _blurEnabled; }
            set
            {
                _blurEnabled = value;

                OnBorderUISettingsChanged();
                OnPropertyChanged("BlurEnabled");
            }
        }


        private static int _blurStrength;
        public static event Action BlurStrengthChanged;

        public static int BlurStrength
        {
            get { return _blurStrength; }
            set
            {
                _blurStrength = value;
                

                if (BlurStrengthChanged != null)
                {
                    BlurStrengthChanged();
                }

                OnBorderUISettingsChanged();
                OnPropertyChanged("BlurStrength");
            }
        }


        private static WindowBorderSkin _skin;
        public static event Action SkinChanged;

        public static WindowBorderSkin Skin
        {
            get { return _skin; }
            set
            {
                _skin = value;
                if (SkinChanged != null)
                {
                    SkinChanged();
                }

                OnPropertyChanged("Skin");
            }
        }


        private static ExplorerSkin _explorerSkin;
        public static event Action ExplorerSkinChanged;

        public static ExplorerSkin ExplorerSkin
        {
            get { return _explorerSkin; }
            set
            {
                _explorerSkin = value;
                if (ExplorerSkinChanged != null)
                {
                    ExplorerSkinChanged();
                }

                OnPropertyChanged("ExplorerSkin");
            }
        }


        private static bool _showTrayIcon;

        public static bool ShowTrayIcon
        {
            get { return _showTrayIcon; }
            set
            {
                _showTrayIcon = value;

                OnPropertyChanged("ShowTrayIcon");
            }
        }


        private static bool _runStartUp;

        public static bool RunStartUp
        {
            get { return _runStartUp; }
            set
            {
                _runStartUp = value;

                OnPropertyChanged("RunStartUp");

                if (_runStartUp && !File.Exists(StartUpShortcutPath))
                {
                    var shell = new WshShell();
                    var newShortcut = (WshShortcut) shell.CreateShortcut(StartUpShortcutPath);
                    newShortcut.TargetPath = Application.ExecutablePath;
                    newShortcut.Description = Application.ProductName + " Startup Shortcut";
                    newShortcut.Save();
                }
                else if (!_runStartUp && File.Exists(StartUpShortcutPath))
                {
                    File.Delete(StartUpShortcutPath);
                }
            }
        }


        private static bool _explorerSkinning;
        public static event Action ExplorerSkinningChanged;

        public static bool ExplorerSkinning
        {
            get { return _explorerSkinning; }
            set
            {
                _explorerSkinning = value;
                if (ExplorerSkinningChanged != null)
                {
                    ExplorerSkinningChanged();
                }

                OnPropertyChanged("ExplorerSkinning");
            }
        }


        private static bool _hideMenuBar;
        public static event Action HideMenuBarChanged;

        public static bool HideMenuBar
        {
            get { return _hideMenuBar; }
            set
            {
                _hideMenuBar = value;
                if (HideMenuBarChanged != null)
                {
                    HideMenuBarChanged();
                }

                OnPropertyChanged("HideMenuBar");
            }
        }


        private static bool _borderSkinning;
        public static event Action BorderSkinningChanged;

        public static bool BorderSkinning
        {
            get { return _borderSkinning; }
            set
            {
                _borderSkinning = value;
                if (BorderSkinningChanged != null)
                {
                    BorderSkinningChanged();
                }

                OnPropertyChanged("BorderSkinning");
            }
        }

        private static LanguageFile _language;

        public static LanguageFile Language
        {
            get { return _language; }
            set
            {
                _language = value;

                OnPropertyChanged("Language");
            }
        }


        private static bool _disableFullBlurOnMove;

        public static bool DisableFullBlurOnMove
        {
            get { return _disableFullBlurOnMove; }
            set
            {
                _disableFullBlurOnMove = value;

                OnPropertyChanged("DisableFullBlurOnMove");
            }
        }

        private static bool _disableBlurOnMove;

        public static bool DisableBlurOnMove
        {
            get { return _disableBlurOnMove; }
            set
            {
                _disableBlurOnMove = value;

                OnPropertyChanged("DisableBlurOnMove");
            }
        }

        private static double _reflectionSpeed;

        public static double ReflectionSpeed
        {
            get { return _reflectionSpeed; }
            set
            {
                _reflectionSpeed = value;
                OnPropertyChanged("ReflectionSpeed");
            }
        }


        private static bool _hideAddressbar;
        private static bool _firstRun;
        public static event Action HideAddressbarChanged;

        public static bool HideAddressbar
        {
            get { return _hideAddressbar; }
            set
            {
                _hideAddressbar = value;
                if (HideAddressbarChanged != null)
                {
                    HideAddressbarChanged();
                }

                OnPropertyChanged("HideAddressbar");
            }
        }

        public static void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(propertyName);
            }
        }

        // ReSharper disable once InconsistentNaming
        public static void OnBorderUISettingsChanged()
        {
            if (BorderUISettings != null)
            {
                BorderUISettings();
            }
        }
    }
}