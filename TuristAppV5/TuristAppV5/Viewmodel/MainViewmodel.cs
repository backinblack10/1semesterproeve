using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Sockets;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Facebook;
using TuristAppV5.Annotations;
using TuristAppV5.Common;
using TuristAppV5.Model;
using TuristAppV5.View;

namespace TuristAppV5.Viewmodel
{
    public class MainViewmodel : INotifyPropertyChanged
    {

        private static Kategori _selectedKategori;
        private static Kategoriliste _selectedKategoriliste;
        private SingletonViewmodel _singletonViewmodel = SingletonViewmodel.Instance;
        private TilfoejKommentarHandler _tilfoejKommentarHandler;
        private RelayCommand _tilfoejKommentarCommand;
        private RelayCommand _tilfoejToDoListeCommand;
        private RelayCommand _sletToDoListeCommand;

        private ObservableCollection<FacebookData> _infoData = new ObservableCollection<FacebookData>();
        private ObservableCollection<FacebookData> _feedData = new ObservableCollection<FacebookData>();

        public MainViewmodel()
        {
            _tilfoejKommentarHandler = new TilfoejKommentarHandler(this);
            _tilfoejKommentarCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejKommentar);
            _tilfoejToDoListeCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejToDoListe);
            _sletToDoListeCommand = new RelayCommand(_tilfoejKommentarHandler.SletToDoListe);
            //_tilfoejKommentarHandler.SaveKategoriAsync();
            try
            {
                _tilfoejKommentarHandler.LoadKategoriAsync();
            }
            catch (FileNotFoundException)
            {
                _tilfoejKommentarHandler.SaveKategoriAsync();
            }
            catch (UnauthorizedAccessException)
            {
                _tilfoejKommentarHandler.SaveKategoriAsync();
            }

            LoadFacebookData();

        }
        private async void LoadFacebookData()
        {
            try
            {
                FacebookClient accessToken = new FacebookClient("722191401190090|zV8YHfAogIsAsGHsE8TOZWIY_0g");
                dynamic infoData = await accessToken.GetTaskAsync("visitroskilde");
                InfoData.Add(new FacebookData { Navn = infoData["name"], Om = infoData["about"], Kilde = infoData["cover"]["source"], Likes = infoData["likes"].ToString() });

                dynamic feedData = await accessToken.GetTaskAsync("visitroskilde/feed?limit=3&offset=1&fields=message, picture, created_time");
                foreach (dynamic item in feedData["data"])
                {
                    FeedData.Add(new FacebookData { Billede = item["picture"], Besked = item["message"], Dato = "Skrevet d. " + DateTime.Parse(item["created_time"]).ToString("dd/MM-yyyy") });

                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                /*MessageDialog fbError = new MessageDialog("Kunne ikke connecte til Facebook API", "Ups! Der skete en fejl");
                fbError.ShowAsync();*/
            }
        }


        #region GetSet Metoder

        public ObservableCollection<FacebookData> InfoData
        {
            get { return _infoData; }
            set { _infoData = value; }
        }

        public ObservableCollection<FacebookData> FeedData
        {
            get { return _feedData; }
            set { _feedData = value; }
        }

        public RelayCommand SletToDoListeCommand
        {
            get { return _sletToDoListeCommand; }
            set { _sletToDoListeCommand = value; }
        }

        public ObservableCollection<Kategori> KategoriCollection
        {
            get { return _singletonViewmodel.KategoriCollection; }
            set { _singletonViewmodel.KategoriCollection = value; }
        }

        public ObservableCollection<Kategoriliste> MinProfilCollection
        {
            get { return _singletonViewmodel.MinProfilCollection; }
            set { _singletonViewmodel.MinProfilCollection = value; OnPropertyChanged("MinProfilCollection"); }
        }

        public ObservableCollection<Kategoriliste> EatOrangeCollection
        {
            get { return _singletonViewmodel.EatOrangeCollection; }
            set { _singletonViewmodel.EatOrangeCollection = value; OnPropertyChanged("EatOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> SeeOrangeCollection
        {
            get { return _singletonViewmodel.SeeOrangeCollection; }
            set { _singletonViewmodel.SeeOrangeCollection = value; OnPropertyChanged("SeeOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> ShopOrangeCollection
        {
            get { return _singletonViewmodel.ShopOrangeCollection; }
            set { _singletonViewmodel.ShopOrangeCollection = value; OnPropertyChanged("ShopOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> FeelOrangeCollection
        {
            get { return _singletonViewmodel.FeelOrangeCollection; }
            set { _singletonViewmodel.FeelOrangeCollection = value; OnPropertyChanged("FeelOrangeCollection"); }
        }

        public ObservableCollection<ObservableCollection<Kategoriliste>> CollectionOfCollectionForJson
        {
            get { return _singletonViewmodel.CollectionOfCollectionForJson; }
            set
            {
                _singletonViewmodel.CollectionOfCollectionForJson = value; 
                OnPropertyChanged("CollectionOfCollectionForJson");
            }
        }

        public Kategori SelectedKategori
        {
            get { return _selectedKategori; }
            set
            {
                _selectedKategori = value;
                OnPropertyChanged("SelectedKategori");
            }
        }
        public static Kategoriliste SelectedKategoriliste
        {
            get { return _selectedKategoriliste; }
            set
            {   
                _selectedKategoriliste = value;
            }
        }

        public RelayCommand TilfoejKommentarCommand
        {
            get { return _tilfoejKommentarCommand; }
            set { _tilfoejKommentarCommand = value; }
        }

        public TilfoejKommentarHandler TilfoejKommentarHandler
        {
            get { return _tilfoejKommentarHandler; }
            set { _tilfoejKommentarHandler = value; }
        }

        public RelayCommand TilfoejToDoListeCommand
        {
            get { return _tilfoejToDoListeCommand; }
            set { _tilfoejToDoListeCommand = value; }
        }

        #endregion

        #region ProtertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
