using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class KlijentFilijalaDTO
    {
        private int klijentId;
        private int idFilijala;
        private int idTA;
        private string klijentIme;
        private string nazivTA;
        private string nazivFilijala;

        public int KlijentId
        {
            get => klijentId;
            set
            {
                if (klijentId != value)
                {
                    klijentId = value;
                    RaisePropertyChanged("KlijentId");
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
        public string KlijentIme
        {
            get => klijentIme;
            set
            {
                if (klijentIme != value)
                {
                    klijentIme = value;
                    RaisePropertyChanged("KlijentIme");
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
