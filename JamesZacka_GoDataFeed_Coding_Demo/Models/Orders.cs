using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    [Table("Orders")]
    public class Orders
    {
        public int ID { get; set; }

        [Required]
        public DateTime OrderDate {get;set;}

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public DateTime Status { get; set; }

        //[Required]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        //public double Total { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        //[Required]
        //public List<Products> Items { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customers Customer { get; set; }
    }
}
