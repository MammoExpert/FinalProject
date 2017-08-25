using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;
        private readonly Predicate<object> _canExecute;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public ActionCommand(Action action, Predicate<object> canExecute)
        {
            if (action == null)
                throw new ArgumentNullException("execute");

            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class ActionCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<T> _action;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter) { return true; }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
                _action(castParameter);
            }
        }
    }
}
