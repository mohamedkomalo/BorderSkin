using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BorderSkin.Utilities;
using LayeredForms;
using LayeredForms.Utilities;

namespace BorderSkin.BorderSkinning.Skin.Ini
{
    class SkinIniLoader : IWindowBorderSkinLoader
    {
        private readonly InfoFile _skinIniFile;

        public SkinIniLoader(String SkinName)
        {
            _skinIniFile = GetSkinIni(SkinName);
        }

        public string SkinPath
        {
            get { return _skinIniFile.Directory.FullName; }
        }

        public bool Exists(String id)
        {
            return _skinIniFile.Exists(id);
        }

        public int GetCustomIntegerProperty(string id, string propertyName, int defaultINotExists)
        {
            return _skinIniFile.GetValue(id, propertyName, defaultINotExists);
        }

        public string GetCustomStringProperty(string id, string propertyName, string defaultINotExists)
        {
            return _skinIniFile.GetValue(id, propertyName, defaultINotExists);
        }

        public List<string> GetColorSchemes()
        {
            return GetColorSchemes(Name);
        }

        public string Name
        {
            get { return GetSkinName(_skinIniFile.Directory.FullName); }
        }

        public string Author
        {
            get { return _skinIniFile.Author; }
        }

        public string Website
        {
            get { return _skinIniFile.Website; }
        }

        public SkinElement GetSkinElement(string ID)
        {
            if (!Exists(ID)) return null;

            var element = new SkinElement();

            element.ID = ID;

            if (_skinIniFile.Exists(ID, SkinKeys.ImageFile))
            {
                var imageFile = GetImageFile(ID);
                var framesNumber = _skinIniFile.GetValue(ID, SkinKeys.FramesNumber, 2);

                var image = new ImageWithDeviceContext(imageFile);
                element.Frames = ExtractFramesInImage(image, image.Height / framesNumber);

                var directoryPath = Path.GetDirectoryName(imageFile);
                if (directoryPath != null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(imageFile) + "MaskOut.png";
                    fileName = Path.Combine(directoryPath, fileName);

                    if (File.Exists(fileName))
                    {
                        element.MaskOutBitmap = new ImageWithDeviceContext(fileName);
                    }
                }
            }

            if (_skinIniFile.Exists(ID, SkinKeys.Sizing)) element.StretchPadding = GetRect(ID, SkinKeys.Sizing);
            if (_skinIniFile.Exists(ID, SkinKeys.Content)) element.ContentPadding = GetRect(ID, SkinKeys.Content);
            
            if (_skinIniFile.Exists(ID, SkinKeys.Edges)) element.NormalEdges = GetRect(ID, SkinKeys.Edges);
            if (_skinIniFile.Exists(ID, SkinKeys.MaxEdges)) element.MaxEdges = GetRect(ID, SkinKeys.MaxEdges);
            if (_skinIniFile.Exists(ID, SkinKeys.ElementAlignment)) element.ElementAlign = GetAlignment(ID, SkinKeys.ElementAlignment);

            if (_skinIniFile.Exists(ID, SkinKeys.BackColor)) element.BackColor = GetColor(ID, SkinKeys.BackColor);

            if (_skinIniFile.Exists(ID, SkinKeys.TextColor)) element.NormalTextBrush = GetColorBrush(ID, SkinKeys.TextColor);
            if (_skinIniFile.Exists(ID, SkinKeys.MaxTextColor)) element.MaxTextBrush = GetColorBrush(ID, SkinKeys.MaxTextColor);
            if (_skinIniFile.Exists(ID, SkinKeys.TextAlignment)) element.TextAlign = GetAlignment(ID, SkinKeys.TextAlignment);

            if (_skinIniFile.Exists(ID, SkinKeys.Font))
            {
                element.Font = GetFont(ID);
                element.TextFormat = new StringFormat(StringFormat.GenericTypographic)
                {
                    FormatFlags = StringFormatFlags.NoWrap,
                    Trimming = StringTrimming.EllipsisCharacter
                };
            }

            return element;
        }

        public Color GetColor(string ID, string Key)
        {
            return GetColor(ID, Key, Color.Black);
        }

        public Color GetColor(string ID, string Key, Color DefaultColor)
        {
            if (_skinIniFile.Exists(ID, Key))
            {
                string[] Info = GetArray(ID, Key);
                return Color.FromArgb(Convert.ToInt32(Info[0]), Convert.ToInt32(Info[1]), Convert.ToInt32(Info[2]),
                    Convert.ToInt32(Info[3]));
            }
            return DefaultColor;
        }

