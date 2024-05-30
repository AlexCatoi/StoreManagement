using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;

namespace SuperMarket.Converters
{
    public class AchizitieConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[0]!="")
            {
                var context = new Context();
                int cantitate = int.Parse(values[0].ToString());
                string code = values[1].ToString();

                Produs produs = context.Produs
                    .Include(p => p.Stoc)
                    .Include(p => p.Categorie)
                    .Include(p => p.Producator)
                    .FirstOrDefault(p => p.CodBare == code);
               
                if (produs != null)
                {
                    float subtotal = (float)Math.Round(cantitate * produs.PretProdus,2);
                    ProdusePeBon pr= new ProdusePeBon { Produs = produs, cantitate = cantitate, Subtotal = subtotal };
                    return pr;
                }
            }
            return null;
        }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
