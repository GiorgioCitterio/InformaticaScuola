using EsercizioRistorante.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace EsercizioRistorante.Data
{
    public class RistoranteDbContext : DbContext
    {
        public RistoranteDbContext(DbContextOptions<RistoranteDbContext> options) : base(options)
        { 
        }

        public DbSet<Ristorante> Ristorantes => Set<Ristorante>();
        public DbSet<Piatto> Piattos => Set<Piatto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piatto>()
                .HasOne(r => r.Ristorante)
                .WithMany(p => p.Piattos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.PiattoId);

            modelBuilder.Entity<Piatto>().HasData(
                new Piatto() { PiattoId = 1, Costo = 10, NomePiatto = "piatto 1", RistoranteId = 1 },
                new Piatto() { PiattoId = 2, Costo = 20, NomePiatto = "piatto 2", RistoranteId = 2 },
                new Piatto() { PiattoId = 3, Costo = 15, NomePiatto = "piatto 3", RistoranteId = 3 });

            modelBuilder.Entity<Ristorante>().HasData(
                new Ristorante() { RistoranteId = 1, Città = "milano", Nome = "nome 1" },
                new Ristorante() { RistoranteId = 2, Città = "roma", Nome = "nome 2" },
                new Ristorante() { RistoranteId = 3, Città = "napoli", Nome = "nome 3" });
        }
    }
}
