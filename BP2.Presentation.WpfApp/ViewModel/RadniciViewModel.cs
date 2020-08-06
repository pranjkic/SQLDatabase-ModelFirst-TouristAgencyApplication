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
    public class RadniciViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        FilijalaService filijalaService = new FilijalaService();
        RadnikService radnikService = new RadnikService();
        bool isChange = false;

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

        //USVOJENI CENOVNICI
        private BindingList<RadnikDTO> all { get; set; }
        public BindingList<RadnikDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }
        private RadnikDTO selected;
        public RadnikDTO Selected
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
        private string jmbg;
        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("Jmbg");
            }
        }

        private string isS;
        public string IsS
        {
            get { return isS; }
            set
            {
                isS = value;
                OnPropertyChanged("IsS");
            }
        }
        private string isV;
        public string IsV
        {
            get { return isV; }
            set
            {
                isV = value;
                OnPropertyChanged("IsV");
            }
        }
        private string isM;
        public string IsM
        {
            get { return isM; }
            set
            {
                isM = value;
                OnPropertyChanged("IsM");
            }
        }

        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public RadniciViewModel()
        {
            Refresh();
            Visible = "Visible";
            AllFilijale = filijalaService.GetAll();
            foreach (FilijalaDTO filijalaDTO in AllFilijale)
            {
                filijalaDTO.NazivTA = turistickaAgencijaService.FindById(filijalaDTO.IdTA).Naziv;
            }
            IsS = "True";
            IsM = "False";
            IsV = "False";
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
            Name = Selected.Ime;
            LastName = Selected.Prezime;
            Jmbg = Selected.Jmbg;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte radnika.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!radnikService.Remove(Selected.Id))
            {
                MessageBox.Show("Sekretarica ima izdati ugovor, ne moze biti obrisana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    string type = null;
                    if (isS == "True")
                        type = "Sekretarica";
                    else if (isM == "True")
                        type = "Menadzer";
                    else if (isV == "True")
                        type = "Vodic";

                    RadnikDTO radnikDTO = new RadnikDTO()
                    {
                        Ime = Name,
                        Prezime = LastName,
                        Jmbg = Jmbg,
                        IdFilijala = SelectedFilijala.Id,
                        IdTA = SelectedFilijala.IdTA,
                        TipRadnika = type
                    };
                    radnikService.Create(radnikDTO);
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity())
                {
                    RadnikDTO radnikDTO = new RadnikDTO()
                    {
                        Id = Selected.Id,
                        Ime = Name,
                        Prezime = LastName,
                        Jmbg = Jmbg,
                        IdFilijala = Selected.IdFilijala,
                        IdTA = Selected.IdTA,
                        TipRadnika = Selected.TipRadnika
                    };
                    radnikService.Update(radnikDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                    Visible = "Visible";
                }
            }
        }
        public bool CheckValidity()
        {
            if (SelectedFilijala == null || string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Jmbg))
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
            Jmbg = "";
        }

        public void Refresh()
        {
            All = radnikService.GetAll();
            foreach (RadnikDTO radnikDTO in All)
            {
                TuristickaAgencijaDTO turistickaAgencijaDTO = turistickaAgencijaService.FindById(radnikDTO.IdTA);
                FilijalaDTO filijalaDTO = filijalaService.FindById(radnikDTO.IdFilijala, radnikDTO.IdTA);
                radnikDTO.NazivTA = turistickaAgencijaDTO.Naziv;
                radnikDTO.NazivFilijala = filijalaDTO.Naziv;
            }
        }
    }
}
