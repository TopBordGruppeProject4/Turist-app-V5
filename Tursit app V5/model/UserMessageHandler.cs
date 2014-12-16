using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Tursit_app_V5.view;

namespace Tursit_app_V5.model
{
    class UserMessageHandler
    {
        private MessageDialog messageDialog;

        public UserMessageHandler(string message, string title)
        {
            messageDialog = new MessageDialog(message, title);
        }

        public void Show(string command = "")
        {
            messageDialog.ShowAsync();
        }
    }
}
