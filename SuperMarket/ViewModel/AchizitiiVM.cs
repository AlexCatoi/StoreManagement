using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModel
{
    public  class AchizitiiVM
    {
        private AchizitiiLogic logic;

        string name {  get; set; }
        public ICommand addIt {  get; set; }
      

        public AchizitiiVM(string name)
        {
            logic = new AchizitiiLogic();
            achizitiiList = logic.GetAll();
            addIt = new RelayCommand(OpenWindow);
            this.name = name;
        }

        public ObservableCollection<ProdusePeBon> achizitiiList
        {
            get => logic.List;
            set => logic.List = value;
        }


        private ProdusePeBon selected;
        public ProdusePeBon Selected
        {
            get { return selected; }
            set
            {
                selected = value;
            }
        }
        public void AddAch(object obj)
        {
            logic.AddAchizitie(obj);
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddAch);
                }
                return addCommand;
            }
        }

        public void AddABon(object obj)
        {
            logic.AddABon(name);
        }

        private ICommand addBonComm;
        public ICommand AddBonComm
        {
            get
            {
                if (addBonComm == null)
                {
                    addBonComm = new RelayCommand(AddABon);
                }
                return addBonComm;
            }
        }

        public void OpenWindow(Object obj)
        {
            AddAchizitieView a = new AddAchizitieView();
            a.DataContext = this;
            a.ShowDialog();
        }
    }
}
