using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class UsvojiCenovnikDTO
    {
        //private int id;
        private DateTime startDate;
        private DateTime endDate;
        private int idTA;
        private int idCenovnik;
        private double koeficijentNaplate;
        private string nazivTA;
        private string cenovnikDateRange;

        //public int Id
        //{
        //    get => id;
        //    set
        //    {
        //        if (id != value)
        //        {
        //            id = value;
        //            RaisePropertyChanged("Id");
        //        }

        //    }
        //}
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                if (startDate != value)
                {
                    startDate = value;
                    RaisePropertyChanged("StartDate");
                }
            }
        }

        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    RaisePropertyChanged("EndDate");
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
        public int IdCenovnik
        {
            get => idCenovnik;
            set
            {
                if (idCenovnik != value)
                {
                    idCenovnik = value;
                    RaisePropertyChanged("IdCenovnik");
                }

            }
        }
        public double KoeficijentNaplate
        {
            get => koeficijentNaplate;
            set
            {
                if (koeficijentNaplate != value)
                {
                    koeficijentNaplate = value;
                    RaisePropertyChanged("KoeficijentNaplate");
                }
            }
        }
        public string CenovnikDateRange
        {
            get => cenovnikDateRange;
            set
            {
                if (cenovnikDateRange != value)
                {
                    cenovnikDateRange = value;
                    RaisePropertyChanged("CenovnikDateRange");
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
