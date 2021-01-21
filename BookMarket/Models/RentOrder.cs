using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class RentOrder
    {

        public RentOrder()
        {
            RentOrderDetails = new List<RentOrderDetails>();
        }

        public int Id { get; set; }


        public string OrderNo { get; set; }
        [Required]

        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual List<RentOrderDetails> RentOrderDetails { get; set; }





    }
}
