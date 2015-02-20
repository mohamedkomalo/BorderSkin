using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Explorer.Skin;
using BorderSkin.BorderSkinning.Handlers;
using BorderSkin.Utilities;
using LayeredForms;
using SHDocVw;
using WinApiWrappers;
using ButtonState = LayeredForms.ButtonState;

namespace BorderSkin.BorderSkinning.Explorer.Forms
{
    class ExplorerSkinWindow : SkinableWindowBorder
    {

        private ShellBrowserWindow explorerWindow;
        public ShellBrowserWindow ExplorerWindow {
            get { return explorerWindow; }
            set {
                if (explorerWindow != null) {
                    explorerWindow.NavigateComplete2 -= NavigateComplete;
                }
                explorerWindow = value;
                if (explorerWindow != null) {
                    explorerWindow.NavigateComplete2 += NavigateComplete;
                }
            }

        }
        public LayeredTextbox SearchButton;
        public LayeredImageButton NavigateBackButton;
        public LayeredImageButton NavigateForwardButton;
        public LayeredImageButton RefreshButton;
        public LayeredImageButton DownArrowButton;
        public LayeredImageButton HistoryButton;
        public LayeredBreadcrumbs AddressBar;
        
        ExplorerSkin _explorerSkin;
        bool _buttonsRequireUpdate = false;

        int _buttonEventCalls = 0;
        public ExplorerSkinWindow(TopLevelWindow window, ExplorerSkin skin) : base(window, skin, true)
        {

            LockUpdate = true;
            SetExplorerWindow(window);
            TitleControl.Visible = false;
            TitleBackgroundControl1.Visible = false;

            AddressBar = new LayeredBreadcrumbs(TopBorder1);
            TopBorder1.Controls.Remove(AddressBar);
            TopBorder1.Controls.Insert(0, AddressBar);

            SearchButton = new LayeredTextbox(TopBorder1);
            SearchButton.SizeType = LayeredButton.SizingType.SizeToDefault;

            NavigateBackButton = new LayeredImageButton(TopBorder1);
            NavigateBackButton.Enabled = false;

            NavigateForwardButton = new LayeredImageButton(TopBorder1);
            NavigateForwardButton.Enabled = false;

            HistoryButton = new LayeredImageButton(TopBorder1);
            HistoryButton.Enabled = false;

            RefreshButton = new LayeredImageButton(TopBorder1);
            DownArrowButton = new LayeredImageButton(TopBorder1);

            HistoryList = new List<string>();

            ExplorerSkin = skin;
            LockUpdate = false;

            _explorerSettingsUpdateHandler = new ExplorerSettingsUpdateHandler(this);
        }

        protected override void Dispose(bool disposing)
        {
            new Action(RemoveHandlers).Invoke();

            try {
                _explorerSettingsUpdateHandler.Dispose();

                SearchButton = null;
                NavigateBackButton = null;
                NavigateForwardButton = null;
                RefreshButton = null;
                DownArrowButton = null;
                HistoryButton = null;
                AddressBar = null;

                _explorerSkin = null;
                if (!IsClosing) {
                    ExplorerWindow = null;
                }
            } catch (Exception) {
            }
            base.Dispose(disposing);
        }

        public static bool IsExplorerWindow(TopLevelWindow Window)
        {
            if (Window.ProcessName == "explorer" && "CabinetWClass,ExploreWClass".Contains(Window.ClassName)) {
                return true;
            }
            return false;
        }

        public void AddHandlers()
        {
            Settings.Settings.ExplorerSkinChanged += OnExplorerSkinChangedHandler;
            ExplorerWindow.CommandStateChange += ButtonsStateChanged;

            initHandlers();
            initHandlers2();
        }

        public void RemoveHandlers()
        {
            if (!IsClosing) {
                ExplorerWindow.CommandStateChange -= ButtonsStateChanged;
            }
            Settings.Settings.ExplorerSkinChanged -= OnExplorerSkinChangedHandler;

            uninitHandlers();
            uninitHandlers2();
        }

        public void OnExplorerSkinChangedHandler()
        {
            ExplorerSkin = Settings.Settings.ExplorerSkin;
        }

        public string ExplorerPath {
            get {
                if (ExplorerWindow != null) {
                    if (ExplorerWindow.LocationURL.Length > 0) {
                        return new Uri(ExplorerWindow.LocationURL).LocalPath;
                    }
                    return ExplorerWindow.LocationName;
                }
                return "";
            }
        }

