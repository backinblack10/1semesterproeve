using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristAppV5.Model
{
    public class FacebookData
    {
        private string _navn;
        private string _om;
        private string _kilde;
        private string _likes;

        private string _billede;
        private string _besked;
        private string _dato;

        #region GetSet Metoder

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string Om
        {
            get { return _om; }
            set { _om = value; }
        }

        public string Kilde
        {
            get { return _kilde; }
            set { _kilde = value; }
        }

        public string Likes
        {
            get { return _likes; }
            set { _likes = value; }
        }

        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public string Besked
        {
            get { return _besked; }
            set { _besked = value; }
        }

        public string Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        #endregion

    }
}
