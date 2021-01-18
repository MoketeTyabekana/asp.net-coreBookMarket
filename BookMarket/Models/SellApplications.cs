using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class SellApplications
    {
        public int Id { get; set; }
       


        [Required]
        [Display(Name = "Proof of Address")]
        public string ProofOfAddress { get; set; }

        [Required]
        [Display(Name = "Proof of ID ")]
        public string ProofOfID { get; set; }

        //Foreign Key
       
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

       
    }
}