        public override bool Maximized
        {
            get { return base.Maximized; }
            set {
                base.Maximized = value;
                if (AddressBar != null) {
                    AddressBar.RefreshButtons();
                }
            }
        }

        public override int Width {
            get { return base.Width; }
            set {
                if (base.Width != value && AddressBar != null) {
                    AddressBar.RefreshButtons();
                }
                base.Width = value;
            }
        }

        public void Navigate(object sender, string PathToNavigate)
        {
            try {
                PathToNavigate = ShellClassID.IDFromName(PathToNavigate);
                object obj = PathToNavigate;
                if (Directory.Exists(PathToNavigate) || PathToNavigate.Contains("::")) {
                    if (ExplorerWindow.ReadyState == tagREADYSTATE.READYSTATE_COMPLETE) {
                        ExplorerWindow.Navigate2(obj);
                    }
                }

            } catch (Exception) {
            }
        }

        public void NavigateComplete(object pDisp, ref object URL)
        {
            TopBorder1.SuspendUpdate();
            AddressBar.Path = URL.ToString();
            SearchButton.Text = DefaultSearchName;
            _buttonsRequireUpdate = true;
            TopBorder1.ResumeUpdate();
        }

        public void ButtonsStateChanged(int Command, bool Enabled)
        {
            switch ((CommandStateChangeConstants)Command) {
                case CommandStateChangeConstants.CSC_NAVIGATEFORWARD:
                    // 2
                    if (NavigateForwardButton.Enabled != Enabled) {
                        NavigateForwardButton.Enabled = Enabled;
                        _buttonsRequireUpdate = true;
                    }
                    break;
                case CommandStateChangeConstants.CSC_NAVIGATEBACK:
                    // 1
                    if (NavigateBackButton.Enabled != Enabled) {
                        NavigateBackButton.Enabled = Enabled;
                        _buttonsRequireUpdate = true;
                    }
                    break;
            }
            _buttonEventCalls += 1;
            if (_buttonEventCalls == 3) {
                if (_buttonsRequireUpdate && !Maximized) {
                    TopBorder1.Update();
                }
                _buttonEventCalls = 0;
                _buttonsRequireUpdate = false;
            }
        }

        public void SetExplorerWindow(TopLevelWindow Window)
        {
            Thread SearchThread = new Thread(SearchExplorerWindows);
            SearchThread.Start(Window.Handle);
        }

        public override string Text {
            get { return string.Empty; }
            set { }
        }

        public ExplorerSkin ExplorerSkin {
            get { return _explorerSkin; }
            set {
                LockUpdate = true;

                _explorerSkin = value;

                Skin = value; // calls ExplorerControlsChangeHandler.UpdateSkinElementsOnControls();
                
                SearchButton.Text = DefaultSearchName;

                LockUpdate = false;

                Update();
            }
        }

        public void SearchExplorerWindows(object obj)
        {
            IntPtr windowHandle = (IntPtr)obj;

            while (ExplorerWindow == null)
            {
                ExplorerWindow = ExplorerWindows.GetExplorerWindow(windowHandle);
            }

            AddressBar.Path = ExplorerPath;
            SearchButton.Text = DefaultSearchName;
            AddHandlers();

            TopBorder1.Update();
        }

        private void initHandlers()
        {
            AddressBar.EnterPressed += OnAddressBar_Enter;
            AddressBar.StartTextChange += BreadCrumbs_StartTextChange;
            AddressBar.ExitTextChange += BreadCrumbs_ExitTextChange;
            NavigateBackButton.Click += NavigateBack;
            NavigateForwardButton.Click += NavigateForeward;
            RefreshButton.Click += Refresh_Clicked;
            DownArrowButton.Click += DownArrow_Clicked;
        }

        private void uninitHandlers()
        {
            AddressBar.EnterPressed -= OnAddressBar_Enter;
            AddressBar.StartTextChange -= BreadCrumbs_StartTextChange;
            AddressBar.ExitTextChange -= BreadCrumbs_ExitTextChange;
            NavigateBackButton.Click -= NavigateBack;
            NavigateForwardButton.Click -= NavigateForeward;
            RefreshButton.Click -= Refresh_Clicked;
            DownArrowButton.Click -= DownArrow_Clicked;
        }

