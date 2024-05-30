using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SuperMarket.Models
{
    public class Stocuri
    {
        public Stocuri() {
            StocName = "";
            Cantitate= 0;
            UnitateMasura = "";
            NumeProd = "";
            DataAprovizionarii = DateOnly.FromDateTime(DateTime.Today);
            DataExpirarii = DateOnly.FromDateTime(DateTime.Today);
            PretAchizitie = 0;
            PretVanzare = 0;
            Active = 1;
        }

        [Key]
        public int StocId { get; set; }

        [Required]
        public string StocName { get; set; }
        public int Cantitate { get; set; }
        public string UnitateMasura { get; set; }

        public DateOnly DataAprovizionarii { get; set; }
        public DateOnly DataExpirarii { get; set; }
        public string NumeProd { get; set; }
        public float PretAchizitie { get; set; }
        public float PretVanzare { get; set; }
        public int Active { get; set; }
    }
}
