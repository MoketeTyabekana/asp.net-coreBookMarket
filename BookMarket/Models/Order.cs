using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class Order
    {

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }

        public int Id { get; set; }

       
        public string OrderNo { get; set; }
        [Required]
        
        public DateTime OrderDate { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

       



    }
}
