using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    [Table("Products")]
    public class Products
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Manufacturer { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Price { get; set; }

        //[Required]
        //public int Quantity { get; set; }
    }
}
