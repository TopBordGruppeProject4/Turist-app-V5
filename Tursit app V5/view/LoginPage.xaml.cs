// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Controls;
using Tursit_app_V5.model;
using Tursit_app_V5.viewmodel;

namespace Tursit_app_V5.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
                Userlist userlist = MainViewModel.Userlist;
                if (userlist.Check(username, password))
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
    }
}