        public Padding GetRect(string ID, string Key)
        {
            string[] Info = GetArray(ID, Key);
            return new Padding(Convert.ToInt32(Info[0]), Convert.ToInt32(Info[1]), Convert.ToInt32(Info[2]),
                Convert.ToInt32(Info[3]));
        }


        public ColorScheme GetColorScheme(string colorSchemeName)
        {
            var realName = SkinIDs.ColorSchemes + colorSchemeName;

            var activeColor = GetColor(realName, SkinKeys.ActiveColor, Color.Transparent);
            var inActiveColor = GetColor(realName, SkinKeys.InActiveColor, activeColor);

            return new ColorScheme(colorSchemeName, activeColor, inActiveColor);
        }

        private SolidBrush GetColorBrush(string ID, string Key)
        {
            if (_skinIniFile.Exists(ID, Key))
            {
                return new SolidBrush(GetColor(ID, Key));
            }
            return null;
        }

        private VerticalAlignment GetAlignment(string ID, string Key)
        {
            string Align = _skinIniFile.GetValue(ID, Key, VerticalAlignment.left.ToString()).ToLower();
            return (VerticalAlignment) Enum.Parse(typeof (VerticalAlignment), Align);
        }

        private string GetImageFile(string ID)
        {
            return Path.Combine(SkinPath, _skinIniFile.GetValue(ID, SkinKeys.ImageFile, ID));
        }

        private string[] GetArray(string ID, string Key)
        {
            string[] functionReturnValue = null;
            functionReturnValue = _skinIniFile.GetValue(ID, Key, "0,0,0,0").Split(',');
            Array.Resize(ref functionReturnValue, 5);
            return functionReturnValue;
        }

        private Font GetFont(string ID)
        {
            if (_skinIniFile.Exists(ID))
            {
                string[] Info = _skinIniFile.GetValue(ID, SkinKeys.Font, "Arial,9,0,0,0").Split(',');
                Array.Resize(ref Info, 6);
                var Style = FontStyle.Regular;
                if (Convert.ToInt32(Info[2]) == 1)
                    Style = Style | FontStyle.Bold;
                if (Convert.ToInt32(Info[3]) == 1)
                    Style = Style | FontStyle.Italic;
                if (Convert.ToInt32(Info[4]) == 1)
                    Style = Style | FontStyle.Underline;
                return new Font(Info[0], Convert.ToInt32(Info[1]), Style, GraphicsUnit.Point);
            }
            return null;
        }

        public static string GetSkinName(string SkinFolder)
        {
            return GetSkinIni(SkinFolder).Directory.Name;
        }

        public static string GetSkinFolder(string SkinName)
        {
            return Path.Combine(SkinPaths.SkinsFolder, SkinName);
        }

        public static string GetSkinIniPath(string SkinName)
        {
            return Path.Combine(GetSkinFolder(SkinName), SkinPaths.SkinIniFile);
        }

        public static InfoFile GetSkinIni(string SkinName)
        {
            return new InfoFile(GetSkinIniPath(SkinName));
        }

        public static List<string> GetColorSchemes(string SkinName)
        {
            List<string> functionReturnValue = default(List<string>);
            IniFile SkinIni = GetSkinIni(SkinName);
            functionReturnValue = new List<string>();
            foreach (string SectionName in SkinIni.SectionsNames)
            {
                if (SectionName.Contains(SkinIDs.ColorSchemes))
                {
                    functionReturnValue.Add(SectionName.Replace(SkinIDs.ColorSchemes, ""));
                }
            }
            return functionReturnValue;
        }

        private static ImageWithDeviceContext[] ExtractFramesInImage(ImageWithDeviceContext image, int frameHeight)
        {
            if (frameHeight == 0)
                return new ImageWithDeviceContext[0];

            int frames = image.Height / frameHeight;

            var states = new ImageWithDeviceContext[frames];

            for (int i = 0; i < frames; i++)
            {
                states[i] = new ImageWithDeviceContext(new Size(image.Width, frameHeight));
                states[i].BitBltImage(image, new Point(0, frameHeight * i), Point.Empty, new Size(image.Width, frameHeight));
            }
            return states;
        }
    }
}