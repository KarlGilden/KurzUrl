using System.ComponentModel.DataAnnotations;

namespace KurzUrl.Models
{
    public class Url
    {
        [Key]
        [Required]
        public String Slug {  get; set; }
        [Required]
        public String OriginalUrl {  get; set; }
        [Required]
        public required Int16 Clicks { get; set; }

    }
}
