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

        public ICommand AddUserFavoritesCommand
        {
            get
            {
                if (_userCommand == null)
                {
                    _userCommand = new RelayCommand<Picture>(favorite => AddFavoritePicture(favorite));
                }
                return _userCommand;
            }
            set { _userCommand = value; }
        }

        public ICommand RemoveUserFavoriteCommand
        {
            get
            {
                if (_userCommand == null)
                {
                    _userCommand = new RelayCommand<Picture>(favorite => RemoveFavoritePicture(favorite));
                }
                return _userCommand;
            }
            set { _userCommand = value; }
        }

        private void RemoveFavoritePicture(Picture favoritePicture)
        {
            User currentUser = Userlist.UserlistInstance.CurrentUser;
            currentUser.RemoveFavourite(favoritePicture);
        }

        private void AddFavoritePicture(Picture favoritePicture)
        {
            User currentUser = Userlist.UserlistInstance.CurrentUser;
            currentUser.AddFavourite(favoritePicture);
        }

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
