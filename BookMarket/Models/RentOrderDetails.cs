using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class RentOrderDetails
    {
        public int Id { get; set; }

        [Display(Name = "Order")]
        public int OrderId { get; set; }
        [Display(Name = "Book")]
        public int BookId { get; set; }
        [Display(Name = "User")]
        public string UserId { get; set; }




        [ForeignKey("OrderId")]
        public RentOrder Order { get; set; }

        [ForeignKey("BookId")]
        public Books Book { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
