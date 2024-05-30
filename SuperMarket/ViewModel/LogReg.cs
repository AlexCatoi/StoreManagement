using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Views;

namespace SuperMarket.ViewModel
{
    public class LogReg
    {

        public ICommand OpenWindowCommand {  get; set; }
        public Action CloseAction { get; set; }
        public string name {  get; set; }
       
        public TipUtilizator role { get; set; }
       
        public LogReg() {
            OpenWindowCommand = new RelayCommand(OpenWindow);
        }
        
        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            Console.WriteLine(nr);
            switch (nr)
            {
                case "1":
                    LoginView log = new LoginView();
                    CloseAction();
                    log.ShowDialog();
                    break;
                case "2":
                    RegView reg = new RegView();
                    CloseAction();
                    reg.ShowDialog();
                    break;
                case "3":
                    UsersView users = new UsersView();
                    users.ShowDialog();
                    break;
                case "4":
                    BonView bon = new BonView(false,"");
                    bon.ShowDialog();
                    break;
                case "5":
                    ProducatorView producator = new ProducatorView();
                    producator.ShowDialog();
                    break;
                case "6":
                    ProductView product = new ProductView();
                    product.ShowDialog();
                    break;
                case "7":
                    StocView stc = new StocView();  
                    stc.ShowDialog();
                    break;
                case "8":
                    SearchByProducer sbp=new SearchByProducer();
                    sbp.ShowDialog();
                    break;
            }
        }
    }
}
