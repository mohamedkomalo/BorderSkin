using BorderSkin.BorderSkinning.Explorer.Forms;
using BorderSkin.BorderSkinning.Skin;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Handlers
{
    class ExplorerSkinWndowControlsHandler : SkinWindowControlsChangeHandler
    {
        private ExplorerSkinWindow _explorerSkinWindow;
        public ExplorerSkinWndowControlsHandler(ExplorerSkinWindow explorerSkinWindow)
            : base(explorerSkinWindow)
        {
            _explorerSkinWindow = explorerSkinWindow;
        }

        public override void UpdateSkinElementsOnControls()
        {
            base.UpdateSkinElementsOnControls();

            if (_explorerSkinWindow.ExplorerSkin == null)
                return;
            
            UpdateBaseButtonAppearance(_explorerSkinWindow.NavigateBackButton, _explorerSkinWindow.ExplorerSkin.NavigateBackButton);
            UpdateBaseButtonAppearance(_explorerSkinWindow.NavigateForwardButton, _explorerSkinWindow.ExplorerSkin.NavigateForewardButton);
            UpdateBaseButtonAppearance(_explorerSkinWindow.HistoryButton,
                _explorerSkinWindow.ExplorerSkin.HistoryButton);
            UpdateBaseButtonAppearance(_explorerSkinWindow.DownArrowButton, _explorerSkinWindow.ExplorerSkin.DownArrowButton);
            UpdateBaseButtonAppearance(_explorerSkinWindow.RefreshButton, _explorerSkinWindow.ExplorerSkin.RefreshButton);

            ChangeLayeredTextbox(_explorerSkinWindow.SearchButton, _explorerSkinWindow.ExplorerSkin.SearchButton);
            ChangeLayeredTextbox(_explorerSkinWindow.AddressBar, _explorerSkinWindow.ExplorerSkin.AddressBarButton);

            _explorerSkinWindow.AddressBar.SkinElement = _explorerSkinWindow.ExplorerSkin.AddressBarButton;
            _explorerSkinWindow.AddressBar.BreadcrumbButton = _explorerSkinWindow.ExplorerSkin.BreadCrumbButton;

            _explorerSkinWindow.AddressBar.BreadcrumbButton = _explorerSkinWindow.ExplorerSkin.BreadCrumbButton;
            _explorerSkinWindow.AddressBar.DropdownMenu = _explorerSkinWindow.ExplorerSkin.Box;

            _explorerSkinWindow.AddressBar.RightArrowWidth = _explorerSkinWindow.ExplorerSkin.RightArrowWidth;
            _explorerSkinWindow.AddressBar.RefreshButtons();
        }

        protected void ChangeLayeredTextbox(LayeredTextbox textbox, SkinElement element)
        {
            UpdateBaseButtonAppearance(textbox, element);

            textbox.TextPadding = element.ContentPadding;
            textbox.StringFormat = element.TextFormat;
            textbox.TextColorBrush = element.GetTextBrush(_explorerSkinWindow.Parent.Maximized);
            textbox.Font = element.Font;
            textbox.TextVerticalAlignment = element.TextAlign;
            textbox.BackColor = element.BackColor;
        }
    }
}
