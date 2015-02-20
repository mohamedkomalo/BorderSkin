namespace BorderSkin.BorderSkinning.Handlers
{
    class SkinWindowControlsChangeHandler : LayeredControlsChangeHandler
    {
        public SkinWindowControlsChangeHandler(SkinableWindowBorder skinWindow) : base(skinWindow)
        {
        }

        public override void UpdateSkinElementsOnControls()
        {
            _skinWindow.TopBorder1.SkinElement = _skinWindow.Maximized
                ? _skinWindow.Skin.MaximizedTopFrame
                : _skinWindow.Skin.TopFrame;

            UpdateControlAppearance(_skinWindow.TopBorder1, _skinWindow.Maximized ? _skinWindow.Skin.MaximizedTopFrame : _skinWindow.Skin.TopFrame);
            UpdateControlAppearance(_skinWindow.LeftBorder1, _skinWindow.Skin.LeftFrame);
            UpdateControlAppearance(_skinWindow.RightBorder1, _skinWindow.Skin.RightFrame);
            UpdateControlAppearance(_skinWindow.BottomBorder1, _skinWindow.Skin.BottomFrame);

            UpdateBaseButtonAppearance(_skinWindow.MaximizeButton1, _skinWindow.Maximized ? _skinWindow.Skin.RestoreButton : _skinWindow.Skin.MaximizeButton);
            UpdateBaseButtonAppearance(_skinWindow.MinimizeButton1, _skinWindow.Skin.MinimizeButton);
            UpdateBaseButtonAppearance(_skinWindow.CloseButton1, _skinWindow.Parent.CloseBoxOnly ? _skinWindow.Skin.Close2Button : _skinWindow.Skin.CloseButton);
            UpdateBaseButtonAppearance(_skinWindow.HelpButton1, _skinWindow.Skin.HelpButton);

            UpdateLocation(_skinWindow.IconControl1, _skinWindow.Skin.Icon);

            UpdateLabel(_skinWindow.TitleControl1, _skinWindow.Skin.Caption);

            UpdateControlAppearance(_skinWindow.TitleBackgroundControl1, _skinWindow.Skin.TitleBackground);
            UpdateLocation(_skinWindow.TitleBackgroundControl1, _skinWindow.Skin.TitleBackground);
            ResetHeight(_skinWindow.TitleBackgroundControl1, _skinWindow.Skin.TitleBackground);


            ResetHeight(_skinWindow.TopBorder1, _skinWindow.Maximized ? _skinWindow.Skin.MaximizedTopFrame : _skinWindow.Skin.TopFrame);
            ResetHeight(_skinWindow.BottomBorder1, _skinWindow.Skin.BottomFrame);
            _skinWindow.LeftBorder1.Width = _skinWindow.Skin.LeftFrame.FrameWidth;
            _skinWindow.RightBorder1.Width = _skinWindow.Skin.RightFrame.FrameWidth;
        }
    }
}