        public void OnAddressBar_Enter()
        {
            string NewPath = Environment.ExpandEnvironmentVariables(AddressBar.Text);
            if (NewPath.StartsWith("\\"))
            {
                return;
            }
            if (File.Exists(NewPath) || Directory.Exists(NewPath) || NewPath.Contains("::"))
            {
                if (ExplorerWindow.ReadyState == tagREADYSTATE.READYSTATE_COMPLETE)
                {
                    ExplorerWindow.Navigate2(NewPath);
                }
            }
        }

        public void BreadCrumbs_StartTextChange()
        {
            AddressBar.Text = ExplorerPath;
            AddressBar.ButtonsVisible = false;
        }

        public void BreadCrumbs_ExitTextChange()
        {
            AddressBar.ButtonsVisible = true;
        }

        public void NavigateBack(object sender, MouseEventArgs e)
        {
            try
            {
                ExplorerWindow.GoBack();
            }
            catch (Exception)
            {
            }
        }

        public void NavigateForeward(object sender, MouseEventArgs e)
        {
            try
            {
                ExplorerWindow.GoForward();
            }
            catch (Exception)
            {
            }
        }

        public void Refresh_Clicked(object sender, MouseEventArgs e)
        {
            ExplorerWindow.Refresh();
        }

        public void DownArrow_Clicked(object sender, MouseEventArgs e)
        {
//            if (Directory.Exists(AddressBar.Path))
//            {
//                TopLevelWindow.FromHandle(AddressBar.SkinTextBox.Handle).Location = Point.Empty;
//                TopLevelWindow.FromHandle(AddressBar.SkinTextBox.TextBoxControl.Handle).Bounds = new Rectangle(TopBorder1.Left + AddressBar.Location.X, (TopBorder1.Top + AddressBar.Location.Y) - (AddressBar.SkinTextBox.TextBoxControl.Height - AddressBar.Size.Height), AddressBar.Size.Width, AddressBar.Size.Height);
//                AddressBar.SkinTextBox.TextBoxControl.DropDownWidth = AddressBar.Size.Width;
//
//                SkinElement element = AddressBar.SkinElement;
//                ExplorerSkin.TextBox.ShowDropDown(ExplorerPath, element.Font, element.TextBrush(false).Color, element.BackColor, element.TextAlign);
//                DownArrowButton.ForceState = ButtonState.Pressed;
//                DownArrowButton.HoverState = ButtonState.Pressed;
//                AddressBar.ForceState = ButtonState.Pressed;
//                AddressBar.HoverState = ButtonState.Pressed;
//                ExplorerSkin.TextBox.TextBoxControl.DropDownClosed += OnBoxHideFromDownArrow;
//            }
        }

        private void OnBoxHideFromDownArrow(object sender, EventArgs e)
        {
//            if (!ExplorerSkin.TextBox.TextBoxControl.DroppedDown)
//            {
//                DownArrowButton.ForceState = ButtonState.None;
//                DownArrowButton.HoverState = ButtonState.Hover;
//                AddressBar.ForceState = ButtonState.None;
//                AddressBar.HoverState = ButtonState.Hover;
//                ExplorerSkin.TextBox.TextBoxControl.DropDownClosed -= OnBoxHideFromDownArrow;
//                TopBorder1.Update();
//            }
        }

        List<string> HistoryList;

        private void initHandlers2()
        {
            ExplorerWindow.BeforeNavigate2 += BeforeNavi;
            ExplorerWindow.NavigateComplete2 += NavigationFinished;
            HistoryButton.Click += OnRecentVisit;
        }

        private void uninitHandlers2()
        {
            ExplorerWindow.BeforeNavigate2 -= BeforeNavi;
            ExplorerWindow.NavigateComplete2 -= NavigationFinished;
            HistoryButton.Click -= OnRecentVisit;
        }

        int CurrentIndex;
        public void BeforeNavi(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            if (HistoryList.Count == 0)
            {
                HistoryList.Add(ShellClassID.IDFromName(ExplorerPath));
                CurrentIndex = 0;
            }
        }

        public void NavigationFinished(object pDisp, ref object URL)
        {
            string NextURL = URL.ToString();
            if (!HistoryList.Contains(NextURL))
            {
                if (HistoryList.Count > 0 && CurrentIndex > 0)
                {
                    HistoryList.RemoveRange(0, CurrentIndex);
                }
                HistoryList.Insert(0, URL.ToString());
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex = HistoryList.IndexOf(NextURL);
            }
            if (HistoryList.Count > 0)
            {
                HistoryButton.Enabled = true;
            }
        }

