using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.Models;

namespace SuperMarket.Logic
{
    public class StocLogic
    {
        private Context context = new Context();
        public ObservableCollection<Stocuri> StocList { get; set; }
        public string ErrorMessage { get; set; }
      
        public void AddStoc(Stocuri Curent)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            Stocuri stoc = Curent;
            if (stoc != null)
            {
                if (stoc.Cantitate<=0 || stoc.DataAprovizionarii > DateOnly.FromDateTime(DateTime.Today) || stoc.DataExpirarii <= DateOnly.FromDateTime(DateTime.Today))
                {
                    MessageBox.Show("Data, cantitate sau pret incorect!");
                }
                else
                {
                    stoc.PretVanzare = stoc.PretAchizitie + (float)0.1 * stoc.PretAchizitie;
                    context.Stoc.Add(stoc);
                    context.SaveChanges();
                    stoc.StocId = context.Stoc.Max(item => item.StocId);
                    MessageBox.Show("Inserare cu succes!");
                }
            }
        }

        public ObservableCollection<Stocuri> GetAllStocs()
        {
            List<Stocuri> stocs = context.Stoc.ToList();
            ObservableCollection<Stocuri> result = new ObservableCollection<Stocuri>();
            foreach (Stocuri stoc in stocs)
            {
                if (stoc.Active == 1)
                    result.Add(stoc);
            }
            return result;
        }

        public void CheckExpiryDate()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            List<Stocuri> stocs = context.Stoc.ToList();

            foreach (Stocuri stoc in stocs)
            {
                if (stoc.DataExpirarii <= today)
                {
                    stoc.Active = 0;
                }
            }
            context.SaveChanges();
        }
    }
}
