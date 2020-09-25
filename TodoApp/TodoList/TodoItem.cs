namespace WpfCore.TodoList
{
    /// <summary>
    /// A simple TodoItem class.
    /// </summary>
    public class TodoItem
    {
        #region Properties

        /// <summary>
        /// Keeps track for the amount of todos created (simulating increment id).
        /// </summary>
        private static int _todoItemCount = 0;

        /// <summary>
        /// Id of the todo.
        /// </summary>
        public int Id;

        /// <summary>
        /// Description of the todo.
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// Completion status of the todo.
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Creates a TodoItem with a description. Use total amount of created todos as id. Increment todoItemCount.
        /// </summary>
        /// <param name="description">Description of the new todo</param>
        public TodoItem(string description)
        {
            Description = description;
            Id = _todoItemCount;
            _todoItemCount++;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Toggle the completion status.
        /// </summary>
        public void ToggleTodo()
        {
            IsCompleted = !IsCompleted;
        }

        #endregion Methods
    }
}