using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tursit_app_V5.model
{
    public class Picture
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string Hyperlink { get; set; }

        public Picture(string name, string photo, string description, string hyperlink)
        {
            Name = name;
            Photo = photo;
            Description = description;
            Hyperlink = hyperlink;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Photo: {1}, Description: {2}, Hyperlink: {3}", Name, Photo, Description, Hyperlink);
        }
    }
}
