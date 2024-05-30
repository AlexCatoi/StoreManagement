    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
    using Microsoft.VisualBasic.Logging;
    using Microsoft.Win32;
    using SuperMarket.Helper;
    using SuperMarket.Logic;
    using SuperMarket.Views;

    namespace SuperMarket.ViewModel
    {
        public class LoginVM
        {
            public Action CloseAction{ get; set;}
            public string Username { get; set; }
            public string Password { get; set; }
            private UsersLogic Logic=new UsersLogic();
            public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RegisterCommand {  get; set; }
            public LoginVM()
            {
            LoginCommand = new RelayCommand(OpenWindow);
            CancelCommand = new RelayCommand(OpenWindow);
            RegisterCommand = new RelayCommand(Logic.AddUser);
            }
            public void OpenWindow(object obj)
            {
                string nr = obj as string;
                Console.WriteLine(nr);
                switch (nr)
                {
                    case "1":
                        var result = Logic.OldUser(Username, Password);
                        if(!result)
                        {
                            MessageBox.Show("Fail");
                            CloseAction();
                        }
                        else
                        {
                            MessageBox.Show("Your Logged!");
                              
                            if (Logic.role==(TipUtilizator)1)
                            {
                                Main main = new Main(Logic.name,Logic.role);
                                CloseAction();
                                main.ShowDialog();
                            }
                            else
                            {
                                CasierView main = new CasierView(Logic.name, Logic.role);
                                CloseAction();
                                main.ShowDialog();
                            }
                        }
                        break;
                    case "2":
                        MainLogin m = new MainLogin();
                        CloseAction();
                        m.ShowDialog();
                        break;
                    default:
                      CloseAction();
                      break;
                }
            }
        }
    }
