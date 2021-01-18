using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        //When Checking Out
        
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "Complex/Building (Optional)")]
        public string Complex { get; set; }
        
        [Display(Name = "Suburb")]
        public string Suburb { get; set; }
        
        [Display(Name = "City/Town")]
        public string City { get; set; }
        
        [Display(Name = "Province")]
        public string Province { get; set; }
        
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        

       




    }
}
