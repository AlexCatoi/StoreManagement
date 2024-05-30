using SuperMarket.Helper;
using SuperMarket.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SuperMarket.ViewModel
{
    public class CasierVM
    {
        public ICommand OpenWindowCommand { get; set; }
        public string name { get; set; }

        public TipUtilizator role { get; set; }

        public CasierVM()
        {
            OpenWindowCommand = new RelayCommand(OpenWindow);
        }

        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    BonView bon=new BonView(true,name);
                    bon.ShowDialog();
                    break;
                case "2":
                    SearchView src = new SearchView();
                    src.ShowDialog();
                    break;
                
            }
        }
    }
}
