using PropertyChanged;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TodoApp;
using TodoApp.TodoList;
using TodoApp.TodoList.ViewModel;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoItemViewModel : INotifyPropertyChanged
    {
        public int TodoId { get; set; }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    SaveChangesToTodo(value);
                }
            }
        }

        public bool IsCompleted { get; set; }

        public ICommand ToggleCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TodoItemViewModel(int id, string description, bool isCompleted)
        {
            ToggleCommand = new RelayCommand(_ => ToggleTodo(), _ => true);

            TodoId = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        public void ToggleTodo()
        {
            using (var db = new TodoContext())
            {
                Todo todo = db.Todos.Find(TodoId);
                todo.IsCompleted = !todo.IsCompleted;
                db.SaveChanges();
            }
        }

        public void SaveChangesToTodo(string newDescription)
        {
            using (var db = new TodoContext())
            {
                Todo todo = db.Todos.First(todo => todo.TodoId == TodoId);
                todo.Description = newDescription;
                db.SaveChanges();
            }
        }
    }
}