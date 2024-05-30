using SuperMarket.Models;
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
using System.Windows.Shapes;

namespace SuperMarket.Views
{
    /// <summary>
    /// Interaction logic for AchizitiiView.xaml
    /// </summary>
    public partial class AchizitiiView : Window
    {
        public AchizitiiView(string name)
        {
            var ViewModel = new AchizitiiVM(name);
            InitializeComponent();
            this.DataContext = ViewModel;
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var ViewModel = this.DataContext as AchizitiiVM;
                ViewModel.Selected = e.Row.Item as ProdusePeBon;
            }
        }
    }
}
