using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Tursit_app_V5.viewmodel
{
    class Login
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Login(string password, string name)
        {
            Password = password;
            Name = name;
        }

        public void LoginFunction()
        {
            
        }
    }

    
}
