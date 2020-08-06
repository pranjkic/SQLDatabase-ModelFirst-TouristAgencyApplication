using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Core.Model
{
    public class UsvojenoPutovanje
    {
        private int taId;
        private int destinationId;
        private int guideId;
        private string ta;
        private string destination;
        private string guide;
        private DateTime startDate;
        private int duration;
        private double price;
        private string accomodation;

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
        public int DestinationId
        {
            get => destinationId;
            set
            {
                if (destinationId != value)
                {
                    destinationId = value;
                    RaisePropertyChanged("DestinationId");
                }

            }
        }
        public int GuideId
        {
            get => guideId;
            set
            {
                if (guideId != value)
                {
                    guideId = value;
                    RaisePropertyChanged("GuideId");
                }

            }
        }
        public string TA
        {
            get => ta;
            set
            {
                if (ta != value)
                {
                    ta = value;
                    RaisePropertyChanged("TA");
                }

            }
        }
        public string Destination
        {
            get => destination;
            set
            {
                if (destination != value)
                {
                    destination = value;
                    RaisePropertyChanged("Destination");
                }
            }
        }
        public string Guide
        {
            get => guide;
            set
            {
                if (guide != value)
                {
                    guide = value;
                    RaisePropertyChanged("Guide");
                }
            }
        }
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
        public int Duration
        {
            get => duration;
            set
            {
                if (duration != value)
                {
                    duration = value;
                    RaisePropertyChanged("Duration");
                }

            }
        }
        public double Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged("Price");
                }

            }
        }
        public string Accomodation
        {
            get => accomodation;
            set
            {
                if (accomodation != value)
                {
                    accomodation = value;
                    RaisePropertyChanged("Accomodation");
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
