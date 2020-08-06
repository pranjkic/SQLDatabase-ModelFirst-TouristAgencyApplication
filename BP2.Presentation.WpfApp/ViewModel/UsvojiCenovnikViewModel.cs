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
    public class UsvojiCenovnikViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        CenovnikService cenovnikService = new CenovnikService();
        UsvojiCenovnikService usvojiCenovnikService = new UsvojiCenovnikService();
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
                OnPropertyChanged("SelectedTA");
            }
        }

        //CENOVNICI
        private BindingList<CenovnikDTO> allCenovnici { get; set; }
        public BindingList<CenovnikDTO> AllCenovnici
        {
            get { return allCenovnici; }
            set
            {
                allCenovnici = value;
                OnPropertyChanged("AllCenovnici");
            }
        }
        private CenovnikDTO selectedCenovnik;
        public CenovnikDTO SelectedCenovnik
        {
            get { return selectedCenovnik; }
            set
            {
                selectedCenovnik = value;
                OnPropertyChanged("SelectedCenovnik");
            }
        }
        
        //USVOJENI CENOVNICI
        private BindingList<UsvojiCenovnikDTO> all { get; set; }
        public BindingList<UsvojiCenovnikDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }
        private UsvojiCenovnikDTO selected;
        public UsvojiCenovnikDTO Selected
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

        private string koef;
        public string Koef
        {
            get { return koef; }
            set
            {
                koef = value;
                OnPropertyChanged("Koef");
            }
        }


        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public UsvojiCenovnikViewModel()
        {
            Refresh();
            Visible = "Visible";
            AllTAs = turistickaAgencijaService.GetAll();
            AllCenovnici = cenovnikService.GetAll();
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
            Koef = Selected.KoeficijentNaplate.ToString();
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte objekat.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            usvojiCenovnikService.Remove(Selected.IdTA, Selected.IdCenovnik);
            Refresh();
            Clear();
            Visible = "Visible";
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    UsvojiCenovnikDTO usvojiCenovnikDTO = new UsvojiCenovnikDTO() { KoeficijentNaplate = double.Parse(Koef), IdTA = SelectedTA.Id, IdCenovnik = SelectedCenovnik.Id };
                    if(usvojiCenovnikService.Create(usvojiCenovnikDTO))
                    {
                        Refresh();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Odabrani cenovnik je vec usvojen.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                if (CheckValidity())
                {
                    UsvojiCenovnikDTO usvojiCenovnikDTO = new UsvojiCenovnikDTO()
                    {
                        IdTA = Selected.IdTA,
                        IdCenovnik = Selected.IdCenovnik,
                        KoeficijentNaplate = double.Parse(Koef)
                    };
                    usvojiCenovnikService.Update(usvojiCenovnikDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                    Visible = "Visible";
                }
            }
        }
        public bool CheckValidity()
        {
            if (Koef == null || SelectedTA == null || SelectedCenovnik == null)
            {                
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            try
            {
                double.Parse(Koef);
            }
            catch
            {
                MessageBox.Show("Koeficijent mora biti unet u ispravnom formatu.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            Koef = "";
        }

        public void Refresh()
        {
            All = usvojiCenovnikService.GetAll();
            foreach(UsvojiCenovnikDTO usvojiCenovnikDTO in All)
            {
                TuristickaAgencijaDTO turistickaAgencijaDTO = turistickaAgencijaService.FindById(usvojiCenovnikDTO.IdTA);
                CenovnikDTO cenovnikDTO = cenovnikService.FindById(usvojiCenovnikDTO.IdCenovnik);
                usvojiCenovnikDTO.StartDate = cenovnikDTO.StartDate;
                usvojiCenovnikDTO.EndDate = cenovnikDTO.EndDate;
                usvojiCenovnikDTO.NazivTA = turistickaAgencijaDTO.Naziv;
                usvojiCenovnikDTO.CenovnikDateRange = usvojiCenovnikDTO.StartDate.ToString().Split(' ')[0] + " - " + usvojiCenovnikDTO.EndDate.ToString().Split(' ')[0];
            }
        }
    }
}
