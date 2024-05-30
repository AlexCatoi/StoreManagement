using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Bonuri
    {
        public Bonuri()
        {
            DataEliberarii=DateOnly.FromDateTime(DateTime.Today);
            NumeCasier = "";
            ProduseVandute = new List<ProdusePeBon>();
            SumaTotala = 0;
            Active = 1;
        }
        [Key]
        public int BonId { get; set; }

        [Required]

        public DateOnly DataEliberarii { get; set; }
        public string NumeCasier { get; set; }

        public List<ProdusePeBon> ProduseVandute { get; set; } 
        public float SumaTotala { get; set; }
        public int Active { get; set; }
    }
}
