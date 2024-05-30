using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SuperMarket.Helper;
using SuperMarket.Models;

namespace SuperMarket.Converters
{
    public class UserConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2]!=null)
            {
                return new User()
                {
                    NumeUtilizator = values[0].ToString(),
                    Parola = values[1].ToString(),
                    TipUser = (TipUtilizator)Enum.Parse(typeof(TipUtilizator), values[2].ToString())
                };
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
