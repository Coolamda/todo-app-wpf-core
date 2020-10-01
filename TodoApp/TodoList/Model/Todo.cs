using GalaSoft.MvvmLight;

namespace TodoApp.TodoList.ViewModel
{
    public class Todo : ObservableObject
    {
        private int _todoId;
        private string _description;
        private bool _isCompleted = false;

        public int TodoId
        {
            get => _todoId;
            set => Set<int>(() => TodoId, ref _todoId, value);
        }

        public string Description
        {
            get => _description;
            set => Set<string>(() => Description, ref _description, value);
        }

        public bool IsCompleted
        {
            get => _isCompleted;
            set => Set<bool>(() => IsCompleted, ref _isCompleted, value);
        }
    }
}
