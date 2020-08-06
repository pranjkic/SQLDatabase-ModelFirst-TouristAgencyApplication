using BP2.Core.Ports.ServiceInterfaces;
using BP2.Core.ServiceAdapter.Services;
using BP2.Presentation.ViewModel.WPFAssets;
using BP2.Repository.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Presentation.ViewModel.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {


        private BindingList<Proba> tas { get; set; }
        public BindingList<Proba> Tas
        {
            get { return tas; }
            set
            {
                tas = value;
                OnPropertyChanged("Tas");
            }
        }

        private Proba selected;
        public Proba Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }



        //private readonly ITuristickaAgencijaService turistickaAgencijaService = new TuristickaAgencijaService();
        //public IEnumerable<TuristickaAgencija> tas = new List<TuristickaAgencija>();
        public MyICommand TestCommand { get; set; }
        public MyICommand PutovanjaComand { get; set; }

        public MainWindowViewModel()
        {
            Tas = new BindingList<Proba>();
            TestCommand = new MyICommand(OnTestCommandExecute);
            PutovanjaComand = new MyICommand(OnPutovanjaCommandExecute);
        }
        public void OnPutovanjaCommandExecute(object parameter)
        {
            //PutovanjaView
        }




        public void OnTestCommandExecute(object parameter)
        {
            /*
            try
            {
                tas = turistickaAgencijaService.GetAllTuristickeAgencije();
            }
            catch(Exception e)
            {
                string s = e.Message;
            }
            */
            BindingList<Proba> lst = new BindingList<Proba>()
            {
                new Proba(){ Id = 1, Name = "N1" },
                new Proba(){ Id = 1, Name = "N2" },
                new Proba(){ Id = 1, Name = "N3" },
            };
            Tas = lst;
        }
        public class Proba
        {
            private string name;
            private int id;

            public int Id
            {
                get => id;
                set
                {
                    if (id != value)
                    {
                        id = value;
                        RaisePropertyChanged("Id");
                    }

                }
            }
            public string Name
            {
                get => name;
                set
                {
                    if (name != value)
                    {
                        name = value;
                        RaisePropertyChanged("Name");
                    }
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        };
    }
}
