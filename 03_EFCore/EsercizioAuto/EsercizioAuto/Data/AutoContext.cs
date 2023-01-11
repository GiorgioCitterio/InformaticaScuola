using EsercizioAuto.Model;
using Microsoft.EntityFrameworkCore;

namespace EsercizioAuto.Data;

public class AutoContext : DbContext
{
    public DbSet<Auto> Auto { get; set; } = null!;
    public DbSet<Proprietario> Proprietario { get; set; } = null!;
    public DbSet<Assicurazione> Assicurazione { get; set; } = null!;
    public string DbPath { get; }
    public AutoContext()
    { 
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Auto.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>()
            .HasOne(p => p.Proprietario)
            .WithMany(a => a.Auto)
            .HasForeignKey(a => a.ProprietarioId);
        modelBuilder.Entity<Auto>()
            .HasOne(a => a.Assicurazione)
            .WithMany(a => a.Auto)
            .HasForeignKey(a => a.AssicurazioneId);
    }
}
