using EsercizioRistorante.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace EsercizioRistorante.Data
{
    public class RistoranteDbContext : DbContext
    {
        public RistoranteDbContext(DbContextOptions<RistoranteDbContext> options) : base(options) { }

        public DbSet<Ristorante> chef => Set<Ristorante>();
        public DbSet<Piatto> Piattos => Set<Piatto>();
        public DbSet<Portata> Portatas => Set<Portata>();
        public DbSet<Chef> Chefs => Set<Chef>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Piatto>()
                .HasOne(r => r.Ristorante)
                .WithMany(p => p.Piattos)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.RistoranteId);

            modelBuilder.Entity<Portata>()
                .HasOne(c => c.Chef)
                .WithMany(p => p.Portatas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.ChefId);

            modelBuilder.Entity<Portata>()
                .HasOne(c => c.Piatto)
                .WithMany(p => p.Portatas)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(p => p.PiattoId);

            modelBuilder.Entity<Portata>().HasKey(p => new {p.PiattoId, p.ChefId});

            modelBuilder.Entity<Piatto>().HasData(
                new Piatto() { PiattoId = 1, Costo = 10, NomePiatto = "piatto 1", RistoranteId = 1 },
                new Piatto() { PiattoId = 2, Costo = 20, NomePiatto = "piatto 2", RistoranteId = 2 },
                new Piatto() { PiattoId = 3, Costo = 15, NomePiatto = "piatto 3", RistoranteId = 3 });

            modelBuilder.Entity<Ristorante>().HasData(
                new Ristorante() { RistoranteId = 1, Città = "milano", Nome = "nome 1" },
                new Ristorante() { RistoranteId = 2, Città = "roma", Nome = "nome 2" },
                new Ristorante() { RistoranteId = 3, Città = "napoli", Nome = "nome 3" });

            modelBuilder.Entity<Portata>().HasData(
                new Portata() { PiattoId = 1, ChefId = 1, NumeroPorzioni = 5 },
                new Portata() { PiattoId = 2, ChefId = 2, NumeroPorzioni = 15 },
                new Portata() { PiattoId = 3, ChefId = 3, NumeroPorzioni = 10 });

            modelBuilder.Entity<Chef>().HasData(
                new Chef() { ChefId = 1, DataDiNascita = DateTime.UtcNow, Nome = "nome 1", },
                new Chef() { ChefId = 2, DataDiNascita = DateTime.UtcNow, Nome = "nome 2", },
                new Chef() { ChefId = 3, DataDiNascita = DateTime.UtcNow, Nome = "nome 3", });
        }
    }
}
