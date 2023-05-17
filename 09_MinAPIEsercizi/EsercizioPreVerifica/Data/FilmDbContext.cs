using EsercizioPreVerifica.Model;
using Microsoft.EntityFrameworkCore;

namespace EsercizioPreVerifica.Data
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) { }
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Regista> Registas => Set<Regista>();
        public DbSet<Cinema> Cinemas => Set<Cinema>();
        public DbSet<Proiezione> Proieziones => Set<Proiezione>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Regista)
                .WithMany(f => f.Films)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(f => f.RegistaId);

            modelBuilder.Entity<Proiezione>()
                .HasOne(c => c.Cinema)
                .WithMany(p => p.Proieziones)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(c => c.CinemaId);

            modelBuilder.Entity<Proiezione>()
                .HasOne(f => f.Film)
                .WithMany(p => p.Proieziones)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(f => f.FilmId);

            modelBuilder.Entity<Proiezione>().HasKey(p => new { p.CinemaId, p.FilmId });

            modelBuilder.Entity<Regista>().HasData(
                new Regista() { RegistaId = 1, Cognome = "a", Nome = "b", Nazionalità = "IT" },
                new Regista() { RegistaId = 2, Cognome = "f", Nome = "g", Nazionalità = "IT" },
                new Regista() { RegistaId = 3, Cognome = "h", Nome = "i", Nazionalità = "IT" });

            modelBuilder.Entity<Film>().HasData(
                new Film() { RegistaId = 1, FilmId = 1, Titolo = "c", Durata = 180, DataDiProduzione = DateTime.Now },
                new Film() { RegistaId = 2, FilmId = 2, Titolo = "d", Durata = 300, DataDiProduzione = DateTime.UtcNow },
                new Film() { RegistaId = 2, FilmId = 3, Titolo = "e", Durata = 700, DataDiProduzione = DateTime.Today },
                new Film() { RegistaId = 3, FilmId = 4, Titolo = "j", Durata = 60, DataDiProduzione = DateTime.Today });
            modelBuilder.Entity<Cinema>().HasData(
                new Cinema() { CinemaId = 1, Città = "città1", Nome = "nome1", Indirizzo = "indirizzo1" },
                new Cinema() { CinemaId = 2, Città = "città2", Nome = "nome2", Indirizzo = "indirizzo2" },
                new Cinema() { CinemaId = 3, Città = "città3", Nome = "nome3", Indirizzo = "indirizzo3" });

            modelBuilder.Entity<Proiezione>().HasData(
                new Proiezione() { CinemaId = 1, Data = DateTime.Now, FilmId = 1, Ora = DateTime.Now },
                new Proiezione() { CinemaId = 2, Data = DateTime.Now, FilmId = 2, Ora = DateTime.Now },
                new Proiezione() { CinemaId = 1, Data = DateTime.Now, FilmId = 3, Ora = DateTime.Now },
                new Proiezione() { CinemaId = 3, Data = DateTime.Now, FilmId = 1, Ora = DateTime.Now });
        }
    }
}
