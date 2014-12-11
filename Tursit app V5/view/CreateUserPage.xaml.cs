using TursitAppV4.Model;
using Tursit_app_V5.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237
using Tursit_app_V5.model;
using Tursit_app_V5.viewmodel;

namespace Tursit_app_V5.view
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CreateUserPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public CreateUserPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;

            List<int> childrenChoises = new List<int>(){0, 1, 2, 3, 4, 5};
            foreach (var childrenChoise in childrenChoises)
            {
                userChildren.Items.Add(childrenChoise);
            }

            List<string> genders = new List<string>(){"Mand", "Kvinde"};
            foreach (var gender in genders)
            {
                UserGender_ComboBox.Items.Add(gender);
            }

            List<string> relationships = new List<string>(){"Single", "I forhold", "Gift"};
            foreach (var relationship in relationships)
            {
                UserRelationship_ComboBox.Items.Add(relationship);
            }
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void CreateUser_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username     = Username_TextBlock.Text;
                string gender       = UserGender_ComboBox.SelectedValue.ToString();
                string password     = UserPassword_PasswordBox.Password;
                DateTimeOffset date = UserAge_DatePicker.Date;
                int childrens       = (int) userChildren.SelectedValue;
                string relationship = UserRelationship_ComboBox.SelectedValue.ToString();

                CommandHandler commandHandler  = new CommandHandler();

                if (date <= DateTimeOffset.Now)
                {
                    if (commandHandler.CreateUserCommand(new User(username, gender, password, date, childrens, relationship)))
                    {
                        FileHandler.Save(MainViewModel.Userlist.ListOfUsers);

                        UserSuccessTextBlock.Text = "Brugeren er blevet oprettet ☺";
                        UserErrorTextBlock.Visibility = Visibility.Collapsed;
                        UserSuccessTextBlock.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        UserErrorMessage("Der findes en bruger med det brugernavn i forvejen, beklager...");
                    }
                }
                else
                {
                    UserErrorMessage("Tror du, at du er fra fremtiden eller hva?");
                }
                
            }
            catch (Exception)
            {
                UserErrorMessage("Der opstod en fejl... Har du husket at udfylde alle felterne korrekt?");
            }
            
        }

        private void UserErrorMessage(string message)
        {
            UserErrorTextBlock.Text = message;
            UserSuccessTextBlock.Visibility = Visibility.Collapsed;
            UserErrorTextBlock.Visibility = Visibility.Visible;
        }
    }
}
