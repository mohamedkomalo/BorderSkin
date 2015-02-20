using System;
using System.Collections.Generic;
using BorderSkin.BorderSkinning.Skin;
using WinApiWrappers;

namespace BorderSkin.Execlusion
{
    class ExcludedWindow : IDisposable
    {

        private string _classNames;
        private readonly HashSet<string> _classNamesSet = new HashSet<string>();
        private bool _disposedValue;

        public ExcludedWindow(string exclusionName, string processName, string classNames, string skinName, string colorSchemeName, bool hasSkin)
        {
            ExclusionName = exclusionName;
            ProcessName = processName.ToLower();

            ClassNames = classNames;

            SkinName = skinName;
            ColorSchemeName = colorSchemeName;
            HasSkin = hasSkin;
            if (hasSkin)
            {
                Skin = WindowBorderSkinProvider.LoadTheme(skinName, colorSchemeName);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue) {
                if (HasSkin) {
                    Skin.Dispose();
                }
            }
            _disposedValue = true;
        }


        public string ExclusionName { get; set; }
        
        public string ProcessName { get; set; }
        
        public string WindowName { get; set; }

        public string SkinName { get; set; }
        
        public string ColorSchemeName { get; set; }
        
        public bool HasSkin { get; set; }

        public WindowBorderSkin Skin { get; set; }

        public string ClassNames
        {
            get { return _classNames; }
            set
            {
                _classNames = value;

                foreach (var name in _classNames.Split(','))
                {
                    if (name != String.Empty)
                        _classNamesSet.Add(name.ToLower());
                }
            }
        }

        public bool ClassContains(string windowClassName)
        {
            return _classNamesSet.Count == 0 || _classNamesSet.Contains(windowClassName.ToLower());
        }

        public bool CheckWindow(TopLevelWindow window)
        {
            return ProcessName.Equals(window.ProcessName, StringComparison.OrdinalIgnoreCase) &&
                   ClassContains(window.ClassName);
        }
    }
}
