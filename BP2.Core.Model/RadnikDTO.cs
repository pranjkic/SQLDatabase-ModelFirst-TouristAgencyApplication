using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class RadnikDTO
    {
        private int id;
        private string ime;
        private string prezime;
        private string jmbg;
        private int idFilijala;
        private int idTA;
        private string nazivTA;
        private string nazivFilijala;
        private string tipRadnika;
        private int num;

        private string destinacije;
        private int brojPutovanja;
        public string Destinacije
        {
            get => destinacije;
            set
            {
                if (destinacije != value)
                {
                    destinacije = value;
                    RaisePropertyChanged("Destinacije");
                }

            }
        }
        public int BrojPutovanja
        {
            get => brojPutovanja;
            set
            {
                if (brojPutovanja != value)
                {
                    brojPutovanja = value;
                    RaisePropertyChanged("BrojPutovanja");
                }

            }
        }
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
        public string Jmbg
        {
            get => jmbg;
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    RaisePropertyChanged("Jmbg");
                }

            }
        }
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
        public int IdTA
        {
            get => idTA;
            set
            {
                if (idTA != value)
                {
                    idTA = value;
                    RaisePropertyChanged("IdTA");
                }

            }
        }
        public string NazivTA
        {
            get => nazivTA;
            set
            {
                if (nazivTA != value)
                {
                    nazivTA = value;
                    RaisePropertyChanged("NazivTA");
                }

            }
        }
        public string NazivFilijala
        {
            get => nazivFilijala;
            set
            {
                if (nazivFilijala != value)
                {
                    nazivFilijala = value;
                    RaisePropertyChanged("NazivFilijala");
                }

            }
        }
        public int Num
        {
            get => num;
            set
            {
                if (num != value)
                {
                    num = value;
                    RaisePropertyChanged("Num");
                }

            }
        }
        public string TipRadnika
        {
            get => tipRadnika;
            set
            {
                if (tipRadnika != value)
                {
                    tipRadnika = value;
                    RaisePropertyChanged("TipRadnika");
                }

            }
        }

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
