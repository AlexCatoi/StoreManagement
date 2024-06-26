﻿using SuperMarket.ViewModel;
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
    /// Interaction logic for RegView.xaml
    /// </summary>
    public partial class RegView : Window
    {
        public RegView()
        {
            InitializeComponent();
            var ViewModel = DataContext as LoginVM;
            ViewModel.CloseAction = new Action(this.Close);
        }
    }
}
