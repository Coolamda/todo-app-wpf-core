using Microsoft.EntityFrameworkCore;
using TodoApp.TodoList.ViewModel;

namespace TodoApp.TodoList
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        // TODO: Don't use absolute path
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=W011076SYS\\SQLEXPRESS;Database=Todo;Trusted_Connection=True;");
    }
}
