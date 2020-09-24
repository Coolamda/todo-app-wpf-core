using System;
using System.Windows.Input;

namespace TodoApp
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}