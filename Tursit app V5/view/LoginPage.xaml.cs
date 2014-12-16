// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Controls;
using TursitAppV4.Model;
using Tursit_app_V5.model;
using Tursit_app_V5.viewmodel;

namespace Tursit_app_V5.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            // Loads saved users, if they exists
            LoadUsers();
        }

        private void CreateUserButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateUserPage));
        }

        private void LoginButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            string username = UsernameTextBlock.Text;
            string password = UserPasswordBox.Password;
            if (username != "" && password != "")
            {
                CommandHandler commandHandler = new CommandHandler();
                if (commandHandler.LoginCommand(username, password))
                {
                    this.Frame.Navigate(typeof(GalleryPage));
                }
                LoginErrorTextBlock.Text = "Bruger informationerne er forkert...";
            }
            else
            {
                LoginErrorTextBlock.Text = "Du skal udfylde felterne...";
            }
        }

        private async void LoadUsers()
        {
            var loadedUsers = await FileHandler.Load();
            if (loadedUsers != null)
            {
                MainViewModel.Userlist.ListOfUsers = loadedUsers;
            }
        }
    }
}
