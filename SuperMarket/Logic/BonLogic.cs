using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Logic
{
    public class BonLogic
    {
        private Context context = new Context();
        public ObservableCollection<Bonuri> BonList { get; set; }

        public ObservableCollection<Bonuri> GetAllBons()
        {
            List<Bonuri> bonuri = context.Bon
                .Include(p=>p.ProduseVandute)
                .ToList();
            ObservableCollection<Bonuri> result = new ObservableCollection<Bonuri>();
            foreach (Bonuri bon in bonuri)
            {
                if (bon.Active == 1)
                    result.Add(bon);
            }
            return result;
        }

        public ObservableCollection<ProdusePeBon> GetDetails(Bonuri Bon)
        {
           List<ProdusePeBon> produse=context.ProdusePeBons
                .Include(p=>p.Produs)
                .ToList();
            ObservableCollection<ProdusePeBon> result = new ObservableCollection<ProdusePeBon>(produse);
           
            return result;
        }

    }
}
