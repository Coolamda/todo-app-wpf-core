using System;
using System.Windows.Input;

namespace TodoApp
{
    /// <summary>
    /// Class for creating Commands. Primarly used in Viewmodels.
    /// </summary>
    internal class RelayCommand : ICommand
    {
        #region Private Fields

        /// <summary>
        /// Action which should be executed.
        /// </summary>
        private Action<object> _action;

        /// <summary>
        /// Function which checks if the action should be executed.
        /// </summary>
        private Func<object, bool> _canExecute;

        #endregion Private Fields

        #region Events

        /// <summary>
        /// Gets raised if CanExecute is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion Events

        #region Construtor

        /// <summary>
        /// Create a command using an action and canExecute.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <param name="canExecute">Function checking if action should be executed.</param>
        public RelayCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        #endregion Construtor

        #region Methods

        /// <summary>
        /// If CanExecute is true the action gets executed.
        /// </summary>
        /// <param name="parameter">Parameter given to _canExecucte.</param>
        /// <returns>True or false whether the action should be executed or not.</returns>
        public bool CanExecute(object parameter)
        {
            // Checks if _canExecute is given. If so it executes _canExecute.
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Execute the action with given parameter.
        /// </summary>
        /// <param name="parameter">Parameter used in the action.</param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion Methods
    }
}
