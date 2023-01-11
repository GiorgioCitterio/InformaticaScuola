
using EsercizioVerifica3IA.Model;
using Microsoft.EntityFrameworkCore;

namespace EsercizioVerifica3IA.Data;

public class MotorsportContext : DbContext
{
    public DbSet<Scuderia> Scuderia { get; set; } = null!;
    public DbSet<Pilota> Pilota { get; set; } = null!;
    public DbSet<PuntiPiloti> PuntiPiloti { get; set; } = null!;
    public string DbPath { get; }

    public MotorsportContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Motorsport.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pilota>()
            .HasOne(p => p.Scuderia)
            .WithMany(s => s.Pilota)
            .HasForeignKey(p => p.ScuderiaId);
        modelBuilder.Entity<PuntiPiloti>()
            .HasOne(p => p.Pilota)
            .WithMany(p => p.PuntiPiloti)
            .HasForeignKey(p => p.PilotaId);
    }
}
