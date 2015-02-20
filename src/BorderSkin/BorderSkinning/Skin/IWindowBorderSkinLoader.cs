using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BorderSkin.BorderSkinning.Skin
{
    interface IWindowBorderSkinLoader
    {
        SkinElement GetSkinElement(string ID);
        Color GetColor(string ID, string Key);
        Color GetColor(string ID, string Key, Color DefaultColor);
        Padding GetRect(string ID, string Key);
        ColorScheme GetColorScheme(string colorSchemeName);
        bool Exists(string id);

        int GetCustomIntegerProperty(string id, string propertyName, int defaultINotExists);

        string GetCustomStringProperty(string id, string propertyName, string defaultINotExists);

        List<string> GetColorSchemes();

        string Name { get; }

        string Author { get; }

        string Website { get; }
    }
}