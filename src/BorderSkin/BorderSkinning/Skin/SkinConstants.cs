using System.IO;

namespace BorderSkin.BorderSkinning.Skin
{
    class SkinPaths
    {
        public const string SkinIniFile = "skin.ini";
        public static readonly string SkinsFolder = Path.Combine(Program.AppPath, "Themes");
    }

    class SkinIDs
    {
        public const string General = "General";
        public const string ColorSchemes = "ColorSchemes.";
        public const string Top = "Top";
        public const string MaximizedTop = "MaximizedTop";
        public const string Left = "Left";
        public const string Right = "Right";
        public const string Bottom = "Bottom";
        public const string Icon = "Icon";
        public const string Caption = "Caption";
        public const string CaptionBackground = "CaptionBackground";
        public const string MinButton = "MinButton";
        public const string MaxButton = "MaxButton";
        public const string ResButton = "ResButton";
        public const string CloseButton = "CloseButton";
        public const string Close2Button = "Close2Button";
        public const string HelpButton = "HelpButton";
        public const string Reflection = "Reflection";
    }

    class SkinKeys
    {

        public const string ImageFile = "ImageFile";
        public const string Sizing = "Sizing";
        public const string Content = "Content";
        public const string Edges = "Edges";

        public const string MaxEdges = "MaxEdges";

        public const string Font = "Font";
        public const string BackColor = "BackColor";

        public const string MaxBackColor = "MaxBackColor";
        public const string ActiveColor = "ActiveColor";

        public const string InActiveColor = "InActiveColor";
        public const string TextColor = "TextColor";

        public const string MaxTextColor = "MaxTextColor";
        public const string ElementAlignment = "ElementAlignment";

        public const string TextAlignment = "TextAlignment";

        public const string ReflectionInActive = "ReflectionInActive";
        public const string DefaultSearchText = "DefaultSearchText";
        public const string RightArrowWidth = "BreadcrumbRightArrowWidth";
        public const string FramesNumber = "FramesNumber";
    }

}