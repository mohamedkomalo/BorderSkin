using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Explorer.Skin;
using BorderSkin.BorderSkinning.Forms;
using BorderSkin.BorderSkinning.Skin;
using BorderSkin.Utilities;
using LayeredForms;
using LayeredForms.Utilities;
using ButtonState = LayeredForms.ButtonState;
using Padding = System.Windows.Forms.Padding;

namespace BorderSkin.BorderSkinning.Explorer.Forms
{
    public delegate void NavigationRequestedEventHandler(object sender, string Path);

    public delegate void ButtonEnterEventHandler(object sender, string Path);

    class LayeredBreadcrumbs : LayeredTextbox
    {
        public new bool PressedMode;
        private List<LayeredButtonWithSkinElement> _buttons;
        private LayeredPopupMenu _dropdownMenu;
        private string _path = String.Empty;

        private SkinBorder _parent;

        public LayeredBreadcrumbs(SkinBorder parent) : base(parent)
        {
            _buttons = new List<LayeredButtonWithSkinElement>();
            TextVisible = false;

            _parent = parent;
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (value == _path) return;
                _path = value;
                RefreshButtons();
            }
        }

        public bool ButtonsVisible
        {
            set
            {
                foreach (LayeredButtonWithSkinElement b in _buttons)
                {
                    b.Visible = value;
                }
            }
        }

        public override Cursor Cursor
        {
            get { return Cursors.Default; }
        }

        public SkinElement BreadcrumbButton { get; set; }

        public int RightArrowWidth { get; set; }

        public override Size Size
        {
            get
            {
                Padding edges = SkinElement.GetEdges(Parent.Maximized);
                return new Size(Parent.Width - (edges.Left + edges.Right), base.Size.Height);
            }
        }

        public SkinElement SkinElement { get; set; }

        public new SkinBorder Parent
        {
            get { return _parent; }
        }

        public LayeredPopupMenu DropdownMenu
        {
            get { return _dropdownMenu; }
            set
            {
                if (_dropdownMenu != null)
                {
                    _dropdownMenu.PopupMenuClosed -= DropdownMenuOnClose;
                }
                _dropdownMenu = value;
                if (_dropdownMenu != null)
                {
                    _dropdownMenu.PopupMenuClosed += DropdownMenuOnClose;
                }
            }
        }

        public event NavigationRequestedEventHandler NavigationRequested;

        protected override void Dispose(bool disposing)
        {
            ClearButtons(false);

            _path = null;
            BreadcrumbButton = null;
            _buttons = null;
            DropdownMenu = null;

            base.Dispose(disposing);
        }

        public void RefreshButtons()
        {
            if (!IsUpdateLocked())
            {
                ClearButtons();
                Parent.SuspendUpdate();
                string[] PathArray = Path.Split('\\');
                var BreadCrumbPath = new List<string>();

                Padding RealEdges = BreadcrumbButton.GetEdges(Parent.Maximized);
                Point ControlEdges = Location;

                int AddressBarWidth = Parent.Width - (RealEdges.Left + RealEdges.Right);
                int LastWidth = 0;
                for (int i = PathArray.Length - 1; i >= 0; i += -1)
                {
                    int TextWidth = TitleRenderer.TextWidth(PathArray[i], BreadcrumbButton.Font) +
                                    BreadcrumbButton.StretchPadding.Left + BreadcrumbButton.StretchPadding.Right;
                    if ((LastWidth + TextWidth) < AddressBarWidth)
                    {
                        BreadCrumbPath.Insert(0, PathArray[i]);
                    }
                    LastWidth += TextWidth;
                }
                Padding LastLocation = BreadcrumbButton.CalculateEdgesRelativeToTopLeftCorner(Parent.Width, Parent.Maximized, RightWidth);
                BreadCrumbPath.Insert(0, ExplorerSkinIDs.RightArrowButton);
                //Path.Split("\"c)
                foreach (string PathName in BreadCrumbPath)
                {
                    if (PathName.Length > 0)
                    {
                        var NewButton = new LayeredButtonWithSkinElement(Parent);
                        NewButton.SkinElement = BreadcrumbButton;
                        NewButton.RightWidth = RightArrowWidth;

                        if (PathName.Contains("::"))
                        {
                            NewButton.Text = ExtendedFileInfo.GetDisplayName(Path);
                        }
                        else
                        {
                            NewButton.Text = PathName;
                        }
                        if (PathName == ExplorerSkinIDs.RightArrowButton)
                        {
                            NewButton.SizeType = SizingType.SizeToRightWidth;
                            NewButton.TextVisible = false;
                            NewButton.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        }
                        else
                        {
                            NewButton.SizeType = SizingType.SizeToText;
                            NewButton.Tag = Path.Substring(0, Path.IndexOf(PathName) + PathName.Length);
                            if (!PathName.Contains("::"))
                            {
                                NewButton.Tag += System.IO.Path.DirectorySeparatorChar;
                            }
                        }
                        NewButton.X = LastLocation.Left;
                        NewButton.Y = BreadcrumbButton.CalculateEdgesRelativeToTopLeftCorner(0, Parent.Maximized).Top;

                        NewButton.Click += BreadcrumbButton_OnClick;
                        NewButton.MouseEnter += BreadcrumbButtonOnMouseEnter;

                        _buttons.Add(NewButton);
                        if (BreadcrumbButton.ElementAlign == VerticalAlignment.left)
                        {
                            LastLocation.Left += NewButton.Size.Width;
                        }
                        else
                        {
                            NewButton.X -= NewButton.Size.Width;
                            LastLocation.Left = NewButton.X;
                        }
                    }
                }

                Parent.ResumeUpdate();
            }
        }

