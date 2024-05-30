using SuperMarket.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperMarket.Views
{
    /// <summary>
    /// Interaction logic for BonView.xaml
    /// </summary>
    public partial class BonView : Window
    {
        public BonView(bool i,string name)
        {
            var ViewModel = new BonVM(i,name);
            InitializeComponent();
            this.DataContext = ViewModel;
            
        }
    }
}
