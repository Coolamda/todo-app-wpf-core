using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TodoApp;
using TodoApp.TodoList;
using TodoApp.TodoList.ViewModel;

namespace WpfCore.TodoList.ViewModel
{
    internal class TodoItemViewModel : ViewModelBase
    {
        private string _description;
        private bool _isCompleted;

        public int TodoId { get; set; }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    SaveChangesToTodo(value);
                    RaisePropertyChanged("Description");
                }
            }
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                RaisePropertyChanged("IsCompleted");
            }
        }

        public ICommand ToggleCommand { get; set; }

        public TodoItemViewModel(int id, string description, bool isCompleted)
        {
            ToggleCommand = new RelayCommand(ToggleTodo, () => true);

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