using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MammoExpert.PatientServices.PresenterCore
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public virtual string DisplayName { get; protected set; }
        public Action CloseAction { get; set; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(p);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members

        #region CloseCommand

        private ActionCommand _closeCommand;
        public event EventHandler RequestClose;
        
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

        #endregion
    }
}
