using EsercizioRomanzi.Model;
using Microsoft.EntityFrameworkCore;

namespace EsercizioRomanzi.Data;

public class RomanziContext : DbContext
{
    public DbSet<Autore> Autori { get; set; } = null!;
    public DbSet<Personaggio> Personaggi { get; set; } = null!;
    public DbSet<Romanzo> Romanzi { get; set; } = null!;
    public string DbPath { get; }
    public RomanziContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Romanzi.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
