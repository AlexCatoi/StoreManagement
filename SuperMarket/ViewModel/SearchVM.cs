using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SuperMarket.ViewModel
{
    public class SearchVM : BasePropertyChanged
    {
        private ProductLogic logic;
        private ProducatorLogic logicpers;

        public SearchVM()
        {
            logic = new ProductLogic();
            logicpers = new ProducatorLogic();
            productList = logic.GetAllProducts();
            producerList = new ObservableCollection<Producator> { new Producator { NumeProducator = "All" } };
            producerList.AddRange(logicpers.GetAllProducers());

            NameList = new ObservableCollection<string> { "All" };
            NameList.AddRange(productList.Select(p => p.NumeProdus).Distinct());

            CategorieList = new ObservableCollection<string> { "All" };
            CategorieList.AddRange(productList.Select(p => p.Categorie.Denumire).Distinct());

            CodList = new ObservableCollection<string> { "All" };
            CodList.AddRange(productList.Select(p => p.CodBare).Distinct());
        }

        public ObservableCollection<Produs> productList
        {
            get => logic.ProductList;
            set
            {
                logic.ProductList = value;
                NotifyPropertyChanged(nameof(productList));

                NameList = new ObservableCollection<string> { "All" };
                NameList.AddRange(productList.Select(p => p.NumeProdus).Distinct());

                CategorieList = new ObservableCollection<string> { "All" };
                CategorieList.AddRange(productList.Select(p => p.Categorie.Denumire).Distinct());

                CodList = new ObservableCollection<string> { "All" };
                CodList.AddRange(productList.Select(p => p.CodBare).Distinct());
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
                if (selectedProducer != value)
                {
                    selectedProducer = value;
                    NotifyPropertyChanged(nameof(SelectedProducer));
                    NotifyPropertyChanged(nameof(FilteredProductList));
                }
            }
        }

        public IEnumerable<Produs> FilteredProductList
        {
            get
            {
                var filteredProducts = productList.AsEnumerable();

                if (SelectedProducer != null && SelectedProducer.NumeProducator != "All")
                    filteredProducts = filteredProducts.Where(p => p.Producator.NumeProducator == SelectedProducer.NumeProducator);

                if (!string.IsNullOrEmpty(SelectedName) && SelectedName != "All")
                    filteredProducts = filteredProducts.Where(p => p.NumeProdus == SelectedName);

                if (!string.IsNullOrEmpty(SelectedCategorie) && SelectedCategorie != "All")
                    filteredProducts = filteredProducts.Where(p => p.Categorie.Denumire == SelectedCategorie);

                if (!string.IsNullOrEmpty(SelectedCod) && SelectedCod != "All")
                    filteredProducts = filteredProducts.Where(p => p.CodBare == SelectedCod);

                return filteredProducts;
            }
        }

        public ObservableCollection<string> NameList { get; set; }
        public ObservableCollection<string> CategorieList { get; set; }
        public ObservableCollection<string> CodList { get; set; }

        private string selectedName;
        public string SelectedName
        {
            get { return selectedName; }
            set
            {
                if (selectedName != value)
                {
                    selectedName = value;
                    NotifyPropertyChanged(nameof(SelectedName));
                    NotifyPropertyChanged(nameof(FilteredProductList));
                }
            }
        }

        private string selectedCategorie;
        public string SelectedCategorie
        {
            get { return selectedCategorie; }
            set
            {
                if (selectedCategorie != value)
                {
                    selectedCategorie = value;
                    NotifyPropertyChanged(nameof(SelectedCategorie));
                    NotifyPropertyChanged(nameof(FilteredProductList));
                }
            }
        }

        private string selectedCod;
        public string SelectedCod
        {
            get { return selectedCod; }
            set
            {
                if (selectedCod != value)
                {
                    selectedCod = value;
                    NotifyPropertyChanged(nameof(SelectedCod));
                    NotifyPropertyChanged(nameof(FilteredProductList));
                }
            }
        }
    }

    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
