using PropertyChanged;
using System;
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

        public string NewTodoDescription { get; set; }

        public TodoItemViewModel SelectedItem { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public TodoListViewModel()
        {
            CreateCommand = new RelayCommand(_ => CreateTodo(), _ => CanExecuteCreate());
            DeleteCommand = new RelayCommand(_ => DeleteTodo(), _ => CanExecuteDelete());

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
            var todo = new Todo
            {
                TodoId = SelectedItem.TodoId,
                Description = SelectedItem.Description,
                IsCompleted = SelectedItem.IsCompleted
            };

            using (var db = new TodoContext())
            {
                db.Todos.Remove(todo);
                db.SaveChanges();
            }

            TodoItems.Remove(SelectedItem);
        }

        public bool CanExecuteDelete()
        {
            if (SelectedItem == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CanExecuteCreate()
        {
            return !String.IsNullOrWhiteSpace(NewTodoDescription);
        }
    }
}