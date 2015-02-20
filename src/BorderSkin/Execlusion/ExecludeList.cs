using System;
using System.Collections.Generic;
using System.IO;
using BorderSkin.Utilities;
using WinApiWrappers;

namespace BorderSkin.Execlusion
{
    class ExcludeList : Dictionary<string, ExcludedWindow>
    {
        const string ProcessNameKey = "Process";
        const string ClassNamesKey = "Classes";
        const string SkinNameKey = "Skin";
        const string ColorSchemeNameKey = "ColorScheme";
        const string HasSkinKey = "HasSkin";

        private readonly IniFile _excludeFile;

        public event Action<ExcludedWindow> ExcludedWindowAdded;
        public event Action<ExcludedWindow> ExcludedWindowRemoving;

        private readonly bool _loading;

        public ExcludeList(string execlusionFile)
        {
            _excludeFile = new IniFile(execlusionFile);
            _loading = true;

            foreach (string programName in _excludeFile.SectionsNames) {
                string processName = _excludeFile.GetValue(programName, ProcessNameKey, string.Empty);
                string classNames = _excludeFile.GetValue(programName, ClassNamesKey, "");

                string skinName = _excludeFile.GetValue(programName, SkinNameKey, string.Empty);
                string colorScheme = _excludeFile.GetValue(programName, ColorSchemeNameKey, string.Empty);
                bool skinned = bool.Parse(_excludeFile.GetValue(programName, HasSkinKey, "False"));

                Add(programName, processName, classNames, skinName, colorScheme, skinned);
            }
            _loading = false;
        }

        public new void Add(ExcludedWindow Window)
        {
            base.Add(Window.ProcessName, Window);

            if (ExcludedWindowAdded != null)
                ExcludedWindowAdded.Invoke(Window);

            SaveChanges();
        }

        public void Add(string programName, TopLevelWindow window)
        {
            Add(new ExcludedWindow(programName, window.ProcessName, window.ClassName, string.Empty, string.Empty, false));
            SaveChanges();
        }

        public void Add(string programName, string process, string classNames, string skinName, string colorSchemeName, bool skinned)
        {
            Add(new ExcludedWindow(programName, process, classNames, skinName, colorSchemeName, skinned));
            SaveChanges();
        }

        public new void Remove(string processName)
        {
            ExcludedWindow found = this[processName];

            if (found != null) {
                Remove(found);
            }
        }

        public new void Remove(ExcludedWindow excluded)
        {
            if (ExcludedWindowRemoving != null)
                ExcludedWindowRemoving.Invoke(excluded);

            base.Remove(excluded.ProcessName);
            excluded.Dispose();
            SaveChanges();
        }

        public new void Clear()
        {
            base.Clear();
            SaveChanges();
        }

        public new ExcludedWindow this[String processName]
        {
            get
            {
                ExcludedWindow excludedWindow;
                TryGetValue(processName.ToLower(), out excludedWindow);

                return excludedWindow;
            }
        }

        public ExcludedWindow this[TopLevelWindow window]
        {
            get
            {
                ExcludedWindow excludedWindow = this[window.ProcessName];
                return excludedWindow != null && excludedWindow.ClassContains(window.ClassName)
                    ? excludedWindow
                    : null;
            }
        }

        public bool HasWindows {
            get { return Count > 0; }
        }

        public void SaveChanges()
        {
            if (!_loading) {
                if (File.Exists(_excludeFile.FileName)) {
                    File.Delete(_excludeFile.FileName);
                    if (Count == 0)
                    {
                        File.WriteAllText(_excludeFile.FileName, "");
                    }
                }
                foreach (ExcludedWindow Window in this.Values) {
                    _excludeFile.SetValue(Window.ExclusionName, ProcessNameKey, Window.ProcessName);
                    if (Window.ClassNames.Length > 0)
                        _excludeFile.SetValue(Window.ExclusionName, ClassNamesKey, Window.ClassNames);
                    if (Window.SkinName.Length > 0)
                        _excludeFile.SetValue(Window.ExclusionName, SkinNameKey, Window.SkinName);
                    if (Window.ColorSchemeName.Length > 0)
                        _excludeFile.SetValue(Window.ExclusionName, ColorSchemeNameKey, Window.ColorSchemeName);
                    _excludeFile.SetValue(Window.ExclusionName, HasSkinKey, Window.HasSkin.ToString());

                    File.AppendAllText(_excludeFile.FileName, "\n");
                }
            }
        }
    }
}
