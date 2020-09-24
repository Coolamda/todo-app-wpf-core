using PropertyChanged;
using System.ComponentModel;

namespace WpfCore.TodoList.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    internal class TodoItemViewModel : INotifyPropertyChanged
    {
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public TodoItemViewModel(string description, bool isCompleted)
        {
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}