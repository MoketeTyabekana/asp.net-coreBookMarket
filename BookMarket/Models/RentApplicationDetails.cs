using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class RentApplicationDetails
    {
        public int Id { get; set; }

        [Display(Name = "Application")]
        public int RentApplicationId { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("RentApplicationId")]
        public RentApplication RentApplication { get; set; }
        public string Reason { get; set; }
    }
}
