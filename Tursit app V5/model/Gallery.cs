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
        public string Photo { get; set; }
        public ObservableCollection<Picture> PictureCollection { get; set; }

        public Gallery(string name, string picture, ObservableCollection<Picture> pictureCollection)
        {
            Name = name;
            Picture = picture;
            PictureCollection = pictureCollection;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Picture: {1}, PictureCollection: {2}", Name, Picture, PictureCollection);
        }
    }
}
