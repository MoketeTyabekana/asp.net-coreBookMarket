using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class TagNames
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Name")]

        public string TagName { get; set; }
    }
}
