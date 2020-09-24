using PropertyChanged;
using System.ComponentModel;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoItemViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TodoItemViewModel(int id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}