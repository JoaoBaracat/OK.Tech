using System;
using System.ComponentModel.DataAnnotations;

namespace OK.Tech.Api.Models
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "The {0} must be supplied")]
        [StringLength(200, ErrorMessage ="The {0} lenght must be between {2} and {1}", MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The {0} must be supplied")]
        [StringLength(1000, ErrorMessage = "The {0} lenght must be between {2} and {1}", MinimumLength = 3)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "The {0} must be supplied")]
        public decimal Price { get; set; }
        //public DateTime CreateDate { get; set; }
        
        public bool Active { get; set; }

    }
}
