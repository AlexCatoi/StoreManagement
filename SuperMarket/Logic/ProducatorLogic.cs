using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using Microsoft.VisualBasic.ApplicationServices;

namespace SuperMarket.Logic
{
    public class ProducatorLogic
    {
        private Context context = new Context();
        public ObservableCollection<Producator> ProdList { get; set; }
        public string ErrorMessage { get; set; }
        
        public void AddProd(Producator selected)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Producator prod = selected;
            if (prod != null)
            {
                if (string.IsNullOrEmpty(prod.NumeProducator) || string.IsNullOrEmpty(prod.TaraProducator))
                {
                    MessageBox.Show("Campurile nu pot fi goale");
                }
                else
                {
                    if(AlreadyExists(prod))
                        MessageBox.Show("Producatorul deja exista!");
                    else
                    {
                        context.Producator.Add(prod);
                        context.SaveChanges();
                        prod.ProducatorId = context.Producator.Max(item => item.ProducatorId);
                        MessageBox.Show("Inserare cu succes!");
                    }
                }
            }
        }
        public bool AlreadyExists(Producator curent)
        {
            var producerex = context.Producator.FirstOrDefault(x => x.NumeProducator == curent.NumeProducator && x.ProducatorId!=curent.ProducatorId);
            if (producerex == null)
                return false;
            return true;
        }
        public void UpdateProducer(Producator SelectedProd)
        {
            Producator prod = SelectedProd;
            if (prod == null)
            {
                MessageBox.Show("Selecteaza un producator");
            }
            else if (string.IsNullOrEmpty(prod.NumeProducator) || string.IsNullOrEmpty(prod.TaraProducator))
            {
                MessageBox.Show("Fara campuri goale!"); 
            }
            else if(AlreadyExists(SelectedProd))
            {
                MessageBox.Show("Producatorul exista deja!");
            }
            else
            {
                context.Producator.Attach(prod);
                context.Entry(prod).State = EntityState.Modified;
                context.SaveChanges();
                ErrorMessage = "";
                MessageBox.Show("Updatare cu succes!");
            }
        }

        public void DeleteProducer(Producator SelectedProd,ObservableCollection<Produs> productList)
        {
            Producator prod = SelectedProd;
            if (prod == null)
            {
                MessageBox.Show("Selecteaza un producator");
            }
            else
            {
                if(IsUsed(prod,productList))
                    MessageBox.Show("Producatorul are produse in magazin");
                else
                {
                    Producator pro = context.Producator.Where(i => i.ProducatorId == prod.ProducatorId).FirstOrDefault();
                    pro.Active = 0;
                    context.SaveChanges();
                    ProdList.Remove(prod);
                    ErrorMessage = "";
                }
            }
        }
        public bool IsUsed(Producator curent,ObservableCollection<Produs> productList)
        {
            foreach (Produs prod in productList)
                if (prod.Producator.NumeProducator == curent.NumeProducator)
                    return true;
            return false;
        }
        public ObservableCollection<Producator> GetAllProducers()
        {
            List<Producator> prods = context.Producator.ToList();
            ObservableCollection<Producator> result = new ObservableCollection<Producator>();
            foreach (Producator prod in prods)
            {
                if(prod.Active==1)
                    result.Add(prod);
            }
            return result;
        }
    }
}
