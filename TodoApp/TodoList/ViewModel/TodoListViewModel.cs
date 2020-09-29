using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp;

namespace WpfCore.TodoList.ViewModel
{
    /// <summary>
    /// ViewModel of a TodoList. Layer between TodoList and view. Keeps track of todos.
    /// Commands for adding and deleting todos.
    /// </summary>

    // Use Fody.PropertyChanged for simpler creation of bindings.
    [AddINotifyPropertyChangedInterface]
    internal class TodoListViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///
        /// </summary>
        private TodoList _todoList = new TodoList();

        #region Properties

        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; } = new ObservableCollection<TodoItemViewModel>();

        #endregion Properties

        public ICommand CreateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public string NewTodoDescription { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public object SelectedItem { get; set; }

        public TodoListViewModel()
        {
            CreateCommand = new RelayCommand(_ => CreateTodo(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteTodo(), _ => true);

            _todoList.AddTodo("Wäsche wasche");
            _todoList.AddTodo("WPF App entwickeln");
            _todoList.AddTodo("Berichts vervollständigen");

            _todoList.TodoItems[1].IsCompleted = true;

            foreach (TodoItem todoItem in _todoList.TodoItems)
            {
                TodoItems.Add(new TodoItemViewModel(todoItem.Id, todoItem.Description, todoItem.IsCompleted));
            }
        }

        private void CreateTodo()
        {
            var newTodo = _todoList.AddTodo(NewTodoDescription);
            var newTodoViewModel = new TodoItemViewModel(newTodo.Id, newTodo.Description, newTodo.IsCompleted);
            TodoItems.Add(newTodoViewModel);
            NewTodoDescription = "";
        }

        public void DeleteTodo()
        {
            TodoItemViewModel todoItemViewModel = (TodoItemViewModel)SelectedItem;
            _todoList.RemoveTodoAtId(todoItemViewModel.Id);
            TodoItems.Remove(todoItemViewModel);
        }
    }
}