        private void BreadcrumbButton_OnClick(object sender, MouseEventArgs e)
        {
            var button = (LayeredButtonWithSkinElement)sender;

            string buttonFolderPath = ButtonToPath(sender);
            string buttonFolderName = button.Text;

            if (!Directory.Exists(buttonFolderPath) && buttonFolderName != "My Computer" && buttonFolderName != "Computer")
            {
                return;
            }

            bool isInsideArrowButton;

            if (BreadcrumbButton.ElementAlign == VerticalAlignment.left)
            {
                isInsideArrowButton =
                    e.X > button.Location.X + (button.Size.Width - button.RightWidth) &&
                    e.X < button.Location.X + button.Size.Width;
            }
            else
            {
                isInsideArrowButton = e.X > button.Location.X && e.X < button.Location.X + button.RightWidth;
            }

            if (!isInsideArrowButton)
            {
                OnNavigationRequested(buttonFolderPath);
                return;
            }

            PressedMode = true;

            ForceState = ButtonState.Pressed;
            button.HoverState = ButtonState.Pressed;
            button.ForceState = ButtonState.Pressed;

            Parent.Update();

            BreadcrumbButtonOnMouseEnter(sender, e);
        }

        private void BreadcrumbButtonOnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!PressedMode) return;

            DropdownMenu.Items.Clear();

            var button = (LayeredButtonWithSkinElement) sender;
            string folderPath = ButtonToPath(sender);

            if (button.Text == "My Computer" || button.Text == "Computer")
            {
                foreach (DriveInfo d in DriveInfo.GetDrives())
                {
                    DropdownMenu.Items.Add(new LayeredPopupMenuItem(d.Name, d.Name, null));
                }
            }
            else if (Directory.Exists(folderPath))
            {
                string Path = ButtonToPath(sender);
                string[] folders = Directory.GetDirectories(Path);

                foreach (string folder in folders)
                {
                    String forldername = System.IO.Path.GetFileName(folder);
                    Icon folderIcon = ExtendedFileInfo.GetIconForFilename(folder, true);

                    var item = new LayeredPopupMenuItem(forldername, folder,
                        folderIcon.ToBitmap());

                    folderIcon.Dispose();

                    DropdownMenu.Items.Add(item);

                    if (_buttons.IndexOf(button) + 1 < _buttons.Count)
                    {
                        string folderbefore = ButtonToPath(_buttons[_buttons.IndexOf(button) + 1]);
                        folderbefore = folderbefore.Remove(folderbefore.Length - 1);

                        if (folder.Equals(folderbefore))
                        {
                            item.Bold = true;
                        }
                    }
                }
            }
            else
            {
                return;
            }

            foreach (LayeredButtonWithSkinElement layeredButton in _buttons)
            {
                layeredButton.ForceState = ButtonState.None;
            }

            button.HoverState = ButtonState.Pressed;
            button.ForceState = ButtonState.Pressed;

            if (BreadcrumbButton.ElementAlign == VerticalAlignment.right)
            {
                DropdownMenu.Left = Parent.Left + (button.Location.X - DropdownMenu.Width) + button.Size.Width/2;
            }
            else
            {
                DropdownMenu.Left = Parent.Left + button.Location.X + button.Size.Width/2;
            }

            DropdownMenu.Top = Parent.Top + button.Location.Y + button.Size.Height;

            if (DropdownMenu.Items.Count == 0)
            {
                DropdownMenu.Height = 0;
            }

            DropdownMenu.Show();
            DropdownMenu.ItemClicked += DropDownMenuItemClicked;
        }

        private void DropDownMenuItemClicked(object sender, string path)
        {
            OnNavigationRequested(path);
            DropdownMenu.ItemClicked -= DropDownMenuItemClicked;
        }

        private void DropdownMenuOnClose(object sender, EventArgs e)
        {
            if (!DropdownMenu.Visible)
            {
                PressedMode = false;
                foreach (LayeredButtonWithSkinElement b in _buttons)
                {
                    b.ForceState = ButtonState.None;
                    b.HoverState = ButtonState.Hover;
                }
                ForceState = ButtonState.None;
                Parent.Update();
            }
        }

        private string ButtonToPath(object sender)
        {
            return ((LayeredButtonWithSkinElement) sender).Tag;
        }

        public void ClearButtons(bool RemoveList = true)
        {
            foreach (LayeredButtonWithSkinElement Button in _buttons)
            {
                Button.Click -= BreadcrumbButton_OnClick;
                if (RemoveList)
                {
                    Parent.Controls.Remove(Button);
                }
                Button.Dispose();
            }
            _buttons.Clear();
        }

        protected virtual void OnNavigationRequested(string path)
        {
            NavigationRequestedEventHandler handler = NavigationRequested;
            if (handler != null) handler(this, path);
        }
    }
}