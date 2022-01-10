using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fiorella.Models
{
    public class Category : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
