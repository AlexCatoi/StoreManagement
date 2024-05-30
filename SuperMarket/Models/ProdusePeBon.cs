using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Models
{
    public class ProdusePeBon
    {
        public ProdusePeBon() { 
            Produs=new Produs();
            cantitate = 0;
            Subtotal = 0;
            Active = 1;
        }
        [Key]
        public int Id { get; set; }
        public Produs Produs { get; set; }
        public int cantitate { get; set; }
        public float Subtotal { get; set; }
        public int Active { get; set; }
    }
}
