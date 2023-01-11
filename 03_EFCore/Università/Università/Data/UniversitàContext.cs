using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Università.Model;

namespace Università.Data;

public class UniveristàContext : DbContext
{
    public string DbPath { get; }
    public DbSet<Corso> Corso { get; set; } = null!;
    public DbSet<Docente> Docente { get; set; } = null!;
    public DbSet<Frequenta> Frequenta { get; set; } = null!;
    public DbSet<Studente> Studente { get; set; } = null!;
    public DbSet<CorsoLaurea> CorsoLaurea { get; set; } = null!;
    public UniveristàContext()
    {

        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Università.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var converterTipoLaurea = new EnumToStringConverter<TipoLaurea>(); //trasformo gli enumerati in stringhe
        var converterFacoltà = new EnumToStringConverter<Facoltà>();
        var converterDipartimento = new EnumToStringConverter<Dipartimento>();
        modelBuilder //va nella tabella CorsoLaurea prende la property enumerata e la trasforma in stringa
                .Entity<CorsoLaurea>()
                .Property(cl => cl.TipoLaurea)
                .HasConversion(converterTipoLaurea);
        modelBuilder
               .Entity<CorsoLaurea>()
               .Property(cl => cl.Facoltà)
               .HasConversion(converterFacoltà);
        modelBuilder
               .Entity<Docente>()
               .Property(d => d.Dipartimento)
               .HasConversion(converterDipartimento);

        modelBuilder.Entity<Frequenta>()
            .HasKey(f => new { f.Matricola, f.CodCorso }); //dico che sono 2 chiavi primarie
        modelBuilder.Entity<Frequenta>()
            .HasOne(s => s.Studente) //prendo la navigation property
            .WithMany(f => f.Frequenta) //prende la lista nella tabella Studente
            .HasForeignKey(f => f.Matricola); //e gli aggancio la chiave
        modelBuilder.Entity<Frequenta>()
            .HasOne(c => c.Corso)
            .WithMany(f => f.Frequenta)
            .HasForeignKey(f => f.CodCorso);
    }
}