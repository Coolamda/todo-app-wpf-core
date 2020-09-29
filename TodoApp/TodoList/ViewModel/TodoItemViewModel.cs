using PropertyChanged;
using System.ComponentModel;

namespace WpfCore.TodoList.ViewModel
{
    /// <summary>
    /// Viewmodel of a TodoItem. Layer between a TodoItem and the view.
    /// </summary>

    // Use Fody.PropertyChanged for simpler creation of bindings.
    [AddINotifyPropertyChangedInterface]
    internal class TodoItemViewModel : INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Id of the TodoItem. Notify when changed.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the TodoItem. Notify when changed.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Completion status of the TodoItem. Notify when changed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// PropertyChanged Event. Fires when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Properties

        #region Contructor

        /// <summary>
        /// Contstructor for creating a TodoItemViewModel.
        /// </summary>
        /// <param name="id">Increment id of the TodoItem.</param>
        /// <param name="description">Description of the TodoItem.</param>
        /// <param name="isCompleted">Comletion Status of the TodoItem.</param>
        public TodoItemViewModel(int id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

        #endregion Contructor
    }
}