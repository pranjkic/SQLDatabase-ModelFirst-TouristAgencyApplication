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
    public class UgovorViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        RadnikService radnikService = new RadnikService();
        KlijentFilijalaService klijentFilijalaService = new KlijentFilijalaService();
        UsvojiPutovanjeService usvojiPutovanjeService = new UsvojiPutovanjeService();
        PutovanjeService putovanjeService = new PutovanjeService();
        KlijentService klijentService = new KlijentService();
        UgovorService ugovorService = new UgovorService();
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

        //KLIJENTI
        private BindingList<KlijentFilijalaDTO> allKlijenti { get; set; }
        public BindingList<KlijentFilijalaDTO> AllKlijenti
        {
            get { return allKlijenti; }
            set
            {
                allKlijenti = value;
                OnPropertyChanged("AllKlijenti");
            }
        }
        private KlijentFilijalaDTO selectedKlijent;
        public KlijentFilijalaDTO SelectedKlijent
        {
            get { return selectedKlijent; }
            set
            {
                selectedKlijent = value;
                OnPropertyChanged("SelectedKlijent");
            }
        }

        //SEKRETARICE
        private BindingList<RadnikDTO> allSekretarice { get; set; }
        public BindingList<RadnikDTO> AllSekretarice
        {
            get { return allSekretarice; }
            set
            {
                allSekretarice = value;
                OnPropertyChanged("AllSekretarice");
            }
        }
        private RadnikDTO selectedSekretarica;
        public RadnikDTO SelectedSekretarica
        {
            get { return selectedSekretarica; }
            set
            {
                selectedSekretarica = value;
                OnPropertyChanged("SelectedSekretarica");
            }
        }

        //PUTOVANJA
        private BindingList<UsvojenoPutovanje> allPutovanja { get; set; }
        public BindingList<UsvojenoPutovanje> AllPutovanja
        {
            get { return allPutovanja; }
            set
            {
                allPutovanja = value;
                OnPropertyChanged("AllPutovanja");
            }
        }
        private UsvojenoPutovanje selectedPutovanje;
        public UsvojenoPutovanje SelectedPutovanje
        {
            get { return selectedPutovanje; }
            set
            {
                selectedPutovanje = value;
                OnPropertyChanged("SelectedPutovanje");
            }
        }

        //UGOVORI
        private BindingList<UgovorDTO> all { get; set; }
        public BindingList<UgovorDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }
        private UgovorDTO selected;
        public UgovorDTO Selected
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

        private string taVisibility;
        public string TaVisibility
        {
            get { return taVisibility; }
            set
            {
                taVisibility = value;
                OnPropertyChanged("TaVisibility");
            }
        }

        private string sifraOsiguranja;
        public string SifraOsiguranja
        {
            get { return sifraOsiguranja; }
            set
            {
                sifraOsiguranja = value;
                OnPropertyChanged("SifraOsiguranja");
            }
        }

        public MyICommand ChooseTAComand { get; set; }
        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public UgovorViewModel()
        {
            Refresh();
            Visible = "Hidden";
            TaVisibility = "Visible";
            AllTAs = turistickaAgencijaService.GetAll();
            UpdateComand = new MyICommand(OnUpdateComandExecute);
            RemoveComand = new MyICommand(OnRemoveComandExecute);
            ConfirmComand = new MyICommand(OnConfirmComandComandExecute);
            ChooseTAComand = new MyICommand(OnChooseTAComandComandExecute);
        }

        public void OnUpdateComandExecute(object parameter)
        {
            //if (Selected == null)
            //{
            //    MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}
            //isChange = true;
            //Visible = "Hidden";
            //SelectedTA = turistickaAgencijaService.FindById(Selected.IdTA);
            //Name = Selected.Naziv;
            //City = Selected.Grad;
            //Address = Selected.Adresa;
            //Email = Selected.Email;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ugovorService.Remove(Selected.Id);
            Refresh();
            Clear();
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    UgovorDTO ugovorDTO = new UgovorDTO()
                    {
                        PutovanjeId = SelectedPutovanje.DestinationId,
                        PutovanjeTAId = SelectedPutovanje.TaId,
                        PutovanjeVodicId = SelectedPutovanje.GuideId,

                        KlijentId = SelectedKlijent.KlijentId,
                        KlijentFilijalaId = SelectedKlijent.IdFilijala,
                        KlijentTAId = SelectedKlijent.IdTA,

                        SekretaricaId = SelectedSekretarica.Id,
                        SifraOsiguranja = Guid.NewGuid().ToString()
                    };
                    ugovorService.Create(ugovorDTO);
                    Refresh();
                    Clear();
                    Visible = "Hidden"; 
                    TaVisibility = "Visible";
                }
            }
            isChange = false;
            //else
            //{
            //if (CheckValidity())
            //{
            //    FilijalaDTO FilijalaDTO = new FilijalaDTO()
            //    {
            //        Id = Selected.Id,
            //        IdTA = Selected.IdTA,
            //        Naziv = Name,
            //        Grad = City,
            //        Adresa = Address,
            //        Email = Email
            //    };
            //    filijalaService.Update(FilijalaDTO);
            //    Refresh();
            //    Clear();
            //    isChange = false;
            //    Visible = "Visible";
            //}
            //}
        }

        public void OnChooseTAComandComandExecute(object parameter)
        {
            AllSekretarice = radnikService.GetAllSekretarice(SelectedTA.Id);
            AllKlijenti = klijentFilijalaService.GetAllById(SelectedTA.Id);
            foreach (KlijentFilijalaDTO klijentFilijalaDTO in AllKlijenti)
            {
                KlijentDTO klijentDTO = klijentService.FindById(klijentFilijalaDTO.KlijentId);
                klijentFilijalaDTO.KlijentIme = klijentDTO.Ime + " " + klijentDTO.Prezime;
            }
            AllPutovanja = usvojiPutovanjeService.GetAllById(SelectedTA.Id);
            foreach (UsvojenoPutovanje usvojenoPutovanje in AllPutovanja)
            {
                PutovanjeDTO putovanjeDTO = putovanjeService.FindById(usvojenoPutovanje.DestinationId);
                usvojenoPutovanje.Destination = putovanjeDTO.Destinacija;
            }
            Visible = "Visible"; 
            TaVisibility = "Hidden";
        }

        public bool CheckValidity()
        {
            if (SelectedKlijent == null || SelectedPutovanje == null || SelectedSekretarica == null)
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
            All = ugovorService.GetAll();
            foreach(UgovorDTO ugovorDTO in All)
            {
                PutovanjeDTO putovanjeDTO = putovanjeService.FindById(ugovorDTO.PutovanjeId);
                KlijentDTO klijentDTO = klijentService.FindById(ugovorDTO.KlijentId);
                TuristickaAgencijaDTO turistickaAgencijaDTO = turistickaAgencijaService.FindById(ugovorDTO.PutovanjeTAId);

                ugovorDTO.Klijent = klijentDTO.Ime + " " + klijentDTO.Prezime;
                ugovorDTO.Destinacija = putovanjeDTO.Destinacija;
                ugovorDTO.NazivTA = turistickaAgencijaDTO.Naziv;
                ugovorDTO.SifraOsiguranja = ugovorDTO.SifraOsiguranja;
            }
        }
    }
}
