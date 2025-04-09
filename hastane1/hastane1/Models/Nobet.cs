using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hastane1.Models
{
    public class Nobet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public TimeSpan Saat { get; set; }

        [ForeignKey("Asistan")]
        public int? AsistanId { get; set; }

        public Asistan? Asistan { get; set; }

        [ForeignKey("Bolum")]
        public int? BolumId { get; set; }

        public Bolum? Bolum { get; set; }

    
    }

}
