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
    public class CenovnikViewModel : BindableBase
    {
        CenovnikService cenovnikService = new CenovnikService();
        bool isChange = false;

        private BindingList<CenovnikDTO> all { get; set; }
        public BindingList<CenovnikDTO> All
        {
            get { return all; }
            set
            {
                all = value;
                OnPropertyChanged("All");
            }
        }

        private CenovnikDTO selected;
        public CenovnikDTO Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }


        public MyICommand UpdateComand { get; set; }
        public MyICommand RemoveComand { get; set; }
        public MyICommand ConfirmComand { get; set; }


        public CenovnikViewModel()
        {
            Refresh();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            UpdateComand = new MyICommand(OnUpdateComandExecute);
            RemoveComand = new MyICommand(OnRemoveComandExecute);
            ConfirmComand = new MyICommand(OnConfirmComandComandExecute);
        }

        public void OnUpdateComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte datum.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            isChange = true;
            StartDate = Selected.StartDate;
            EndDate = Selected.EndDate;
        }
        public void OnRemoveComandExecute(object parameter)
        {
            if (Selected == null)
            {
                MessageBox.Show("Selektujte datum.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!cenovnikService.Remove(Selected.Id))
            {
                MessageBox.Show("Cenovnik u upotrebi ne moze biti obrisan.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    CenovnikDTO cenovnikDTO = new CenovnikDTO() { StartDate = StartDate, EndDate = EndDate };
                    cenovnikService.Create(cenovnikDTO);
                    Refresh();
                    Clear();
                }
            }
            else
            {
                if (CheckValidity())
                {
                    CenovnikDTO cenovnikDTO = new CenovnikDTO()
                    {
                        Id = Selected.Id,
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    cenovnikService.Update(cenovnikDTO);
                    Refresh();
                    Clear();
                    isChange = false;
                }
            }
        }
        public bool CheckValidity()
        {
            if (DateTime.Compare(StartDate, EndDate) >= 0)
            {
                MessageBox.Show("Pocetni datum mora biti pre krajnjeg.", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        public void Clear()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }

        public void Refresh()
        {
            All = cenovnikService.GetAll();
        }
    }
}
