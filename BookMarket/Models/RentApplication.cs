using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class RentApplication
    {
        public RentApplication()
        {
            RentApplicationDetails = new List<RentApplicationDetails>();
        }
        public int Id { get; set; }


        [Required]
        [Display(Name = "Proof of Address")]
        public string ProofOfAddress { get; set; }

        [Required]
        [Display(Name = "Proof of ID ")]
        public string ProofOfID { get; set; }

        [Required]
        [Display(Name = "Proof Of Next Of Kin Id ")]
        public string NextOfKinId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Next Of Kin Cell No")]

        public string NextOfKinContacts { get; set; }

        [Required]
        public string Status { get; set; }


       

        public virtual List<RentApplicationDetails> RentApplicationDetails { get; set; }
    }
}
