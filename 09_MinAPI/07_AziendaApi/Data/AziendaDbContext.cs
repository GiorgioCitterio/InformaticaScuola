using _07_AziendaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace _07_AziendaApi.Data
{
    public class AziendaDbContext : DbContext
    {
        public AziendaDbContext(DbContextOptions<AziendaDbContext> options) : base(options) { }
        public DbSet<Azienda> Aziende => Set<Azienda>();
        public DbSet<Prodotto> Prodotti => Set<Prodotto>();
        public DbSet<Sviluppatore> Sviluppatori => Set<Sviluppatore>();
        public DbSet<SviluppaProdotto> SviluppaProdotti => Set<SviluppaProdotto>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //diventano entrambi chiavi primarie
            //setto le pk per due campi della classe
            //per la gestione della Molti a molti "SviluppaProdotto"
            modelBuilder.Entity<SviluppaProdotto>()
                .HasKey(sp => new { sp.SviluppatoreId, sp.ProdottoId });

            //chiave esterna su Sviluppatore
            //fk su sviluppatore
            modelBuilder.Entity<SviluppaProdotto>()
                .HasOne(sp => sp.Sviluppatore)
                .WithMany(s => s.SviluppaProdotti)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(s => s.SviluppatoreId);

            //chiave esterna su Prodotto
            modelBuilder.Entity<SviluppaProdotto>()
                .HasOne(sp => sp.Prodotto)
                .WithMany(c => c.SviluppaProdotti)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(bc => bc.ProdottoId);//definizione di chiave esterna
            #region Dati
            modelBuilder.Entity<Azienda>().HasData(
                new() { AziendaId = 1, Nome = "Microsoft", Indirizzo = "One Microsoft Way, Redmond, WA 98052, Stati Uniti" },
                new() { AziendaId = 2, Nome = "Google", Indirizzo = "1600 Amphitheatre Pkwy, Mountain View, CA 94043, Stati Uniti" },
                new() { AziendaId = 3, Nome = "Apple", Indirizzo = "1 Apple Park Way Cupertino, California, 95014-0642 United States" }
                );
            modelBuilder.Entity<Prodotto>().HasData(
                new() { ProdottoId = 1, Nome = "SuperNote", Descrizione = "Applicazione per la gestione delle Note", AziendaId = 1 },
                new() { ProdottoId = 2, Nome = "My Cinema", Descrizione = "Applicazione per la visione di film in streaming", AziendaId = 1 },
                new() { ProdottoId = 3, Nome = "SuperCad", Descrizione = "Applicazione per il cad 3d", AziendaId = 2 }
                );
            modelBuilder.Entity<Sviluppatore>().HasData(
                new() { SviluppatoreId = 1, Nome = "Mario", Cognome = "Rossi", AziendaId = 1 },
                new() { SviluppatoreId = 2, Nome = "Giulio", Cognome = "Verdi", AziendaId = 1 },
                new() { SviluppatoreId = 3, Nome = "Leonardo", Cognome = "Bianchi", AziendaId = 2 }
                );
            modelBuilder.Entity<SviluppaProdotto>().HasData(
                new() { SviluppatoreId = 1, ProdottoId = 1 },
                new() { SviluppatoreId = 2, ProdottoId = 1 },
                new() { SviluppatoreId = 3, ProdottoId = 3 }
                );
            #endregion
        }
    }
}
