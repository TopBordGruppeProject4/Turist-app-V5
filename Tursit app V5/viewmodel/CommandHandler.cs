using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tursit_app_V5.Common;
using Tursit_app_V5.model;

namespace Tursit_app_V5.viewmodel
{
    public class CommandHandler
    {

        public bool CreateUserCommand(User user)
        {
            Userlist userlist = Userlist.UserlistInstance;
            if (userlist.CreateUser(user.Name, user.Gender, user.Password, user.Birthday, user.NumberOfChildren,
                user.Relationship))
            {
                return true;
            }
            
            return false;
        }

        public bool LoginCommand(string username, string password)
        {
            Userlist userlist = Userlist.UserlistInstance;
            if (userlist.Check(username, password))
            {
                return true;
            }
            return false;
        }

    }
}
