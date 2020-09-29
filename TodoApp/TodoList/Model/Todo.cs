namespace TodoApp.TodoList.ViewModel
{
    public class Todo
    {
        public int TodoId { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
