using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristAppV5.Model
{
    public class Kategori
    {
        private string _kategorinavn;
        private string _billede;
        private ObservableCollection<Kategoriliste> _kategoriliste;

        #region GetSet Metoder

        public string Kategorinavn
        {
            get { return _kategorinavn; }
            set { _kategorinavn = value; }
        }

        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public ObservableCollection<Kategoriliste> Kategoriliste
        {
            get { return _kategoriliste; }
            set { _kategoriliste = value; }
        }

        #endregion
        public Kategori()
        {

        }
        public Kategori(string kategorinavn, string billede, ObservableCollection<Kategoriliste> kategoriliste)
        {
            _kategorinavn = kategorinavn;
            _billede = billede;
            _kategoriliste = kategoriliste;
        }
    }
}
