using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class MyBookDetails
    {
        public int Id { get; set; }

        [Display(Name = "MyBook")]
        public int MyBookId { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("MyBookId")]
        public MyBooks MyBook { get; set; }

    }
}
