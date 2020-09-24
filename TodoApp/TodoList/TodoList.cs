using System.Collections.Generic;

namespace WpfCore.TodoList
{
    public class TodoList
    {
        public List<TodoItem> TodoItems = new List<TodoItem>();

        public TodoItem AddTodo(string description)
        {
            var todoItem = new TodoItem(description);
            TodoItems.Add(todoItem);
            return todoItem;
        }

        public void RemoveTodoAtId(int id)
        {
            TodoItems.RemoveAt(id);
        }

        public void RemoveTodo(TodoItem todoItem)
        {
            TodoItems.Remove(todoItem);
        }
    }
}