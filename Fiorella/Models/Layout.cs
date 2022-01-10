using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Fiorella.Models
{
    public class Layout : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Logo { get; set; }
        public string facebook_url { get; set; }
        public string twitter_url { get; set; }
        public IFormFile file { get; set; }
    }
}
