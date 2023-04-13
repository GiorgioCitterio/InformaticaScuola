using Microsoft.EntityFrameworkCore;

namespace _04_TodoApi
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
        //la property è il nome della tabella che ci sarà sul database
        DbSet<Todo> Todos => Set<Todo>();
    }
}
