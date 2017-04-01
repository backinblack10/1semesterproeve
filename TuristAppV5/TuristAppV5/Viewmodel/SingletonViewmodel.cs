using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuristAppV5.Annotations;
using TuristAppV5.Model;

namespace TuristAppV5.Viewmodel
{
     public class SingletonViewmodel : INotifyPropertyChanged
    {
        private static SingletonViewmodel _instance;
        private ObservableCollection<Kategori> _kategoriCollection;
        private ObservableCollection<Kategoriliste> _minProfilCollection;
        private ObservableCollection<Kategoriliste> _eatOrangeCollection;
        private ObservableCollection<Kategoriliste> _seeOrangeCollection;
        private ObservableCollection<Kategoriliste> _shopOrangeCollection;
        private ObservableCollection<Kategoriliste> _feelOrangeCollection;
        private ObservableCollection<ObservableCollection<Kategoriliste>> _collectionOfCollectionForJson;
        private Kategoriliste _restaurantVigen;
        private Kategoriliste _restaurantHerthadalen;
        private Kategoriliste _roskildeKloster;
        private Kategoriliste _roskildeMuseum;
        private Kategoriliste _rosTorv;
        private Kategoriliste _elgiganten;
        private Kategoriliste _vikingeskibsMuseet;
        private const string Beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur dui sapien, ullamcorper vel volutpat ac, elementum vitae erat. Nam in est eu erat ornare pulvinar. Suspendisse potenti. \n\n Nam et rhoncus diam. Aliquam pretium nibh ut rutrum dictum. Aliquam quis fringilla nulla. Integer a magna tempor, eleifend nunc ut, blandit eros. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In viverra venenatis nibh at placerat.";

