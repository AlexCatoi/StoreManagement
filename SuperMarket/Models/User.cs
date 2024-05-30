using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Helper;

namespace SuperMarket.Models
{
    public class User
    {
        public User() {
            NumeUtilizator = "";
            Parola = "";
            TipUser = 0;
            Active = 1;
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        public string NumeUtilizator { get; set; }
        public string Parola { get; set; }

        public TipUtilizator TipUser { get; set; } 
        public int Active {  get; set; }
    }
}
