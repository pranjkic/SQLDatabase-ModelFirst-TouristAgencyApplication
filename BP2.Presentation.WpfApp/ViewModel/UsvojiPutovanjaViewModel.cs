using BP2.Core.Model;
using BP2.Core.ServiceAdapter.Services;
using BP2.Presentation.ViewModel.WPFAssets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BP2.Presentation.WpfApp.ViewModel
{
    public class UsvojiPutovanjaViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        PutovanjeService putovanjeService = new PutovanjeService();
        RadnikService radnikService = new RadnikService();
        UsvojiPutovanjeService usvojiPutovanjeService = new UsvojiPutovanjeService();
        bool isChange = false;

        //TURISTICKE AGENCIJE
        private BindingList<TuristickaAgencijaDTO> allTAs { get; set; }
        public BindingList<TuristickaAgencijaDTO> AllTAs
        {
            get { return allTAs; }
            set
            {
                allTAs = value;
                OnPropertyChanged("AllTAs");
            }
        }
        private TuristickaAgencijaDTO selectedTA;
        public TuristickaAgencijaDTO SelectedTA
        {
            get { return selectedTA; }
            set
            {
                selectedTA = value;
                OnPropertyChanged("selectedTA");
            }
        }

        //PUTOVANJA
        private BindingList<PutovanjeDTO> allPutovanja { get; set; }
        public BindingList<PutovanjeDTO> AllPutovanja
        {
            get { return allPutovanja; }
            set
            {
                allPutovanja = value;
                OnPropertyChanged("AllPutovanja");
            }
        }
        private PutovanjeDTO selectedPutovanje;
        public PutovanjeDTO SelectedPutovanje
        {
            get { return selectedPutovanje; }
            set
            {
                selectedPutovanje = value;
                OnPropertyChanged("SelectedPutovanje");
            }
        }

        //VODICI
        private BindingList<RadnikDTO> allVodici { get; set; }
        public BindingList<RadnikDTO> AllVodici
        {
            get { return allVodici; }
            set
            {
                allVodici = value;
                OnPropertyChanged("AllVodici");
            }
        }
        private RadnikDTO selectedVodic;
        public RadnikDTO SelectedVodic
        {
            get { return selectedVodic; }
            set
            {
                selectedVodic = value;
                OnPropertyChanged("SelectedVodic");
            }
        }

        //USVOJENA PUTOVANJA
        private BindingList<UsvojenoPutovanje> all { get; set; }
        public BindingList<UsvojenoPutovanje> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }
        private UsvojenoPutovanje selected;
        public UsvojenoPutovanje Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        private string visible;
        public string Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        
        private int duration;
        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged("Duration");
            }
        }
        
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private string accommodation;
        public string Accommodation
        {
            get { return accommodation; }
            set
            {
                accommodation = value;
                OnPropertyChanged("Accommodation");
            }
        }

        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public UsvojiPutovanjaViewModel()
        {
            Refresh();
            Visible = "Visible";
            Date = DateTime.Now;
            AllTAs = turistickaAgencijaService.GetAll();
            AllPutovanja = putovanjeService.GetAll();
            //VRATITI SAMO VODICE TE TURISTICKE AGENCIJE
            AllVodici = radnikService.GetAllVodici();

            UpdateComand = new MyICommand(OnUpdateComandExecute);
            RemoveComand = new MyICommand(OnRemoveComandExecute);
            ConfirmComand = new MyICommand(OnConfirmComandComandExecute);
        }

        public void OnUpdateComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte objekat.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            isChange = true;
            Visible = "Hidden";
            Date = Selected.StartDate;
            Duration = Selected.Duration;
            Price = Selected.Price;
            Accommodation = Selected.Accomodation;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte radnika.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!usvojiPutovanjeService.Remove(Selected.TaId, Selected.DestinationId, Selected.GuideId))
            {
                MessageBox.Show("Putovanje je kupljeno, ne moze biti obrisano.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Refresh();
                Clear();
                Visible = "Visible";
            }
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    UsvojenoPutovanje usvojenoPutovanje = new UsvojenoPutovanje()
                    {
                        TaId = SelectedTA.Id,
                        DestinationId = SelectedPutovanje.Id,
                        GuideId = SelectedVodic.Id,
                        StartDate = Date,
                        Duration = Duration,
                        Price = Price,
                        Accomodation = Accommodation
                    };
                    usvojiPutovanjeService.Create(usvojenoPutovanje);
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity1())
                {
                    UsvojenoPutovanje usvojenoPutovanje = new UsvojenoPutovanje()
                    {
                        TaId = Selected.TaId,
                        DestinationId = Selected.DestinationId,
                        GuideId = Selected.GuideId,
                        StartDate = Date,
                        Duration = Duration,
                        Price = Price,
                        Accomodation = Accommodation
                    };
                    usvojiPutovanjeService.Update(usvojenoPutovanje);
                    Refresh();
                    Clear();
                    isChange = false;
                    Visible = "Visible";
                }
            }
        }
        public bool CheckValidity()
        {
            if (SelectedTA == null || SelectedPutovanje == null || SelectedVodic == null || Duration == 0 ||  Price == 0 || string.IsNullOrWhiteSpace(Accommodation))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        public bool CheckValidity1()
        {
            if (Duration == 0 || Price == 0 || string.IsNullOrWhiteSpace(Accommodation))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            Duration = 0;
            Price = 0;
            Accommodation = "";
        }

        public void Refresh()
        {
            All = usvojiPutovanjeService.GetAll();
            foreach (UsvojenoPutovanje usvojenoPutovanje in All)
            {
                TuristickaAgencijaDTO turistickaAgencijaDTO = turistickaAgencijaService.FindById(usvojenoPutovanje.TaId);
                PutovanjeDTO putovanjeDTO = putovanjeService.FindById(usvojenoPutovanje.DestinationId);
                RadnikDTO radnikDTO = radnikService.FindById(usvojenoPutovanje.GuideId);

                usvojenoPutovanje.TA = turistickaAgencijaDTO.Naziv;
                usvojenoPutovanje.Guide = radnikDTO.Ime + " " + radnikDTO.Prezime;
                usvojenoPutovanje.Destination = putovanjeDTO.Destinacija;
            }
        }
    }
}
