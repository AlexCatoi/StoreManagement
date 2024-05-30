using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Models;
using System.Windows;


namespace SuperMarket.Logic
{
    public class Context : DbContext
    {
        public DbSet<Produs> Produs { get; set; }
        public DbSet<Producator> Producator { get; set; }
        public DbSet<CategorieProdus> Categorie { get; set; }
        public DbSet<Bonuri> Bon { get; set; }

        public DbSet<Stocuri> Stoc { get; set; }
        public DbSet<ProdusePeBon> ProdusePeBons { get; set; }
        public DbSet<User> Utilizator { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = SuperMarket; Integrated Security = SSPI; TrustServerCertificate = True");
        }
    }
}
