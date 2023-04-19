using Microsoft.EntityFrameworkCore;
using _06_TodoApiDTO.Model;

namespace _06_TodoApiDTO.Data
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
