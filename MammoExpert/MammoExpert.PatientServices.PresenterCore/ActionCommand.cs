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
            : this(action, null)
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
        private readonly Action<T> _action;
        private readonly Predicate<object> _canExecute;

        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        public ActionCommand(Action<T> action, Predicate<object> canExecute)
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
            if (_action != null && parameter != null)
            {
                var castParameter = (T)Convert.ChangeType(parameter, typeof(T));
                _action(castParameter);
            }
        }
    }
}
