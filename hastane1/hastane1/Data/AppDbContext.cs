using Microsoft.EntityFrameworkCore;

namespace hastane1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AcilDurumHaberi> AcilDurumHaberleri { get; set; }
        public DbSet<Asistan> Asistanlar { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<BolumHakkinda> BolumHakkinda { get; set; }
        public DbSet<Nobet> Nobetler { get; set; }
        public DbSet<OgretimUyesi> OgretimUyeleri { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Asistan - User relationship: One-to-One
            modelBuilder.Entity<Asistan>()
                .HasOne(a => a.User)
                .WithOne(u => u.Asistan)
                .HasForeignKey<Asistan>(a => a.UserId);

            // Asistan - Bolum relationship: Many-to-One
            modelBuilder.Entity<Asistan>()
                .HasOne(a => a.Bolum)
                .WithMany(b => b.Asistanlar)
                .HasForeignKey(a => a.BolumId);

            // Bolum - Nobet relationship: One-to-Many
            modelBuilder.Entity<Nobet>()
                .HasOne(n => n.Bolum)
                .WithMany(b => b.Nobetler)
                .HasForeignKey(n => n.BolumId);

            // Asistan - Nobet relationship: One-to-Many
            modelBuilder.Entity<Nobet>()
                .HasOne(n => n.Asistan)
                .WithMany(a => a.Nobetler)
                .HasForeignKey(n => n.AsistanId);

            // Bolum - OgretimUyesi relationship: One-to-Many
            modelBuilder.Entity<OgretimUyesi>()
                .HasOne(o => o.Bolum)
                .WithMany(b => b.OgretimUyeleri)
                .HasForeignKey(o => o.SorumluBolumId);

            // OgretimUyesi - User relationship: One-to-One
            modelBuilder.Entity<OgretimUyesi>()
                .HasOne(o => o.User)
                .WithOne(u => u.OgretimUyesi)
                .HasForeignKey<OgretimUyesi>(o => o.UserId);

            // OgretimUyesi - Randevu relationship: One-to-Many
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.OgretimUyesi)
                .WithMany(o => o.Randevular)
                .HasForeignKey(r => r.OgretimUyesiId);

            // Asistan - Randevu relationship: One-to-Many
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Asistan)
                .WithMany(a => a.Randevular)
                .HasForeignKey(r => r.AsistanId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
