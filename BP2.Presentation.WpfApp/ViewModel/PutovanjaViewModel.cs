using BP2.Core.Model;
using BP2.Core.ServiceAdapter.Services;
using BP2.Presentation.ViewModel.WPFAssets;
using BP2.Presentation.WpfApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BP2.Presentation.WpfApp.ViewModel
{
    public class PutovanjaViewModel : BindableBase
    {
        PutovanjeService putovanjeService = new PutovanjeService();
        bool isChange = false;

        private BindingList<PutovanjeDTO> all { get; set; }
        public BindingList<PutovanjeDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }

        private PutovanjeDTO selected;
        public PutovanjeDTO Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        private string destination;
        public string Destination
        {
            get { return destination; }
            set
            {
                destination = value;
                OnPropertyChanged("Destination");
            }
        }

        public MyICommand CreateComand { get; set; }
        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }

        public PutovanjaViewModel()
        {
            Refresh();
            CreateComand = new MyICommand(OnCreateComandExecute);
            UpdateComand = new MyICommand(OnUpdateComandExecute);
            RemoveComand = new MyICommand(OnRemoveComandExecute);
        }
        public void OnCreateComandExecute(object parameter)
        {
            if (!isChange)
            {
                if (CheckValidity())
                {
                    putovanjeService.Create(Destination);
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity())
                {
                    PutovanjeDTO putovanjeDTO = new PutovanjeDTO()
                    {
                        Id = Selected.Id,
                        Destinacija = Destination
                    };
                    putovanjeService.Update(putovanjeDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                }
            }
        }
        public void OnUpdateComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte putovanje.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            isChange = true;
            Destination = Selected.Destinacija;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if(Selected == null)
            {
                MessageBox.Show("Selektujte putovanje.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!putovanjeService.Remove(Selected.Id))
            {
                MessageBox.Show("Putovanje je u ponudi turisticke agencije, ne moze biti obrisano.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Refresh();
            }            
        }

        public void Refresh()
        {
            All = putovanjeService.GetAll();
        }

        public void Clear()
        {
            Destination = "";
        }

        public bool CheckValidity()
        {
            if (string.IsNullOrWhiteSpace(Destination))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
    }
}
