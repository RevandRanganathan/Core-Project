using MyApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Product : IValidatableObject
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [ValidPriceAttribute(allowedDomain: "in", ErrorMessage = "Valid Name ends with in")]

        public string Name { get; set; }
        [Required]
        
        public int Price { get; set; }
        [Required]
        public DateTime Pkgd { get; set; }
        [Required]
        public DateTime Exp { get; set; }

        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Pkgd>DateTime.Now)
            {
                yield return new ValidationResult("Pkgd Date should not be in Future");
            }
            if (Exp < DateTime.Now)
            {
                yield return new ValidationResult("Exp Date should not be Current Date");
            }
        }
    }
}
