using SuperMarket.Helper;
using SuperMarket.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SuperMarket.Models;

namespace SuperMarket.ViewModel
{
    public class ProducatorVM
    {
        private ProducatorLogic logic;
        private ProductLogic logicProduct;
        public ProducatorVM()
        {
            logic = new ProducatorLogic();
            prodList = logic.GetAllProducers();
            logicProduct= new ProductLogic();
            productList=logicProduct.GetAllProducts();
        }

        public ObservableCollection<Producator> prodList
        {
            get => logic.ProdList;
            set => logic.ProdList = value;
        }
        public ObservableCollection<Produs> productList
        {
            get => logicProduct.ProductList;
            set => logicProduct.ProductList = value;
        }

        private Producator _selectedProd;
        public Producator SelectedProd
        {
            get { return _selectedProd; }
            set
            {
                _selectedProd = value;
            }
        }

        public void AddProd(object obj)
        {
            logic.AddProd(SelectedProd);
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddProd);
                }
                return addCommand;
            }
        }

        public void UpdateProd(object obj)
        {
            logic.UpdateProducer(SelectedProd);
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(UpdateProd);
                }
                return updateCommand;
            }
        }

        public void DeleteProd(object obj)
        {
            logic.DeleteProducer(SelectedProd, productList);
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteProd);
                }
                return deleteCommand;
            }
        }
    }
}
