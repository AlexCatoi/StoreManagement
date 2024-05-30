using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuperMarket.Logic
{
    public class AchizitiiLogic
    {
        private Context context = new Context();
        public ObservableCollection<ProdusePeBon> List { get; set; }
        public void AddAchizitie(Object curent)
        {
            ProdusePeBon prod = curent as ProdusePeBon;
            if (prod != null)
            {
                if (prod.cantitate<=0 || string.IsNullOrEmpty(prod.Produs.CodBare))
                {
                    MessageBox.Show("Date invalide!");
                }
                else
                {
                    prod.Produs = context.Produs.FirstOrDefault(c => c.PretProdus == (prod.Subtotal / prod.cantitate));
                    context.Produs.Attach(prod.Produs);
                    context.ProdusePeBons.Add(prod);
                     context.SaveChanges();
                     prod.Id = context.ProdusePeBons.Max(item => item.Id);
                     MessageBox.Show("Inserare cu succes!");
                }
             }
         }



        public void AddABon(string name)
        {
           
            Bonuri bon = new Bonuri();

            bon.ProduseVandute =GetAll().ToList();
            bon.DataEliberarii= DateOnly.FromDateTime(DateTime.Today);
            bon.SumaTotala= bon.ProduseVandute.Sum(p => p.Subtotal);
            bon.NumeCasier = name;
            context.Bon.Add(bon);
            DeleteRest(bon);
            context.SaveChanges();

        }

        private void DeleteRest(Bonuri bon)
        {
            foreach (ProdusePeBon p in bon.ProduseVandute)
                p.Active = 0;
        }

        public ObservableCollection<ProdusePeBon> GetAll()
        {
            List<ProdusePeBon> prod = context.ProdusePeBons
                .Include(p => p.Produs)
                .ToList();
            ObservableCollection<ProdusePeBon> result = new ObservableCollection<ProdusePeBon>();
            foreach (ProdusePeBon p in prod)
            {
                if(p.Active==1)
                    result.Add(p);
            }
            return result;
        }
    }

}
