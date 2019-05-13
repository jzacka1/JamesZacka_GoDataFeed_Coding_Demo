using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    [Table("ShoppingCarts")]
    public class ShoppingCarts
    {
        public int ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        //[Required]
        //public List<Products> Items { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Total { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
