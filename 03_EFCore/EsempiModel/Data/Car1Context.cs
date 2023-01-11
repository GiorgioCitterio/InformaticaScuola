using EsempiModel.Model;
using Microsoft.EntityFrameworkCore;
namespace EsempiModel.Data;

public class Car1Context : DbContext
{
    DbSet<Car1> Cars1 { get; set; } = null!;
    DbSet<RecordOfSale> RecordOfSales { get; set; } = null!;
    public string DbPath { get; }
    public Car1Context()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\CarSales.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //pk composta su car1
        modelBuilder.Entity<Car1>()
            .HasKey(c => new { c.State, c.LicensePlate });
        modelBuilder.Entity<RecordOfSale>()
            .HasOne(h => h.Car1)
            .WithMany(c => c.SaleHistory)
            .HasForeignKey(h => new { h.CarState, h.CarLicensePlate });
    }
}
