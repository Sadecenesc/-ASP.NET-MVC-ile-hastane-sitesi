using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime GorusmeTarihi { get; set; }

        [Required]
        public DateTime Başlamazamani {  get; set; }

        public DateTime  Bitişzamani { get; set; }

        [ForeignKey("Asistan")]
        public int? AsistanId { get; set; }

        public Asistan? Asistan { get; set; }

        [ForeignKey("OgretimUyesi")]
        public int? OgretimUyesiId { get; set; }

        public OgretimUyesi? OgretimUyesi { get; set; }

    }

}
