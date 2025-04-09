
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
    public class Bolum
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? BolumAdi { get; set; }

        public int? HastaSayisi { get; set; } = 0;

        public int? BosYatakSayisi { get; set; } = 0;

        public string? Aciklamalar { get; set; }

       
        public ICollection<Nobet>? Nobetler { get; set; }

        
        public ICollection<OgretimUyesi>? OgretimUyeleri { get; set; }

        
        public ICollection<Asistan>? Asistanlar { get; set; }

    }
}
