
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
        public class OgretimUyesi
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string? Ad { get; set; }

            [Required]
            [MaxLength(50)]
            public string? Soyad { get; set; }

            [MaxLength(15)]
            public string? Telefon { get; set; }

            [Required]
            [EmailAddress]
            public string? Eposta { get; set; }

            public string? Adres { get; set; }

            [ForeignKey("Bolum")]
            public int? SorumluBolumId { get; set; }

            public Bolum? Bolum { get; set; }

            
            [ForeignKey("User")]
            public int? UserId { get; set; }
            public User? User { get; set; }
        

            public ICollection<Randevu>? Randevular { get; set; }
    }

    }
