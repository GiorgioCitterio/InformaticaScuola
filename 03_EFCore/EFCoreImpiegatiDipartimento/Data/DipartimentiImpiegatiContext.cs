using EFCoreImpiegatiDipartimento.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreImpiegatiDipartimento.Data;
public class DipartimentiImpiegatiContext : DbContext
{
    public DbSet<Dipartimento> Dipartimenti { get; set; } = null!;
    public DbSet<Impiegato> Impiegati { get; set; } = null!;
    public string DbPath { get; }
    public DipartimentiImpiegatiContext()
    {
        //https://www.hanselman.com/blog/how-do-i-find-which-directory-my-net-core-
        //console - application - was - started -in-or -is -running - from
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\ImpiegatiDipartimenti.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}