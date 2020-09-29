using Microsoft.EntityFrameworkCore;
using TodoApp.TodoList.ViewModel;

namespace TodoApp.TodoList
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:\\sqlite\\db\\todos.db");
    }
}
