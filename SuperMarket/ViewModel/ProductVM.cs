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
    public class ProductVM
    {
        private ProductLogic logic;

        public ProductVM()
        {
            logic = new ProductLogic();
            productList = logic.GetAllProducts();
            logic.HasStock();
        }

        public ObservableCollection<Produs> productList
        {
            get => logic.ProductList;
            set => logic.ProductList = value;
        }

       
        private Produs _selectedProduct;
        public Produs SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
            }
        }
        public void AddProduct(object obj)
        {
            logic.AddProduct(SelectedProduct);
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddProduct);
                }
                return addCommand;
            }
        }
        public void UpdateProduct(object obj)
        {
          logic.UpdateProduct(SelectedProduct);
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(UpdateProduct);
                }
                return updateCommand;
            }
        }

        public void DeleteProd(object obj)
        {
            logic.DeleteProduct(SelectedProduct);
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
