using _08_EsempioValidator.Model;
using Microsoft.EntityFrameworkCore;

namespace _08_EsempioValidator.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Student> Students => Set<Student>();
    }
}
