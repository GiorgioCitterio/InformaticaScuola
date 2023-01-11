using Esempio2.Model;
using Microsoft.EntityFrameworkCore;

namespace Esempio2.Data;

public class PostTagContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public string DbPath { get; }
    public PostTagContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "..\\..\\..\\Post.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<PostTag>()
        //    .HasKey(c => new { c.PostId, c.TagId });
        modelBuilder.Entity<PostTag>()
            .HasOne(p => p.Post)
            .WithMany(pt => pt.PostTags)
            .HasForeignKey(pt => pt.PostId);
        modelBuilder.Entity<PostTag>()
            .HasOne(t => t.Tag)
            .WithMany(pt => pt.PostTags)
            .HasForeignKey(pt => pt.TagId);
    }
}
