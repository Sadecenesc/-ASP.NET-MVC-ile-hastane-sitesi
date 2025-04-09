
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
    public class Asistan
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

        [MaxLength(100)]
        public string? UzmanlikBolgesi { get; set; }

        public string? NobetBilgisi { get; set; }

        
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Bolum")]
        public int? BolumId { get; set; }
        public Bolum? Bolum { get; set; }
        public ICollection<Nobet>? Nobetler { get; set; }
        public ICollection<Randevu>? Randevular { get; set; }
    }

}