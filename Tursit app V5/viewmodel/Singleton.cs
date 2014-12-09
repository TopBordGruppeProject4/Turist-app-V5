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
        private static Singleton _instance = null;

        public MainViewModel ViewModel;
        public Userlist UserList;

        private Singleton()
        {
            ViewModel = new MainViewModel();
        }

        public static Singleton Instance
        {
            get { return _instance ?? (_instance = new Singleton()); }
        }
    }
}
