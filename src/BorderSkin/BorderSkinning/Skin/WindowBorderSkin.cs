using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Skin.Ini;
using LayeredForms;
using LayeredForms.Utilities;

namespace BorderSkin.BorderSkinning.Skin
{
    class WindowBorderSkin : IDisposable
    {
        public SkinElement TopFrame { get; set; }
        public SkinElement MaximizedTopFrame { get; set; }
        public SkinElement LeftFrame { get; set; }
        public SkinElement RightFrame { get; set; }
        public SkinElement BottomFrame { get; set; }

        public SkinElement ReflectionImage { get; set; }
        public SkinElement MinimizeButton { get; set; }
        public SkinElement MaximizeButton { get; set; }
        public SkinElement RestoreButton { get; set; }
        public SkinElement HelpButton { get; set; }
        public SkinElement CloseButton { get; set; }

        public SkinElement Close2Button { get; set; }
        public SkinElement Icon { get; set; }
        public SkinElement Caption { get; set; }

        public SkinElement TitleBackground { get; set; }
        public Padding SizingPadding { get; set; }
        public byte InActiveReflection { get; set; }

        public ColorScheme ColorScheme { get; private set; }

        private bool _disposedValue;
        private readonly IWindowBorderSkinLoader _skinLoader;

        public WindowBorderSkin(string skinName, string colorSchemeName)
        {
            if (!Directory.Exists(skinName))
            {
                throw new Exception("Skin selected doesn't exsits.\nMake sure that you didn't remove the skin folder.");
            }

            _skinLoader = new SkinIniLoader(skinName);

            ColorScheme = SkinLoader.GetColorScheme(colorSchemeName);

            MaximizedTopFrame = SkinLoader.GetSkinElement(SkinIDs.MaximizedTop);
            TopFrame = SkinLoader.GetSkinElement(SkinIDs.Top);
            LeftFrame = SkinLoader.GetSkinElement(SkinIDs.Left);
            RightFrame = SkinLoader.GetSkinElement(SkinIDs.Right);
            BottomFrame = SkinLoader.GetSkinElement(SkinIDs.Bottom);
            ReflectionImage = SkinLoader.GetSkinElement(SkinIDs.Reflection);

            MinimizeButton = SkinLoader.GetSkinElement(SkinIDs.MinButton);
            MaximizeButton = SkinLoader.GetSkinElement(SkinIDs.MaxButton);
            RestoreButton = SkinLoader.GetSkinElement(SkinIDs.ResButton);
            HelpButton = SkinLoader.GetSkinElement(SkinIDs.HelpButton);
            TitleBackground = SkinLoader.GetSkinElement(SkinIDs.CaptionBackground);
            CloseButton = SkinLoader.GetSkinElement(SkinIDs.CloseButton);
            Close2Button = SkinLoader.Exists(SkinIDs.Close2Button) ? SkinLoader.GetSkinElement(SkinIDs.Close2Button) : CloseButton;

            Caption = SkinLoader.GetSkinElement(SkinIDs.Caption);
            Icon = SkinLoader.GetSkinElement(SkinIDs.Icon);

            SizingPadding = SkinLoader.GetRect(SkinIDs.General, SkinKeys.Sizing);
            InActiveReflection = (byte)SkinLoader.GetCustomIntegerProperty(SkinIDs.General, SkinKeys.ReflectionInActive, 255);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                IDisposable obj = TopFrame;
                if (obj != null)
                {
                    obj.Dispose();
                    obj = null;
                }
                IDisposable obj1 = MaximizedTopFrame;
                if (obj1 != null)
                {
                    obj1.Dispose();
                    obj1 = null;
                }
                IDisposable obj2 = LeftFrame;
                if (obj2 != null)
                {
                    obj2.Dispose();
                    obj2 = null;
                }
                IDisposable obj3 = RightFrame;
                if (obj3 != null)
                {
                    obj3.Dispose();
                    obj3 = null;
                }
                IDisposable obj4 = BottomFrame;
                if (obj4 != null)
                {
                    obj4.Dispose();
                    obj4 = null;
                }
                IDisposable obj5 = ReflectionImage;
                if (obj5 != null)
                {
                    obj5.Dispose();
                    obj5 = null;
                }
                IDisposable obj6 = MinimizeButton;
                if (obj6 != null)
                {
                    obj6.Dispose();
                    obj6 = null;
                }
                IDisposable obj7 = MaximizeButton;
                if (obj7 != null)
                {
                    obj7.Dispose();
                    obj7 = null;
                }
                IDisposable obj8 = RestoreButton;
                if (obj8 != null)
                {
                    obj8.Dispose();
                    obj8 = null;
                }
                IDisposable obj9 = HelpButton;
                if (obj9 != null)
                {
                    obj9.Dispose();
                    obj9 = null;
                }
                IDisposable obj10 = CloseButton;
                if (obj10 != null)
                {
                    obj10.Dispose();
                    obj10 = null;
                }
                IDisposable obj11 = Close2Button;
                if (obj11 != null)
                {
                    obj11.Dispose();
                    obj11 = null;
                }
                IDisposable obj15 = Icon;
                if (obj15 != null)
                {
                    obj15.Dispose();
                    obj15 = null;
                }
                IDisposable obj12 = Caption;
                if (obj12 != null)
                {
                    obj12.Dispose();
                    obj12 = null;
                }
                IDisposable obj13 = TitleBackground;
                if (obj13 != null)
                {
                    obj13.Dispose();
                    obj13 = null;
                }
                IDisposable obj16 = ColorScheme;
                if (obj16 != null)
                {
                    obj16.Dispose();
                    obj16 = null;
                }
            }
            _disposedValue = true;
        }

        public override string ToString()
        {
            return Name + "," + ColorScheme.Name;
        }

        public static implicit operator WindowBorderSkin(string Name)
        {
            return WindowBorderSkinProvider.LoadTheme(Name, "");
        }

        public string Name
        {
            get { return SkinLoader.Name; }
        }

        public string Author
        {
            get { return SkinLoader.Author; }
        }

        public string Website
        {
            get { return SkinLoader.Website; }
        }

        public List<string> ColorSchemes
        {
            get { return _skinLoader.GetColorSchemes(); }
        }

        public IWindowBorderSkinLoader SkinLoader
        {
            get { return _skinLoader; }
        }

        public void ChangeColorScheme(string newColorSchemeName)
        {
            if (ColorScheme != null)
            {
                ColorScheme.Dispose();
                ColorScheme = null;
            }

            ColorScheme = SkinLoader.GetColorScheme(newColorSchemeName);
        }
    }
}