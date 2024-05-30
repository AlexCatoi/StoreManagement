using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModel
{
    public class StocVM
    {
        private StocLogic logic;
        public StocVM()
        {
            logic = new StocLogic();
            logic.CheckExpiryDate();
            stocList = logic.GetAllStocs();

        }

        public ObservableCollection<Stocuri> stocList
        {
            get => logic.StocList;
            set => logic.StocList = value;
        }


        private Stocuri _selectedStoc;
        public Stocuri SelectedStoc
        {
            get { return _selectedStoc; }
            set
            {
                _selectedStoc = value;
            }
        }

        public void AddStoc(object obj)
        {
            logic.AddStoc(SelectedStoc);
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddStoc);
                }
                return addCommand;
            }
        }
    }
}
