using EsercizioPreVerifica.Model;
using Microsoft.EntityFrameworkCore;

namespace EsercizioPreVerifica.Data
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Regista> Registas => Set<Regista>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Regista)
                .WithMany(f => f.Films)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(f => f.RegistaId);

            modelBuilder.Entity<Regista>().HasData(
           new Regista() { RegistaId = 1, Cognome = "a", Nome = "b", Nazionalità = "IT" },
           new Regista() { RegistaId = 2, Cognome = "f", Nome = "g", Nazionalità = "IT" },
           new Regista() { RegistaId = 3, Cognome = "h", Nome = "i", Nazionalità = "IT" });

            modelBuilder.Entity<Film>().HasData(
                new Film() { RegistaId = 1, FilmId = 1, Titolo = "c", Durata = 180, DataDiProduzione = DateTime.Now },
                new Film() { RegistaId = 2, FilmId = 2, Titolo = "d", Durata = 300, DataDiProduzione = DateTime.UtcNow },
                new Film() { RegistaId = 2, FilmId = 3, Titolo = "e", Durata = 700, DataDiProduzione = DateTime.Today },
                new Film() { RegistaId = 3, FilmId = 4, Titolo = "j", Durata = 60, DataDiProduzione = DateTime.Today });

        }
    }
}
