using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TodoApp;
using TodoApp.TodoList;
using TodoApp.TodoList.ViewModel;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; } = new ObservableCollection<TodoItemViewModel>();

        public ICommand CreateCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ToggleCommand { get; set; }

        public string NewTodoDescription { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public object SelectedItem { get; set; }

        public TodoListViewModel()
        {
            CreateCommand = new RelayCommand(_ => CreateTodo(), _ => true);
            DeleteCommand = new RelayCommand(_ => DeleteTodo(), _ => true);

            using (var db = new TodoContext())
            {
                var todos = db.Todos.ToList();
                foreach (Todo todo in todos)
                {
                    TodoItems.Add(new TodoItemViewModel(todo.TodoId, todo.Description, todo.IsCompleted));
                }
            }
        }

        private void CreateTodo()
        {
            var todo = new Todo
            {
                Description = NewTodoDescription
            };

            using (var db = new TodoContext())
            {
                db.Todos.Add(todo);
                db.SaveChanges();
            }

            TodoItems.Add(new TodoItemViewModel(todo.TodoId, todo.Description, todo.IsCompleted));
            NewTodoDescription = "";
        }

        public void DeleteTodo()
        {
            TodoItemViewModel todoItemViewModel = (TodoItemViewModel)SelectedItem;
            var todo = new Todo
            {
                TodoId = todoItemViewModel.Id,
                Description = todoItemViewModel.Description,
                IsCompleted = todoItemViewModel.IsCompleted
            };

            using (var db = new TodoContext())
            {
                db.Todos.Remove(todo);
                db.SaveChanges();
            }

            TodoItems.Remove(todoItemViewModel);
        }
    }
}