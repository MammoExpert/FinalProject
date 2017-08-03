using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;
        readonly Predicate<object> _canExecute;

        public ActionCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ActionCommand(Action action, Predicate<object> canExecute)
        {
            if (action == null)
                throw new ArgumentNullException("execute");

            _action = action;
            _canExecute = canExecute;
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
}
