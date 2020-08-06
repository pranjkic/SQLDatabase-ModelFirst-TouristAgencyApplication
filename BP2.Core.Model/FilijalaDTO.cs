using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class FilijalaDTO
    {
        private int id;
        private string naziv;
        private string grad;
        private string adresa;
        private string email;
        private string nazivTA;
        private int idTA;

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
        public string Naziv
        {
            get => naziv;
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    RaisePropertyChanged("Naziv");
                }
            }
        }
        public string Grad
        {
            get => grad;
            set
            {
                if (grad != value)
                {
                    grad = value;
                    RaisePropertyChanged("Grad");
                }
            }
        }
        public string Adresa
        {
            get => adresa;
            set
            {
                if (adresa != value)
                {
                    adresa = value;
                    RaisePropertyChanged("Adresa");
                }
            }
        }
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged("Email");
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
