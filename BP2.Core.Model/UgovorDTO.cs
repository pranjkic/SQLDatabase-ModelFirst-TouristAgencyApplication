using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class UgovorDTO
    {
        private int id;
        private string sifraOsiguranja;

        private int putovanjeId;
        private int putovanjeTAId;
        private int putovanjeVodicId;

        private int klijentId;
        private int klijentFilijalaId;
        private int klijentTAId;

        private int sekretaricaId;

        private string klijent;
        private string destinacija;
        private string nazivTA;
        private DateTime datumPolaska;
        private double cena;
        private string sifraUgovora;

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
        
        public int PutovanjeId
        {
            get => putovanjeId;
            set
            {
                if (putovanjeId != value)
                {
                    putovanjeId = value;
                    RaisePropertyChanged("PutovanjeId");
                }

            }
        }
        public int PutovanjeTAId
        {
            get => putovanjeTAId;
            set
            {
                if (putovanjeTAId != value)
                {
                    putovanjeTAId = value;
                    RaisePropertyChanged("PutovanjeTAId");
                }

            }
        }
        public int PutovanjeVodicId
        {
            get => putovanjeVodicId;
            set
            {
                if (putovanjeVodicId != value)
                {
                    putovanjeVodicId = value;
                    RaisePropertyChanged("PutovanjeVodicId");
                }

            }
        }

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
        public int KlijentFilijalaId
        {
            get => klijentFilijalaId;
            set
            {
                if (klijentFilijalaId != value)
                {
                    klijentFilijalaId = value;
                    RaisePropertyChanged("KlijentFilijalaId");
                }

            }
        }
        public int KlijentTAId
        {
            get => klijentTAId;
            set
            {
                if (klijentTAId != value)
                {
                    klijentTAId = value;
                    RaisePropertyChanged("KlijentTAId");
                }

            }
        }

        public int SekretaricaId
        {
            get => sekretaricaId;
            set
            {
                if (sekretaricaId != value)
                {
                    sekretaricaId = value;
                    RaisePropertyChanged("SekretaricaId");
                }

            }
        }

        public string SifraOsiguranja
        {
            get => sifraOsiguranja;
            set
            {
                if (sifraOsiguranja != value)
                {
                    sifraOsiguranja = value;
                    RaisePropertyChanged("SifraOsiguranja");
                }

            }
        }

        public string Klijent
        {
            get => klijent;
            set
            {
                if (klijent != value)
                {
                    klijent = value;
                    RaisePropertyChanged("Klijent");
                }

            }
        }
        public string Destinacija
        {
            get => destinacija;
            set
            {
                if (destinacija != value)
                {
                    destinacija = value;
                    RaisePropertyChanged("Destinacija");
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

        public DateTime DatumPolaska
        {
            get => datumPolaska;
            set
            {
                if (datumPolaska != value)
                {
                    datumPolaska = value;
                    RaisePropertyChanged("DatumPolaska");
                }

            }
        }
        public double Cena
        {
            get => cena;
            set
            {
                if (cena != value)
                {
                    cena = value;
                    RaisePropertyChanged("Cena");
                }

            }
        }
        public string SifraUgovora
        {
            get => sifraUgovora;
            set
            {
                if (sifraUgovora != value)
                {
                    sifraUgovora = value;
                    RaisePropertyChanged("SifraUgovora");
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
