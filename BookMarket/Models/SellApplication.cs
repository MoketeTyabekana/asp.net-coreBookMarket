using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class SellApplication
    {
        public SellApplication()
        {
            SellApplicationDetails = new List<SellApplicationDetails>();
        }
        public int Id { get; set; }
       

        [Required]
        public string Status { get; set; }


        [Required]
        [Display(Name = "Proof of Id")]
        public string ProofId { get; set; }
        [Required]
        [Display(Name = "Proof of Address")]
        public string ProofAddress { get; set; }



        public virtual List<SellApplicationDetails> SellApplicationDetails { get; set; }

    }
}
