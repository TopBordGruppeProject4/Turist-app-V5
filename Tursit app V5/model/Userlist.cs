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
        public ObservableCollection<User> LisOfUsers { get; set; }

        public Userlist(ObservableCollection<User> lisOfUsers)
        {
            LisOfUsers = lisOfUsers;
        }

        public override string ToString()
        {
            return string.Format("LisOfUsers: {0}", LisOfUsers);
        }
    }
}