        public void OnRecentVisit(object sender, MouseEventArgs e)
        {
            if (HistoryList.Count > 0)
            {
                ExplorerSkin.Box.Top = TopBorder1.Top + TopBorder1.Height;
                ExplorerSkin.Box.Width = 200;
                ExplorerSkin.Box.Height = 400;
                if (HistoryButton.VerticalAlignment == VerticalAlignment.left)
                {
                    if (Maximized)
                    {
                        ExplorerSkin.Box.Left = TopBorder1.Left;
                    }
                    else
                    {
                        ExplorerSkin.Box.Left = LeftBorder.Left + LeftBorder.Width;
                    }
                }
                else
                {
                    ExplorerSkin.Box.Left = RightBorder1.Left - ExplorerSkin.Box.Width;
                }
                HistoryButton.ForceState = ButtonState.Pressed;
                HistoryButton.HoverState = ButtonState.Pressed;
                TopBorder1.Update();

                ExplorerSkin.Box.Items.Clear();
                for (int i = 0; i < HistoryList.Count; i++)
                {
                    var path = HistoryList[i];
                    var item = new LayeredPopupMenuItem(Path.GetFileName(path), path, null);
                    if (i == CurrentIndex)
                    {
                        item.Checked = true;
                        item.Bold = true;
                        Bitmap image = Image.FromHbitmap(ExplorerSkin.RecentIcons.Frames[0].HBitmap);
                        image.MakeTransparent(Color.Black);

                        item.Image = image;
                    }
                    else if (i < CurrentIndex)
                    {
                        Bitmap image = Image.FromHbitmap(ExplorerSkin.RecentIcons.Frames[1].HBitmap);
                        image.MakeTransparent(Color.Black);
                        item.HoveredImage = image;
                    }
                    else if (i > CurrentIndex)
                    {
                        Bitmap image = Image.FromHbitmap(ExplorerSkin.RecentIcons.Frames[2].HBitmap);
                        image.MakeTransparent(Color.Black);
                        item.HoveredImage = image;
                    }
                    ExplorerSkin.Box.Items.Add(item);
                }

                ExplorerSkin.Box.Show();

                ExplorerSkin.Box.ItemClicked += Navigate;
                ExplorerSkin.Box.PopupMenuClosed += OnRecentClose;
            }
        }

        public void OnRecentClose(object sender, EventArgs e)
        {
            HistoryButton.ForceState = ButtonState.None;
            HistoryButton.HoverState = ButtonState.Hover;
            TopBorder1.Update();

            ExplorerSkin.Box.ItemClicked -= Navigate;
            ExplorerSkin.Box.PopupMenuClosed -= OnRecentClose;
        }

        private void initHandlers3()
        {
            SearchButton.StartTextChange += SearchBox_StartTextChange;
            SearchButton.ExitTextChange += SearchBox_ExitTextChange;
        }

        public string DefaultSearchName
        {
            get
            {
                string name = AddressBar.Path;
                return ExplorerSkin.DefaultSearchText + " " + ExtendedFileInfo.GetDisplayName(name);
            }
        }

        public void SearchBox_StartTextChange()
        {
            if (SearchButton.Text == DefaultSearchName)
            {
                SearchButton.Text = "";
            }
        }

        public void SearchBox_ExitTextChange()
        {
            if (string.IsNullOrEmpty(SearchButton.Text))
            {
                SearchButton.Text = DefaultSearchName;
            }
        }

        //Sub SearchBox_EnterPressed() Handles SearchButton.TextChanged 'SearchButton.EnterPressed
        //    Dim ListViewHandle As IntPtr
        //    For Each c As TopLevelWindow In Me.Parent.Controls
        //        If c.ClassName = "SysListView32" Then
        //            ListViewHandle = c.Handle
        //            Exit For
        //        End If
        //    Next
        //    Dim ListViewControl As New SystemListView(ListViewHandle)
        //    Dim CurrentSearchWord As String = SearchButton.SkinTextBox.TextBoxControl.Text.ToLower
        //    Dim aa As IWshRuntimeLibrary.Drive ' = DirectCast(ExplorerWindow.Document, Shell32.IShellFolderViewDual3)
        //    aa.FilterView(CurrentSearchWord)

        //End Sub

        //Public deleted As New List(Of LVITEM)
        string LastSearchWord = "";

        bool ContinueDelete = false;
        private readonly ExplorerSettingsUpdateHandler _explorerSettingsUpdateHandler;


        protected override LayeredControlsChangeHandler ControlsChangeHandler
        {
            get { return new ExplorerSkinWndowControlsHandler(this); }
        }
    }
}
