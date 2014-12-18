using Windows.UI.Popups;

namespace Tursit_app_V5.viewmodel
{
    class UserMessageHandler
    {
        private MessageDialog messageDialog;

        public UserMessageHandler(string message, string title)
        {
            messageDialog = new MessageDialog(message, title);
        }

        public void Show()
        {
            messageDialog.ShowAsync();
        }
    }
}
