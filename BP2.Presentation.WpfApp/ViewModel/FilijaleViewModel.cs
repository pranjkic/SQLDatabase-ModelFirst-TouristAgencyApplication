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
    public class FilijaleViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        FilijalaService filijalaService = new FilijalaService();
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

        //FILIJALE
        private BindingList<FilijalaDTO> all { get; set; }
        public BindingList<FilijalaDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }
        private FilijalaDTO selected;
        public FilijalaDTO Selected
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
        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }


        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public FilijaleViewModel()
        {
            Refresh();
            Visible = "Visible";
            AllTAs = turistickaAgencijaService.GetAll();
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
            Visible = "Hidden";
            SelectedTA = turistickaAgencijaService.FindById(Selected.IdTA);
            Name = Selected.Naziv;
            City = Selected.Grad;
            Address = Selected.Adresa;
            Email = Selected.Email;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            try
            {
                if (Selected == null)
                {
                    MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                filijalaService.Remove(Selected.Id, Selected.IdTA);
                Refresh();
                Clear();
                Visible = "Visible";
            }
            catch(Exception e)
            {
                MessageBox.Show("Filijala u kojoj su zaposleni radnici ne moze biti obrisana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    FilijalaDTO filijalaDTO = new FilijalaDTO() { Naziv = Name, Grad = City, Adresa = Address, Email = Email };
                    filijalaService.Create(filijalaDTO, SelectedTA);
                    Refresh();
                    Clear();                    
                }
            }
            else
            {
                if (CheckValidity())
                {
                    FilijalaDTO FilijalaDTO = new FilijalaDTO()
                    {
                        Id = Selected.Id,
                        IdTA = Selected.IdTA,
                        Naziv = Name,
                        Grad = City,
                        Adresa = Address,
                        Email = Email                        
                    };
                    filijalaService.Update(FilijalaDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                    Visible = "Visible";
                }
            }
        }
        public bool CheckValidity()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(Address) || string.IsNullOrWhiteSpace(Email) || SelectedTA == null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            Name = "";
            City = "";
            Address = "";
            Email = "";
            SelectedTA = null;
        }

        public void Refresh()
        {
            All = filijalaService.GetAll();
        }
    }
}
