using System;
using System.Drawing;

namespace BorderSkin.BorderSkinning.Skin
{
    class ColorScheme : IDisposable
    {
        private readonly Brush _activeColorBrush;
        private readonly Brush _inActiveColorBrush;

        private bool _disposedValue;

        public ColorScheme(string name, Color activeColor, Color inActiveColor)
        {
            Name = name;
            _activeColorBrush = new SolidBrush(activeColor);
            _inActiveColorBrush = new SolidBrush(inActiveColor);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue) {
                _activeColorBrush.Dispose();
                _inActiveColorBrush.Dispose();

                Name = null;
            }
            _disposedValue = true;
        }

        public string Name { get; private set; }

        public Brush GetBrush(bool active){
            return active ? _activeColorBrush : _inActiveColorBrush;
        }

        #region " IDisposable Support "
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
