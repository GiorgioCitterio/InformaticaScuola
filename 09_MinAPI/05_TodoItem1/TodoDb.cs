using Microsoft.EntityFrameworkCore;

namespace _05_TodoItem1
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
