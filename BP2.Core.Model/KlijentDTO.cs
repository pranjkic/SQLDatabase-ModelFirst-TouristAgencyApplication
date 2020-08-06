using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class KlijentDTO
    {
        private int id;
        private string ime;
        private string prezime;
        private string brojPasosa;
        private int taId;
        //private string nazivTA;
        private int idFilijala;
        //private string nazivFilijala;

        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }

            }
        }
        public string Ime
        {
            get => ime;
            set
            {
                if (ime != value)
                {
                    ime = value;
                    RaisePropertyChanged("Ime");
                }
            }
        }
        public string Prezime
        {
            get => prezime;
            set
            {
                if (prezime != value)
                {
                    prezime = value;
                    RaisePropertyChanged("Prezime");
                }
            }
        }
        public string BrojPasosa
        {
            get => brojPasosa;
            set
            {
                if (brojPasosa != value)
                {
                    brojPasosa = value;
                    RaisePropertyChanged("BrojPasosa");
                }
            }
        }
        public int TaId
        {
            get => taId;
            set
            {
                if (taId != value)
                {
                    taId = value;
                    RaisePropertyChanged("TaId");
                }

            }
        }
        //public string NazivTA
        //{
        //    get => nazivTA;
        //    set
        //    {
        //        if (nazivTA != value)
        //        {
        //            nazivTA = value;
        //            RaisePropertyChanged("NazivTA");
        //        }
        //    }
        //}
        public int IdFilijala
        {
            get => idFilijala;
            set
            {
                if (idFilijala != value)
                {
                    idFilijala = value;
                    RaisePropertyChanged("IdFilijala");
                }

            }
        }
        //public string NazivFilijala
        //{
        //    get => nazivFilijala;
        //    set
        //    {
        //        if (nazivFilijala != value)
        //        {
        //            nazivFilijala = value;
        //            RaisePropertyChanged("NazivFilijala");
        //        }

        //    }
        //}



        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
