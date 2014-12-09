using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tursit_app_V5.model
{
    class Userlist
    {
        public ObservableCollection<User> ListOfUsers { get; set; }

        public User CurrentUser = null;

        public Userlist(ObservableCollection<User> listOfUsers)
        {
            ListOfUsers = listOfUsers;
        }

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

        public Boolean CreateUser(string name, string gender, string password, int age, int numberOfChildren, string relationship)
        {
            if (ListOfUsers.Any(user => user.Name.Equals(name))) return false;
            ListOfUsers.Add(new User(name, gender, password, age, numberOfChildren, relationship));
            return true;
        }

        public override string ToString()
        {
            return string.Format("LisOfUsers: {0}", ListOfUsers);
        }
    }
}
