using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SuperMarket.Models;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Helper;



namespace SuperMarket.Logic
{
    public class UsersLogic
    {
        private Context context=new Context();
        public ObservableCollection<User> UserList { get; set; }
        

        public string name { get; set; }
        public TipUtilizator role { get; set; }
        public bool OldUser(string nume,string parola)
        {
            var result = context.Utilizator.Any(u => u.NumeUtilizator == nume && u.Parola == parola);
            if (result)
            {
                var userex = context.Utilizator.FirstOrDefault(x => x.NumeUtilizator == nume);
                name = nume;
                role = userex.TipUser;
            }
            return result;
        }

        
        public void AddUser(object obj)
        {
            //parametrul obj este cel dat prin CommandParameter cu MultipleBinding la Button in xaml
            User user = obj as User;
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.NumeUtilizator) || string.IsNullOrEmpty(user.Parola))
                {
                    MessageBox.Show("Campurile pentru nume si parola nu pot fi goale");
                }
                else if(UserExists(user))
                    MessageBox.Show("Usernameul exista!");
                else
                {
                    context.Utilizator.Add(user);
                    context.SaveChanges();
                    user.UserId = context.Utilizator.Max(item => item.UserId);
                    MessageBox.Show("Inserare cu succes!");
                }
            }
        }

        public bool UserExists(User user) {
            var userex = context.Utilizator.FirstOrDefault(x => x.NumeUtilizator == user.NumeUtilizator);
            if (userex == null)
                return false;
            return true;
        }
        public void UpdateUser(User SelectedUser)
        {
            User user = SelectedUser;
            if (user == null)
            {
                MessageBox.Show("Selecteaza o persoana");
            }
            else if (string.IsNullOrEmpty(user.NumeUtilizator))
            {
                MessageBox.Show("Numele persoanei trebuie precizat");
            }
            else
            {
                context.Utilizator.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
                MessageBox.Show("Updatare cu succes!");

            }
        }

        public void DeleteUser(User SelectedUser)
        {
            User user = SelectedUser;
            if (user == null)
            {
                MessageBox.Show("Selecteaza o persoana");
            }
            else
            {
                User u = context.Utilizator.Where(i => i.UserId == user.UserId).FirstOrDefault();
                u.Active = 0;
                context.SaveChanges();
                UserList.Remove(user);
            }
        }
        public ObservableCollection<User> GetAllUsers()
        {
            List<User> users = context.Utilizator.ToList();
            ObservableCollection<User> result = new ObservableCollection<User>();
            foreach (User user in users)
            {
                if(user.Active==1)
                    result.Add(user);
            }
            return result;
        }
    }
}
