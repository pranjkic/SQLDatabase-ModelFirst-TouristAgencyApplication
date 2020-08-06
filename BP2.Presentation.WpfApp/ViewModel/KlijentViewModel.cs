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
    public class KlijentViewModel : BindableBase
    {
        KlijentService klijentService = new KlijentService();
        FilijalaService filijalaService = new FilijalaService();
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        bool isChange = false;

        private BindingList<KlijentDTO> all { get; set; }
        public BindingList<KlijentDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }

        private KlijentDTO selected;
        public KlijentDTO Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        //FILIJALE
        private BindingList<FilijalaDTO> allFilijale { get; set; }
        public BindingList<FilijalaDTO> AllFilijale
        {
            get { return allFilijale; }
            set
            {
                allFilijale = value;
                OnPropertyChanged("AllFilijale");
            }
        }
        private FilijalaDTO selectedFilijala;
        public FilijalaDTO SelectedFilijala
        {
            get { return selectedFilijala; }
            set
            {
                selectedFilijala = value;
                OnPropertyChanged("SelectedFilijala");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string passport;
        public string Passport
        {
            get { return passport; }
            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }
        

        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public KlijentViewModel()
        {
            AllFilijale = filijalaService.GetAll();
            foreach(FilijalaDTO filijalaDTO in AllFilijale)            
                filijalaDTO.NazivTA = turistickaAgencijaService.FindById(filijalaDTO.IdTA).Naziv;            
            Refresh();
            UpdateComand = new MyICommand(OnUpdateComandExecute);
            RemoveComand = new MyICommand(OnRemoveComandExecute);
            ConfirmComand = new MyICommand(OnConfirmComandComandExecute);
        }

        public void OnUpdateComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            isChange = true;
            Name = Selected.Ime;
            LastName = Selected.Prezime;
            Passport = Selected.BrojPasosa;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!klijentService.Remove(Selected.Id))
            {
                MessageBox.Show("Klijent koji posluje sa filijalom ne moze se obrisati.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Refresh();
        }      

        public void OnConfirmComandComandExecute(object parameter)
        {
            if(!isChange)
            {
                if(CheckValidity())
                {
                    klijentService.Create(Name, LastName, Passport);
                    Refresh();
                    Clear();
                }                
            }
            else
            {
                if (CheckValidity())
                {
                    KlijentDTO klijentDTO = new KlijentDTO()
                    {
                        Id = Selected.Id,
                        Ime = Name,
                        Prezime = LastName,
                        BrojPasosa = Passport
                    };
                    klijentService.Update(klijentDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                }
            }
        }
        public bool CheckValidity()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Passport))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            Name = "";
            LastName = "";
            Passport = "";
        }

        public void Refresh()
        {
            All = klijentService.GetAll();
        }
    }
}
