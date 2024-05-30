using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Producator
    {
        public Producator() {
            NumeProducator = "";
            TaraProducator = "";
            Active = 1;
        }
        [Key]
        public int ProducatorId {  get; set; }
        public int Active {  get; set; }
      [MaxLength(50), Required]
        public string NumeProducator { get; set; }
        public string TaraProducator { get; set; }
    }
}
