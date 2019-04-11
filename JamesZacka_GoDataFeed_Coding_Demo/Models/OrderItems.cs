using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JamesZacka_GoDataFeed_Coding_Demo.Models
{
    public class OrderItems
    {
        public int ID { get; set; }

        [Required]
        public virtual Orders Order { get; set; }

        [Required]
        public virtual Products Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public double Total { get; set; }
    }
}
