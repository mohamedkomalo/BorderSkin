using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using BorderSkin.BorderSkinning.Skin;
using BorderSkin.BorderSkinning.Skin.Ini;
using BorderSkin.Utilities;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Explorer.Skin
{
    class ExplorerSkin : WindowBorderSkin
    {

        public SkinElement NavigateBackButton;
        public SkinElement NavigateForewardButton;
        public SkinElement SearchButton;
        public SkinElement HistoryButton;

        public SkinElement DownArrowButton;
        public SkinElement RefreshButton;
        public SkinElement BreadCrumbButton;
        public SkinElement BoxButton;
        public SkinElement AddressBarButton;

        public LayeredPopupMenu Box;

        public int RightArrowWidth;

        public string DefaultSearchText;
        public SkinElement PopupBox;
        public SkinElement PopupboxItem;
        public SkinElement RecentIcons;

        public ExplorerSkin(string SkinPath, string ColorScheme) : base(SkinPath, ColorScheme)
        {
            NavigateBackButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.NavigateBackButton);
            NavigateForewardButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.NavigateForewardButton);
            SearchButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.SearchButton);
            RefreshButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.RefreshButton);
            DownArrowButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.DownArrowButton);
            BreadCrumbButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.BreadCrumbButton);
            HistoryButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.HistoryButton);
            AddressBarButton = SkinLoader.GetSkinElement(ExplorerSkinIDs.AddressBarBackground);
            
            PopupBox = SkinLoader.GetSkinElement(ExplorerSkinIDs.Box);
            PopupboxItem = SkinLoader.GetSkinElement(ExplorerSkinIDs.BoxButton);
            RecentIcons = SkinLoader.GetSkinElement(ExplorerSkinIDs.RecentIcons);

            Box = new LayeredPopupMenu();
            Box.BackgroundImage = PopupBox.Frames[0];
            Box.ContentMargin = PopupBox.ContentPadding;
            Box.StretchMargin = PopupBox.StretchPadding;
            Box.ScrollbarAlighnemt = PopupBox.ElementAlign;

            Box.ItemBackgroundImage = PopupboxItem.Frames[0];
            Box.ItemHoveredBackgroundImage = PopupboxItem.Frames[1];
            Box.ItemBackgroundImageStretchMargin = PopupboxItem.StretchPadding;
            Box.ItemContent = PopupboxItem.ContentPadding;
            Box.ItemIconLocation = new Point(PopupboxItem.NormalEdges.Left, PopupboxItem.NormalEdges.Top);

            Box.Font = PopupboxItem.Font;
            Box.ForeColorBrush = PopupboxItem.NormalTextBrush;

            BoxButton = PopupboxItem;

            DefaultSearchText = SkinLoader.GetCustomStringProperty(SkinIDs.General, SkinKeys.DefaultSearchText, "Search");
            RightArrowWidth = SkinLoader.GetCustomIntegerProperty(SkinIDs.General, SkinKeys.RightArrowWidth, 0);
        }

        protected override void Dispose(bool disposing)
        {
            IDisposable obj8 = NavigateBackButton;
            if (obj8 != null) {
                obj8.Dispose();
                obj8 = null;
            }
            IDisposable obj9 = NavigateForewardButton;
            if (obj9 != null) {
                obj9.Dispose();
                obj9 = null;
            }
            IDisposable obj10 = SearchButton;
            if (obj10 != null) {
                obj10.Dispose();
                obj10 = null;
            }
            IDisposable obj7 = HistoryButton;
            if (obj7 != null) {
                obj7.Dispose();
                obj7 = null;
            }
            IDisposable obj2 = DownArrowButton;
            if (obj2 != null) {
                obj2.Dispose();
                obj2 = null;
            }
            IDisposable obj3 = RefreshButton;
            if (obj3 != null) {
                obj3.Dispose();
                obj3 = null;
            }
            IDisposable obj4 = BreadCrumbButton;
            if (obj4 != null) {
                obj4.Dispose();
                obj4 = null;
            }
            IDisposable obj = BoxButton;
            if (obj != null) {
                obj.Dispose();
                obj = null;
            }
            IDisposable obj1 = AddressBarButton;
            if (obj1 != null) {
                obj1.Dispose();
                obj1 = null;
            }

            IDisposable obj5 = Box;
            if (obj5 != null) {
                obj5.Dispose();
                obj5 = null;
            }

            base.Dispose(disposing);
        }

        public static new ExplorerSkin LoadTheme(string SkinName, string ColorSchemeName)
        {
            string SkinPath = SkinIniLoader.GetSkinFolder(SkinName);
            return new ExplorerSkin(SkinPath, ColorSchemeName);
        }

        public static bool IsExplorerSkin(string SkinName)
        {
            IniFile SkinFile = new IniFile(Path.Combine(SkinPaths.SkinsFolder, SkinName + "\\skin.ini"));
            return SkinFile.GetValue("Info", "ExplorerSkin", false);
        }

        public static List<string> AllExplorerSkins {
            get {
                List<string> functionReturnValue = default(List<string>);
                functionReturnValue = new List<string>();
                DirectoryInfo Root = new DirectoryInfo(SkinPaths.SkinsFolder);
                foreach (DirectoryInfo DirectoryName in Root.GetDirectories()) {
                    if (IsExplorerSkin(DirectoryName.Name)) {
                        functionReturnValue.Add(DirectoryName.Name);
                    }
                }
                return functionReturnValue;
            }
        }
    }
}
