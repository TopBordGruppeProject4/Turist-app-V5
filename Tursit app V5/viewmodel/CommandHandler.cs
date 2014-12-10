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
    class CommandHandler
    {
        private ICommand _userCommand;

        public ICommand UserCommand
        {
            get
            {
                if (_userCommand == null)
                {
                    _userCommand = new RelayCommand<User>(user => CreateUserCommand(user));
                }
                return _userCommand;
            }
            set { _userCommand = value; }
        }

        public void CreateUserCommand(User user)
        {
            Userlist userlist = Userlist.UserlistInstance;
            userlist.CreateUser(user.Name, user.Gender, user.Password, user.Birthday, user.NumberOfChildren,
                user.Relationship);
        }

        public void LoginCommand()
        {
            
        }

    }
}
