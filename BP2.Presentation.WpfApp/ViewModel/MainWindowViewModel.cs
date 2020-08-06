using BP2.Presentation.ViewModel.WPFAssets;
using BP2.Presentation.WpfApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP2.Presentation.WpfApp.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {


        public MyICommand TestCommand { get; set; }
        public MyICommand PutovanjaComand { get; set; }
        public MyICommand KlijentiComand { get; set; }
        public MyICommand TuristickeAgencijeComand { get; set; }
        public MyICommand FilijaleComand { get; set; }
        public MyICommand CenovniciComand { get; set; }
        public MyICommand UsvojiCenovnikComand { get; set; }
        public MyICommand ZaposliRadnikaComand { get; set; }
        public MyICommand UsvojiPutovanjeComand { get; set; }
        public MyICommand KlijentFilijalaComand { get; set; }
        public MyICommand UgovorComand { get; set; }
        



        public MainWindowViewModel()
        {
            //Tas = new BindingList<Proba>();
            PutovanjaComand = new MyICommand(OnPutovanjaCommandExecute);
            KlijentiComand = new MyICommand(OnKlijentiCommandExecute);
            TuristickeAgencijeComand = new MyICommand(OnTuristickeAgencijeCommandExecute);
            FilijaleComand = new MyICommand(OnFilijaleCommandExecute);
            CenovniciComand = new MyICommand(OnCenovniciComandExecute);
            UsvojiCenovnikComand = new MyICommand(OnUsvojiCenovnikComandExecute);
            ZaposliRadnikaComand = new MyICommand(OnZaposliRadnikaComandExecute);
            UsvojiPutovanjeComand = new MyICommand(OnUsvojiPutovanjeComandExecute);
            KlijentFilijalaComand = new MyICommand(KlijentFilijalaComandExecute);
            UgovorComand = new MyICommand(UgovorComandExecute);
        }
        public void OnTuristickeAgencijeCommandExecute(object parameter)
        {
            TuristickeAgencijeView turistickeAgencijeView = new TuristickeAgencijeView();
            turistickeAgencijeView.ShowDialog();
        }
        public void OnPutovanjaCommandExecute(object parameter)
        {
            PutovanjaView putovanjaView = new PutovanjaView();
            putovanjaView.ShowDialog();
        }
        public void OnKlijentiCommandExecute(object parameter)
        {
            KlijentView klijentView = new KlijentView();
            klijentView.ShowDialog();
        }
        public void OnFilijaleCommandExecute(object parameter)
        {
            FilijaleView filijaleView = new FilijaleView();
            filijaleView.ShowDialog();
        }
        public void OnCenovniciComandExecute(object parameter)
        {
            CenovnikView cenovnikView = new CenovnikView();
            cenovnikView.ShowDialog();
        }
        public void OnUsvojiCenovnikComandExecute(object parameter)
        {
            UsvojiCenovnikView usvojiCenovnikView = new UsvojiCenovnikView();
            usvojiCenovnikView.ShowDialog();
        }
        public void OnZaposliRadnikaComandExecute(object parameter)
        {
            RadniciView radniciView = new RadniciView();
            radniciView.ShowDialog();
        }
        public void OnUsvojiPutovanjeComandExecute(object parameter)
        {
            UsvojiPutovanjaView usvojiPutovanjaView = new UsvojiPutovanjaView();
            usvojiPutovanjaView.ShowDialog();
        }
        public void KlijentFilijalaComandExecute(object parameter)
        {
            KlijentFilijalaView klijentFilijalaView = new KlijentFilijalaView();
            klijentFilijalaView.ShowDialog();
        }
        public void UgovorComandExecute(object parameter)
        {
            UgovorView ugovorView = new UgovorView();
            ugovorView.ShowDialog();
        }
    }
}

/*
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
*/

/*
        public void OnTestCommandExecute(object parameter)
        {
            
            //try
            //{
            //    tas = turistickaAgencijaService.GetAllTuristickeAgencije();
            //}
            //catch(Exception e)
            //{
            //    string s = e.Message;
            //}
            
            BindingList<Proba> lst = new BindingList<Proba>()
            {
                new Proba(){ Id = 1, Name = "N1" },
                new Proba(){ Id = 1, Name = "N2" },
                new Proba(){ Id = 1, Name = "N3" },
            };
            //Tas = lst;
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
        */
