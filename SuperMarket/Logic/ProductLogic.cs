using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SuperMarket.Logic
{
    public class ProductLogic
    {
        private Context context = new Context();
        public ObservableCollection<Produs> ProductList { get; set; }
        public string ErrorMessage { get; set; }
        
        public void AddProduct(Produs curent)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Produs prod = curent;
            if (prod != null)
            {
                if (string.IsNullOrEmpty(prod.NumeProdus) || string.IsNullOrEmpty(prod.CodBare))
                {
                    MessageBox.Show("Campurile nu pot fi goale!");
                }
                else
                {
                    Producator producatorExists = context.Producator.FirstOrDefault(p => p.NumeProducator == prod.Producator.NumeProducator);
                    Stocuri stocExists = context.Stoc.FirstOrDefault(c => c.StocName == prod.NumeProdus && c.NumeProd==prod.Producator.NumeProducator);
                    if(!VerifyCod(prod))
                        MessageBox.Show("Codul de bare exista deja!");
                    else if (producatorExists==null || stocExists==null)
                    {
                        MessageBox.Show("Producator or Stoc does not exist in the database");
                    }
                    else 
                    { 
                        prod.Producator = producatorExists;
                        prod.Stoc = stocExists;
                        prod.PretProdus = (float)Math.Round(prod.Stoc.PretVanzare / prod.Stoc.Cantitate, 2);
                        CategorieProdus cat= context.Categorie.FirstOrDefault(x => x.Denumire == prod.Categorie.Denumire);
                        if (cat == null)
                            context.Categorie.Add(prod.Categorie);
                        else
                            prod.Categorie = cat;
                        context.Produs.Add(prod);
                        context.SaveChanges();
                        prod.ProdusId = context.Produs.Max(item => item.ProdusId);
                        MessageBox.Show("Inserare cu succes!");
                    }
                }
            }
        }

        public void UpdateProduct(Produs SelectedProduct)
        {
            Produs prod = SelectedProduct;
            if (prod == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else if (string.IsNullOrEmpty(prod.NumeProdus))
            {
                ErrorMessage = "Numele produsului trebuie precizat";
            }
            else
            {
                Producator producatorExists = context.Producator.FirstOrDefault(p => p.NumeProducator == prod.Producator.NumeProducator);
                Stocuri stocExists = context.Stoc.FirstOrDefault(c => c.StocName == prod.NumeProdus);
                if (!VerifyCod(prod))
                    MessageBox.Show("Codul de bare exista deja!");
                else if (producatorExists == null || stocExists == null)
                {
                    MessageBox.Show("Producator or Stoc does not exist in the database");
                }
                else
                {
                    context.Produs.Attach(prod);
                    context.Entry(prod).State = EntityState.Modified;
                    context.SaveChanges();
                    ErrorMessage = "";
                    MessageBox.Show("Update cu succes!");
                }
            }
        }

        public bool VerifyCod(Produs curent)
        {
            var barex = context.Produs.FirstOrDefault(x => x.CodBare == curent.CodBare);
            if (barex == null)
                return true;
            return false;
        }
        public void DeleteProduct(Produs SelectedProd)
        {
            Produs prod = SelectedProd;
            if (prod == null)
            {
                ErrorMessage = "Selecteaza un produs";
            }
            else
            {
                Produs p = context.Produs.Where(i => i.ProdusId == prod.ProdusId).FirstOrDefault();
                p.Active = 0;
                context.SaveChanges();
                ProductList.Remove(prod);
                ErrorMessage = "";
            }
        }
        public ObservableCollection<Produs> GetAllProducts()
        {
            List<Produs> produse = context.Produs
                .Include(p => p.Producator)
                .Include(p => p.Stoc)
                .Include(p => p.Categorie)
                .ToList();
            ObservableCollection<Produs> result = new ObservableCollection<Produs>();
            foreach (Produs prod in produse)
            {
                if(prod.Active==1)
                    result.Add(prod);
            }
            return result;
        }

        public void HasStock()
        {
            List<Produs> produse = context.Produs
               .Include(p => p.Producator)
               .Include(p => p.Stoc)
               .Include(p => p.Categorie)
               .ToList();
            ObservableCollection<Produs> result = new ObservableCollection<Produs>();
            foreach (Produs prod in produse)
            {
                if (prod.Stoc.Active==0)
                {
                    Stocuri stoc = context.Stoc.FirstOrDefault(s => s.StocName == prod.NumeProdus);
                    if (stoc != null)
                       { prod.Stoc = stoc;
                        context.Update(prod);
                        context.SaveChanges();
                    }
                }
            }
        }

    }
}
