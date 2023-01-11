
using EsempiModel2.Model;
using Microsoft.EntityFrameworkCore;

namespace EsempiModel2.Data;

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public string DbPath { get; }
    public BlogContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Blog.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
