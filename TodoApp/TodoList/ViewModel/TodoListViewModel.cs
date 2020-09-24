using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoListViewModel : INotifyPropertyChanged
    {
        private TodoList _todoList = new TodoList();

        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; } = new ObservableCollection<TodoItemViewModel>();

        public ICommand CreateCommand { get; set; }

        // public ICommand ToggleCommand { get; set; } Nicht nötig?

        public string NewTodoDescription { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TodoListViewModel()
        {
            CreateCommand = new RelayCommand((_) => CreateTodo(), (_) => true);

            _todoList.AddTodo("Wäsche wasche");
            _todoList.AddTodo("WPF App entwickeln");
            _todoList.AddTodo("Berichts vervollständigen");

            _todoList.TodoItems[1].IsCompleted = true;

            foreach (TodoItem todoItem in _todoList.TodoItems)
            {
                TodoItems.Add(new TodoItemViewModel(todoItem.Description, todoItem.IsCompleted));
            }
        }

        private void CreateTodo()
        {
            var newTodo = _todoList.AddTodo(NewTodoDescription);
            var newTodoViewModel = new TodoItemViewModel(newTodo.Description, newTodo.IsCompleted);
            TodoItems.Add(newTodoViewModel);
            NewTodoDescription = "";
        }
    }
}