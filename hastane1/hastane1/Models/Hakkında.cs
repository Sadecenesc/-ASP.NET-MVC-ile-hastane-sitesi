
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
    public class BolumHakkinda
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        public string? Tarihce { get; set; }

        public string? Misyon { get; set; }

        public string? Vizyon { get; set; }

        public string? OzelNotlar { get; set; }
    }
}
