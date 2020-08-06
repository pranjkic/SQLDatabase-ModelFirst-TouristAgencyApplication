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
    public class TuristickeAgencijeViewModel : BindableBase
    {
        TuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        bool isChange = false;

        private BindingList<TuristickaAgencijaDTO> all { get; set; }
        public BindingList<TuristickaAgencijaDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }

        private TuristickaAgencijaDTO selected;
        public TuristickaAgencijaDTO Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
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


        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public TuristickeAgencijeViewModel()
        {
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
            Name = Selected.Naziv;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte klijenta.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(turistickaAgencijaService.Remove(Selected.Id))
            {
                Refresh();
            }
            else
            {
                MessageBox.Show("Turisticka agencija koja poseduje filijalu ne moze biti obrisana.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void OnConfirmComandComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    turistickaAgencijaService.Create(Name);
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity())
                {
                    TuristickaAgencijaDTO turistickaAgencijaDTO = new TuristickaAgencijaDTO()
                    {
                        Id = Selected.Id,
                        Naziv = Name,
                    };
                    turistickaAgencijaService.Update(turistickaAgencijaDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                }
            }
        }
        public bool CheckValidity()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            Name = "";
        }

        public void Refresh()
        {
            All = turistickaAgencijaService.GetAll();
        }
    }
}
