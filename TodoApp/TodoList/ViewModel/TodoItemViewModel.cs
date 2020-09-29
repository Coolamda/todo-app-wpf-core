using PropertyChanged;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp;
using TodoApp.TodoList;
using TodoApp.TodoList.ViewModel;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoItemViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public ICommand ToggleCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TodoItemViewModel(int id, string description, bool isCompleted)
        {
            ToggleCommand = new RelayCommand(_ => ToggleTodo(), _ => true);

            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        public void ToggleTodo()
        {
            using (var db = new TodoContext())
            {
                Todo todo = db.Todos.Find(Id);
                todo.IsCompleted = !todo.IsCompleted;
                db.SaveChanges();
            }
        }
    }
}