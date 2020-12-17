using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace epicture
{
    public class DataList
    {
        public string Url { get; set; }
        public Imgur.API.Models.Impl.GalleryImage Img { get; set; }

        public DataList() { }

        public DataList(string url, Imgur.API.Models.Impl.GalleryImage img)
        {
            this.Url = url;
            this.Img = img;
        }
    }
}