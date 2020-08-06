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
    class KlijentFilijalaViewModel : BindableBase
    {
        KlijentService klijentService = new KlijentService();
        FilijalaService filijalaService = new FilijalaService();
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        KlijentFilijalaService klijentFilijalaService = new KlijentFilijalaService();
        bool isChange = false;

        private BindingList<KlijentFilijalaDTO> all { get; set; }
        public BindingList<KlijentFilijalaDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }

        private KlijentFilijalaDTO selected;
        public KlijentFilijalaDTO Selected
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

        //PUTOVANJA
        private BindingList<KlijentDTO> allKlijenti { get; set; }
        public BindingList<KlijentDTO> AllKlijenti
        {
            get { return allKlijenti; }
            set
            {
                allKlijenti = value;
                OnPropertyChanged("AllKlijenti");
            }
        }
        private KlijentDTO selectedKlijent;
        public KlijentDTO SelectedKlijent
        {
            get { return selectedKlijent; }
            set
            {
                selectedKlijent = value;
                OnPropertyChanged("SelectedKlijent");
            }
        }

        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }

        public KlijentFilijalaViewModel()
        {
            AllKlijenti = klijentService.GetAll();
            AllFilijale = filijalaService.GetAll();
            foreach (FilijalaDTO filijalaDTO in AllFilijale)
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
            //Name = Selected.Ime;
            //LastName = Selected.Prezime;
            //Passport = Selected.BrojPasosa;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!klijentFilijalaService.Remove(Selected.KlijentId, Selected.IdFilijala, Selected.IdTA))
            {
                MessageBox.Show("Klijent ima ugovor, ne moze biti obrisan.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Refresh();
            }
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    KlijentFilijalaDTO klijentFilijalaDTO = new KlijentFilijalaDTO()
                    {
                        KlijentId = SelectedKlijent.Id,
                        IdFilijala = SelectedFilijala.Id,
                        IdTA = SelectedFilijala.IdTA
                    };
                    if (!klijentFilijalaService.Create(klijentFilijalaDTO))
                        MessageBox.Show("Klijent vec posluje sa filijalom.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);                    
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity())
                {
                    //KlijentFilijalaDTO klijentDTO = new KlijentFilijalaDTO()
                    //{
                    //    Id = Selected.Id,
                    //    Ime = Name,
                    //    Prezime = LastName,
                    //    BrojPasosa = Passport
                    //};
                    //klijentService.Update(klijentDTO);
                    //Refresh();
                    //Clear();
                    isChange = false;
                }
            }
        }
        public bool CheckValidity()
        {
            if (SelectedKlijent == null || SelectedFilijala == null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
        }

        public void Refresh()
        {
            All = klijentFilijalaService.GetAll();
            foreach(KlijentFilijalaDTO klijentFilijalaDTO in All)
            {
                FilijalaDTO filijalaDTO = filijalaService.FindById(klijentFilijalaDTO.IdFilijala, klijentFilijalaDTO.IdTA);
                TuristickaAgencijaDTO turistickaAgencijaDTO = turistickaAgencijaService.FindById(klijentFilijalaDTO.IdTA);
                KlijentDTO klijentDTO = klijentService.FindById(klijentFilijalaDTO.KlijentId);

                klijentFilijalaDTO.NazivTA = turistickaAgencijaDTO.Naziv;
                klijentFilijalaDTO.NazivFilijala = filijalaDTO.Naziv;
                klijentFilijalaDTO.KlijentIme = klijentDTO.Ime + " " + klijentDTO.Prezime;
            }
        }
    }
}
