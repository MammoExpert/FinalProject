using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Input;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class WorkspaceViewModel : ViewModelBase
    {
        private ActionCommand _closeCommand;
        public event EventHandler RequestClose;

        protected WorkspaceViewModel() { }     

        // команда, которая убирает рабочую область из UI
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new ActionCommand(() =>
                    {
                        var handler = this.RequestClose;
                        if (handler != null)
                            handler(this, EventArgs.Empty);
                    });

                return _closeCommand;
            }
        }   

    }
}
