using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SuperMarket.Helper;
using SuperMarket.Logic;
using SuperMarket.Models;

namespace SuperMarket.ViewModel
{
    public class UsersVM
    {
        private UsersLogic logic;
        public UsersVM()
        {
            logic= new UsersLogic();
            userList=logic.GetAllUsers();
        }

        public ObservableCollection<User> userList
        {
            get => logic.UserList;
            set => logic.UserList = value;
        }


        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
            }
        }

        public void UpdateUser(object obj)
        {
            logic.UpdateUser(SelectedUser);
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(UpdateUser);
                }
                return updateCommand;
            }
        }

        public void DeleteUser(object obj)
        {
            logic.DeleteUser(SelectedUser);
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(DeleteUser);
                }
                return deleteCommand;
            }
        }
    }
}
