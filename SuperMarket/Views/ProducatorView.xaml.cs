using SuperMarket.Models;
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
    /// Interaction logic for ProducatorView.xaml
    /// </summary>
    public partial class ProducatorView : Window
    {
        public ProducatorView()
        {
            InitializeComponent();
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                ViewModel.SelectedProd = e.Row.Item as Producator;
            }
        }
    }
}
