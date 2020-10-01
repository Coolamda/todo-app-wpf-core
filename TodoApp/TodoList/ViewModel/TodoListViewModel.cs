using System;
using System.Collections.ObjectModel;
using System.Linq;
using TodoApp.TodoList;
using TodoApp.TodoList.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfCore.TodoList.ViewModel
{
    internal class TodoListViewModel : ViewModelBase
    {
        private TodoItemViewModel _selectedItem = null;
        private string _newTodoDescription = null;

        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; } = new ObservableCollection<TodoItemViewModel>();

        public RelayCommand CreateCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }

        public string NewTodoDescription
        {
            get => _newTodoDescription;
            set
            {
                _newTodoDescription = value;
                RaisePropertyChanged();
                CreateCommand.RaiseCanExecuteChanged();
            }
        }

        public TodoItemViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                RaisePropertyChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public TodoListViewModel()
        {
            CreateCommand = new RelayCommand(CreateTodo, CanExecuteCreate);
            DeleteCommand = new RelayCommand(DeleteTodo, CanExecuteDelete);

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

        public bool CanExecuteDelete() => !(SelectedItem == null);

        public bool CanExecuteCreate() => !String.IsNullOrWhiteSpace(NewTodoDescription);
    }
}