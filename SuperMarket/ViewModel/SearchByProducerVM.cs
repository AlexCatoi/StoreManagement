using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperMarket.ViewModel
{
    public class SearchByProducerVM:BasePropertyChanged
    {
        private ProductLogic logic;
        private ProducatorLogic logicpers;
        public SearchByProducerVM()
        {
            logic = new ProductLogic();
            logicpers= new ProducatorLogic();
            productList = logic.GetAllProducts();
            producerList=logicpers.GetAllProducers();
        }

        public ObservableCollection<Produs> productList
        {
            get => logic.ProductList;
            set
            {
                logic.ProductList = value;
                NotifyPropertyChanged(nameof(productList));
            }
        }
        public ObservableCollection<Producator> producerList
        {
            get => logicpers.ProdList;
            set
            {
                logicpers.ProdList = value;
                NotifyPropertyChanged(nameof(producerList));
            }
        }
        private Producator selectedProducer;
        public Producator SelectedProducer
        {
            get { return selectedProducer; }
            set
            {
                if(selectedProducer!=value)
                {
                    selectedProducer = value;
                    NotifyPropertyChanged(nameof(selectedProducer));
                    NotifyPropertyChanged(nameof(FilteredProductList));
                }
            }
        }

        public IEnumerable<Produs> FilteredProductList
        {
            get
            {
                if (SelectedProducer == null)
                    return productList;
                else
                    return productList.Where(p => p.Producator.NumeProducator == SelectedProducer.NumeProducator);
            }
        }
    }
}
