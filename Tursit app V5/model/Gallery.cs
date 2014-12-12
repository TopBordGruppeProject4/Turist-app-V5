using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tursit_app_V5.model
{
    class Gallery
    {
        public string Name { get; set; }
        public ObservableCollection<Picture> PictureCollection { get; set; }

        public Gallery(string name,  ObservableCollection<Picture> pictureCollection)
        {
            Name = name;
            PictureCollection = pictureCollection;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, PictureCollection: {2}", Name, PictureCollection);
        }
    }
}
