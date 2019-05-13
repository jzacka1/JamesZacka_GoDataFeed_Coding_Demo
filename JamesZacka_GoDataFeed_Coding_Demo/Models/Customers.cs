using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    [Table("Customers")]
    public class Customers
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [StringLength(36)]
        public string Salt { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        //public virtual ShoppingCarts ShoppingCart { get; set; }
    }
}
