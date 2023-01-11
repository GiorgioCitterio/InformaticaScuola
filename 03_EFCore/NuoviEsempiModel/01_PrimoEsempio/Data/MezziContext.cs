
using _01_PrimoEsempio.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _01_PrimoEsempio.Data;

public class MezziContext : DbContext
{
    public DbSet<Car> Cars { get; set; }=null!;
    public DbSet<Motorino> Motorinos { get; set; } = null!;
    public DbSet<Camion> Camions { get; set; } = null!;
    public string DbPath { get; }
    public MezziContext()
    {
        //https://www.hanselman.com/blog/how-do-i-find-which-directory-my-net-core-
        //console - application - was - started -in-or -is -running - from
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Mezzi1.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bus>().HasKey(b => b.Telaio);
    }
}
