using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookMarket.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Edition")]
        public string Edition { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Publish Year")]
        public string YearPublished { get; set; }

        

        [Display(Name = "Price")]
        [Required]

        public decimal Price { get; set; }

        
        public string Image { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public string Condition { get; set; }

        [Required]
        [Display(Name ="Available")]
        public bool IsAvailable { get; set; }

        [Display(Name ="Category")]
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }

        [Display(Name = "Tag Name")]
        [Required]
        public int TagNameId { get; set; }
        [ForeignKey("TagNameId")]
        public TagNames TagName { get; set; }



    }
}
