using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tursit_app_V5.model;

namespace Tursit_app_V5.viewmodel
{
    class Singleton
    {
        private static Singleton instance = null;

        public MainViewModel ViewModel;
        public Userlist UserList;

        private Singleton()
        {
            ViewModel = new MainViewModel();
            UserList = new Userlist(getUserData());
        }

        public static Singleton Instance
        {
            get { return instance ?? (instance = new Singleton()); }
        }

        private ObservableCollection<User> getUserData()
        {
            return new ObservableCollection<User>
            {
                new User("Søren", "Male", "1234", 32, 2, "Married"),
                new User("Malene", "Female", "1234", 25, 0, "Single"),
                new User("Karen", "Female", "1234", 56, 2, "Divorced")
            };
        } 
    }
}
