using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tursit_app_V5.model
{
    class User
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public int NumberOfChildren { get; set; }
        public string Relationship { get; set; }

        public ObservableCollection<Picture> Favourites { get; set; }

        public User(string name, string gender, string password, int age, int numberOfChildren, string relationship)
        {
            Name = name;
            Gender = gender;
            Password = password;
            Age = age;
            NumberOfChildren = numberOfChildren;
            Relationship = relationship;
            Favourites = new ObservableCollection<Picture>();
        }

        public Boolean AddFavourite(Picture picture)
        {
            if (Favourites.Contains(picture)) return false;
            Favourites.Add(picture);
            return true;
        }

        public Boolean RemoveFavourite(Picture picture)
        {
            if (!Favourites.Contains(picture)) return false;
            Favourites.Remove(picture);
            return true;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Gender: {1}, Password: {2}, Age: {3}, NumberOfChildren: {4}, Relationship: {5}", Name, Gender, Password, Age, NumberOfChildren, Relationship);
        }
    }
}
