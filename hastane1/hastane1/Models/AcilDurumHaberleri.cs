using System.ComponentModel.DataAnnotations;

namespace hastane1.Models
{
    public class AcilDurumHaberi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Baslik { get; set; }

        [Required]
        public string? Aciklama { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;

        public string? EkipEpostalari { get; set; }
    }
}
