
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
    public partial class MainWindow : Window
    {
        public ImgurClient client;
        public ObservableCollection<DataList> contents = new ObservableCollection<DataList>();
        bool scene = false;
        string favolist;
        string list;
        public int test = 1;

        public ObservableCollection<DataList> Contents
        {
            get { return contents; }
        }

        public ObservableCollection<DataList> favoris = new ObservableCollection<DataList>();

        public ObservableCollection<DataList> Favoris
        {
            get { return favoris; }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            Start_imgur();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string clientID = ID.Text;
            string clientIDSecret = IDSecret.Text;
            if (clientID == "Client ID" || clientID == "" || clientIDSecret == "Client Secret" || clientIDSecret == "")
                return;
            connection.Visibility = Visibility.Collapsed;
            program.Visibility = Visibility.Visible;
        }

        public void Start_imgur()
        {
            client = new ImgurClient("f7a587fdaf84afa", "91b0fe46d92a877fdc8c1d2017f77aee5126569f");
            favolist = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Fav\", "FavList.txt");
            list = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\Fav\", "Swap.txt");

            if (!File.Exists(favolist))
                File.Create(favolist);
            else if (File.Exists(favolist))
            {
                string line = null;
                using (StreamReader reader = new StreamReader(favolist))
                {
                    test = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        DataList favoris = new DataList();
                        favoris.Url = line;
                        Favoris.Add(favoris);
                    }
                    reader.Close();
                }
            }
            if (!File.Exists(list))
                File.Create(list);
            else if (File.Exists(list))
                File.WriteAllText(list, string.Empty);
        }

        public static bool Checkco()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    { 
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void Display_Favoris(object send , RoutedEventArgs e)
        {
            Contents.Clear();
            foreach(var favoris in Favoris)
                Contents.Add(favoris);
            scene = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int nb = -1;
            Image image = ((StackPanel)((DockPanel)((Button)sender).Parent).Parent).Children.OfType<DockPanel>().First().Children.OfType<Image>().First();
            DataList favoris = new DataList();

            if (image.Source.ToString() != null)
            {
                favoris.Url = image.Source.ToString();
                using (var FavListTxt = new StreamWriter(favolist, true))
                {
                    FavListTxt.WriteLine(image.Source.ToString());
                    FavListTxt.Close();
                }
                if (scene == false)
                {
                    Favoris.Add(favoris);
                }
                foreach (var favorispars in Favoris)
                {
                    if (Contents[++nb].Url == image.Source.ToString() && scene == false)
                    {
                        Contents.RemoveAt(nb);
                        break;
                    }
                }
            }
        }

        private async void onTextChangedSearch(object sender, RoutedEventArgs e)
        {
            scene = false;
            string look = searching.Text;
            Contents.Clear();
            var endpoint = new GalleryEndpoint(client);
 
            Imgur.API.Enums.ImageFileType? Filetype = null;
            switch (type.Text)
            {
                case "Jpg":
                    Filetype = Imgur.API.Enums.ImageFileType.Jpg;
                    break;
                case "Png":
                    Filetype = Imgur.API.Enums.ImageFileType.Png;
                    break;
                case "Gif":
                    Filetype = Imgur.API.Enums.ImageFileType.Gif;
                    break;
                case "Anigif":
                    Filetype = Imgur.API.Enums.ImageFileType.Anigif;
                    break;
                default:
                    break;
            }

            Imgur.API.Enums.ImageSize? Fileformat = null;
            switch (format.Text)
            {
                case "Small":
                    Fileformat = Imgur.API.Enums.ImageSize.Small;
                    break;
                case "Medium":
                    Fileformat = Imgur.API.Enums.ImageSize.Med;
                    break;
                case "Big":
                    Fileformat = Imgur.API.Enums.ImageSize.Big;
                    break;
                case "Large":
                    Fileformat = Imgur.API.Enums.ImageSize.Lrg;
                    break;
                case "Huge":
                    Fileformat = Imgur.API.Enums.ImageSize.Huge;
                    break;
                default:
                    break;
            }
            if (look == "")
            {
                return;
            }
            while (Checkco() == false);
            var gallerys = await endpoint.SearchGalleryAdvancedAsync(look, null, null, null, Filetype, Fileformat, Imgur.API.Enums.GallerySortOrder.Time);
            foreach (var gallery in gallerys)
            {
                if (gallery.GetType() != typeof(Imgur.API.Models.Impl.GalleryAlbum))
                {
                    Imgur.API.Models.Impl.GalleryImage tip = (Imgur.API.Models.Impl.GalleryImage)gallery;
                    DataList content = new DataList();
                    content.Url = tip.Link;
                    Contents.Add(content);
                    continue;
                }
                Imgur.API.Models.Impl.GalleryAlbum tmp = (Imgur.API.Models.Impl.GalleryAlbum)gallery;
                foreach (var image in tmp.Images)
                {
                    DataList content = new DataList();
                    content.Url = image.Link;
                    Contents.Add(content);
                }
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Image img = ((StackPanel)((DockPanel)((Button)sender).Parent).Parent).Children.OfType<DockPanel>().First().Children.OfType<Image>().First();
            DataList locfavoris = new DataList();

            if (img.Source.ToString() != string.Empty)
            {
                int i = -1;
                foreach (var favoris in Favoris)
                {
                    if (Favoris[++i].Url == img.Source.ToString())
                    {
                        Favoris.RemoveAt(i);
                        Contents.RemoveAt(i);
                            string line = null;
                            string line_to_delete = img.Source.ToString();
                        using (StreamReader reader = new StreamReader(favolist))
                        {
                            using (StreamWriter writer = new StreamWriter(list))
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (String.Compare(line, line_to_delete) == 0)
                                        continue;
                                    writer.WriteLine(line);
                                }
                                writer.Close();
                            }
                           reader.Close();
                        }
                        using (StreamReader readerswap = new StreamReader(list))
                        {
                            File.WriteAllText(favolist, string.Empty);
                            using (StreamWriter writterFav = new StreamWriter(favolist))
                            {
                                while ((line = readerswap.ReadLine()) != null)
                                {
                                    writterFav.WriteLine(line);
                                }
                            }

                        }
                            break;
                        }
                    }
                }
            }
        }
    }
