using System.Collections.Generic;

namespace WpfCore.TodoList
{
    /// <summary>
    /// A simple TodoList. User can add and remove TodoItems to the list.
    /// </summary>
    public class TodoList
    {
        #region Properties

        /// <summary>
        /// A list of TodoItems.
        /// </summary>
        public List<TodoItem> TodoItems = new List<TodoItem>();

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds an TodoItem to Todoitems.
        /// </summary>
        /// <param name="description">Description of the new todo.</param>
        /// <returns></returns>
        public TodoItem AddTodo(string description)
        {
            var todoItem = new TodoItem(description);
            TodoItems.Add(todoItem);
            return todoItem;
        }

        /// <summary>
        /// Removes a TodoItem in TodoItems by using an id.
        /// </summary>
        /// <param name="id">Id of todo which should be deleted.</param>
        public void RemoveTodoAtId(int id)
        {
            TodoItems.RemoveAt(id);
        }

        /// <summary>
        /// Removes a TodoItem by using a reference.
        /// </summary>
        /// <param name="todoItem">Reference of TodoItem which should be deleted.</param>
        public void RemoveTodo(TodoItem todoItem)
        {
            TodoItems.Remove(todoItem);
        }

        #endregion Methods
    }
}
