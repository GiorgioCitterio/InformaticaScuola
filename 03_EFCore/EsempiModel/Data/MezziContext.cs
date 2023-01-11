/*
using EsempiModel.Model;
using Microsoft.EntityFrameworkCore;

namespace EsempiModel.Data;

public class MezziContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Moto> Motos { get; set; } = null!;
    public DbSet<Truck> Trucks { get; set; } = null!;
    public string DbPath { get; }
    public MezziContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Mezzi.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
*/