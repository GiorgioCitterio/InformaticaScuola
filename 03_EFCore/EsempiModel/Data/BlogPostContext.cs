/*
using EsempiModel.Model;
using Microsoft.EntityFrameworkCore;

namespace EsempiModel.Data;

public class BlogPostContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    public string DbPath { get; }
    public BlogPostContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Blog4.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(b => b.Posts)
            .HasForeignKey(p => p.BlogForeignKey);
    }
}
*/