        protected SingletonViewmodel()
        {
            //Første kategori "Min Profil"
            _minProfilCollection = new ObservableCollection<Kategoriliste>();
            //_minProfilCollection.Add(new Kategoriliste("Prindsen", "12345678", "Hjemmeside", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Familien Rosted overtog Prindsen. de hun sin datters ku", "17:30-73:92"));

            //Anden Kategori "Eat Orange" (Restauranter)
            _eatOrangeCollection = new ObservableCollection<Kategoriliste>();
            _restaurantVigen = new Kategoriliste("Restaurant Vigen", "46 75 50 08", "http://www.vigen.dk/", 55.673157, 12.079819, "../Assets/Vigen.jpg", "Bag Restaurant Vigen står brødrende Patrick Skovgaard og Claus Skovgaard. Vi åbnede 1. maj 2007 Restaurant Vigen i Roskilde. 8. januar 2010 åbnede vi også Jyllinge Marina midt på Jyllinge Lystbådehavn. Jyllinge Marina er siden hen solgt. Siden 28. februar har vi også haft Skänk Øl- & Vinbar på Hestetorvet Vi har tilsammen mange års erfaring med restaurationsdrift Vil du se mere til os, så besøg os på Restaurant Vigen eller Skänk. Vi glæder os til at byde dig velkommen!", "Torsdag - Søndag 12-22");
            _restaurantHerthadalen = new Kategoriliste("Restaurant Herthadalen", "46 48 01 57", "http://herthadalen.dk/", 55.613802, 11.943416, "../Assets/Herthadalen.jpg", "For enden af Danmarks længste allé, som er en del af Ledreborg Gods, ligger Herthadalen. De smukke selskabslokaler, som alle har egen terrasse med udsigt over Knapsø, har plads fra 15  til 200 personer, og er en perfekt ramme til din udflugt, skovtur, fødselsdag, jubilæum, konfirmation, bryllup, barnedåb, møde, kursus, konference m.m. Vi sørger for, at alt bliver skræddersyet til dine ønsker, og vi bidrager med input og erfaringer for at skabe de bedst mulige rammer for dit arrangement.", "Fredag 18-??");
            for (int eat = 0; eat < 4; eat++)
            {
                _eatOrangeCollection.Add(_restaurantVigen);
                _eatOrangeCollection.Add(_restaurantHerthadalen);
            }
           
            //Tredje Kategori "See Orange" (Seværdigheder)
            _seeOrangeCollection = new ObservableCollection<Kategoriliste>();
            _roskildeKloster = new Kategoriliste("Roskilde Kloster", "46 35 02 19", "http://www.roskildekloster.dk/", 55.642142, 12.085647, "../Assets/RoskildeKloster.jpg", "Klosteret ligger som en kulturhistorisk perle lige midt i Roskildes centrum, blot 100 meter bag den travle hovedgade og fem minutter fra Domkirken. Det unikke bygningskompleks og den store parklignende have udgør en ren ”tidslomme”, hvor der midt i byens hektiske hverdag er en unik ro og historisk stemning.", "Alle dage 9-21");
            _roskildeMuseum = new Kategoriliste("Roskilde Museum", "46 31 65 29", "http://www.roskildemuseum.dk/", 55.642588, 12.083136, "../Assets/RoskildeMuseum.jpg", "Roskilde Museum er et statsanerkendt kulturhistorisk lokalmuseum for Roskilde, Frederikssund Kommune og Lejre kommuner. Museet er blevet til ved en sammenlægning af en række museer i området, herunder Lejre Museum, Frederiksund Museum og Roskilde Museum. Museets formål er at indsamle, bevare og formidle området kulturarv gennem historien og består af i alt otte afdelinger. Museets leder er Frank Birkebæk.", "Alle dage 11-16");
            for (int see = 0; see < 5; see++)
            {
                _seeOrangeCollection.Add(_roskildeKloster);
                _seeOrangeCollection.Add(_roskildeMuseum);
            }
            
            //Fjerde Kategori "Shop Orange" (Shops)
            _shopOrangeCollection = new ObservableCollection<Kategoriliste>();
            _rosTorv = new Kategoriliste("Ro's Torv", "46 38 06 80", "http://www.rostorv.dk/", 55.641065, 12.098470, "../Assets/rostorv.jpg", "RO's Torv ligger i Roskilde og er et unikt shoppingcenter med fokus på design, kunst og arkitektur. De lyse og smukke omgivelser skaber en stemning og stil, som gør det til en særlig oplevelse at besøge centret.", "man-tor 10-19, fre-søn 10-20");
            _elgiganten = new Kategoriliste("Elgiganten", "46 38 06 97", "http://www.elgiganten.dk/", 55.641043, 12.098401, "../Assets/elgiganten.jpg", "Elgiganten er en af Danmarks største forhandlere af bl.a. elektronik og hvidevarer med 30 butikker i hele Danmark foruden webshoppen, der leverer over hele landet. Elgiganten fører et kæmpe udvalg af TV, computer, hvidevarer, køkkenmaskiner, mobiler, GPS og meget mere, og i Elgiganten finder du masser af kendte mærker – f.eks. Apple, Bosch, Canon, Electrolux, Sony og Samsung – selvfølgelig altid til skarpe priser.", "man-fre 10-20, lør-søn 10-17");
            for (int shop = 0; shop < 4; shop++)
            {
                _shopOrangeCollection.Add(_rosTorv);
                _shopOrangeCollection.Add(_elgiganten);
            }
            

            //Femte Kategori "Feel Orange" (Aktiviteter)
            _feelOrangeCollection = new ObservableCollection<Kategoriliste>();
            _vikingeskibsMuseet = new Kategoriliste("Vikingeskibsmuseet", "46 30 02 00", "http://www.vikingeskibsmuseet.dk/", 55.649633, 12.077733, "../Assets/Vikingeskibsmuseet.jpg", "I mange årtier før udgravningen af skibene, som blev påbegyndt i 1962, kendte de lokale fiskere på Roskilde Fjord til et gammelt skib på bunden af fjorden. Skibet kaldte de for Margreteskibet, da de mente, at det stammede tilbage fra Margrete 1.'s tid. Det skulle senere vise sig, at der var mange flere skibe, og at de var endnu ældre. Men allerede i 1920'erne blev der fjernet sten og trædele fra skibene, blandt andet et kølsvin og de blev fotograferet. Kølsvinet endte sine dage i en brændeovn en kold vinterdag under 2. verdenskrig. Efter fundene af vikingeskibene Skuldelev 1-6 åbnede den første del af Vikingeskibmuseet i 1969 baseret på disse skibe. Den del af museet kendes i dag som Museumshallen. Det er tegnet af arkitekt professor Erik Christian Sørensen I 1997 indviedes anden del af museet Museumsøen, der indeholder et bådeværft og rekonstruktion af de gamle skibe.", "Alle dage 10-16");
            for (int feel = 0; feel < 3; feel++)
            {
                _feelOrangeCollection.Add(_vikingeskibsMuseet);
            }

            //Kategorilisten i toppen af MainPage
            _kategoriCollection = new ObservableCollection<Kategori>();
            _kategoriCollection.Add(new Kategori("Min profil", "../Assets/profile.png", _minProfilCollection));
            _kategoriCollection.Add(new Kategori("Eat Orange", "../Assets/eat.png", _eatOrangeCollection));
            _kategoriCollection.Add(new Kategori("See Orange", "../Assets/see.png", _seeOrangeCollection));
            _kategoriCollection.Add(new Kategori("Shop Orange", "../Assets/shop.png", _shopOrangeCollection));
            _kategoriCollection.Add(new Kategori("Feel Orange", "../Assets/feel.png", _feelOrangeCollection));

            // Collection til Json filen
            _collectionOfCollectionForJson = new ObservableCollection<ObservableCollection<Kategoriliste>>();
            _collectionOfCollectionForJson.Add(_minProfilCollection);
            _collectionOfCollectionForJson.Add(_eatOrangeCollection);
            _collectionOfCollectionForJson.Add(_seeOrangeCollection);
            _collectionOfCollectionForJson.Add(_shopOrangeCollection);
            _collectionOfCollectionForJson.Add(_feelOrangeCollection);
        }

        #region GetSet Metoder
        public ObservableCollection<Kategori> KategoriCollection
        {
            get { return _kategoriCollection; }
            set { _kategoriCollection = value; }
        }

        public ObservableCollection<Kategoriliste> MinProfilCollection
        {
            get { return _minProfilCollection; }
            set { _minProfilCollection = value; OnPropertyChanged("MinProfilCollection"); }
        }

        public ObservableCollection<Kategoriliste> EatOrangeCollection
        {
            get { return _eatOrangeCollection; }
            set { _eatOrangeCollection = value; OnPropertyChanged("EatOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> SeeOrangeCollection
        {
            get { return _seeOrangeCollection; }
            set { _seeOrangeCollection = value; OnPropertyChanged("SeeOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> ShopOrangeCollection
        {
            get { return _shopOrangeCollection; }
            set { _shopOrangeCollection = value; OnPropertyChanged("ShopOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> FeelOrangeCollection
        {
            get { return _feelOrangeCollection; }
            set { _feelOrangeCollection = value; OnPropertyChanged("FeelOrangeCollection"); }
        }

         public ObservableCollection<ObservableCollection<Kategoriliste>> CollectionOfCollectionForJson
         {
             get { return _collectionOfCollectionForJson; }
             set { _collectionOfCollectionForJson = value; }
         }
        #endregion
         public static SingletonViewmodel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonViewmodel();
                }
                return _instance;
            }
        }
         
         #region OnPropertyChanged();

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
