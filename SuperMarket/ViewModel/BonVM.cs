using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualBasic.Logging;
using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using SuperMarket.Views;

namespace SuperMarket.ViewModel
{
    public class BonVM
    {
        private BonLogic bl;
        public ICommand AddIt { get; set; }
        public ICommand DetailCommand { get; set; }
        string name { get; set; }
        public bool Role { get; set; }
        public BonVM(bool i, string name)
        {
            bl = new BonLogic();
            bonList = bl.GetAllBons();
            AddIt = new RelayCommand(OpenWindow);
            DetailCommand = new RelayCommand(OpenWindow);
            Role = i;
            this.name = name;
        }

        public ObservableCollection<Bonuri> bonList
        {
            get => bl.BonList;
            set => bl.BonList = value;
        }

        private Bonuri selectedBon;
        public Bonuri SelectedBon
        {
            get { return selectedBon; }
            set
            {
                selectedBon = value;
            }
        }

        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            Console.WriteLine(nr);
            switch (nr)
            {
                case "1":
                    AchizitiiView a = new AchizitiiView(name);
                    a.ShowDialog();
                    break;
                default:
                    BonDetails b = new BonDetails();
                    b.DataContext = this;
                    b.ShowDialog();
                    break;
            }
        }

        
    }
}
