using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCore.TodoList
{
    public class TodoItem
    {
        private static int _todoItemCount = 0;

        public int Id;

        public string Description { get; set; } = null;

        public bool IsCompleted { get; set; } = false;

        public TodoItem(string description)
        {
            Description = description;
            Id = _todoItemCount;
            _todoItemCount++;
        }

        public TodoItem(string description, bool isCompleted)
        {
            Description = description;
            IsCompleted = isCompleted;
        }

        public void ToggleTodo()
        {
            IsCompleted = !IsCompleted;
        }
    }
}