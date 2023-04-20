using Microsoft.EntityFrameworkCore;

namespace _04_TodoApi
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
        //la property è il nome della tabella che ci sarà sul database
        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
                    new Todo { Id = 1, Name = "Pippo", IsComplete = true },
                    new Todo { Id = 2, Name = "Pluto", IsComplete = false },
                    new Todo { Id = 3, Name = "Juan", IsComplete = true }
                );
        }
    }
}
