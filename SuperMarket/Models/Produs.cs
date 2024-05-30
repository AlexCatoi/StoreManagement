using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Produs
    {
        public Produs()
        {
            NumeProdus = "";
            CodBare = "";
            Categorie = new CategorieProdus();
            Stoc = new Stocuri();
            Producator = new Producator();
            PretProdus = 0;
            Active = 1;
        }
        [Key]
        public int ProdusId { get; set; }

        [Required]
        public string NumeProdus { get; set; }

        public int CategorieId { get; set; }
        public int ProducatorId { get; set; }
        public int StocId { get; set; }
        public string CodBare { get; set; }
        public CategorieProdus Categorie { get; set; }
        public Producator Producator{get;set;}
        public Stocuri Stoc { get; set; }
        public float PretProdus { get; set; }   
        public int Active { get; set; }
        
    }
}
