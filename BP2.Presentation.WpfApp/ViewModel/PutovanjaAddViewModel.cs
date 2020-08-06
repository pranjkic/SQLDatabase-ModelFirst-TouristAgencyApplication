using BP2.Core.Model;
using BP2.Core.ServiceAdapter.Services;
using BP2.Presentation.ViewModel.WPFAssets;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BP2.Presentation.WpfApp.ViewModel
{
    public class PutovanjaAddViewModel : BindableBase
    {
        PutovanjeService putovanjeService = new PutovanjeService();

        Window window = null;
        bool isChange = false;

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

        public MyICommand ConfirmComand { get; set; }

        public PutovanjaAddViewModel(Window windowParam)
        {
            //if(PutovanjaViewModel.SelectedObject != null)
            {
                isChange = true;
                Destination = Destination;
            }
            
            window = windowParam;
            ConfirmComand = new MyICommand(OnConfirmComandComandExecute);
        }
        public void OnConfirmComandComandExecute(object parameter)
        {
            if(!isChange)
            {
                putovanjeService.Create(Destination);
                window.Close();
            }
            else
            {
                PutovanjeDTO putovanjeDTO = new PutovanjeDTO()
                {
                    Id = 0,
                    Destinacija = Destination
                };
                putovanjeService.Update(putovanjeDTO);
                window.Close();
            }            
        }
    }
}
