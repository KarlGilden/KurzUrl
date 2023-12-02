﻿using System.ComponentModel.DataAnnotations;

namespace KurzUrl.Models
{
    public class Url
    {
        [Key]
        [Required]
        public String Id {  get; set; }
        [Required]
        public String OriginalUrl {  get; set; }
        [Required]
        public required String ShortUrl { get; set; }
        [Required]
        public required Int16 Clicks { get; set; }

    }
}
