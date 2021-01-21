using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class SellApplicationDetails
    {
        public int Id { get; set; }

        [Display(Name = "Application")]
        public int SellApplicationId { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("SellApplicationId")]
        public SellApplication SellApplication { get; set; }

       

        public string Reason { get; set; }
    }
}
