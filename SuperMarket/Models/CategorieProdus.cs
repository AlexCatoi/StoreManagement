using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class CategorieProdus
    {
        public CategorieProdus() {
            Denumire = "";
            Active = 1;
        }
        public CategorieProdus(string den)
        {
            Denumire =den;
            Active = 1;
        }
        [Key]
        public int CategorieId { get; set; }

        [Required]
        public string Denumire { get; set; }
        public int Active { get; set; }
    }
}
