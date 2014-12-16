using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tursit_app_V5.model
{
    public class Userlist
    {
        private static Userlist _userlistInstance;

        private Userlist()
        {
            ListOfUsers = new ObservableCollection<User>();
            ListOfUsers.Add(new User("Søren", "Mand", "1234", DateTimeOffset.Parse("08/21/1963"), 2, "Married"));
            ListOfUsers.Add(new User("Malene", "Kvinde", "1234", DateTimeOffset.Parse("05/19/1983"), 0, "Single"));
            ListOfUsers.Add(new User("Karen", "Kvinde", "1234", DateTimeOffset.Parse("11/05/1978"), 2, "Divorced"));
        }

        public static Userlist UserlistInstance
        {
            get
            {
                if (_userlistInstance == null)
                {
                    _userlistInstance = new Userlist();
                }
                return _userlistInstance;
            }
        }

        public ObservableCollection<User> ListOfUsers { get; set; }

        public User CurrentUser = null;

        public Boolean Check(string name, string password)
        {
            foreach (var user in ListOfUsers)
            {
                if (user.Name.Equals(name) && user.Password.Equals(password))
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public Boolean CreateUser(string name, string gender, string password, DateTimeOffset date, int numberOfChildren, string relationship)
        {
            if (ListOfUsers.Any(user => user.Name.Equals(name))) return false;
            ListOfUsers.Add(new User(name, gender, password, date, numberOfChildren, relationship));
            return true;
        }

        public override string ToString()
        {
            return string.Format("LisOfUsers: {0}", ListOfUsers);
        }
    }
}
